using System;

namespace OperationAccount.Business.SuperDigital.Commands.Conta
{
    public class DeletarContaCommand:BaseContaCommand
    {
        public DeletarContaCommand(Guid id, string numero, decimal saldo)
        {
            Id = id;
            Numero = numero;
            Saldo = saldo;
        }
    }
}
