using DmrBoard.Core.Authorization.Roles;
using DmrBoard.Core.Authorization.Users;
using DmrBoard.Core.Bus;
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
        public BaseController(UserManager<User> userManager,
                  IConfiguration configuration,
                  IMediatorHandler mediator)
        {
            UserManager = userManager;
            Configuration = configuration;
            _mediator = mediator;
        }



    }
}
