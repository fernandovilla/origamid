using Gestao.App.Data;
using Gestao.App.Services.Users;
using Gestao.Domain.Model.Users;

namespace Gestao.App.Services.Auth
{
    public class AuthService(IUnitOfWorkFactory UnitOfWorkFactory, IUserService UserService) : IAuthService
    {
        public Task<TokenResponseDto?> LoginAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> RegisterAsync(UserDto userDto)
        {
            throw new NotImplementedException();

            //return await UserService.CreateAsync(userDto);
            

            //repository.CreateAsync()

            // +usuario
            // +credenciais
            // +rules
        }
    }
}
