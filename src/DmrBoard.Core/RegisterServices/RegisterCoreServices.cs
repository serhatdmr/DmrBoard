using DmrBoard.Core.Organizations;
using Microsoft.Extensions.DependencyInjection;

namespace DmrBoard.Core.RegisterServices
{
    public static class RegisterCoreServices
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IOrganizationManager, OrganizationManager>();



        }
    }
}
