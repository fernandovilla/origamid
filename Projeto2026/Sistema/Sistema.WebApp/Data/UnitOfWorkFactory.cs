using Microsoft.EntityFrameworkCore;

namespace Ninegoldy.Data
{
    public sealed class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public UnitOfWorkFactory(IDbContextFactory<ApplicationDbContext> dbContextFactory)
            => _dbContextFactory = dbContextFactory;

        public IUnitOfWork Create()
            => new UnitOfWork(_dbContextFactory.CreateDbContext());
    }
}
