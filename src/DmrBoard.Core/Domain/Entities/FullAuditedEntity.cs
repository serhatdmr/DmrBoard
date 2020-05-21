using System;

namespace DmrBoard.Core.Domain.Entities
{
    public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, IHasDeletionAudited, ISoftDelete
    {
        public DateTime? DeletionTime { get; set; }
        public int? DeleterUserId { get; set; }
        public bool IsDeleted { get; set; }
    }

}
