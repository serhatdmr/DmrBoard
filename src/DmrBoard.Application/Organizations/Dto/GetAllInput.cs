using DmrBoard.Application.Dto;

namespace DmrBoard.Application.Organizations.Dto
{
    public class GetAllInput : PagedResultRequestDto
    {
        public string FilterName { get; set; }
    }
}
