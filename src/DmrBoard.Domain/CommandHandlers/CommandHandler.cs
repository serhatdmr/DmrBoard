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
        private readonly IUnitofWork _unitofWork;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitofWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _unitofWork = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                 _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_unitofWork.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
