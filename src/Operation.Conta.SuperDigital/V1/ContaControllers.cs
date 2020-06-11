using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OperationAccount.Api.SuperDigital.Configuration;
using OperationAccount.Api.SuperDigital.Controllers;
using OperationAccount.Api.SuperDigital.ViewModels;
using OperationAccount.Business.SuperDigital.Commands.Conta;
using OperationAccount.Business.SuperDigital.Commands.Lancamento;
using OperationAccount.Business.SuperDigital.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationAccount.Api.SuperDigital.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/conta")]
    [ApiExplorerSettings(GroupName = "API - Conta"), ApiController]
    public class ContaControllers:BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ContaControllers(IMediator mediator, IMapper mapper, INotificador notificador):base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpPost("Transferencia")]
        public async Task<ActionResult<LancamentoViewModel>> Transferencia([FromBody] LancamentoViewModel lancamentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

          
            var LancamentoCommand = _mapper.Map<AdicionarLancamentoCommand>(lancamentoViewModel);
           await _mediator.Send(LancamentoCommand);

           return CustomResponse(lancamentoViewModel);
        }

        [HttpPost("CriarConta")]
        public async Task<ActionResult<IEnumerable<ContaViewModel>>> CriarConta([FromBody] IEnumerable<ContaViewModel> contaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            foreach (var conta  in contaViewModel) {
                var contaCommand = _mapper.Map<AdicionarContaCommand>(conta);
                await _mediator.Send(contaCommand);
            }

            return CustomResponse(contaViewModel);
        }

    }
}
