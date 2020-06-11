using OperationAccount.Business.SuperDigital.Commands;
using System;

namespace OperationAccount.Business.SuperDigital.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
