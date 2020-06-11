using System;

namespace OperationAccount.Business.SuperDigital.Commands.Lancamento
{
    public class AdicionarLancamentoCommand:BaseLancamentoCommand
    {
        public AdicionarLancamentoCommand(decimal valor, ContaOrigemCommand origemConta, ContaDestinoCommand destinoConta)
        {
            Valor = valor;
            Data = DateTime.Now;
            OrigemConta = origemConta;
            DestinoConta = destinoConta;

        }
        public ContaOrigemCommand OrigemConta { get; private set; }
        public ContaDestinoCommand DestinoConta { get; private set; }
    }
}
