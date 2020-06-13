namespace DmrBoard.Core.Interfaces
{
    public interface IPagedResultRequest
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
