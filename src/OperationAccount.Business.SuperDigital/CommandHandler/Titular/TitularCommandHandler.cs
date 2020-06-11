using MediatR;
using OperationAccount.Business.SuperDigital.Commands.Titular;
using OperationAccount.Business.SuperDigital.Interface;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OperationAccount.Business.SuperDigital.CommandHandler.Titular
{
    public class TitularCommandHandler : BaseCommandHandler,
          IRequestHandler<AdicionarTitularCommand, bool>,
          IRequestHandler<AtualizarTitularCommand, bool>,
          IRequestHandler<DeletarTitularCommand, bool>
    {
        private readonly ITitularRepository _titularRepository;
        public TitularCommandHandler(ITitularRepository titularRepository,
         INotificador notificador,
         IUnitOfWork uow) : base(notificador, uow)
        {
            _titularRepository = titularRepository;
        }
        public async Task<bool> Handle(AdicionarTitularCommand request, CancellationToken cancellationToken)
        {  
          
            var titular =  new Models.Titular(request.Nome,request.Cpf);

            if (!ExecutarValidacao(titular)) return false;

            if(_titularRepository.Buscar(t=> t.Cpf.Equals(request.Cpf)).Result.Any())
            {
                Notificar("Já existe um titular com este cpf informado.");
                return false;
            }
                                                                     
            await _titularRepository.Adicionar(titular);

            return true;

        }

        public async Task<bool> Handle(AtualizarTitularCommand request, CancellationToken cancellationToken)
        {
            var titular = Models.Titular.TitularFactory.AtualizarTitular(request.Id,request.Nome,request.Cpf);

            if (!ExecutarValidacao(titular)) return false;

            await _titularRepository.Atualizar(titular);

            return true;

        }

        public async Task<bool> Handle(DeletarTitularCommand request, CancellationToken cancellationToken)
        {
            if (_titularRepository.Buscar(c => c.Id == request.Id).Result.Any())
            {
                Notificar("Titular não encontrado");
                return false;
            }

            await _titularRepository.Remover(request.Id);

            return true;
        }
    }
}
