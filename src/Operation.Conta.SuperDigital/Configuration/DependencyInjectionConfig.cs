using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OperationAccount.Business.SuperDigital.CommandHandler.Conta;
using OperationAccount.Business.SuperDigital.CommandHandler.Lancamento;
using OperationAccount.Business.SuperDigital.CommandHandler.Titular;
using OperationAccount.Business.SuperDigital.Commands.Conta;
using OperationAccount.Business.SuperDigital.Commands.Lancamento;
using OperationAccount.Business.SuperDigital.Commands.Titular;
using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Business.SuperDigital.Notification;
using OperationAccount.Data.SuperDigital.Context;
using OperationAccount.Data.SuperDigital.Repository;
using OperationAccount.Data.SuperDigital.Uow;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace OperationAccount.Api.SuperDigital.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<OperacaoDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ITitularRepository, TitularRepository>();

            services.AddScoped<IRequestHandler<AdicionarContaCommand, bool>, ContaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarContaCommand, bool>, ContaCommandHandler>();
            services.AddScoped<IRequestHandler<DeletarContaCommand, bool>, ContaCommandHandler>();

            services.AddScoped<IRequestHandler<AdicionarTitularCommand, bool>, TitularCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarTitularCommand, bool>, TitularCommandHandler>();
            services.AddScoped<IRequestHandler<DeletarTitularCommand, bool>, TitularCommandHandler>();

            services.AddScoped<IRequestHandler<AdicionarLancamentoCommand, bool>, LancamentoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarLancamentoCommand, bool>, LancamentoCommandHandler>();
            services.AddScoped<IRequestHandler<DeletarLancamentoCommand, bool>, LancamentoCommandHandler>();


            services.AddScoped<INotificador, Notificador>();
      

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
