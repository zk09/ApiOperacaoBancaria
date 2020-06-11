using System;

namespace OperationAccount.Api.SuperDigital.ViewModels
{
    public class LancamentoViewModel
    {
        public decimal Valor { get;  set; }
        public ContaOrigemViewModel ContaOrigem { get;  set; }
        public ContaDestinoViewModel ContaDestino { get;  set; }
    }
}
