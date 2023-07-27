using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Agendabolo.Core.Ingredientes
{
    public class EstoqueRepository : GenericRepository.GenericRepositoryDbContext<EstoqueDTA, int>, IEstoqueRepository
    {
        public EstoqueRepository(ApplicationDbContext context)
            : base(context)
        { }

        public void SubtrairQuantidadeEstoque(EstoqueDTA estoque, int quantidade)
        {
            
        }

        public void AdicionarQuantidadeEstoque(EstoqueDTA estoque, int quantidade)
        {

        }
    }
}
