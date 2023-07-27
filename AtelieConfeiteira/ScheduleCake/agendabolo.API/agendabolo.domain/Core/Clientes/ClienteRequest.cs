using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agendabolo.Core.Ingredientes;

namespace Agendabolo.Core.Clientes
{
    public partial class ClienteRequest : ClienteDTA, IValidatableObject
    {
        public new int Status { get; set; }
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Nome))
                results.Add(new ValidationResult("Invalid name", new string[] { nameof(ClienteDTA.Nome) }));

            return results;
        }
    }
}
