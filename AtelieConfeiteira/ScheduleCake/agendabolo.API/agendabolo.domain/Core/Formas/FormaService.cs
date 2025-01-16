using Agendabolo.Core.LogDeErros;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Formas
{
    public class FormaService : IServiceBase<FormaDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    unit.FormaRepository.Delete(id);
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

        public IEnumerable<FormaDTA> Get()
        {
            using (var unit = new UnitOfWorkDbContext())
            {
                return unit.FormaRepository.Get().ToList();
            }
        }

        public FormaDTA GetByID(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    return unit.FormaRepository.GetByID(id);
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
            using (var unit = new UnitOfWorkDbContext())
            {
                return unit.FormaRepository.Count();
            }
        }

        public (bool, FormaDTA) Save(FormaDTA forma)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    var repository = unit.FormaRepository;

                    if (forma.Id == 0)
                        repository.Insert(forma);
                    else
                        repository.Update(forma);

                    unit.Save();
                }

                return (true, forma);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, forma);
        }
    }
}
