# Autenticação Google em Blazor (.NET 8/9) sem ASP.NET Core Identity

Arquitetura: **Cookie (sessão local) + Google (OAuth2/OIDC como provedor de login)**.

```
Browser ──► /auth/login ──► Google ──► /signin-google (middleware) ──► Cookie emitido ──► returnUrl
```

> **Por que endpoints HTTP e não componentes Blazor para login/logout?**
> No Blazor Server (interativo), o circuito roda sobre SignalR/WebSocket e **não consegue
> gravar cookies** na resposta. O challenge/sign-out precisa acontecer numa requisição HTTP normal.

---

## 1. Pacote e secrets

```bash
dotnet add package Microsoft.AspNetCore.Authentication.Google
dotnet user-secrets init
dotnet user-secrets set "Authentication:Google:ClientId" "xxxx.apps.googleusercontent.com"
dotnet user-secrets set "Authentication:Google:ClientSecret" "GOCSPX-xxxx"
```

### Google Cloud Console
1. APIs & Services → Credentials → **Create OAuth client ID** → *Web application*.
2. **Authorized redirect URIs**: `https://localhost:7001/signin-google` (ajuste a porta; em produção use o domínio real).
3. `/signin-google` é o `CallbackPath` padrão, tratado pelo próprio middleware. **Não crie rota para ele.**

### appsettings.json (não sensível)
```json
{
  "Authentication": {
    "Google": {
      "AllowedDomains": [ "minhaempresa.com.br" ],
      "AdminEmails": [ "admin@minhaempresa.com.br" ]
    }
  }
}
```
Deixe `AllowedDomains` vazio para aceitar qualquer conta Google.

---

## 2. Program.cs

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.HttpOverrides;
using MeuApp.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Expõe o AuthenticationState para toda a árvore de componentes
builder.Services.AddCascadingAuthenticationState();

