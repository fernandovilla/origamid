﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace Agendabolo.Core.Pessoas
{
    public enum TipoPessoaEnum
    {
        PessoaFisica = 1,
        PessoaJuridica= 2,
    }

    public enum GeneroPessoaEnum
    {
        NaoInformado = 0,
        Masculino = 1,
        Feminino = 2
    }

    [Table("pessoas")]
    public partial class PessoaDTA
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("status")]
        public StatusCadastroEnum Status { get; set; } = StatusCadastroEnum.Normal;

        [Column("tipopessoa")]
        public TipoPessoaEnum TipoPessoa { get; set; }

        [Column("datacadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        [Column("telefone")]
        public string  Telefone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("cep")]
        public string CEP { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("cidadeibge")]
        public int CidadeIBGE { get; set; }

        [Column("iduf")]
        public int IdUF { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("referencia")]
        public string Referencia { get; set; }

        [Column("observacoes")]
        public string Observacoes { get; set; }
    }

    /// <summary>
    /// Campos referentes à Pessoa Física
    /// </summary>
    partial class PessoaDTA
    {

        [Column("rg")]
        public string RG { get; set; }

        [Column("rgemissor")]
        public string RGEmissor { get; set; }

        [Column("rguf")]
        public string RGUF { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }

        [Column("genero")]
        public GeneroPessoaEnum Genero { get; set; }
    }

    /// <summary>
    /// Canpos referentes à Pessoa Jurídica
    /// </summary>
    partial class PessoaDTA 
    {
        [Column("razaosocial")]
        public string RazaoSocial { get; set; }

        [Column("contato")]
        public string Contato { get; set; }

        [Column("cnpj")]
        public string CNPJ { get; set; }

        [Column("ie")]
        public string IE { get; set; }
    }

    

}
