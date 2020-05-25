using DmrBoard.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Application.Authorization
{
    public class UserAppService : IUserAppService
    {
        private readonly IMediatorHandler _mediator;
     
        public UserAppService(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }
    }
}
