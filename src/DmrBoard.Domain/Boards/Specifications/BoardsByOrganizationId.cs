using DmrBoard.Core.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DmrBoard.Domain.Boards.Specifications
{
    public class BoardsByOrganizationId : BaseSpecification<Board>
    {
        public BoardsByOrganizationId(Guid organizationId) : base(k => k.OrganizationId == organizationId)
        {

        }
    }
}
