using Sistema.Data;
using Sistema.Models.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Models.Ingredientes
{
    public class IngredienteService
    {
        public IEnumerable<Ingrediente> Select()
        {
            using(var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
            {
                return unit.GetIngredienteRepository().SelectAll().ToList();
            }
        }
        
        public Ingrediente Select(ulong id) 
        {
            try
            {
                if (id == 0)
                    throw new ArgumentException("Invalid Id");

                using(var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
                {
                    return unit.GetIngredienteRepository().Select(id);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;        
        }

        public Tuple<bool, Ingrediente> Save(Ingrediente ingrediente)
        {
            try
            {
                if (ingrediente == null)
                    throw new ArgumentNullException("Ingrediente inválido");


                using (var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
                {
                    var repository = unit.GetIngredienteRepository();

                    if (ingrediente.Id == 0)
                        ingrediente.Id = repository.Insert(ingrediente);
                    else
                        repository.Update(ingrediente);

                    unit.SaveChanges();
                }

                return Tuple.Create(true, ingrediente);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return Tuple.Create(false, ingrediente);
        }

        public bool Delete(ulong id)
        {
            try
            {

                if (id == 0)
                    throw new ArgumentException("Invalid Id");

                using (var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
                {
                    var repository = unit.GetIngredienteRepository();
                    repository.Delete(id);

                    unit.SaveChanges();
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
