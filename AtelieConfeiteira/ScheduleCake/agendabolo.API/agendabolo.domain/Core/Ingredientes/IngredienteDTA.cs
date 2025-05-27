using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Agendabolo.Core.Ingredientes
{
    [Dapper.Contrib.Extensions.Table("ingredientes")]
    public class IngredienteDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nome")]
        public string Nome { get; set; }

        [Column("marca")]
        public string Marca { get; internal set; }

        [Column("precocustoquilo")]
        public decimal PrecoCustoQuilo { get; set; }

        [Column("precocustomedio")]
        public decimal PrecoCustoMedio { get; set; }
        
        [Column("status")]
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;

        [Column("dataultimoprecocusto")]
        public DateTime DataUltimoPrecoCusto { get; set; }

        [Column("tipo")]
        public TipoIngrediente Tipo { get; set; }

        [Computed]
        public double EstoqueTotal => Estoque != null ? Estoque.Sum(i => i.Quantidade) : 0;


        [JsonIgnore]
        [Computed]
        public ICollection<Receitas.ReceitaIngredienteDTA> Receitas { get; set; }

        [Computed]
        public IEnumerable<IngredienteEmbalagemDTA> Embalagens { get; set; }

        [Computed]
        public ICollection<IngredienteEstoqueDTA> Estoque { get; set; }
        
    }
}
