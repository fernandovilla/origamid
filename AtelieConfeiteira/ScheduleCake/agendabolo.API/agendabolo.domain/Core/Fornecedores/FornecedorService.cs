using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fornecedores
{
    public class FornecedorService : IServiceBase<FornecedorDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    unit.FornecedorRepository.Delete(id);
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

        public IEnumerable<FornecedorDTA> Get()
        {
            using (var unit = new UnitOfWorkDbContext())
            {
                return unit.FornecedorRepository.Get().ToList();
            }
        }

        public FornecedorDTA GetByID(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    return unit.FornecedorRepository.GetByID(id);
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
                return unit.FornecedorRepository.Count();
            }
        }

        public (bool, FornecedorDTA) Save(FornecedorDTA fornecedor)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    var repository = unit.FornecedorRepository;

                    if (fornecedor.Id == 0)
                        repository.Insert(fornecedor);
                    else
                        repository.Update(fornecedor);

                    unit.Save();
                }

                return (true, fornecedor);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, fornecedor);
        }
    }
}
