using FluentValidation.Results;
using OperationAccount.Business.SuperDigital.Interface;
using System.Collections.Generic;
using System.Linq;

namespace OperationAccount.Business.SuperDigital.Notification
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;
        private IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;
        private bool ExisteNotificacao=> _notificacoes.Any();
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AddNotificacao(string mensagem)
        {
            _notificacoes.Add(new Notificacao(mensagem));
        }

        public void AddNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void AddNotificacoes(IReadOnlyCollection<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public void AddNotificacoes(IList<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }
        public void AddNotifications(ICollection<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }
        public void AddNotificacoes(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotificacao(error.ErrorMessage);
            }
        }

        bool INotificador.ExisteNotificacao()
        {
            return ExisteNotificacao;
        }

        IReadOnlyCollection<Notificacao> INotificador.Notificacoes()
        {
            return Notificacoes;
        }
    }
}
