using System;

namespace OperationAccount.Business.SuperDigital.Commands.Lancamento
{
    public class AtualizarLancamentoCommand:BaseLancamentoCommand
    {
        public AtualizarLancamentoCommand(Guid id, decimal valor, DateTime data)
        {
            Id = id;
            Valor = valor;
            Data = data;
        }
    }
}
