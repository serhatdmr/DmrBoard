using System;

namespace DmrBoard.Core.Domain.Entities
{
    public interface IHasDeletionAudited
    {
        DateTime? DeletionTime { get; set; }
        public int? DeleterUserId { get; set; }

    }

}
