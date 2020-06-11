using System;

namespace OperationAccount.Api.SuperDigital.ViewModels
{
    public class TitularViewModel
    {
        public TitularViewModel(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
        public string Nome { get;  set; }
        public string Cpf { get;  set; }
    }
}
