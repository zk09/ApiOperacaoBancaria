using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using OperationAccount.Data.SuperDigital.Context;
using OperationAccount.Api.SuperDigital.Configuration;
using OperationAccount.Api.SuperDigital.Extensions;
using MediatR;

namespace Operation.Conta.SuperDigital
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
    
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<OperacaoDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMediatR(typeof(Startup).Assembly);

            services.AddAutoMapper(typeof(Startup));

            services.WebApiConfig();

            services.AddSwaggerConfig();

            services.ResolveDependencies();
        }

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            // Configurãções para não precisar de certificado rodando em docker
            app.UseDeveloperExceptionPage();

             app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvcConfiguration();

            app.UseSwaggerConfig(provider);
        }
    }
}
