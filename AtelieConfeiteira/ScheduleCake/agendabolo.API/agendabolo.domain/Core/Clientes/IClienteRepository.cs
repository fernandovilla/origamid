using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Clientes
{
    public interface IClienteRepository: IGenericRepository<ClienteDTA, int>
    {
    }
}
