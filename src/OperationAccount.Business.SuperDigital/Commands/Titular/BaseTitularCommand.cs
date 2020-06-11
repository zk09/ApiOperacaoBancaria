using System;

namespace OperationAccount.Business.SuperDigital.Commands.Titular
{
    public abstract  class BaseTitularCommand:Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
    }
}
