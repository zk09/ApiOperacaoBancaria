using System;
using FluentValidation;

namespace OperationAccount.Business.SuperDigital.Models
{
    public class Lancamentos : Entity<Lancamentos>
    {
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public virtual ContaCorrente ContaCorrente { get; private set; }
        public Guid? ContaId { get; private set; }
        public Lancamentos(decimal valor)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Data = DateTime.Now;
        }


        public void AtribuirConta(ContaCorrente conta)
        {
            this.ContaCorrente = conta;
        }


        #region Validation

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarLancamento();
            ValidationResult = Validate(this);

        }
        private void ValidarLancamento()
        {
            RuleFor(c => c.Valor)
                .GreaterThan(0)
                .WithMessage("É necessário inserir um valor para realizar uma transferência");
        }

        #endregion

    }
}
