using MediatR;
using OperationAccount.Business.SuperDigital.Commands.Lancamento;
using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Business.SuperDigital.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace OperationAccount.Business.SuperDigital.CommandHandler.Lancamento
{
    public class LancamentoCommandHandler : BaseCommandHandler,
          IRequestHandler<AdicionarLancamentoCommand, bool>,
          IRequestHandler<AtualizarLancamentoCommand, bool>,
          IRequestHandler<DeletarLancamentoCommand, bool>
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IContaRepository _contaRepository;
        public LancamentoCommandHandler(IContaRepository contaRepository,ILancamentoRepository lancamentoRepository,
            INotificador notificador,
            IUnitOfWork uow) : base(notificador, uow)
        {
            _lancamentoRepository = lancamentoRepository;
            _contaRepository = contaRepository;
        }
        public async Task<bool> Handle(AdicionarLancamentoCommand request, CancellationToken cancellationToken)
        {
            var lancamento = new Lancamentos(request.Valor);
            var titularContaOrigem = _contaRepository.ObterTitularDaContaPorCPF(request.OrigemConta.Cpf).Result;
            var titularContaDestino = _contaRepository.ObterTitularDaContaPorCPF(request.DestinoConta.Cpf).Result;

            if (request.OrigemConta.Cpf.Equals(request.DestinoConta.Cpf)
               && request.OrigemConta.Numero.Equals(request.DestinoConta.Numero))
            {
                Notificar("Conta origem e destino possuem os mesmos dados, verifique o cpf e o numero da conta");
                return false;
            }

            if (titularContaOrigem == null)
            {
                Notificar("Conta origem não existe no CPF informado");
            }

            if (titularContaDestino == null)
            {

                Notificar("Conta destino não existe no CPF informado");
            }

            if (ExisteNotificacao()) return false;


            var contaO = ContaCorrente.ContaFactory.AtualizarConta(
                titularContaOrigem.ContaId, 
                titularContaOrigem.Id,
                titularContaOrigem,
                titularContaOrigem.ContaCorrente.Numero,
                titularContaOrigem.ContaCorrente.Saldo);

            var contaD = ContaCorrente.ContaFactory.AtualizarConta(
                             titularContaDestino.ContaId,
                             titularContaDestino.Id,
                             titularContaDestino,
                             titularContaDestino.ContaCorrente.Numero,
                             titularContaDestino.ContaCorrente.Saldo);

            lancamento.AtribuirConta(contaO);

            if (!ExecutarValidacao(lancamento) ||
                !ExecutarValidacao(contaO) ||
                !ExecutarValidacao(contaD)) return false;

            contaO.RealizarTransferencia(contaD, lancamento);

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _contaRepository.Atualizar(contaO);
                await _contaRepository.Atualizar(contaD);
                await _lancamentoRepository.Adicionar(lancamento);
                scope.Complete();
                scope.Dispose();
            }

              return true;
            
        }

        public Task<bool> Handle(AtualizarLancamentoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(DeletarLancamentoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
