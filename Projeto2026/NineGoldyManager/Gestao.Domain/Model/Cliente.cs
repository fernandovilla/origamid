using Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model
{
    public class Cliente : IStatusManager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        


        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
