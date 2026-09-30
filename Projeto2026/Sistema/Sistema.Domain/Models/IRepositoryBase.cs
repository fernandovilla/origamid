using Sistema.Domain.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Domain.Models
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
