using MediatR;
using OperationAccount.Business.SuperDigital.Commands.Conta;
using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Business.SuperDigital.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace OperationAccount.Business.SuperDigital.CommandHandler.Conta
{
    public class ContaCommandHandler : BaseCommandHandler,
         IRequestHandler<AdicionarContaCommand,bool>,
         IRequestHandler<AtualizarContaCommand,bool>,
         IRequestHandler<DeletarContaCommand,bool>
    {
        private readonly IContaRepository _contaRepository;
        private readonly ITitularRepository _titularRepository;
        public ContaCommandHandler(IContaRepository contaRepository,
            ITitularRepository titularRepository,
            INotificador notificador,
            IUnitOfWork uow) :base(notificador, uow)
        {
            _contaRepository = contaRepository;
            _titularRepository = titularRepository;
        }
        public async Task<bool> Handle(AdicionarContaCommand request, CancellationToken cancellationToken)
        {
            var titular = new Models.Titular(request.Titular.Nome,request.Titular.Cpf);
            var conta = ContaCorrente.ContaFactory.NovaConta(titular.Id,request.Numero,request.Saldo);
                conta.AtribuirTitular(titular);

            if (!ExecutarValidacao(conta) ||!ExecutarValidacao(titular)) return false;

            var baseConta = _contaRepository.ObterTitularDaContaPorCPF(titular.Cpf).Result;
            if (baseConta!=null)
            {
                Notificar("Já existe um titular com esse CPF informado");
                return false;
            }

                await _contaRepository.Adicionar(conta);

                return true;
               
        }

        public async Task<bool> Handle(AtualizarContaCommand request, CancellationToken cancellationToken)
        {
            var baseTitular = _contaRepository.ObterTitularDaContaPorIdConta(request.Id).Result;
            var conta = ContaCorrente.ContaFactory.AtualizarConta(request.Id, baseTitular.Id, baseTitular, request.Numero, request.Saldo);

            if (!ExecutarValidacao(conta)) return false;

            await _contaRepository.Adicionar(conta);

            return true;
        }

        public async Task<bool> Handle(DeletarContaCommand request, CancellationToken cancellationToken)
        {

            if (_contaRepository.Buscar(c=> c.Id == request.Id).Result.Any())
            {
                Notificar("Conta não encontrada");
                return false;
            }

            var baseConta = _contaRepository.ObterTitularDaContaPorIdConta(request.Id).Result;
            if (baseConta!=null)
            {
                Notificar("Existe um titular nessa conta, não foi possível realizar operação");
                return false;
            }

            await _contaRepository.Remover(request.Id);

            return true;
        }
    }
}
