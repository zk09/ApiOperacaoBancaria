using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Business.SuperDigital.Models;
using OperationAccount.Data.SuperDigital.Context;

namespace OperationAccount.Data.SuperDigital.Repository
{
    public class TitularRepository : Repository<Titular>, ITitularRepository
    {
        public TitularRepository(OperacaoDbContext context) : base(context) { }
    }
}
