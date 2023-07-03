using System;
using System.Collections.Generic;
using System.Text;
using Agendabolo.GenericRepository;

namespace Agendabolo.Core.Fabricantes
{
    public interface IFabricanteRepository: IGenericRepository<FabricanteDTA, int>
    {
    }
}
