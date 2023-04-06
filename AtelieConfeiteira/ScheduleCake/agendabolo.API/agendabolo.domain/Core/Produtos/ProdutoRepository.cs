using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public class ProdutoRepository : GenericRepository.GenericRepository<ProdutoDTA, ulong>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context)
            : base(context)
        { }

    }
}
