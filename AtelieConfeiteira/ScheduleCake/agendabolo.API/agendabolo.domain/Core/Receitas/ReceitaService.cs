using Agendabolo.Core.LogDeErros;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaService : IServiceBase<ReceitaDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    unit.ReceitaRepository.Delete(id);
                    unit.Save();
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
            using (var unit = new UnitOfWorkDbContext())
            {
                return unit.ReceitaRepository.Get().ToList();
            }
        }

        public ReceitaDTA GetByID(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    var receita = unit.ReceitaRepository.GetByID(id);]
                    
                    var ingredienteRepository = unit.IngredienteRepository;
                    foreach(var i in receita.Ingredientes)
                    {
                        var ingrediente = ingredienteRepository.GetByID(i.IdIngrediente);
                        var pesoReceita = (decimal)(receita.PesoReferencia * i.Percentual / 100);
                        var custoQuiloReceita = (ingrediente.PrecoCustoQuilo / 1000) * pesoReceita;
                    }

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
            using(var unit = new UnitOfWorkDbContext())
            {
                return unit.ReceitaRepository.Count();
            }
        }

        public (bool, ReceitaDTA) Save(ReceitaDTA receita)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    var repository = unit.ReceitaRepository;

                    if (receita.Id == 0)
                        repository.Insert(receita);
                    else
                        repository.Update(receita);

                    unit.Save();
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
