﻿using Agendabolo.Core.Logs;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fabricantes
{
    public class FabricanteService: IServiceBase<FabricanteDTA, ulong>
    {
        public bool Delete(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    unit.FabricantesRepository.Delete(id);
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

        public int GetTotal()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.FabricantesRepository.Count();
            }
        }

        public IEnumerable<FabricanteDTA> Get()
        {
            using(var unit = new UnitOfWork())
            {
                return unit.FabricantesRepository.Get();
            }
        }

        public FabricanteDTA GetByID(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.FabricantesRepository.GetByID(id);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;
        }

        public (bool, FabricanteDTA) Save(FabricanteDTA fabricante)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.FabricantesRepository;

                    if (fabricante.Id == 0)
                        repository.Insert(fabricante);
                    else
                        repository.Update(fabricante);

                    unit.Save();
                }

                return (true, fabricante);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return (false, fabricante);
        }
    }
}