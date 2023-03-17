using Agendabolo.Core.Logs;
using Agendabolo.Data;
using System;
using System.Collections.Generic;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteService: IServiceBase<IngredienteDTA, ulong>
    {
        public int GetTotal()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.IngredienteRepository.Count();
            }
        }

        public IEnumerable<IngredienteDTA> Get()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.IngredienteRepository.Get();
            }
        }
        
        public IngredienteDTA GetByID(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.IngredienteRepository.GetByID(id);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;
        }

        public (bool, IngredienteDTA) Save(IngredienteDTA ingrediente)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.IngredienteRepository;

                    if (ingrediente.Id == 0)
                        repository.Insert(ingrediente);
                    else
                        repository.Update(ingrediente);

                    unit.Save();
                }

                return (true, ingrediente);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return (false, ingrediente);
        }

        public bool Delete(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    unit.IngredienteRepository.Delete(id);
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
    }
}
