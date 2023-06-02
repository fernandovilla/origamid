using Agendabolo.Core.Logs;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    public class ProdutoService : IServiceBase<ProdutoDTA, ulong>
    {
        public bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoDTA> Get()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.ProdutoRepository.Get();
            }
        }

        public ProdutoDTA GetByID(ulong id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var produto = unit.ProdutoRepository.GetByID(id);

                    if (produto.Receitas.Any())
                    {
                        var rec = unit.ReceitasRepository;
                        produto.Receitas.ForEach(r => r.Receita = rec.Get(i => i.Id == r.IdReceita).FirstOrDefault());                            
                    }

                    return produto;
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
            using (var unit = new UnitOfWork())
            {
                return unit.ProdutoRepository.Count();
            }
        }

        public (bool, ProdutoDTA) Save(ProdutoDTA entity)
        {
            throw new NotImplementedException();
        }
    }
}
