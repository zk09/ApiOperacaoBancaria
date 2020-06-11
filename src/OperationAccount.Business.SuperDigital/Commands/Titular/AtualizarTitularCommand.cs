using System;

namespace OperationAccount.Business.SuperDigital.Commands.Titular
{
    public class AtualizarTitularCommand:BaseTitularCommand
    {
        public AtualizarTitularCommand(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}
