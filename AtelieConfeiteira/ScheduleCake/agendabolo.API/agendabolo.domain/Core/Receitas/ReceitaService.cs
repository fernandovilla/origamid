using Agendabolo.Core.Logs;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaService : IServiceBase<Receita, ulong>
    {
        public bool Delete(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    unit.ReceitasRepository.Delete(id);
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

        public IEnumerable<Receita> Get()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.ReceitasRepository.Get();                
            }
        }

        public Receita GetByID(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.ReceitasRepository.GetByID(id);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;
        }

        public int GetTotal()
        {
            using(var unit = new UnitOfWork())
            {
                return unit.ReceitasRepository.Count();
            }
        }

        public (bool, Receita) Save(Receita receita)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.ReceitasRepository;

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
                LogDeErros.Default.Write(ex);
            }

            return (false, receita);
        }
    }
}
