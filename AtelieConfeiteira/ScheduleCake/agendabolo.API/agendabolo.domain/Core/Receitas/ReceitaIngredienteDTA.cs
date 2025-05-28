using Agendabolo.Core.Ingredientes;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using dapper = Dapper.Contrib.Extensions;

namespace Agendabolo.Core.Receitas
{
    [dapper.Table("receitasingredientes")]
    public partial class ReceitaIngredienteDTA
    {                
        [dapper.Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("idreceita")]
        public int IdReceita { get; set; }        

        [Column("idingrediente")]
        public int IdIngrediente { get; set; }        

        [Column("percentual")]
        public double Percentual { get; set; } = 0f;

        [Column("ordem")]
        public int Ordem { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; } =  StatusCadastro.Normal;
    }


    [DebuggerDisplay("{Id} | {Nome} | {Status}")]
    partial class ReceitaIngredienteDTA
    {
        public ReceitaIngredienteDTA()
        { }

        public ReceitaIngredienteDTA(ReceitaDTA receita, IngredienteDTA ingrediente)
            : this()
        {
            this.Receita = receita;
            this.Ingrediente = ingrediente;
        }

        [Computed]
        public ReceitaDTA Receita { get; set; }

        [Computed]
        public IngredienteDTA Ingrediente { get; set; }

        [Computed]
        public string Nome => Ingrediente?.Nome;
    }

    public class ReceitaIngredienteComparer : IEqualityComparer<ReceitaIngredienteDTA>
    {
        public bool Equals(ReceitaIngredienteDTA x, ReceitaIngredienteDTA y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] ReceitaIngredienteDTA obj)
        {
            if (Object.ReferenceEquals(obj, null)) 
                return 0;
            
            return obj.Id == 0 ? 0 : obj.Id.GetHashCode();            
        }
    }
}
