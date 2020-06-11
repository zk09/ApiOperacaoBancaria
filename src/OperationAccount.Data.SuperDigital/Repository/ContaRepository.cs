using Microsoft.EntityFrameworkCore;
using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Business.SuperDigital.Models;
using OperationAccount.Data.SuperDigital.Context;
using System;
using System.Threading.Tasks;

namespace OperationAccount.Data.SuperDigital.Repository
{
    public class ContaRepository : Repository<ContaCorrente>, IContaRepository
    {
        public ContaRepository(OperacaoDbContext context) : base(context) { }


        public async Task<Titular> ObterTitularDaContaPorCPF(string cpf)
        {
            return await Db.Titulares.AsNoTracking()
           .Include(c => c.ContaCorrente)
           .FirstOrDefaultAsync(c => c.Cpf.Equals(cpf));
        }

        public async Task<Titular> ObterTitularDaContaPorIdConta(Guid id)
        {
            return await Db.Titulares.AsNoTracking()
           .Include(c => c.ContaCorrente)
           .FirstOrDefaultAsync(c => c.ContaId ==id);
        }
    }
}
