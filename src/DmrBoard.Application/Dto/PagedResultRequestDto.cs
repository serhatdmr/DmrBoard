using DmrBoard.Core.Interfaces;

namespace DmrBoard.Application.Dto
{
    public class PagedResultRequestDto : IPagedResultRequest
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}
