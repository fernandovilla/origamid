using Agendabolo.Core.Ingredientes;
using Agendabolo.Data;
using Agendabolo.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Historicos
{
    public interface IHistoricoEntradaRepository : IGenericRepository<HistoricoEntradaDTA, int>
    {    }
}
