using DmrBoard.Core.Interfaces;

namespace DmrBoard.Core.Entities
{
    public class PaginationFilter : IPagedResultRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
