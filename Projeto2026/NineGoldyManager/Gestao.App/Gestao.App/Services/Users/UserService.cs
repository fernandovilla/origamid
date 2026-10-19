using Gestao.App.Data;
using Gestao.App.Services.Auth;
using Gestao.App.Services.Companies;
using Gestao.Domain.Model.Companies;
using Gestao.Domain.Model.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gestao.App.Services.Users
{
    public class UserService(
        IUserStore<ApplicationUser> UserStore, 
        UserManager<ApplicationUser> UserManager, 
        ICompanyService CompanyService, 
        IUnitOfWorkFactory unitOfWorkFactory) : IUserService
    {        
        public bool SupportsUserEmail => UserManager.SupportsUserEmail;

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!UserManager.SupportsUserEmail)
                throw new NotSupportedException("The default UI requires a user store with email support.");

            return (IUserEmailStore<ApplicationUser>)UserStore;   
        }

        public async Task<ApplicationUser> CreateAsync(string userName, string password)
        {
            try
            {
                var newUser = new ApplicationUser();
                await UserStore.SetUserNameAsync(newUser, userName, CancellationToken.None);

                var emailStore = (IUserEmailStore<ApplicationUser>)UserStore;
                await emailStore.SetEmailAsync(newUser, userName, CancellationToken.None);
                await emailStore.SetEmailConfirmedAsync(newUser, false, CancellationToken.None);

                //newUser.Company = new Company() { 
                //    TradeName = "INDEFINIDO" 
                //};

                return await CreateAsync(newUser, password);
            }
            catch(Exception ex)
            {
                throw ex;
             
            }
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
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

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password, Company company)
        {
            throw new NotImplementedException();
        }

        public async Task<User> CreateAsync(UserDto userDto)
        {
            var user = new User();
            user.Email = userDto.UserName;
            user.UserName = userDto.UserName;

            user.Credential = new UserCredential();
            user.Credential.PasswordHash = new PasswordHasher<User>().HashPassword(user, userDto.Password);

            user.Credential.AccessRule = new UserAccessRule();
            user.Credential.AccessRule.Rule = UserAccessRuleEnum.Limited;


            using var unit = unitOfWorkFactory.Create();

            user.Company = await CreateNewEmptyCompany(unit);
            user.CompanyId = user.Company.Id;

            unit.UserRepository.CreateAsync(user);

            await unit.SaveChangesAsync();

            return user;
        }

        private async Task<Company> CreateNewEmptyCompany(IUnitOfWork unit)
        {
            var newCompany = new Company();
            await unit.CompanyRepository.CreateAsync(newCompany);

            return newCompany;
        }
    }
}
