using DmrBoard.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmrBoard.Web.Host.Configurations
{
    public static class DependencyInjectionSetup
    { 
        public static void AddDependencyInjectionSetup(this IServiceCollection service)
        {
            NativeInjectorBootStrapper.RegisterServices(service);
        }
    }
}
