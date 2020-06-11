using System;

namespace OperationAccount.Api.SuperDigital.ViewModels
{
    public class ContaViewModel
    {
        public ContaViewModel(string numero, decimal saldo, TitularViewModel cliente)
        {
            Numero = numero;
            Saldo = saldo;
            Cliente = cliente;
        }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public TitularViewModel Cliente { get;  set; }

    }
}
