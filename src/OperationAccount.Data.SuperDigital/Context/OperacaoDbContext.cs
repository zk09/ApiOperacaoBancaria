using Microsoft.EntityFrameworkCore;
using OperationAccount.Business.SuperDigital.Models;
using System.Linq;

namespace OperationAccount.Data.SuperDigital.Context
{
    public class OperacaoDbContext : DbContext
    {
        public OperacaoDbContext(DbContextOptions<OperacaoDbContext> options) : base(options) { }
        public OperacaoDbContext() { }

        public DbSet<ContaCorrente> Contas { get; set; }
        public DbSet<Titular> Titulares { get; set; }
        public DbSet<Lancamentos> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SuperDigital");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OperacaoDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
   
    }
}
