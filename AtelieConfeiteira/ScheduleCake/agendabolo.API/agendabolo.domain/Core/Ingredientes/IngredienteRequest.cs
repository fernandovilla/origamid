using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteRequest : IngredienteDTA, IValidatableObject, IParsableEntity<IngredienteRequest, IngredienteDTA>
    {
        public static IngredienteRequest Parse(IngredienteDTA entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new IngredienteRequest()
            {
                Id = entity.Id,
                IdUnidadeMedida = entity.IdUnidadeMedida,
                Nome = entity.Nome,
                PrecoCusto = entity.PrecoCusto,
                PrecoCustoMedio = entity.PrecoCustoMedio,
                QuantidadeEmbalagem = entity.QuantidadeEmbalagem,
                Status = entity.Status
            };
        }

        public static IngredienteDTA ToDTA(IngredienteRequest entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            return new IngredienteDTA()
            {
                Id = entity.Id,
                IdUnidadeMedida = entity.IdUnidadeMedida,
                Nome = entity.Nome,
                PrecoCusto = entity.PrecoCusto,
                PrecoCustoMedio = entity.PrecoCustoMedio,
                QuantidadeEmbalagem = entity.QuantidadeEmbalagem,
                Status = entity.Status
            };
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
