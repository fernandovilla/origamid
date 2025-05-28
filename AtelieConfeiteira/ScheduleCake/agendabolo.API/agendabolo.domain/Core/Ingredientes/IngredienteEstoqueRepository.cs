using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteEstoqueRepository : GenericRepository.GenericRepositoryDbContext<IngredienteEstoqueDTA, int>, IIngredienteEstoqueRepository
    {
        public IngredienteEstoqueRepository(IDatabaseContext database)
            : base(database)
        { }

        public void SubtrairQuantidadeEstoque(IngredienteEstoqueDTA estoque, int quantidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarQuantidadeEstoque(IngredienteEstoqueDTA estoque, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}
