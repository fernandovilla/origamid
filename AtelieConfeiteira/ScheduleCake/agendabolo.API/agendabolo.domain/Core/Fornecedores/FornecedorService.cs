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
                using (var unit = new UnitOfWork())
                {
                    unit.GetFornecedorRepository.Delete(id);
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

        public IEnumerable<FornecedorDTA> Get()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.GetFornecedorRepository.Get().ToList();
            }
        }

        public FornecedorDTA Get(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    return unit.GetFornecedorRepository.Get(id);
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
            using (var unit = new UnitOfWork())
            {
                return unit.GetFornecedorRepository.Count();
            }
        }

        public (bool, FornecedorDTA) Save(FornecedorDTA fornecedor)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var repository = unit.GetFornecedorRepository;

                    if (fornecedor.Id == 0)
                        repository.Insert(fornecedor);
                    else
                        repository.Update(fornecedor);

                    unit.SaveChanges();
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
