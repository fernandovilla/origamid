using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agendabolo.Core.Receitas
{
    public class ReceitaRequest : IValidatableObject
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public int Rendimento { get; set; }
        public string Preparo { get; set; }
        public string Cozimento { get; set; }
        public IEnumerable<ReceitaIngredienteRequest> Ingredientes { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(this.Nome) }));

            if (!Enum.TryParse(typeof(StatusCadastro), Status.ToString(), out object outStatus))
                results.Add(new ValidationResult("Invalid Status", new string[] { nameof(this.Status) }));

            return results;
        }
    }
}
