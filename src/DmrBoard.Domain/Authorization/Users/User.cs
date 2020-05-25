using DmrBoard.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace DmrBoard.Core.Authorization.Users
{
    public class User : IdentityUser<int>, IAuditedEntity, IHasDeletionAudited, ISoftDelete
    {
        public virtual string FirstName { get; set; }
        public virtual string SurName { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual int? DeleterUserId { get; set; }
        public virtual int? CreatorUserId { get; set; }
        public virtual DateTime? CreationTime { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual int? LastModifierUserId { get; set; }
    }
}
