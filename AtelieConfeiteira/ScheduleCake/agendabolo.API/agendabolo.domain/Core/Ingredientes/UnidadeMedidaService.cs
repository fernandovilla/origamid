using Agendabolo.Core.Logs;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class UnidadeMedidaService : IServiceBase<UnidadeMedidaDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    unit.UnidadeMedidaRepository.Delete(id);
                    unit.Save();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return false;
        }

        public IEnumerable<UnidadeMedidaDTA> Get()
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                    return unit.UnidadeMedidaRepository.Get().ToList();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;
        }

        public UnidadeMedidaDTA GetByID(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                    return unit.UnidadeMedidaRepository.GetByID(id);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;
        }

        public int GetTotal()
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                    return unit.UnidadeMedidaRepository.Count();
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return 0;
        }

        public (bool, UnidadeMedidaDTA) Save(UnidadeMedidaDTA unidadeMedida)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    if (unidadeMedida.Id == 0)
                        unit.UnidadeMedidaRepository.Insert(unidadeMedida);
                    else
                        unit.UnidadeMedidaRepository.Update(unidadeMedida);

                    unit.Save();
                }

                return (true, unidadeMedida);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return (false, unidadeMedida);
        }
    }
}
