using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmrBoard.Web.Host.RegisterServices
{
    public static class RegisterSerilogServices
    {
        //public static IServiceCollection AddSerilogServices(this IServiceCollection services)
        //{
        //    Log.Logger = new LoggerConfiguration()
        //        .MinimumLevel.Information()
        //        .ReadFrom = new Serilog.Configuration.LoggerSettingsConfiguration {  }
        //        .WriteTo.File("C:\\logs\\DmrBoard\\")
        //        .CreateLogger();

        //    AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();

        //    return services.AddSingleton((ILogger)Log.Logger);
        //}
    }
}
