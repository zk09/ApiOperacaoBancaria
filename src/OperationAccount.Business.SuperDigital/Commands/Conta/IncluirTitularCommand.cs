using System;

namespace OperationAccount.Business.SuperDigital.Commands.Conta
{
    public class IncluirTitularCommand : Command
    {
        public IncluirTitularCommand(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
    }
}
