using DmrBoard.Core.Authorization.Roles;
using DmrBoard.Core.Authorization.Users;
using DmrBoard.Core.Domain.Entities;
using DmrBoard.Core.Events;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Organizations;
using DmrBoard.Domain.Boards;
using DmrBoard.EntityFrameworkCore.Util;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DmrBoard.EntityFrameworkCore.Data
{
    public class DmrDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly ICurrentUserService _userSession;
        private readonly ILogger _logger;
        public DmrDbContext(DbContextOptions options, ICurrentUserService userSession, ILogger<DmrDbContext> logger) : base(options)
        {
            _userSession = userSession;
            _logger = logger;
        }
        public DbSet<StoredEvent> StoredEvents { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Organization>(b =>
            {
                b.Property(k => k.Name).HasMaxLength(100).IsRequired();
            });

            builder.Entity<Board>(b =>
            {
                b.Property(k => k.Name).HasMaxLength(100).IsRequired();
            });


            builder.Entity<StoredEvent>(b =>
            {
                b.Property(k => k.Timestamp).HasColumnName("CreationDate");
                b.Property(k => k.MessageType).HasColumnName("Action").HasMaxLength(100);
            });

            builder.SetQueryFilterOnAllEntities<ISoftDelete>(p => !p.IsDeleted);

            base.OnModelCreating(builder);

            //builder.Entity<ISoftDelete>().HasQueryFilter(p => !p.IsDeleted);
            //foreach (var type in builder.Model.GetEntityTypes()
            //.Where(t => t.BaseType == null)
            //.Select(t => t.ClrType)
            //.Where(t => typeof(ISoftDelete).IsAssignableFrom(t)))
            //{
            //    type.Set
            //}


            //foreach (var entityType in builder.Model.GetEntityTypes())
            //{
            //    var isDeletedProperty = entityType.FindProperty("IsDeleted");
            //    if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
            //    {
            //        var parameter = Expression.Parameter(entityType.ClrType, "p");
            //        var filter = Expression.Lambda(Expression.Property(parameter, isDeletedProperty.PropertyInfo), parameter);
            //        entityType.SetQueryFilter(filter);
            //    }
            //}
        }
  //      private void SetQueryFilterOnAllEntities<TEntityInterface>(
  //this ModelBuilder builder,
  //Expression<Func<TEntityInterface, bool>> filterExpression)
  //      {
  //          foreach (var type in builder.Model.GetEntityTypes()
  //            .Where(t => t.BaseType == null)
  //            .Select(t => t.ClrType)
  //            .Where(t => typeof(TEntityInterface).IsAssignableFrom(t)))
  //          {
             
  //          }
  //      }
    

        public override int SaveChanges()
        {
            ChangedEntityAuditedSet();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangedEntityAuditedSet();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ChangedEntityAuditedSet()
        {
            var entries = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            var now = DateTime.Now;
            int? userId = null;
            try
            {
                if (_userSession?.UserId != null)
                    userId = int.Parse(_userSession.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ChangedEntityAuditedSet");
            }



            foreach (var changedEntity in entries)
            {
                if (changedEntity.Entity is IAuditedEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreationTime = DateTime.Now;
                            entity.CreatorUserId = userId;
                            break;

                        case EntityState.Modified:
                            entity.LastModificationTime = now;
                            entity.LastModifierUserId = userId;
                            break;
                    }
                }

                if (changedEntity.Entity is ISoftDelete softDeleteEntity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Modified:
                            if (softDeleteEntity.IsDeleted)
                            {
                                if (changedEntity.Entity is IHasDeletionAudited entityDeletion)
                                {
                                    entityDeletion.DeletionTime = DateTime.Now;
                                    entityDeletion.DeleterUserId = userId;
                                }
                            }
                            break;
                    }
                }

            }
        }
    }
}
