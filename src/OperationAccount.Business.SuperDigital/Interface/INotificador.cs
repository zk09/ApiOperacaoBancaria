using FluentValidation.Results;
using OperationAccount.Business.SuperDigital.Notification;
using System.Collections.Generic;

namespace OperationAccount.Business.SuperDigital.Interface
{
    public interface INotificador
    {
        void AddNotificacao(string mensagem);
        void AddNotificacao(Notificacao notificacao);
        void AddNotificacoes(IReadOnlyCollection<Notificacao> notificacoes);
        void AddNotificacoes(IList<Notificacao> notificacoes);
        void AddNotifications(ICollection<Notificacao> notificacoes);
        void AddNotificacoes(ValidationResult validationResult);
        bool ExisteNotificacao();
        IReadOnlyCollection<Notificacao> Notificacoes();

    }
}
