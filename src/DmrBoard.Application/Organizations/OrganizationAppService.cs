using AutoMapper;
using DmrBoard.Application.Base;
using DmrBoard.Application.Organizations.Dto;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

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


    }
    public interface IOrganizationAppService
    {
        IEnumerable<OrganizationDto> GetAll();
    }

}
