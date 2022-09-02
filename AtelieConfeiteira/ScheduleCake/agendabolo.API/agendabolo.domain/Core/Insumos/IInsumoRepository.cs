using System;
using System.Collections.Generic;
using System.Text;
using Agendabolo.GenericRepository;

namespace Agendabolo.Core.Insumos
{
    public interface IInsumoRepository : IGenericRepository<Insumo, ulong>
    {
    }
}
