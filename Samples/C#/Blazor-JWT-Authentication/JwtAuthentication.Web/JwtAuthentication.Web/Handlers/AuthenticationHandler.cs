using JwtAuthentication.Lib.Models;
using JwtAuthentication.Web.Client.Services;
using System.Net.Http.Headers;

namespace JwtAuthentication.Web.Handlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private TokenResponseDto _token;
        private IServiceProvider _serviceProvider;

        public AuthenticationHandler(TokenResponseDto token, IServiceProvider serviceProvider)
        {
            _token = token;
            _serviceProvider = serviceProvider;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(_token.AccessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && !string.IsNullOrEmpty(_token.RefreshToken))
            {
                using var scope = _serviceProvider.CreateScope();
                var authApi = scope.ServiceProvider.GetRequiredService<IAuthenticationService>();

                try
                {
                    var newTokens = await authApi.RefreshTokenAsync(new RefreshTokenRequestDto
                    {
                        UserId = 1,
                        RefreshToken = _token.RefreshToken
                    });

                    _token.AccessToken = newTokens.AccessToken;
                    _token.RefreshToken = newTokens.RefreshToken;

                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);

                    response.Dispose();
                    return await base.SendAsync(request, cancellationToken);
                }
                catch
                {
                    return response;
                }
            }

            return response;
        }
    }
}
