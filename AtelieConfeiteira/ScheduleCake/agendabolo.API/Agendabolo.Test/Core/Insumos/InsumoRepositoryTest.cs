using Agendabolo.Core.Ingredientes;
using Agendabolo.Data;
using Agendabolo.Test.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Agendabolo.Test.Core.Insumos
{
    public class InsumoRepositoryTest: IClassFixture<ApplicationDbContextFixture>
    {        
        public InsumoRepositoryTest(IDatabaseContext database)
        {
            
        }

        [Fact]
        public void GetByID()
        {
            using(var unit = new UnitOfWork())
            {
                var repository = unit.GetIngredienteRepository;

                var insumo = repository.Get(3);

                Assert.NotNull(insumo);
            }
        }

        [Fact]
        public void InsertInsumo()
        {
            var insumo = new IngredienteDTA
            {
                Nome = "NOVO INSUMO",
                PrecoCustoQuilo = 10.05m,
                Status = Agendabolo.Core.StatusCadastro.Normal
            };

            int affected = 0;
            using (var unit = new UnitOfWork())
            {
                unit.GetIngredienteRepository.Insert(insumo);
                //affected = unit.Save();
            }

            Assert.Equal(1, affected);
        }


    }
}