var googleSection = builder.Configuration.GetSection("Authentication:Google");
var allowedDomains = googleSection.GetSection("AllowedDomains").Get<string[]>() ?? [];
var adminEmails    = googleSection.GetSection("AdminEmails").Get<string[]>() ?? [];

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme          = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.Cookie.Name         = "__MeuApp.Auth";
        options.Cookie.HttpOnly     = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite     = SameSiteMode.Lax;
        options.ExpireTimeSpan      = TimeSpan.FromHours(8);
        options.SlidingExpiration   = true;
        options.LoginPath           = "/auth/login";
        options.AccessDeniedPath    = "/acesso-negado";
    })
    .AddGoogle(options =>
    {
        options.ClientId     = googleSection["ClientId"]     ?? throw new InvalidOperationException("Google ClientId ausente.");
        options.ClientSecret = googleSection["ClientSecret"] ?? throw new InvalidOperationException("Google ClientSecret ausente.");

        options.Scope.Add("profile");
        options.Scope.Add("email");
        options.SaveTokens = false; // não precisamos dos tokens do Google, só da identidade

        // Enriquecimento de claims (roles locais) ao criar o ticket
        options.Events.OnCreatingTicket = context =>
        {
            var email = context.Identity?.FindFirst(ClaimTypes.Email)?.Value;

            if (email is not null &&
                adminEmails.Contains(email, StringComparer.OrdinalIgnoreCase))
            {
                context.Identity!.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }

            context.Identity!.AddClaim(new Claim(ClaimTypes.Role, "User"));
            return Task.CompletedTask;
        };

        // Validações antes de emitir o cookie
        options.Events.OnTicketReceived = context =>
        {
            var principal = context.Principal!;
            var email = principal.FindFirst(ClaimTypes.Email)?.Value;

            // Em OAuth do Google, "email_verified" vem no userinfo; o ClaimsPrincipal
            // padrão não o mapeia, então validamos domínio pelo e-mail.
            if (string.IsNullOrWhiteSpace(email))
            {
                context.Fail("E-mail não retornado pelo Google.");
                return Task.CompletedTask;
            }

            if (allowedDomains.Length > 0)
            {
                var domain = email[(email.LastIndexOf('@') + 1)..];
                if (!allowedDomains.Contains(domain, StringComparer.OrdinalIgnoreCase))
                {
                    context.Fail($"Domínio '{domain}' não autorizado.");
                }
            }

            return Task.CompletedTask;
        };

        // Falha no fluxo remoto (usuário cancelou, domínio negado, etc.)
        options.Events.OnRemoteFailure = context =>
        {
            context.HandleResponse();
            context.Response.Redirect("/acesso-negado");
            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization();

// Necessário atrás de proxy reverso (nginx, Azure App Service, etc.)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// ---------- Endpoints de autenticação ----------
var auth = app.MapGroup("/auth");

auth.MapGet("/login", (string? returnUrl) =>
{
    var props = new AuthenticationProperties { RedirectUri = SafeLocalUrl(returnUrl) };
    return Results.Challenge(props, [GoogleDefaults.AuthenticationScheme]);
}).AllowAnonymous();

auth.MapPost("/logout", async (HttpContext http, IAntiforgery antiforgery) =>
{
    await antiforgery.ValidateRequestAsync(http);
    await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.LocalRedirect("/");
}).RequireAuthorization();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();

// Proteção contra open redirect: só aceita caminhos locais
static string SafeLocalUrl(string? url) =>
    !string.IsNullOrWhiteSpace(url)
    && url.StartsWith('/')
    && !url.StartsWith("//")
    && !url.StartsWith("/\\")
        ? url
        : "/";
```

---

## 3. Components/Routes.razor

```razor
<Router AppAssembly="typeof(Program).Assembly">
    <Found Context="routeData">
        <AuthorizeRouteView RouteData="routeData" DefaultLayout="typeof(Layout.MainLayout)">
            <NotAuthorized>
                @if (context.User.Identity?.IsAuthenticated != true)
                {
                    <RedirectToLogin />
                }
                else
                {
                    <div class="alert alert-danger m-4">Você não tem permissão para acessar esta página.</div>
                }
            </NotAuthorized>
            <Authorizing>
                <p class="m-4">Verificando credenciais...</p>
            </Authorizing>
        </AuthorizeRouteView>
        <FocusOnNavigate RouteData="routeData" Selector="h1" />
    </Found>
</Router>
```

## 4. Components/Auth/RedirectToLogin.razor

```razor
@inject NavigationManager Nav

@code {
    protected override void OnInitialized()
    {
        var returnUrl = "/" + Nav.ToBaseRelativePath(Nav.Uri);
        // forceLoad: precisa ser uma requisição HTTP real para o challenge gravar cookies
        Nav.NavigateTo($"/auth/login?returnUrl={Uri.EscapeDataString(returnUrl)}", forceLoad: true);
    }
}
```

## 5. Components/Auth/LoginDisplay.razor

```razor
<AuthorizeView>
    <Authorized>
        <div class="d-flex align-items-center gap-2">
            @if (context.User.FindFirst("urn:google:picture")?.Value is { } picture)
            {
                <img src="@picture" alt="" width="32" height="32"
                     class="rounded-circle" referrerpolicy="no-referrer" />
            }
            <span>@context.User.Identity?.Name</span>

            <form method="post" action="/auth/logout">
                <AntiforgeryToken />
                <button type="submit" class="btn btn-sm btn-outline-secondary">Sair</button>
            </form>
        </div>
    </Authorized>
    <NotAuthorized>
        <a class="btn btn-sm btn-primary" href="/auth/login">Entrar com Google</a>
    </NotAuthorized>
</AuthorizeView>
```

Use `<LoginDisplay />` no `MainLayout.razor`.

---

## 6. Páginas

### Components/Pages/Perfil.razor (qualquer usuário autenticado)

```razor
@page "/perfil"
@attribute [Authorize]
@using System.Security.Claims

<h1>Meu perfil</h1>

<dl class="row">
    <dt class="col-sm-2">Nome</dt>
    <dd class="col-sm-10">@User?.Identity?.Name</dd>

    <dt class="col-sm-2">E-mail</dt>
    <dd class="col-sm-10">@User?.FindFirst(ClaimTypes.Email)?.Value</dd>

    <dt class="col-sm-2">Id Google</dt>
    <dd class="col-sm-10">@User?.FindFirst(ClaimTypes.NameIdentifier)?.Value</dd>
</dl>

<h5>Claims</h5>
<ul>
    @foreach (var c in User?.Claims ?? [])
    {
        <li><code>@c.Type</code>: @c.Value</li>
    }
</ul>

@code {
    [CascadingParameter] private Task<AuthenticationState>? AuthState { get; set; }
    private ClaimsPrincipal? User;

    protected override async Task OnInitializedAsync()
        => User = AuthState is null ? null : (await AuthState).User;
}
```

### Components/Pages/Admin.razor (apenas role Admin)

```razor
@page "/admin"
@attribute [Authorize(Roles = "Admin")]

<h1>Área administrativa</h1>
<p>Somente administradores veem esta página.</p>
```

### Components/Pages/AcessoNegado.razor

```razor
@page "/acesso-negado"

<h1>Acesso negado</h1>
<p>Não foi possível concluir o login ou sua conta não está autorizada.</p>
<a href="/auth/login">Tentar novamente</a>
```

### `_Imports.razor` (acrescentar)

```razor
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
@using MeuApp.Components.Auth
```

---

## 7. Proteção de código (não só de UI)

- Em minimal APIs / controllers: `.RequireAuthorization()` ou `[Authorize]`.
- Em serviços chamados por componentes Blazor Server, obtenha o usuário via `AuthenticationStateProvider`
  (**nunca** via `IHttpContextAccessor`, que não é confiável dentro do circuito).

```csharp
public class MeuServico(AuthenticationStateProvider authProvider)
{
    public async Task<string?> EmailAtualAsync()
    {
        var state = await authProvider.GetAuthenticationStateAsync();
        return state.User.FindFirst(ClaimTypes.Email)?.Value;
    }
}
```

---

## 8. Checklist de produção

| Item | Detalhe |
|---|---|
| Redirect URI | Cadastrar `https://seudominio.com/signin-google` no Google Console |
| Proxy reverso | `UseForwardedHeaders` antes de tudo (já incluso), senão o `redirect_uri` sai como `http://` |
| Data Protection | Persistir as chaves (Azure Blob, Redis, volume em disco) para que cookies/correlation sobrevivam a restart e a múltiplas instâncias |
| Segredos | Key Vault / variáveis de ambiente, nunca no repositório |
| Expiração | O estado de autenticação do Blazor Server é capturado ao abrir o circuito; sessões longas só enxergam a expiração do cookie em nova navegação completa |
| Roles | O exemplo mapeia por e-mail via config; em sistemas reais, troque por consulta a banco/serviço dentro do `OnCreatingTicket` ou use `IClaimsTransformation` |
| Autorização por policy | `builder.Services.AddAuthorizationBuilder().AddPolicy("Admin", p => p.RequireRole("Admin"))` e `[Authorize(Policy = "Admin")]` |
| Persistir usuário | Se precisar de cadastro próprio, grave o `NameIdentifier` (sub do Google) em uma tabela no `OnTicketReceived` (pelo `context.HttpContext.RequestServices`) |
