using AutoMapper;
using DmrBoard.Application.Mapper;
using DmrBoard.Core.Interfaces;
using DmrBoard.EntityFrameworkCore.Data;
using DmrBoard.EntityFrameworkCore.Data.SeedHelpers;
using DmrBoard.Web.Host.Configurations;
using DmrBoard.Web.Host.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace DmrBoard.Web.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(); 

            services.AddEntityFrameworkSqlite();
            services.AddDbContext<DmrDbContext>(c => c.UseSqlite("Data Source=sqlitedemo.db"));
            services.AddIdentitySetup(Configuration);
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDependencyInjectionSetup();
            services.AddHttpContextAccessor();

            services.AddSwaggerSetup();
            services.AddAutoMapper(typeof(CustomDtoMapper));

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.InitSeedData().Wait();

            app.UseRouting();
            app.UseRequestResponseLogging();
            app.UseAuthorization();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseSwaggerSetup();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
