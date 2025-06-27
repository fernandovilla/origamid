using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaRequest : IValidatableObject
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public int PesoReferencia { get; set; }
        public double TempoPreparo { get; set; }
        public string Preparo { get; set; }
        public string Observacao { get; set; }
        public IEnumerable<ReceitaIngredienteRequest> Ingredientes { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(this.Nome) }));

            if (!Enum.TryParse(typeof(StatusCadastroEnum), Status.ToString(), out object outStatus))
                results.Add(new ValidationResult("Invalid Status", new string[] { nameof(this.Status) }));

            return results;
        }

        public static ReceitaRequest Parse(ReceitaDTA receita)
        {
            if (receita == null)
                return null;

            IEnumerable<ReceitaIngredienteRequest> getItens(IEnumerable<ReceitaIngredienteDTA> ingredientes)
            {
                if (ingredientes != null && ingredientes.Any())
                {
                    foreach (var item in ingredientes)
                    {
                        yield return new ReceitaIngredienteRequest
                        {
                            Id = (int)item.Id,
                            IdIngrediente = (int)item.IdIngrediente,
                            Nome = item.Nome,
                            Percentual = item.Percentual,                            
                            Ordem = item.Ordem,
                            Status = (int)item.Status,
                            PrecoCustoQuilo = item.Ingrediente != null ? item.Ingrediente.PrecoCustoQuilo : 0,
                            PrecoCustoMedioQuilo = item.Ingrediente != null ? item.Ingrediente.PrecoCustoMedio : 0
                        };
                    }
                }
            };

            var receitaRequest = new ReceitaRequest
            {
                Id = (int)receita.Id,
                Nome = receita.Nome,
                Descricao = receita.Descricao,
                Preparo = receita.Preparo,
                Status = (int)receita.Status,
                PesoReferencia =(int)Math.Round(receita.PesoReferencia,0),
                Observacao = receita.Observacao,
                TempoPreparo = receita.TempoPreparo,
                Ingredientes = getItens(receita.Ingredientes)
            };

            return receitaRequest;

        }
    }
}
