using FluentValidation;
using System;

namespace OperationAccount.Business.SuperDigital.Models
{
    public class Titular : Entity<Titular>
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public virtual ContaCorrente ContaCorrente { get; private set; }
        public Guid ContaId { get; private set; }

        public Titular(string nome,string cpf)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
        }
        private Titular() { }

        public void AtribuirConta(ContaCorrente conta)
        {
            if (!conta.IsValid()) return;

            ContaCorrente = conta;
        }

        #region Factory
        public static class TitularFactory
        {
            public static Titular AtualizarTitular(Guid id, string nome, string cpf)
            {
                var cliente = new Titular()
                {
                    Id = id,
                    Nome = nome,
                    Cpf = cpf
                };

                return cliente;
            }

        }
        #endregion

        #region Validation
        public override bool IsValid()
        {
            Valido();
            return ValidationResult.IsValid;
        }

        private void Valido()
        {
            ValidateName();
            ValidateCPF();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .Length(2, 150).WithMessage("O nome precisa ter entre 2 e 150 caracteres");
        }

        private void ValidateCPF()
        {

            RuleFor(c => c.Cpf).NotEmpty().WithMessage("CPF obrigatório");

            RuleFor(c => c.Cpf).IsValidCPF()
                    .WithMessage("CPF inválido");

        }

        #endregion

    }
}
