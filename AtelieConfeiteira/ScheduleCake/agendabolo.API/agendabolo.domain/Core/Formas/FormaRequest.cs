using Agendabolo.Core.Clientes;
using Agendabolo.Core.Ingredientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Formas
{
    public partial class FormaRequest : FormaDTA, IValidatableObject
    {
        
    }

    partial class FormaRequest
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Descricao))
                results.Add(new ValidationResult("Invalid 'descrição'", new string[] { nameof(FormaDTA.Descricao) }));

            return results;
        }
    }
}
