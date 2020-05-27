using AutoMapper;
using DmrBoard.Application.Base;
using DmrBoard.Application.Organizations.Dto;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Notifications;
using DmrBoard.Core.Organizations;
using DmrBoard.Domain.Organizations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DmrBoard.Application.Organizations
{
    public class OrganizationAppService : ApplicationServiceBase, IOrganizationAppService
    {
        private readonly IRepository<Organization, Guid> _organizationRepo;

        public OrganizationAppService(IMediatorHandler mediator, IMapper mapper, IUserSession userSession,
            IRepository<Organization, Guid> organizationRepo) : base(mediator, mapper, userSession)
        {
            _organizationRepo = organizationRepo;
        }


        public IEnumerable<OrganizationDto> GetAll()
        {
            var list = _organizationRepo.GetAll();
            return Mapper.Map<IEnumerable<OrganizationDto>>(list);

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
