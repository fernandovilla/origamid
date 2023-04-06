using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public interface IProdutoRepository : IGenericRepository<ProdutoDTA, ulong>
    {
    }
}
