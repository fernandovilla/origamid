using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.Clientes
{
    public partial class ClienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Observacoes { get; set; }
        public int Status { get; set; }
    }

    partial class ClienteRequest
    {
        public static ClienteDTA ParseToDTA(ClienteRequest clienteRequest)
        {
            return new ClienteDTA()
            {
                Id = clienteRequest.Id,
                Nome = clienteRequest.Nome,
                Telefone = clienteRequest.Telefone,
                Celular = clienteRequest.Celular,
                Instagram = clienteRequest.Instagram,
                Facebook = clienteRequest.Facebook,
                Observacoes = clienteRequest.Observacoes,
                Status = (StatusCadastro)clienteRequest.Status
            };
        }

        public static ClienteRequest ParseFromDTA(ClienteDTA clienteDTA)
        {
            return new ClienteRequest()
            {
                Id = clienteDTA.Id,
                Nome = clienteDTA.Nome,
                Celular = clienteDTA.Celular,
                Telefone = clienteDTA.Telefone,
                Instagram = clienteDTA.Instagram,
                Facebook = clienteDTA.Facebook,
                Observacoes = clienteDTA.Observacoes,
                Status = (int)clienteDTA.Status
            };
        }


    }
}
