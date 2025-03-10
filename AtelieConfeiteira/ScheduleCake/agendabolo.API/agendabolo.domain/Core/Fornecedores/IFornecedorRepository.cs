using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fornecedores
{
    public interface IFornecedorRepository : IGenericRepository<FornecedorDTA, int>
    {
    }
}
