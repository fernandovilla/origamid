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
                using (var unit = new UnitOfWork())
                {
                    unit.GetProdutoRepository.Delete(id);
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
            using (var unit = new UnitOfWork())
            {
                return unit.GetProdutoRepository.Get().ToList();
            }
        }

        public ProdutoDTA Get(int id)
        {
            try
            {
                using (var unit = new UnitOfWork())
                {
                    var produto = unit.GetProdutoRepository.Get(id);

                    var receitaRepository = unit.GetReceitaRepository;
                    var ingredienteRepository = unit.GetIngredienteRepository;

                    if (produto.Tipo == TipoProduto.Produzido)
                    {

                        foreach (var receita in produto.Receitas)
                        {
                            receita.Receita = receitaRepository.Get(receita.IdReceita);

                            foreach (var ingrediente in receita.Receita.Ingredientes)
                                ingrediente.Ingrediente = ingredienteRepository.Get(ingrediente.IdIngrediente);
                        }
                    }
                   
                    return produto;
                }
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
                using (var unit = new UnitOfWork())
                    return unit.GetProdutoRepository.GetByID_Min(id); ;
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
                return unit.GetProdutoRepository.Count();
        }

        public (bool, ProdutoDTA) Save(ProdutoDTA produto)
        {
            try
            {
                using(var unit = new UnitOfWork())
                {
                    var repository = unit.GetProdutoRepository;

                    if (produto.Id == 0)                    
                        this.InsertProduto(unit, produto);
                    else
                        this.UpdateProduto(unit, produto);
                    
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

        private void InsertProduto(IUnitOfWork unit, ProdutoDTA produto)
        {
            unit.GetProdutoRepository.Insert(produto);
        }

        private void UpdateProduto(IUnitOfWork unit, ProdutoDTA produto) 
        {
            unit.GetProdutoRepository.Update(produto);
        }
    }
}
