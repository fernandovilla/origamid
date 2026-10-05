using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Query;
using Ninegoldy.Data;
using Ninegoldy.Exceptions;
using Ninegoldy.Models.Users;
using Ninegoldy.Services.PasswordHasher;

namespace Ninegoldy.Services.Authentication
{
    public class AuthServices : IAuthService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AuthServices(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<UserDTO> RegisterUserAsync(UserRequest userRequest)
        {
            var newUser = new UserDTO
            {
                Id = Guid.NewGuid(),
                Name = string.Empty,
                Email = userRequest.Email,
                UserName = userRequest.Email,
                PasswordHash = ComputeHash(userRequest.Password),
                Role = UserRole.Admin
            };

            using (IUnitOfWork unit = _unitOfWorkFactory.Create())
            {

                if (unit.UserRepository.ExistsEmail(newUser.Email))
                    throw new Exception("E-mail já registrado.");

                var user = await unit.UserRepository.AddAsync(newUser);

                await unit.SaveChangesAsync();

                return user;
            }

        }

        public async Task<UserDTO> LoginAsync(UserLogin userLogin)
        {
            //string passwordHash = ComputeHash(userRequest.Password);


            using (IUnitOfWork unit = _unitOfWorkFactory.Create())
            {
                var user = await unit.UserRepository.GetByEmailAndPasswordAsync(userLogin.Email, "");

                if (user == null)
                    throw new UserNotFoundException();

                if ((new PasswordHasherService()).Verify(userLogin.Password, user.PasswordHash))
                {
                    return user;
                }
                else
                {
                    throw new UserNotFoundException("Usuário ou senha incorretos.");
                }

                return user;
            }

        }

        private string ComputeHash(string password)
        {
            return (new PasswordHasherService()).Hash(password);
        }
    }
}
