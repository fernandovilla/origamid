using Agendabolo.Core.Historicos;
using Agendabolo.Core.Ingredientes;
using Agendabolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Agendabolo.Core.Entradas
{
    public class EntradaService : IServiceBase<EntradaDTA, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntradaDTA> Get()
        {
            throw new NotImplementedException();
        }

        public EntradaDTA GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int GetTotal()
        {
            throw new NotImplementedException();
        }

        public (bool, EntradaDTA) Save(EntradaDTA entrada)
        {
            using (var unit = new UnitOfWorkDbContext())
            {
                var ingredientesRepository = unit.IngredienteRepository;
                var itensCache = new Dictionary<int, IngredienteDTA>();


                IngredienteDTA getIngrediente(int idIngrediente)
                {
                    IngredienteDTA ingrediente = null;
                    if (!itensCache.ContainsKey(idIngrediente))
                    {
                        ingrediente = ingredientesRepository.GetByID(idIngrediente);
                        itensCache.Add(idIngrediente, ingrediente);
                    }
                    else
                    {
                        ingrediente = itensCache[idIngrediente];
                    }

                    return ingrediente;
                }

                HistoricoEntradaItemDTA parseItemHistorico(ItemEntradaDTA item)
                {                    
                    return new HistoricoEntradaItemDTA
                    {
                        IngredienteId = item.IdIngrediente,
                        Quantidade = item.Quantidade,
                        PrecoCustoQuiloAntes = getIngrediente(item.IdIngrediente).PrecoCustoQuilo,
                        PrecoCustoQuiloBruto = item.PrecoCustoQuiloBruto,
                        PrecoCustoQuiloLiquido = item.PrecoCustoQuiloLiquido,
                        Lotes = item.Lotes.Select(l => new HistoricoEntradaItemLoteDTA { 
                            Lote = l.Lote, 
                            DataFabricacao = l.DataFabricacao, 
                            DataValidade = l.DataValidade 
                        })
                    };
                }



                // Inclusão do Histórico - OK
                // Inclusão de Itens Histórico - VERIFICAR COMO FAZER
                var historicoEntrada = new HistoricoEntradaDTA();
                historicoEntrada.Fornecedor = entrada.Fornecedor;
                historicoEntrada.NumeroNF = entrada.NumeroNF;
                historicoEntrada.DataEntrada = entrada.DataEntrada;
                historicoEntrada.DataEmissao = entrada.DataEmissao;
                historicoEntrada.ValorFrete = entrada.Frete;
                historicoEntrada.DistribuiuFreteNosItens = entrada.DistribuiuFreteNosItens;
                historicoEntrada.Itens = entrada.Itens.Select(i => parseItemHistorico(i));
                unit.HistoricoEntradaRepository.Insert(historicoEntrada);


                foreach (var item in entrada.Itens)
                {
                    // Inclusão do estoque e itens no histórico
                    foreach (var lote in item.Lotes)
                    {
                        var estoque = new IngredienteEstoqueDTA();
                        estoque.FornecedorId = entrada.IdFornecedor;
                        estoque.IngredienteId = item.IdIngrediente;
                        estoque.Quantidade = item.Quantidade;
                        estoque.Lote = lote.Lote;
                        estoque.DataFabricacao = lote.DataFabricacao;
                        estoque.DataValidade = lote.DataValidade;

                        unit.EstoqueRepository.Insert(estoque);
                    }

                    // Atualização de preço custo do ingrediente
                    var ingrediente = getIngrediente(item.IdIngrediente);
                    if (ingrediente.PrecoCustoQuilo != item.PrecoCustoQuiloLiquido)
                    {
                        var custoMedio = new decimal[] { ingrediente.PrecoCustoMedio, item.PrecoCustoQuiloLiquido };

                        ingrediente.PrecoCustoQuilo = item.PrecoCustoQuiloLiquido;
                        ingrediente.PrecoCustoMedio = custoMedio.Average();
                    }
                }

                unit.SaveChanges();
            }

            return (true, entrada);
        }
    }
}
