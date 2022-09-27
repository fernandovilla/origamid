using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Agendabolo.Test.Core.Data
{
    public class ApplicationDbContextFixture : IDisposable
    {
        public ApplicationDbContext Context;

        public ApplicationDbContextFixture()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("agendaboloInMemory" + Guid.NewGuid().ToString());

            Context = new ApplicationDbContext(builder.Options);
            Context.Database.EnsureDeleted();

            bool created = Context.Database.EnsureCreated();

            Assert.True(created);

            this.SeedData();
        }

        private void SeedData()
        {
            this.AddInsumos();


            Context.SaveChanges();
        }

        private void AddInsumos()
        {
            for (ulong i = 1; i < 300; i++)
            {
                Context.Ingredientes.Add(new Agendabolo.Core.Ingredientes.Ingrediente
                {
                    Id = i,
                    Nome = $"INSUMO #{i}",
                    PrecoCusto = i + 0.01m,
                    Status = Agendabolo.Core.StatusCadastro.Normal
                });
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
