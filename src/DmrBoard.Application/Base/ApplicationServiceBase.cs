using AutoMapper;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Interfaces;
using System;

namespace DmrBoard.Application.Base
{
    public abstract class ApplicationServiceBase : IDisposable
    {
        public readonly IMediatorHandler Mediator;
        public readonly IMapper Mapper;
        public readonly ICurrentUserService UserSession;

        public ApplicationServiceBase(IMediatorHandler mediator, IMapper mapper, ICurrentUserService userSession)
        {
            Mediator = mediator;
            Mapper = mapper;
            UserSession = userSession;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
