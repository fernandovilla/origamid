﻿using Agendabolo.Core.Receitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Produtos
{
    [Table("produtos")]
    [DebuggerDisplay("{Id} | {Nome} | {Status}")]
    public class ProdutoDTA
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("status")]
        public StatusCadastro Status { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("observacoes")]
        public string Observacoes { get; set; }

        [Column("finalizacao")]
        public string Finalizacao { get; set; }

        [Column("pesoreferencia")]
        public int PesoReferencia { get; set; }

        [Column("tempopreparo")]
        public int TempoPreparo { get; set; }

        [Column("margempreparo")]
        public double MargemPreparo { get; set; }

        [Column("customaodeobra")]
        public decimal CustoMaoDeObra { get; set; }

        [Column("custoembalagem")]
        public decimal CustoEmbalagem { get; set; }

        [Column("margemvendavarejo")]
        public double MargemVendaVarejo { get; set; }

        [Column("precovendavarejo")]
        public decimal PrecoVendaVarejo { get; set; }

        [Column("margemvendaatacado")]
        public double MargemVendaAtacado { get; set; }

        [Column("precovendaatacado")]
        public decimal PrecoVendaAtacado { get; set; }

        public IList<ProdutoReceitaDTA> Receitas { get; set; }
    }
}
