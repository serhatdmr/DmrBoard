using DmrBoard.Core.Domain.Entities;
using DmrBoard.Domain.Boards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DmrBoard.Core.Organizations
{
    public class Organization : FullAuditedEntity<Guid>
    {
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Board> Boards { get; set; } 
    }
}
