using AgendaBolo.Domain.Model.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBolo.Domain.Database
{
    public interface IUnitOfWork
    {
        IIngredienteRepository IngredienteReopsitory { get; }        
        
        int SaveChanges();
    }
}
