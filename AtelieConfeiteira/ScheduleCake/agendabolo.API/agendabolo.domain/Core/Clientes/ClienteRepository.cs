using Agendabolo.Core.Produtos;
using Agendabolo.Data;
using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Clientes
{
    public class ClienteRepository : GenericRepositoryDbContext<ClienteDTA, int>, IClienteRepository
    {
        public ClienteRepository(IDatabaseContext database)
            : base(database)
        { }
    }
}
