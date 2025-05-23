using Agendabolo.Core.Ingredientes;
using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fornecedores
{
    public class FornecedorRepository : GenericRepository.GenericRepositoryDbContext<FornecedorDTA, int>, IFornecedorRepository
    {
        public FornecedorRepository(ApplicationDbContext context)
            : base(context)
        { }
                
        public IEnumerable<FornecedorDTA> Get(Expression<Func<FornecedorDTA, bool>> filter = null)
        {
            IQueryable<FornecedorDTA> fornecedores = _dbset;

            if (filter != null)
                fornecedores = fornecedores.Where(filter);

            return fornecedores.OrderBy(i => i.Nome);
        }

        public FornecedorDTA Get(int id)
        {
            return this.Get(i => i.Id == id)
                .FirstOrDefault();
        }

       
    }
}
