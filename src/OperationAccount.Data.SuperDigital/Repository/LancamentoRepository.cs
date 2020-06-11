using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Business.SuperDigital.Models;
using OperationAccount.Data.SuperDigital.Context;

namespace OperationAccount.Data.SuperDigital.Repository
{
    public class LancamentoRepository : Repository<Lancamentos>, ILancamentoRepository
    {
        public LancamentoRepository(OperacaoDbContext context) : base(context) { }
    }
}
