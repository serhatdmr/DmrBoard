using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DmrBoard.Core.Authorization.Roles;
using DmrBoard.Core.Authorization.Users;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Organizations;
using DmrBoard.Domain.Organizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DmrBoard.Web.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger _logger;

        public WeatherForecastController(UserManager<User> userManager,
            IConfiguration configuration,
            IMediatorHandler mediator,IUserSession userSession) : base(userManager, configuration, mediator)
        {

            var s = userSession.Name;
            var s2 = userSession.UserId;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
           
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
