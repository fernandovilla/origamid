using Agendabolo.Core.Logs;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fabricantes
{
    public class FabricanteService
    {
        public IEnumerable<Fabricante> Select()
        {
            using (var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
            {
                return unit.GetFabricanteRepository().SelectAll().ToList();
            }
        }

        public Fabricante Select(ulong id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid Id");

            using (var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
            {
                return unit.GetFabricanteRepository().Select(id);
            }

            return null;
        }

        public Tuple<bool, Fabricante> Save(Fabricante fabricante)
        {
            try
            {
                if (fabricante == null)
                    throw new ArgumentNullException("Fabricante inválido");


                using (var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
                {
                    var repository = unit.GetFabricanteRepository();

                    if (fabricante.Id == 0)
                        fabricante.Id = repository.Insert(fabricante);
                    else
                        repository.Update(fabricante);

                    unit.SaveChanges();
                }

                return Tuple.Create(true, fabricante);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);                
            }

            return Tuple.Create(false, fabricante);
        }

        public bool Delete(ulong id)
        {
            try
            {

                if (id == 0)
                    throw new ArgumentException("Invalid Id");

                using (var unit = UnitOfWorkFactory.Default.GetUnitOfWork())
                {
                    var repository = unit.GetFabricanteRepository();
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
