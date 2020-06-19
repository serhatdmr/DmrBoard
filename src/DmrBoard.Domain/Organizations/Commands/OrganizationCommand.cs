using DmrBoard.Core.Commands;
using System;

namespace DmrBoard.Domain.Organizations
{
    public abstract class OrganizationCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
    }
}
