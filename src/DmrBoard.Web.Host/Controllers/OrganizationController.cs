using DmrBoard.Application.Organizations;
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
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}[controller]")]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationAppService _organizationAppService;

        public OrganizationController(UserManager<User> userManager,
            IConfiguration configuration, IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notification,
            IOrganizationAppService organizationAppService) : base(userManager, configuration, mediator, notification)
        {
            _organizationAppService = organizationAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _organizationAppService.GetAll();
            return Result(list);
        }

    }
}
