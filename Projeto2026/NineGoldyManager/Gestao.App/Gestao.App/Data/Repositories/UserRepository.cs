using Gestao.Domain.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data.Repositories
{
    public class UserRepository(ApplicationDbContext DbContext) : IUserRepository
    {
        public async Task<User> CreateAsync(User newUser)
        {
            //await  DbContext.Users.AddAsync(newUser);
            //return newUser;
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindByIdAsync(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
