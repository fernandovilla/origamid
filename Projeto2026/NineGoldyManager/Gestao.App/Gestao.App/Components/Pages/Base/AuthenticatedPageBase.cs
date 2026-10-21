using Gestao.App.Client.Libraries.Helpers;
using Gestao.App.Services.Users;
using Gestao.Domain.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.JSInterop;

namespace Gestao.App.Components.Pages.Base
{
    [Authorize]
    public class AuthenticatedPageBase : PageBase
    {
        [Inject] protected AuthenticationStateProvider? AuthProvider { get; set; }
        [Inject] protected IApplicationUserService? ApplicationUserService { get; set; }

        protected ApplicationUser AuthenticatedUser { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            await LoadAuthenticatedUserAsync();
        }

        private async Task LoadAuthenticatedUserAsync()
        {
            var userId = (await AuthenticationHelper.GetAuthenticatedUserIdAsync(AuthProvider))!.Value;

            if (userId != Guid.Empty)
                AuthenticatedUser = await ApplicationUserService.FindByIdAsync(userId);
        }
    }
}
