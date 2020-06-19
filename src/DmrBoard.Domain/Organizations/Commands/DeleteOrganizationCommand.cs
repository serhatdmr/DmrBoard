using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Domain.Organizations
{
    public class DeleteOrganizationCommand : OrganizationCommand
    {
        public DeleteOrganizationCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
