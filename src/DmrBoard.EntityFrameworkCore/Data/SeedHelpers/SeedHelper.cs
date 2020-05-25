using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DmrBoard.EntityFrameworkCore.Data.SeedHelpers
{
    public static class SeedHelper
    {
        public static async Task InitSeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<DmrDbContext>();

                await IdentitySeedHelper.CreateUserAndRoles(serviceScope, dbContext);
            }
        }
    }
}
