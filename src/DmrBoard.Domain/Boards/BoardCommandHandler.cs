using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Notifications;
using DmrBoard.Domain.Boards.Commands;
using DmrBoard.Domain.Boards.Specifications;
using DmrBoard.Domain.CommandHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DmrBoard.Domain.Boards
{
    public class BoardCommandHandler : CommandHandler, IRequestHandler<DeleteBoardCommand, bool>
    {
        private readonly IRepository<Board, Guid> _boardRepo;
        public BoardCommandHandler(IRepository<Board, Guid> boardRepo, IUnitofWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _boardRepo = boardRepo;
        }

        public Task<bool> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var boards = _boardRepo.Get(new BoardsByOrganizationId(request.OrganizationId));

            //if (board == null)
            //{
            //    Bus.RaiseEvent(new DomainNotification(request.Id.ToString(), "İlgili board bulunamadı"));
            //    return Task.FromResult(false);
            //}

            //foreach (var board in boards)
            //{
            //    _boardRepo.Delete(board);
            //}

            return Task.FromResult(true);
        }
    }
}
