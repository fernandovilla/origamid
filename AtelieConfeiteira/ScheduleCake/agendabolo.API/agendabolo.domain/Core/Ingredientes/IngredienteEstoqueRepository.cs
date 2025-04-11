using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteEstoqueRepository : GenericRepository.GenericRepositoryDbContext<IngredienteEstoqueDTA, int>, IIngredienteEstoqueRepository
    {
        public IngredienteEstoqueRepository(ApplicationDbContext context)
            : base(context)
        { }

        public void SubtrairQuantidadeEstoque(IngredienteEstoqueDTA estoque, int quantidade)
        {
            
        }

        public void AdicionarQuantidadeEstoque(IngredienteEstoqueDTA estoque, int quantidade)
        {

        }
    }
}
