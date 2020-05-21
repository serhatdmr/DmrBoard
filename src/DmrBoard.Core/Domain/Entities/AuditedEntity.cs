using System;

namespace DmrBoard.Core.Domain.Entities
{
    public abstract class AuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, IAuditedEntity
    {
        public int? CreatorUserId { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
    }

}
