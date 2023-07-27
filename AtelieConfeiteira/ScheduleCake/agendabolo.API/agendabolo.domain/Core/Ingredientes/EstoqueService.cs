using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class EstoqueService : IServiceBase<EstoqueDTA, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstoqueDTA> Get()
        {
            throw new NotImplementedException();
        }

        public EstoqueDTA GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstoqueDTA> GetByIdProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public int GetQuantidadeByProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public int GetTotal()
        {
            throw new NotImplementedException();
        }

        public (bool, EstoqueDTA) Save(EstoqueDTA estoque)
        {
            throw new NotImplementedException();
        }
    }
}
