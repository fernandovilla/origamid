using Sample_jwt_balta.Models;

namespace Sample_jwt_balta.Repositories
{
    public class UserRepository
    {
        private readonly IEnumerable<User> _users;

        public UserRepository()
        {
            _users = new List<User>()
            {
                new User {Id = 1, Name = "Fernando Villa", Username = "admin@microleme.com",Password = "admin", Role = RoleEnum.Admin},
                new User {Id = 1, Name = "Gerente", Username = "gerente@microleme.com",Password = "222", Role = RoleEnum.Employee},
                new User {Id = 1, Name = "Coordenador", Username = "coordenador@microleme.com",Password = "333", Role = RoleEnum.Employee},
                new User {Id = 1, Name = "Comum", Username = "comum@microleme.com",Password = "comum", Role = RoleEnum.Comum},
            };
        }

        public User? Get(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) 
                throw new ArgumentNullException("username");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            return _users.Where(x => 
                x.Username == username &&
                x.Password.Equals(password))
                .FirstOrDefault();
        }
    }
}
