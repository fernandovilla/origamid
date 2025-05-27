using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Agendabolo.Core.Ingredientes
{
    public enum TipoEmbalagemEnum
    {
        Compra,
        Consumo
    }

    [Dapper.Contrib.Extensions.Table("embalagensingredientes")]
    public partial class IngredienteEmbalagemDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("idingrediente")]
        public int IdIngrediente { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
        
        [Column("preco")]
        public decimal Preco { get; set; }

        [Column("ean")]
        public string EAN { get; set; }

        [Column("idunidademedida")]
        public int IdUnidadeMedida { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }

        [Column("tipoembalagem")]
        public TipoEmbalagemEnum TipoEmbalagem { get; set; }        
    }

    partial class IngredienteEmbalagemDTA : IEqualityComparer<IngredienteEmbalagemDTA>
    {
        [JsonIgnore]
        public IngredienteDTA Ingredente { get; set; }

        public override bool Equals(object obj)
        {
            var rec = obj as IngredienteEmbalagemDTA;

            if (rec == null)
                return false;

            return this.Id == rec.Id;
        }

        public bool Equals(IngredienteEmbalagemDTA x, IngredienteEmbalagemDTA y)
        {
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] IngredienteEmbalagemDTA obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;

            return obj.Id.GetHashCode();
        }
    }
}
