using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Fornecedores
{
    public partial class FornecedorRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
    }

    partial class FornecedorRequest : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
