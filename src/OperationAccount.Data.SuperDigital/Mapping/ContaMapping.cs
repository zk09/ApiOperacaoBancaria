using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationAccount.Business.SuperDigital.Models;

namespace OperationAccount.Data.SuperDigital.Mapping
{
    public class ContaMapping : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("Conta");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Saldo)
                .IsRequired();


            builder
            .Ignore(e => e.ValidationResult);


            builder
            .Ignore(e => e.CascadeMode);

            builder.HasOne(c => c.Titular)
                    .WithOne(t => t.ContaCorrente)
                    .HasForeignKey<ContaCorrente>(c=> c.TitularId);

        }
    }
}
