using OperationAccount.Business.SuperDigital.Models;
using System;
using System.Threading.Tasks;

namespace OperationAccount.Business.SuperDigital.Interface
{
    public interface IContaRepository : IRepository<ContaCorrente>
    {
        Task<Titular> ObterTitularDaContaPorCPF(string cpf);
        Task<Titular> ObterTitularDaContaPorIdConta(Guid id);
    }
}
