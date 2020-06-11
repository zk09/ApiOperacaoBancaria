using FluentValidation.Results;
using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Business.SuperDigital.Models;
using OperationAccount.Business.SuperDigital.Notification;

namespace OperationAccount.Business.SuperDigital.CommandHandler
{
    public abstract class BaseCommandHandler
    {
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uow;

        public BaseCommandHandler(INotificador notificador, IUnitOfWork uow)
        {
            _notificador = notificador;
            _uow = uow;
        }

        protected bool ExisteNotificacao()
        {
            return _notificador.ExisteNotificacao();
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.AddNotificacao(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<V>(V validacao) where V : Entity<V>
        {
            if (validacao.IsValid()) return true;

            Notificar(validacao.ValidationResult);
            return false;

        }

        protected bool Commit()
        {

            if (_notificador.ExisteNotificacao()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _notificador.AddNotificacao("Ocorreu um erro ao salvar os dados no banco");

            return false;
        }
    }
}
