﻿using Agendabolo.Core.LogDeErros;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteService: IServiceBase<IngredienteDTA, int>
    {
        public int GetTotal()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.GetIngredienteRepository.Count();
            }
        }

        public IEnumerable<IngredienteDTA> Get()
        {
            using (var unit = new UnitOfWork())
                return unit.GetIngredienteRepository.Get().ToList();
        }

        public IEnumerable<IngredienteDTA> GetWithEmbalagens()
        {
            using (var unit = new UnitOfWork())
                return unit.GetIngredienteRepository.GetWithEmbalagens().ToList();
        }
        
        public IngredienteDTA Get(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                    return unit.GetIngredienteRepository.Get(id);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return null;
        }

        public (bool, IngredienteDTA) Save(IngredienteDTA ingrediente)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.GetIngredienteRepository;

                    if (ingrediente.Id == 0)
                        repository.Insert(ingrediente);
                    else
                        repository.Update(ingrediente);

                    unit.SaveChanges();
                }

                return (true, ingrediente);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, ingrediente);
        }

        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    unit.GetIngredienteRepository.Delete(id);
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
    }
}
