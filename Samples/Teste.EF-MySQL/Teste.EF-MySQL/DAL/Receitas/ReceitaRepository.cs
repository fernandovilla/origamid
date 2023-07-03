using System.Diagnostics;
using System.Linq.Expressions;
using Teste.DAL;
using Teste.EF_MySQL.DAL.GenericRepository;

namespace Teste.EF_MySQL.DAL.Receitas
{

    public class ReceitaRepository : GenericRepository<ReceitaDTA>
    {
        public ReceitaRepository(AppDbContext context)
            : base(context)
        { }


    }
}
