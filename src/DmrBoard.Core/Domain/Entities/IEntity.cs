namespace DmrBoard.Core.Domain.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
