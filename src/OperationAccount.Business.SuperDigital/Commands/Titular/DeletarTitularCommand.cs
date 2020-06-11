using System;

namespace OperationAccount.Business.SuperDigital.Commands.Titular
{
    public class DeletarTitularCommand:BaseTitularCommand
    {
        public DeletarTitularCommand(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}
