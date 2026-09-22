using JwtAuthentication.Lib.Entities;
using JwtAuthentication.Lib.Models;

namespace JwtAuthentication.API.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto user);
        Task<TokenResponseDto?> LoginAsync(UserDto user);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
