using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agendabolo.Core.Ingredientes
{
    public partial class IngredienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCustoMedio { get; set; }
        public int Status { get; set; }
        public double EstoqueTotal { get; set; }
        public IEnumerable<IngredienteEmbalagemRequest> Embalagens { get; set; }
    }

    partial class IngredienteRequest : IValidatableObject, IParsableEntity<IngredienteRequest, IngredienteDTA>
    {
        public static IngredienteRequest Parse(IngredienteDTA entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new IngredienteRequest()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                PrecoCustoMedio = entity.PrecoCustoMedio,
                Status = (int)entity.Status,
                EstoqueTotal = entity.Estoque.Sum(i => i.Quantidade),
                Embalagens = entity.Embalagens.Select(i => IngredienteEmbalagemRequest.Parse(i)).ToList()
            };
        }

        public static IngredienteDTA ToDTA(IngredienteRequest entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            return new IngredienteDTA()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                PrecoCustoMedio = entity.PrecoCustoMedio,
                Status = (StatusCadastro)entity.Status,
                Embalagens = entity.Embalagens.Select(i => IngredienteEmbalagemRequest.ToDTA(i)).ToList()
            };
        }

        IngredienteRequest IParsableEntity<IngredienteRequest, IngredienteDTA>.Parse(Agendabolo.Core.Ingredientes.IngredienteDTA entity) { 
            return IngredienteRequest.Parse(entity);
        }

        IngredienteDTA IParsableEntity<IngredienteRequest, IngredienteDTA>.ToDTA(Agendabolo.Core.Ingredientes.IngredienteRequest entity)
        {
            return IngredienteRequest.ToDTA(entity);
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(IngredienteDTA.Nome) }));

            return results;
        }

    }
}
