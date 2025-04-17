using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Historicos
{
    public class HistoricoEntradaRepository : GenericRepository.GenericRepositoryDbContext<HistoricoEntradaDTA, int>, IHistoricoEntradaRepository
    {        
        public HistoricoEntradaRepository(ApplicationDbContext context)
            : base(context)
        { }

        public int Count()
        {
            return _context.Historicos.Where(i => i.TipoOperacao == TipoOperacaoHistoricoEnum.EntradaMercadorias).Count();
        }
    }
}
