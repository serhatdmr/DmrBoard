using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Organizations;
using DmrBoard.Domain.Organizations.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DmrBoard.Domain.Organizations
{
    public class OrganizationQueryHandler : IRequestHandler<ListOrganizationQuery, IEnumerable<Organization>>
    {
        private readonly IRepository<Organization, Guid> _organizationRepository;

        public OrganizationQueryHandler(IRepository<Organization, Guid> organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<Organization>> Handle(ListOrganizationQuery request, CancellationToken cancellationToken)
        {
            var list = _organizationRepository.GetAll();
            return await Task.FromResult(list);
        }
    }
}
