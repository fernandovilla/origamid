using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class UnidadeMedidaRepository : GenericRepository.GenericRepositoryDbContext<UnidadeMedidaDTA, int>, IUnidadeMedidaRepository
    {
        public UnidadeMedidaRepository(ApplicationDbContext context) 
            : base(context)
        { }
    }
}
