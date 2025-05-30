using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaService : IServiceBase<ReceitaDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    unit.GetReceitaRepository.Delete(id);
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

        public IEnumerable<ReceitaDTA> Get()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.GetReceitaRepository.Get().ToList();
            }
        }

        public ReceitaDTA Get(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var receita = unit.GetReceitaRepository.Get(id);

                    var ingredienteRepository = unit.GetIngredienteRepository;
                    foreach (var item in receita.Ingredientes)
                        item.Ingrediente = ingredienteRepository.Get(item.IdIngrediente);

                    return receita;
                }
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return null;
        }

        public int GetTotal()
        {
            using(var unit = new UnitOfWork())
                return unit.GetReceitaRepository.Count();
        }

        public (bool, ReceitaDTA) Save(ReceitaDTA receita)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.GetReceitaRepository;

                    if (receita.Id == 0)
                        repository.Insert(receita);
                    else
                        repository.Update(receita);

                    unit.SaveChanges();
                }


                return (true, receita);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, receita);
        }
    }
}
