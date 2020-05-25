using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Events;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Notifications;
using DmrBoard.Domain.Authorization.Users;
using DmrBoard.Domain.Bus;
using DmrBoard.Domain.EventStore;
using DmrBoard.Domain.Organizations;
using DmrBoard.EntityFrameworkCore.Data;
using DmrBoard.EntityFrameworkCore.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DmrBoard.IoC
{
    public class NativeInjectorBootStrapper
    {

        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IEventStore, EventStoreManager>();
            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateOrganizationCommand, bool>, OrganizationCommandHandler>();


            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddScoped<DmrDbContext>();

            services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            services.AddScoped<IUserSession, UserSession>();
        }

    }
}
