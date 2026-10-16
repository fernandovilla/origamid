using Gestao.App.Services.Auth;
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
        Task<ApplicationUser> CreateAsync(string username, string password);
        Task<User> CreateAsync(UserDto userDto);
        Task<string> GetUserIdAsync(ApplicationUser user);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<ApplicationUser> FindByIdAsync(string userId);        
    }
}
