using Gestao.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> FindByIdAsync(Guid id);
    }
}
