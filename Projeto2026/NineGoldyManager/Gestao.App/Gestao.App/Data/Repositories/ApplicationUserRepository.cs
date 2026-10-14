using Gestao.Domain.Model;
using Gestao.Domain.Model.Users;
using Gestao.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Gestao.App.Data.Repositories
{
    public class ApplicationUserRepository(UserManager<ApplicationUser> UserManager) : IApplicationUserRepository
    {

    }

    
}
