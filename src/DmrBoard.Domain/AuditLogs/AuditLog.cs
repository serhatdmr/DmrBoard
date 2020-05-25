using DmrBoard.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Core.AuditLogs
{
    public class AuditLog : Entity<long>
    {
        public virtual string Request { get; set; }
        public virtual string Response { get; set; }
        public virtual DateTime ExecutionTime { get; set; }
        public virtual int ExecutionDuration { get; set; }
        public int? UserId { get; set; }
    }
}
