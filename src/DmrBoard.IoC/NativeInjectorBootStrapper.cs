﻿using DmrBoard.Application.Organizations;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Events;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Notifications;
using DmrBoard.Domain.AuditLogs;
using DmrBoard.Domain.Authorization.Users;
using DmrBoard.Domain.Boards;
using DmrBoard.Domain.Boards.Commands;
using DmrBoard.Domain.Bus;
using DmrBoard.Domain.Cache;
using DmrBoard.Domain.EventStore;
using DmrBoard.Domain.Organizations;
using DmrBoard.EntityFrameworkCore.Data;
using DmrBoard.EntityFrameworkCore.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DmrBoard.IoC
{
    public static class NativeInjectorBootStrapper
    {

        public static void RegisterServices(IServiceCollection services)
        {

            // Cache manager
            services.AddSingleton<ICacheManager, CacheManager>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IEventStore, EventStoreManager>();
            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateOrganizationCommand, bool>, OrganizationCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteOrganizationCommand, bool>, OrganizationCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteBoardCommand, bool>, BoardCommandHandler>();

            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddScoped<DmrDbContext>();

            services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();


            #region AppService
            services.AddScoped<IOrganizationAppService, OrganizationAppService>();
            #endregion

        }

    }
}
