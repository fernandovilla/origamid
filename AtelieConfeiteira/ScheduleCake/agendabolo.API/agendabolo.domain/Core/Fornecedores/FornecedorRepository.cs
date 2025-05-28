using Agendabolo.Core.Ingredientes;
using Agendabolo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fornecedores
{
    public class FornecedorRepository : GenericRepository.GenericRepositoryDbContext<FornecedorDTA, int>, IFornecedorRepository
    {
        public FornecedorRepository(IDatabaseContext database)
            : base(database)
        { }               
    }
}
