using DmrBoard.Application.Organizations.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DmrBoard.Application.Organizations
{
    public interface IOrganizationAppService
    {
        IEnumerable<OrganizationDto> GetAll();
        Task Create(OrganizationDto dto);
        Task Delete(Guid id);
    }

}
