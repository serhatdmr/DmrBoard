using DmrBoard.Application.Common.Dto;
using DmrBoard.Application.Organizations.Dto;
using System;
using System.Threading.Tasks;

namespace DmrBoard.Application.Organizations
{
    public interface IOrganizationAppService
    {
        PagedResultDto<OrganizationDto> GetAll(GetAllInput input);
        OrganizationDto GetById(Guid organizationId);
        Task Create(OrganizationDto dto);
        Task Delete(Guid id);
    }

}
