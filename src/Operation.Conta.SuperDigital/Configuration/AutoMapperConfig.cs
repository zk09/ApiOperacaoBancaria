using AutoMapper;
using OperationAccount.Api.SuperDigital.ViewModels;
using OperationAccount.Business.SuperDigital.Commands.Conta;
using OperationAccount.Business.SuperDigital.Commands.Lancamento;
using OperationAccount.Business.SuperDigital.Commands.Titular;
using OperationAccount.Api.SuperDigital.Extensions;

namespace OperationAccount.Api.SuperDigital.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {

            CreateMap<ContaViewModel, AdicionarContaCommand>()
                    .ConstructUsing(t => new AdicionarContaCommand(t.Numero, t.Saldo,
                    new IncluirTitularCommand(t.Cliente.Nome, t.Cliente.Cpf.OnlyNumbers())));

            CreateMap<LancamentoViewModel, AdicionarLancamentoCommand>()
                    .ConstructUsing(t => new AdicionarLancamentoCommand(t.Valor,
                    new ContaOrigemCommand(t.ContaOrigem.Numero, t.ContaOrigem.Cpf.OnlyNumbers()),
                    new ContaDestinoCommand(t.ContaDestino.Numero, t.ContaDestino.Cpf.OnlyNumbers())));

        }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new AutoMapperConfig());     
            });
        }
    }
}
