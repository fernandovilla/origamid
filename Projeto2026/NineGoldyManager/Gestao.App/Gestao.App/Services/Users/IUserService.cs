using Gestao.Domain.Model.Companies;
using Gestao.Domain.Model.Users;
using Microsoft.AspNetCore.Identity;

namespace Gestao.App.Services.Users
{
    public interface IUserService
    {
        bool SupportsUserEmail { get; }
        Task<ApplicationUser> CreateAsync(ApplicationUser user);
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password, Company company);
        Task<string> GetUserIdAsync(ApplicationUser user);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<ApplicationUser> FindByIdAsync(string userId);        
    }
}
