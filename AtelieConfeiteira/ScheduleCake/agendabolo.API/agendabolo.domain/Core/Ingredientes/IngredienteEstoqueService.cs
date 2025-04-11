using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteEstoqueService : IServiceBase<IngredienteEstoqueDTA, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IngredienteEstoqueDTA> Get()
        {
            throw new NotImplementedException();
        }

        public IngredienteEstoqueDTA GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IngredienteEstoqueDTA> GetByIdProduto(int idProduto)
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

        public (bool, IngredienteEstoqueDTA) Save(IngredienteEstoqueDTA estoque)
        {
            throw new NotImplementedException();
        }
    }
}
