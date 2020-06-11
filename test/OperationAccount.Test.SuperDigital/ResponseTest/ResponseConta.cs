using OperationAccount.Api.SuperDigital.ViewModels;
using System.Collections.Generic;

namespace OperationAccount.Test.SuperDigital.ResponseTest
{
    public class ResponseConta
    {
        public bool success { get; set; }
        public IEnumerable<ContaViewModel> data { get; set; }
    }
}
