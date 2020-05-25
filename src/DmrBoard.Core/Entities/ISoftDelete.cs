namespace DmrBoard.Core.Domain.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }

}
