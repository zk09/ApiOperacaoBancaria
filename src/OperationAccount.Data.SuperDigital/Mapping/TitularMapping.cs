using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationAccount.Business.SuperDigital.Models;

namespace OperationAccount.Data.SuperDigital.Mapping
{
    public class TitularMapping : IEntityTypeConfiguration<Titular>
    {
        public void Configure(EntityTypeBuilder<Titular> builder)
        {
            builder.ToTable("Titular");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder
            .Ignore(e => e.ValidationResult);


            builder
            .Ignore(e => e.CascadeMode);

            builder.HasOne(t => t.ContaCorrente)
            .WithOne(c => c.Titular)
            .HasForeignKey<Titular>(t => t.ContaId); 
           
        }
    }
}
