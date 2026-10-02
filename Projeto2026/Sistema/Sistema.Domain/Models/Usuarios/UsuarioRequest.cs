using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Domain.Models.Usuarios
{
    public class UsuarioRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
