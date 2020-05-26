using DmrBoard.Core.Authorization.Roles;
using DmrBoard.Core.Authorization.Users;
using DmrBoard.Core.Events;
using DmrBoard.Core.Organizations;
using DmrBoard.Domain.Boards;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DmrBoard.EntityFrameworkCore.Data
{
    public class DmrDbContext : IdentityDbContext<User, Role, int>
    {
        public DmrDbContext(DbContextOptions options) : base(options)
        {
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

            base.OnModelCreating(builder);
        }
    }
}
