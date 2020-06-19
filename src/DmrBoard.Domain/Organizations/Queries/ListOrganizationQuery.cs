using DmrBoard.Core.Organizations;
using MediatR;
using System.Collections.Generic;

namespace DmrBoard.Domain.Organizations.Queries
{
    public class ListOrganizationQuery : IRequest<IEnumerable<Organization>>
    {
    }
}
