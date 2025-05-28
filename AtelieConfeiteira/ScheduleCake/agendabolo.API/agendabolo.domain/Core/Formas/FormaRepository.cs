using Agendabolo.Core.Ingredientes;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Formas
{
    public class FormaRepository : GenericRepository.GenericRepositoryDbContext<FormaDTA, int>, IFormaRepository
    {
        public FormaRepository(IDatabaseContext database)
            : base(database)
        { }
    }


}
