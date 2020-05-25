using DmrBoard.Core.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DmrBoard.Domain.Organizations
{
    public class OrganizationEventHandler : INotificationHandler<CreateOrganizationEvent>
    {

        public Task Handle(CreateOrganizationEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
