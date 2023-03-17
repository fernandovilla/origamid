using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{
    public class IngredienteRequest : IngredienteDTA, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(IngredienteDTA.Nome) }));

            return results;
        }
    }
}
