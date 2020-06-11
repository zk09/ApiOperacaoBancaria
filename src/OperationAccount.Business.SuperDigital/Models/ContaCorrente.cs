using FluentValidation;
using System;
using System.Collections.Generic;

namespace OperationAccount.Business.SuperDigital.Models
{
    public class ContaCorrente : Entity<ContaCorrente>
    {
        public string Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public virtual Titular Titular { get; private set; }
        public Guid TitularId { get; private set; }
        public Guid? LancamentoId { get; private set; }
        public virtual ICollection<Lancamentos> Lancamentos { get; set; }
        private ContaCorrente() { }
        public ContaCorrente(string numero, decimal saldo)
        {
            Id = Guid.NewGuid();
            Numero = numero;
            Saldo = saldo;
        }

        private void DebitarSaldo(decimal valor)
        {
            if (!this.ValidarDebito(valor)) return;
            this.Saldo-= valor;
        }

        public void RealizarTransferencia(ContaCorrente contaDestino, Lancamentos lancamento)
        {
            DebitarSaldo(lancamento.Valor);
            if (!lancamento.IsValid()) return;
            contaDestino.Saldo += lancamento.Valor;
        }

        public void AtribuirTitular(Titular titular)
        {
            if (!titular.IsValid()) return;

            Titular = titular;
        }

        #region Factory
        public static class ContaFactory
        {
            public static ContaCorrente AtualizarConta(Guid id,Guid titularId, Titular titular, string numero, decimal saldo)
            {
                var conta = new ContaCorrente()
                {
                    Id = id,
                    TitularId = titularId,
                    Titular = titular,
                    Numero = numero,
                    Saldo = saldo
                };

                return conta;
            }

            public static ContaCorrente NovaConta(Guid idTitular, string numero, decimal saldo)
            {
                var conta = new ContaCorrente()
                {
                    Id = Guid.NewGuid(),
                    TitularId = idTitular,
                    Numero = numero,
                    Saldo = saldo
                };

                return conta;
            }

        }
        #endregion

        #region Validation
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNumeroConta();
            ValidarTitular();
            ValidationResult = Validate(this);
        }

        private void ValidarNumeroConta()
        {
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O numero da conta  é obrigatório")
                .Length(5, 15).WithMessage("O numero da conta precisa ter entre 5 e 15 numeros");

        }

        private void ValidarTitular()
        {
            RuleFor(c => c.Titular)
                .NotNull().WithMessage("Conta precisar ter um Titular");

        }

        private bool ValidarDebito(decimal valor)
        {
            RuleFor(c => c.Saldo).GreaterThanOrEqualTo(valor).WithMessage("Saldo insuficiente para realizar a operação");
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
