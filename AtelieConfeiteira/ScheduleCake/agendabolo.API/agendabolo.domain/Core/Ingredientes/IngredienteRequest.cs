﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agendabolo.Core.Ingredientes
{
    public partial class IngredienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public decimal PrecoCustoQuilo { get; set; }
        public decimal PrecoCustoMedio { get; set; }
        public DateTime DataUltimoPrecoCusto { get; set; }
        public int Status { get; set; }
        public int Tipo { get; set; }
        public double EstoqueTotal { get; set; }
        public IEnumerable<IngredienteEmbalagemRequest> Embalagens { get; set; }
    }

    partial class IngredienteRequest : IValidatableObject, IParsableEntity<IngredienteRequest, IngredienteDTA>
    {
        public static IngredienteRequest Parse(IngredienteDTA ingrediente)
        {
            if (ingrediente == null)
                throw new ArgumentNullException(nameof(ingrediente));

            return new IngredienteRequest()
            {
                Id = ingrediente.Id,
                Nome = ingrediente.Nome,
                Marca = ingrediente.Marca,
                PrecoCustoQuilo = ingrediente.PrecoCustoQuilo,
                PrecoCustoMedio = ingrediente.PrecoCustoMedio,
                DataUltimoPrecoCusto = ingrediente.DataUltimoPrecoCusto,
                Status = (int)ingrediente.Status,
                Tipo = (int)ingrediente.Tipo
                //EstoqueTotal = ingrediente.Estoque != null ? ingrediente.Estoque.Sum(i => i.Quantidade) : 0,
                //Embalagens = ingrediente?.Embalagens.Select(i => IngredienteEmbalagemRequest.Parse(i)).ToList()
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
                Marca = entity.Marca,
                PrecoCustoQuilo = entity.PrecoCustoQuilo,
                PrecoCustoMedio = entity.PrecoCustoMedio,
                DataUltimoPrecoCusto = entity.DataUltimoPrecoCusto,
                Status = (StatusCadastroEnum)entity.Status,
                Tipo = (TipoIngrediente)entity.Tipo,
                Embalagens = entity.Embalagens?.Select(i => IngredienteEmbalagemRequest.ToDTA(i)).ToList()
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
