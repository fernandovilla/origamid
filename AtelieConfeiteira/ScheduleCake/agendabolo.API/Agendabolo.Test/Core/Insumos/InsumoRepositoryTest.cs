using Agendabolo.Core.Insumos;
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
        private ApplicationDbContextFixture ctxFixture;

        public InsumoRepositoryTest(ApplicationDbContextFixture _ctxFixture)
        {
            this.ctxFixture = _ctxFixture;
        }

        [Fact]
        public void GetByID()
        {
            using(var unit = new UnitOfWork(ctxFixture.Context))
            {
                var repository = unit.InsumosRepository;

                var insumo = repository.GetByID(3);

                Assert.NotNull(insumo);
            }
        }

        [Fact]
        public void InsertInsumo()
        {
            var insumo = new Insumo
            {
                Nome = "NOVO INSUMO",
                PrecoCusto = 10.05m,
                Status = Agendabolo.Core.StatusCadastro.Normal
            };

            int affected = 0;
            using (var unit = new UnitOfWork(ctxFixture.Context))
            {
                unit.InsumosRepository.Insert(insumo);
                affected = unit.Save();
            }

            Assert.Equal(1, affected);
        }


    }
}
