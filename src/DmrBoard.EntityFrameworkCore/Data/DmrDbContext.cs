using DmrBoard.Core.Authorization.Roles;
using DmrBoard.Core.Authorization.Users;
using DmrBoard.Core.Organizations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DmrBoard.EntityFrameworkCore.Data
{
    public class DmrDbContext : IdentityDbContext<User, Role, int>
    {
        public DmrDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
