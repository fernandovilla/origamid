using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.EF_MySQL.DAL.GenericRepository;

namespace Teste.EF_MySQL.DAL.Receitas
{
    public interface IReceitaRepository : IGenericRepository<ReceitaDTA>
    {
    }
}
