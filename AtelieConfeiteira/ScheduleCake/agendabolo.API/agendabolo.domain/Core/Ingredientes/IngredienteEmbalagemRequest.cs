using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Ingredientes
{    
    public class IngredienteEmbalagemRequest : IngredienteEmbalagemDTA, IValidatableObject, IParsableEntity<IngredienteEmbalagemRequest, IngredienteEmbalagemDTA>
    {
        public static IngredienteEmbalagemRequest Parse(IngredienteEmbalagemDTA entity)
        {
            return new IngredienteEmbalagemRequest
            {
                Id = entity.Id,
                IdIngrediente = entity.IdIngrediente,
                Descricao = entity.Descricao,
                EAN = entity.EAN,
                IdUnidadeMedida = entity.IdUnidadeMedida,
                Quantidade = entity.Quantidade,
                TipoEmbalagem = entity.TipoEmbalagem
            };
        }

        public static IngredienteEmbalagemDTA ToDTA(IngredienteEmbalagemRequest entity)
        {
            return new IngredienteEmbalagemDTA
            {
                Id = entity.Id,
                IdIngrediente = entity.IdIngrediente,
                Descricao = entity.Descricao,
                EAN = entity.EAN,
                IdUnidadeMedida = entity.IdUnidadeMedida,
                Quantidade = entity.Quantidade,
                TipoEmbalagem = entity.TipoEmbalagem
            };
        }

        IngredienteEmbalagemRequest IParsableEntity<IngredienteEmbalagemRequest, IngredienteEmbalagemDTA>.Parse(IngredienteEmbalagemDTA entity)
        {
            return IngredienteEmbalagemRequest.Parse(entity);
        }

        IngredienteEmbalagemDTA IParsableEntity<IngredienteEmbalagemRequest, IngredienteEmbalagemDTA>.ToDTA(Agendabolo.Core.Ingredientes.IngredienteEmbalagemRequest entity)
        {
            return IngredienteEmbalagemRequest.ToDTA(entity);
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.IdIngrediente == 0)
                results.Add(new ValidationResult("ID Ingrediente é inválido", new string[] { nameof(IngredienteEmbalagemRequest.Id) }));

            if (this.IdUnidadeMedida == 0)
                results.Add(new ValidationResult("ID Unidade Medida é inválido", new string[] { nameof(IngredienteEmbalagemRequest.Id) }));

            return results;
        }
    }
}
