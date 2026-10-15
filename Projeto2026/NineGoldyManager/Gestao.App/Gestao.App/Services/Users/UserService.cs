using Gestao.App.Services.Companies;
using Gestao.Domain.Model.Companies;
using Gestao.Domain.Model.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Gestao.App.Services.Users
{
    public class UserService(IUserStore<ApplicationUser> UserStore, UserManager<ApplicationUser> UserManager, ICompanyService CompanyService) : IUserService
    {        
        public bool SupportsUserEmail => UserManager.SupportsUserEmail;

        public async Task<ApplicationUser> CreateAsync(string userName, string password)
        {
            try
            {
                var newUser = new ApplicationUser();
                await UserStore.SetUserNameAsync(newUser, userName, CancellationToken.None);

                var emailStore = GetEmailStore();
                await emailStore.SetEmailAsync(newUser, userName, CancellationToken.None);
                await emailStore.SetEmailConfirmedAsync(newUser, false, CancellationToken.None);

                newUser.Company = await CompanyService.CreateAsync();

                return await CreateAsync(newUser, password);
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor.");
            }
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            IdentityResult result = await UserManager.CreateAsync(user);

            if (!result.Succeeded)
                throw new IdentityErrorException(result.Errors);

            var userId = await GetUserIdAsync(user);

            return await FindByIdAsync(userId);

        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await UserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await UserManager.FindByIdAsync(userId);
        }

        public async Task<string> GetUserIdAsync(ApplicationUser user)
        {
            return await UserManager.GetUserIdAsync(user);
        }
    }
}
