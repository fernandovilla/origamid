using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
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


        public override ProdutoDTA GetByID(ulong id)
        {            
            IQueryable<ProdutoDTA> produtos = _dbset;

            //var prod = produtos
            //    .Where(i => i.Id == id)
            //    .Include(i => i.Receitas)
            //    .ThenInclude(i => i.Produto)
            //    .FirstOrDefault();


            var prod = produtos
                .Where(i => i.Id == id)
                .Include(i => i.Receitas)
                .FirstOrDefault();

            return prod;
        }

    }
}
