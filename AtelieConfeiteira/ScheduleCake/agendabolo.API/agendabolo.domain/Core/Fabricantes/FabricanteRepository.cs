using Agendabolo.Data;
using Agendabolo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendabolo.GenericRepository;

namespace Agendabolo.Core.Fabricantes
{
    public class FabricanteRepository : GenericRepository.GenericRepositoryDbContext<FabricanteDTA, int>, IFabricanteRepository
    {
        public FabricanteRepository(IDatabase database) : base(database)
        { }
    }
}