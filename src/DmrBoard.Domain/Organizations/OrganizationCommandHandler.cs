using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Notifications;
using DmrBoard.Core.Organizations;
using DmrBoard.Domain.Boards.Commands;
using DmrBoard.Domain.CommandHandlers;
using DmrBoard.Domain.Organizations.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DmrBoard.Domain.Organizations
{
    public class OrganizationCommandHandler : CommandHandler, IRequestHandler<CreateOrganizationCommand, bool>,
        IRequestHandler<DeleteOrganizationCommand, bool>
    {
        IRepository<Organization, Guid> _organizationRepository;
        public OrganizationCommandHandler(IUnitofWork uow, IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IRepository<Organization, Guid> organizationRepository) : base(uow, bus, notifications)
        {
            _organizationRepository = organizationRepository;
        }


        public Task<bool> Handle(CreateOrganizationCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var organization = new Organization { Name = message.Name };
            _organizationRepository.Add(organization);

            if (Commit())
            {
                Bus.RaiseEvent(new CreateOrganizationEvent(organization.Id, organization.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(DeleteOrganizationCommand message, CancellationToken cancellationToken)
        { 
            _organizationRepository.Delete(message.Id);
            return Task.FromResult(Commit());
        }

    }
}
