using Gestao.App.Client.Libraries.Helpers;
using Gestao.App.Services.Users;
using Gestao.Domain.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Gestao.App.Components.Pages.Base
{
    [Authorize]
    public class AuthenticatedPageBase : PageBase
    {
        [Inject] protected AuthenticationStateProvider? AuthProvider { get; set; }
        [Inject] protected IApplicationUserService? ApplicationUserService { get; set; }

        private ApplicationUser _authenticatedUser = null;

        protected ApplicationUser? AuthenticatedUser
        {            
            get {
                if (_authenticatedUser == null)
                {
                    var task = new Task(async () => await LoadAuthenticatedUserAsync());
                    task.RunSynchronously();
                }
                    
                return _authenticatedUser;
            }
        }
            

        protected async override Task OnInitializedAsync()
        {
            //await LoadAuthenticatedUserAsync();
        }

        private async Task LoadAuthenticatedUserAsync()
        {
            var userId = (await AuthenticationHelper.GetAuthenticatedUserIdAsync(AuthProvider))!.Value;

            ApplicationUser user = null;

            if (userId != Guid.Empty)
                user =  await ApplicationUserService.FindByIdAsync(userId);

            _authenticatedUser = user;
        }

        // private async Task LoadAuthenticatedUserAsyncx()
        // {        
        //     var userId = (await AuthenticationHelper.GetAuthenticatedUserIdAsync(AuthProvider))!.Value;
        //
        //     if (userId != Guid.Empty)
        //         User = await ApplicationUserService.FindByIdAsync(userId);
        // }
    }
}
