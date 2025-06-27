using Agendabolo.Core.Clientes;
using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Pessoas
{
    public interface IPessoaRepository : IGenericRepository<PessoaDTA, int>
    {
        //IEnumerable<PessoaDTA> Get(int idUnidadeNegocio);
        //PessoaDTA Get(int id, int idUnidadeNegocio);
    }
}
