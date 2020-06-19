using AutoMapper;
using DmrBoard.Application.Base;
using DmrBoard.Application.Common.Dto;
using DmrBoard.Application.Organizations.Dto;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Notifications;
using DmrBoard.Core.Organizations;
using DmrBoard.Domain.Organizations;
using DmrBoard.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmrBoard.Application.Organizations
{
    public class OrganizationAppService : ApplicationServiceBase, IOrganizationAppService
    {
        private readonly IRepository<Organization, Guid> _organizationRepo;

        public OrganizationAppService(IMediatorHandler mediator, IMapper mapper, ICurrentUserService userSession,
            IRepository<Organization, Guid> organizationRepo) : base(mediator, mapper, userSession)
        {
            _organizationRepo = organizationRepo;
        }


        public PagedResultDto<OrganizationDto> GetAll(GetAllInput input)
        {
            var query = _organizationRepo.GetAll()
                .WhereIf(!String.IsNullOrEmpty(input.FilterName),
                k => k.Name.ToLower().Contains(input.FilterName.ToLower()));

            var totalCount = query.Count();
            query = query.Paging(input);

            var result = Mapper.Map<IReadOnlyList<OrganizationDto>>(query.ToList());
            return new PagedResultDto<OrganizationDto>(result, totalCount);
        }

        public OrganizationDto GetById(Guid organizationId)
        {
            var organization = _organizationRepo.GetById(organizationId);
            return Mapper.Map<OrganizationDto>(organization);
        }

        public async Task Create(OrganizationDto dto)
        {
            await Mediator.SendCommand(new CreateOrganizationCommand(dto.Name));
        }

        public async Task Delete(Guid id)
        {
            await Mediator.SendCommand(new DeleteOrganizationCommand(id));
        }

    }

}
