using Agendabolo.Core.Pessoas;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agendabolo.Core.Clientes
{
    public partial class ClienteRequest : PessoaDTA, IValidatableObject
    {
    }

    partial class ClienteRequest
    {        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(ClienteRequest.Nome) }));

            return results;
        }
    }
}
