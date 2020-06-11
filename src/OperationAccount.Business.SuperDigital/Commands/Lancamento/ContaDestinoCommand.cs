namespace OperationAccount.Business.SuperDigital.Commands.Lancamento
{
    public class ContaDestinoCommand:Command
    {
        public ContaDestinoCommand(string numero,string cpf)
        {
            Numero = numero;
            Cpf = cpf;
        }
        public string Numero { get; protected set; }
        public string Cpf { get; protected set; }

    }
}
