using DmrBoard.Core.Domain.Specifications;
using DmrBoard.Core.Organizations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DmrBoard.Domain.Organizations.Specifications
{
    public class OrganizationBoards : BaseSpecification<Organization>
    {
        public OrganizationBoards(Guid organizationId) : base(k => k.Id == organizationId)
        {
            AddInclude(k => k.Boards);
        }
    }
}
