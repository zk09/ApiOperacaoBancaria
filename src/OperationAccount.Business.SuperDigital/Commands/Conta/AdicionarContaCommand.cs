using System;

namespace OperationAccount.Business.SuperDigital.Commands.Conta
{
    public class AdicionarContaCommand:BaseContaCommand
    {
        public AdicionarContaCommand(string numero, decimal saldo, IncluirTitularCommand titular)
        {
            Numero = numero;
            Saldo = saldo;
            Titular = titular;
        }


        public IncluirTitularCommand Titular { get; private set; }
    }
}
