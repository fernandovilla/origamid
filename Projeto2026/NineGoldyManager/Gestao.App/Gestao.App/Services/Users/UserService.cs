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
    public class UserService : IUserService
    {
        [Inject] private IUserStore<ApplicationUser> UserStore { get; set; }
        [Inject] private UserManager<ApplicationUser> UserManager { get; set; }
        [Inject] private ICompanyService CompanyService { get; set; }


        public bool SupportsUserEmail => UserManager.SupportsUserEmail;

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user)
        {            
            var newCompanyDefault = await CompanyService.CreateAsync();

            return await CreateAsync(user, string.Empty, newCompanyDefault);
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password, Company company)
        {
            user.Company = company;

            IdentityResult result = await UserManager.CreateAsync(user, password);

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
