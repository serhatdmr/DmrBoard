using DmrBoard.Core.Authorization.Roles;
using DmrBoard.Core.Authorization.Users;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmrBoard.Web.Host.Controllers
{
    public abstract class BaseController : ControllerBase
    {

        protected UserManager<User> UserManager { get; private set; }
        protected IConfiguration Configuration { get; private set; }
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notification;

        public BaseController(UserManager<User> userManager,
                  IConfiguration configuration,
                  IMediatorHandler mediator,
                  INotificationHandler<DomainNotification> notification)
        {
            UserManager = userManager;
            Configuration = configuration;
            _mediator = mediator;
            _notification = (DomainNotificationHandler)notification;

        }

        protected IEnumerable<DomainNotification> Notifications => _notification.GetNotifications();

        protected IActionResult Result(object result = null)
        {
            if (IsValid())
            {
                return Ok(new { success = true, data = result });
            }


            return BadRequest(new
            {
                success = false,
                errors = Notifications.Select(k => k.Value)
            });
        }

        protected bool IsValid()
        {
            return (!_notification.HasNotifications());
        }
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string value)
        {
            _mediator.RaiseEvent(new DomainNotification(code, value));
        }
    }
}
