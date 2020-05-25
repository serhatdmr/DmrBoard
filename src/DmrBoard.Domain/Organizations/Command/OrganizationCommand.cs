using DmrBoard.Core.Commands;

namespace DmrBoard.Domain.Organizations
{
    public abstract class OrganizationCommand : Command
    {
        public string Name { get; set; }
    }
}
