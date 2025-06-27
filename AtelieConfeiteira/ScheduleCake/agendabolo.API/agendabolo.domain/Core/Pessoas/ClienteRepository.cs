using Agendabolo.Core.Clientes;
using Agendabolo.Core.Produtos;
using Agendabolo.Data;
using Agendabolo.GenericRepository;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Pessoas
{
    public class ClienteRepository : GenericRepositoryDbContext<PessoaDTA, int>, IClienteRepository
    {
        public ClienteDTA Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaDTA> Get(Expression<Func<PessoaDTA, bool>> filter = null)
        {
            string sql = "SELECT * FROM clientes c INNER JOIN pessoas p ON c.idpessoa = p.id;";
            var clientes = _database.Connection.Query<ClienteDTA>(sql, null, _database.Transaction);

            return clientes;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClienteDTA entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ClienteDTA entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ClienteDTA entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return base.Count();
        }

        public ClienteRepository(IDatabaseContext database)
            : base(database)
        { }
    }
}
