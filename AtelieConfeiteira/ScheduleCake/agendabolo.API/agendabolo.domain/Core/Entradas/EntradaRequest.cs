using Agendabolo.Core.Historicos;
using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Entradas
{
    public partial class EntradaRequest
    {
        public int IdFornecedor { get; set; }
        public long NumeroNF { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }
        public double Frete { get; set; }
        public bool DistribuiuFreteNosItens { get; set; }
        public IEnumerable<ItemEntradaRequest> Itens { get; set; }
    }

    public partial class EntradaRequest : IValidatableObject, IParsableEntity<EntradaRequest, EntradaDTA>
    {
        public EntradaRequest Parse(EntradaDTA entity)
        {
            throw new NotImplementedException();
        }

        public static EntradaDTA ToDTA(EntradaRequest entrada)
        {
            var entradaDta = new EntradaDTA();
            entradaDta.NumeroNF = entrada.NumeroNF;
            entradaDta.DataEntrada = entrada.DataEntrada;
            entradaDta.DataEmissao = entrada.DataEmissao;
            entradaDta.IdFornecedor = entrada.IdFornecedor;
            entradaDta.DistribuiuFreteNosItens = entrada.DistribuiuFreteNosItens;

            entradaDta.Itens = entrada.Itens.Select(i => new ItemEntradaDTA
            {
                IdIngrediente = i.IdIngrediente,
                Quantidade = i.Quantidade,
                EstoqueAntes = i.EstoqueAntes,
                PrecoCustoQuiloBruto = i.PrecoCustoQuiloBruto,
                PrecoCustoQuiloLiquido = i.PrecoCustoQuiloLiquido,
                Frete = i.Frete,
                Desconto = i.Desconto,
                Lotes = new List<ItemEntradaLoteDTA> { new ItemEntradaLoteDTA { Lote = i.Lote, DataFabricacao = i.DataFabricacao, DataValidade = i.DataValidade } },    
            });

            return entradaDta;
        }

        EntradaDTA IParsableEntity<EntradaRequest, EntradaDTA>.ToDTA(Agendabolo.Core.Entradas.EntradaRequest entity) => ToDTA(entity);

        EntradaRequest IParsableEntity<EntradaRequest, EntradaDTA>.Parse(EntradaDTA entradaDta) => null;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (NumeroNF == 0)
                results.Add(new ValidationResult("Invalid NF number", new string[] { nameof(EntradaDTA.NumeroNF) }));


            return results;
        }
    }
}
