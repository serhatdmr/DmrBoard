using System;

namespace DmrBoard.Core.Domain.Entities
{
    public interface IAuditedEntity
    {
        int? CreatorUserId { get; set; }
        DateTime? CreationTime { get; set; }

        DateTime? LastModificationTime { get; set; }
        int? LastModifierUserId { get; set; }
    }

}
