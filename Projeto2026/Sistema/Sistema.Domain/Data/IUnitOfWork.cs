using Sistema.Domain.Models.Empresas;
using Sistema.Domain.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Domain.Data
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IEmpresaRepository EmpresaRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
