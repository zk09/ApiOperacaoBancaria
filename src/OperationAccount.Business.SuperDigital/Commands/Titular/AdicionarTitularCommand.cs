using System;
using System.Collections.Generic;
using System.Text;

namespace OperationAccount.Business.SuperDigital.Commands.Titular
{
    public class AdicionarTitularCommand:BaseTitularCommand
    {
        public AdicionarTitularCommand(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
    }
}
