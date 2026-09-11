using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Gestao.Domain.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Gestao.App.Data.Interceptors
{
    // Classe que intercepta o processo de SaveChanges no EF
    // Necessário adicioná-la no DbContext.OnConfiguring()
    public class StatusManagerInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            //return base.SavingChanges(eventData, result);
            return StatusManagerAlgorithm(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            //return await base.SavingChangesAsync(eventData, result, cancellationToken);
            return StatusManagerAlgorithm(eventData, result);
        }


        private InterceptionResult<int> StatusManagerAlgorithm(DbContextEventData eventData, InterceptionResult<int> result)
        {
            //TODO - Interceptar registros marcados para exclusão. Trocar o status e DeletedAt = Now

            if (eventData.Context == null)
                return result;

            var entitiesChanged = eventData.Context.ChangeTracker.Entries();

            foreach (var entry in entitiesChanged)
            {
                if (entry.Entity is IStatusManager)
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        entry.State = EntityState.Modified;
                        ((IStatusManager)entry.Entity).Status = StatusEnum.Deleted;
                        ((IStatusManager)entry.Entity).DeletedAt = DateTimeOffset.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        ((IStatusManager)entry.Entity).UpdatedAt = DateTimeOffset.UtcNow;
                    }
                    else if (entry.State == EntityState.Added)
                    {
                        ((IStatusManager)entry.Entity).CreatedAt = DateTimeOffset.UtcNow;
                    }
                }
            }

            return result;
        }
    }
}
