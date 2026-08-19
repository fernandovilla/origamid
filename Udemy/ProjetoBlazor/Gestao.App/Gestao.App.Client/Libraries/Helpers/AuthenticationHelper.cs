using Microsoft.AspNetCore.Components.Authorization;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace Gestao.App.Client.Libraries.Helpers
{
    public class AuthenticationHelper
    {
        public static async Task<Guid?> GetAuthenticatedUserIdAsync(AuthenticationStateProvider provider) 
        {
            var authenticationState = await provider.GetAuthenticationStateAsync();

            var id = authenticationState.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
            
            if (id != null && Guid.TryParse(id.Value, out var userId))
                return userId;

            return null;
        }
    }
}
