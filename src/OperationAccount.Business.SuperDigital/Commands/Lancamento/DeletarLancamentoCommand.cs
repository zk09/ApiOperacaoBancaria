using System;

namespace OperationAccount.Business.SuperDigital.Commands.Lancamento
{
    public class DeletarLancamentoCommand:BaseLancamentoCommand
    {
        public DeletarLancamentoCommand(Guid id, decimal valor, DateTime data)
        {
            Id = id;
            Valor = valor;
            Data = data;
        }
    }
}
