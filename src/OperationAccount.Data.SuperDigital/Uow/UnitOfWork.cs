using OperationAccount.Business.SuperDigital.Commands;
using OperationAccount.Business.SuperDigital.Interface;
using OperationAccount.Data.SuperDigital.Context;

namespace OperationAccount.Data.SuperDigital.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OperacaoDbContext _context;

        public UnitOfWork(OperacaoDbContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAfected = _context.SaveChanges();

            return new CommandResponse(rowsAfected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
