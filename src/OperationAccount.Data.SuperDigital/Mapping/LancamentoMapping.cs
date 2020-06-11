using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationAccount.Business.SuperDigital.Models;

namespace OperationAccount.Data.SuperDigital.Mapping
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamentos>
    {
        public void Configure(EntityTypeBuilder<Lancamentos> builder)
        {
            builder.ToTable("Lancamento");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.Property(c => c.Data)
                .IsRequired();


            builder
            .Ignore(e => e.ValidationResult);


            builder
            .Ignore(e => e.CascadeMode);

            builder.HasOne(t => t.ContaCorrente)
                    .WithMany(c => c.Lancamentos)
                    .HasForeignKey(c => c.ContaId);
        }
    }
}
