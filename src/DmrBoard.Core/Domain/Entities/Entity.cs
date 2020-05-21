using System.ComponentModel.DataAnnotations;

namespace DmrBoard.Core.Domain.Entities
{

    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [Key]
        public virtual TPrimaryKey Id { get; set; }

        public override string ToString()
        {
            return $"[{GetType().Name} {Id}]";
        }
    }

}
