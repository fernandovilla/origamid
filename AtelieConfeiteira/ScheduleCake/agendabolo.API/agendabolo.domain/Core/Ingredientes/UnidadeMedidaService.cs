using Agendabolo.Core.LogDeErros;
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
                using (var unit = new UnitOfWork())
                {
                    unit.GetUnidadeMedidaRepository.Delete(id);
                    unit.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return false;
        }

        public IEnumerable<UnidadeMedidaDTA> Get()
        {
            try
            {
                using (var unit = new UnitOfWork())
                    return unit.GetUnidadeMedidaRepository.Get().ToList();
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return null;
        }

        public UnidadeMedidaDTA Get(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                    return unit.GetUnidadeMedidaRepository.Get(id);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return null;
        }

        public int GetTotal()
        {
            try
            {
                using (var unit = new UnitOfWork())
                    return unit.GetUnidadeMedidaRepository.Count();
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return 0;
        }

        public (bool, UnidadeMedidaDTA) Save(UnidadeMedidaDTA unidadeMedida)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    if (unidadeMedida.Id == 0)
                        unit.GetUnidadeMedidaRepository.Insert(unidadeMedida);
                    else
                        unit.GetUnidadeMedidaRepository.Update(unidadeMedida);

                    unit.SaveChanges();
                }

                return (true, unidadeMedida);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, unidadeMedida);
        }
    }
}
