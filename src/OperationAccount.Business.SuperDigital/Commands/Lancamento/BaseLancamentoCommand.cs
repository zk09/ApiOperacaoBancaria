using System;

namespace OperationAccount.Business.SuperDigital.Commands.Lancamento
{
    public abstract class BaseLancamentoCommand : Command
    {
        public Guid Id { get; protected set; }
        public decimal Valor { get; protected set; }
        public DateTime Data { get; protected set; }

    }
}
