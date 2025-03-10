using Agendabolo.Core.Ingredientes;
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
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }    
        public int Status { get; set; }
    }

    public partial class FornecedorRequest : IValidatableObject, IParsableEntity<FornecedorRequest, FornecedorDTA>
    {
        public static FornecedorRequest Parse(FornecedorDTA entity)
        {
            return new FornecedorRequest
            {
                Id = entity.Id,
                Nome = entity.Nome,
                CNPJ = entity.CNPJ,
                Contato = entity.Contato,
                Telefone = entity.Telefone, 
                Status = (int)entity.Status
            };
        }

        public static FornecedorDTA ToDTA(FornecedorRequest entity)
        {
            return new FornecedorDTA
            {
                Id = entity.Id,
                Nome = entity.Nome,
                CNPJ = entity.CNPJ,
                Contato = entity.Contato,   
                Telefone = entity.Telefone, 
                Status = (StatusCadastro)entity.Status
            };
        }

        FornecedorRequest IParsableEntity<FornecedorRequest, FornecedorDTA>.Parse(Agendabolo.Core.Fornecedores.FornecedorDTA entity)
        {
            return FornecedorRequest.Parse(entity);
        }

        FornecedorDTA IParsableEntity<FornecedorRequest, FornecedorDTA>.ToDTA(Agendabolo.Core.Fornecedores.FornecedorRequest entity)
        {
            return FornecedorRequest.ToDTA(entity);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(FornecedorDTA.Nome) }));

            return results;
        }
    }
}
