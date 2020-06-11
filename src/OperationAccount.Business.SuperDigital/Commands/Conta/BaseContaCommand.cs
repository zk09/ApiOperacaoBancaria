using System;

namespace OperationAccount.Business.SuperDigital.Commands.Conta
{
    public abstract class BaseContaCommand:Command
    {
        public Guid Id { get; protected set; }
        public string Numero { get; protected set; }
        public decimal Saldo { get; protected set; }
    }
}
