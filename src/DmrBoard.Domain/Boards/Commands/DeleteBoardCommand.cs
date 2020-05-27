using DmrBoard.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Domain.Boards.Commands
{
    public class DeleteBoardCommand : Command
    {

        public Guid OrganizationId { get; set; }
        public DeleteBoardCommand(Guid organizationId)
        {
            OrganizationId = organizationId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
