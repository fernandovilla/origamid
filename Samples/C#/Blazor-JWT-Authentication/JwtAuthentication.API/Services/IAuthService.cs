using JwtAuthentication.API.Entities;
using JwtAuthentication.API.Models;

namespace JwtAuthentication.API.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto user);
        Task<string?> LoginAsync(UserDto user);
        
    }
}
