using DmrBoard.Application.Authorization.Dto;
using DmrBoard.Core.Authorization.Users;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Notifications;
using DmrBoard.Web.Host.Configurations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DmrBoard.Web.Host.Controllers.Authorization
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}[controller]")]
    public class TokenAuthController : BaseController
    {
        private readonly SignInManager<User> _signInManager;

        public TokenAuthController(UserManager<User> userManager,
            IConfiguration configuration,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notification,
            SignInManager<User> signInManager) : base(userManager, configuration, mediator, notification)
        {
            _signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Result(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                string token = await GenerateToken(model.Email);
                return Result(token);
            }

            NotifyError("Authenticate", result.ToString());
            return Result(model);
        }

        private async Task<string> GenerateToken(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            var claims = await UserManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Auth:Jwt:Key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = Configuration.GetSection("Auth:Jwt:Issuer").Value,
                Audience = Configuration.GetSection("Auth:Jwt:Audience").Value,
                Expires = DateTime.UtcNow.AddHours(CommonConst.TokenExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
