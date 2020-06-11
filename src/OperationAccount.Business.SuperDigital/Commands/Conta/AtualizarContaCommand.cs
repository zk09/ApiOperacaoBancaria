using System;

namespace OperationAccount.Business.SuperDigital.Commands.Conta
{
    public class AtualizarContaCommand:BaseContaCommand
    {
        public AtualizarContaCommand(Guid id,string numero, decimal saldo)
        {
            Id = id;
            Numero = numero;
            Saldo = saldo;
        }
    }
}
