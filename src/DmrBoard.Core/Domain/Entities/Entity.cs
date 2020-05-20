using System;

namespace DmrBoard.Core.Domain.Entities
{
    [Serializable]
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
         
        public override string ToString()
        {
            return $"[{GetType().Name} {Id}]";
        }
    }
}
