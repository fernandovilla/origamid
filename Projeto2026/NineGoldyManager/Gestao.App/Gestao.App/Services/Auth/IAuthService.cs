using Gestao.Domain.Model.Users;

namespace Gestao.App.Services.Auth
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto user);
        Task<TokenResponseDto?> LoginAsync(UserDto user);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
