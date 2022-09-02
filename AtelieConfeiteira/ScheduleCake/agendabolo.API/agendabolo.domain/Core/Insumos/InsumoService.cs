using Agendabolo.Core.Logs;
using Agendabolo.Data;
using System;
using System.Collections.Generic;

namespace Agendabolo.Core.Insumos
{
    public class InsumoService
    {
        private readonly ApplicationDbContext _context;

        public InsumoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetTotal()
        {
            using (var unit = new UnitOfWork(_context))
            {
                return unit.InsumosRepository.Count();
            }
        }

        public IEnumerable<Insumo> Get()
        {
            using (var unit = new UnitOfWork(_context))
            {
                return unit.InsumosRepository.Get();
            }
        }
        
        public Insumo GetById(ulong id) 
        {
            try
            {
                using (var unit = new UnitOfWork(_context))
                {
                    return unit.InsumosRepository.GetByID(id);
                }
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return null;        
        }

        public (bool, Insumo) Save(Insumo insumo)
        {
            try
            {
                using (var unit = new UnitOfWork(_context))
                {
                    var repository = unit.InsumosRepository;

                    if (insumo.Id == 0)
                        repository.Insert(insumo);
                    else
                        repository.Update(insumo);

                    unit.Save();
                }

                return (true, insumo);
            }
            catch (Exception ex)
            {
                LogDeErros.Default.Write(ex);
            }

            return (false, insumo);
        }

        public bool Delete(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork(_context))
                {
                    unit.InsumosRepository.Delete(id);
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
