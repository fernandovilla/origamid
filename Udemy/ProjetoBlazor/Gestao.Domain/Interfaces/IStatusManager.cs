using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Interfaces
{
    public enum StatusEnum
    {
        Normal = 0,
        Locked = 1,
        Deleted = 2,
    }

    public interface IStatusManager
    {
        StatusEnum Status { get; set; } 
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
        DateTimeOffset? DeletedAt { get; set; }        
    }
}
