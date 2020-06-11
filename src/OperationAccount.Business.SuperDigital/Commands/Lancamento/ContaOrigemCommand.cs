namespace OperationAccount.Business.SuperDigital.Commands.Lancamento
{
    public class ContaOrigemCommand: Command
    {
        public ContaOrigemCommand(string numero, string cpf)
        {
            Numero = numero;
            Cpf = cpf;
        }
        public string Numero { get; protected set; }
        public string Cpf { get; protected set; }
    }
}
