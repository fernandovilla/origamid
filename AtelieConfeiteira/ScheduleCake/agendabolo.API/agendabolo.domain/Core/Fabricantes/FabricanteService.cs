using Agendabolo.Core.LogDeErros;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fabricantes
{
    public class FabricanteService: IServiceBase<FabricanteDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    unit.FabricanteRepository.Delete(id);
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

        public int GetTotal()
        {
            using (var unit = new UnitOfWorkDbContext())
            {
                return unit.FabricanteRepository.Count();
            }
        }

        public IEnumerable<FabricanteDTA> Get()
        {
            using(var unit = new UnitOfWorkDbContext())
            {
                return unit.FabricanteRepository.Get();
            }
        }

        public FabricanteDTA GetByID(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    return unit.FabricanteRepository.GetByID(id);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return null;
        }

        public (bool, FabricanteDTA) Save(FabricanteDTA fabricante)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    var repository = unit.FabricanteRepository;

                    if (fabricante.Id == 0)
                        repository.Insert(fabricante);
                    else
                        repository.Update(fabricante);

                    unit.SaveChanges();
                }

                return (true, fabricante);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, fabricante);
        }
    }
}
