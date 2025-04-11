using Agendabolo.Core.Fabricantes;
using Agendabolo.Core.LogDeErros;
using Agendabolo.Core.Receitas;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Agendabolo.Core.Produtos
{
    public class ProdutoService : IServiceBase<ProdutoDTA, int>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                {
                    unit.ProdutoRepository.Delete(id);
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

        public IEnumerable<ProdutoDTA> Get()
        {
            using (var unit = new UnitOfWorkDbContext())
                return unit.ProdutoRepository.Get().ToList();
        }

        public ProdutoDTA GetByID(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                    return unit.ProdutoRepository.GetByID(id); ;
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return null;
        }

        public ProdutoDTA GetByID_Min(int id)
        {
            try
            {
                using (var unit = new UnitOfWorkDbContext())
                    return unit.ProdutoRepository.GetByID_Min(id); ;
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
                return unit.ProdutoRepository.Count();
        }

        public (bool, ProdutoDTA) Save(ProdutoDTA produto)
        {
            try
            {
                using(var unit = new UnitOfWorkDbContext())
                {
                    var repository = unit.ProdutoRepository;

                    if (produto.Id == 0)
                    {
                        repository.Insert(produto);
                    } else
                    {
                        repository.Update(produto);
                    }

                    unit.SaveChanges();
                }

                return (true, produto);
            }
            catch (Exception ex)
            {
                LogDeErros.LogDeErro.Default.Write(ex);
            }

            return (false, produto);
        }
    }
}
