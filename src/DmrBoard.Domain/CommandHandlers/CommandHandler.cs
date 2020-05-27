using DmrBoard.Core.Bus;
using DmrBoard.Core.Commands;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Domain.CommandHandlers
{
    public class CommandHandler
    {
        public readonly IUnitofWork UnitOfWork;
        public readonly IMediatorHandler Bus;
        public readonly DomainNotificationHandler Notifications;

        public CommandHandler(IUnitofWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            UnitOfWork = uow;
            Notifications = (DomainNotificationHandler)notifications;
            Bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (Notifications.HasNotifications()) return false;
            if (UnitOfWork.Commit()) return true;

            Bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
