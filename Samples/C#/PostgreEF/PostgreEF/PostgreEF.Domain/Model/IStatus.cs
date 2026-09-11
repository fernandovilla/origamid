using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreEF.Domain.Model
{
    public enum StatusEnum
    {
        Normal = 0,
        Bloqueado = 1,
        Excluido = 2
    }

    public interface IStatus
    {
        StatusEnum Status { get; set; }
        DateTimeOffset CreatedAt {  get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
        DateTimeOffset? DeletedAt { get; set; }
    }
}
