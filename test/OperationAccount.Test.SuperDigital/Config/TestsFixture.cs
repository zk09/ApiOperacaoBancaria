using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.AspNetCore.Mvc.Testing;
using OperationAccount.Api.SuperDigital;
using OperationAccount.Api.SuperDigital.Extensions;
using OperationAccount.Api.SuperDigital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace OperationAccount.Test.SuperDigital.Config
{
    [CollectionDefinition(nameof(ApiTestsFixtureCollection))]

   public class ApiTestsFixtureCollection : ICollectionFixture<TestsFixture<StartupApiTest>> { }
   public class TestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly ApiAppFactory<TStartup> Factory;
        public HttpClient Client;

        public decimal valor { get; set; } = 100;
        public string  numeroOrigem { get; set; }
        public string cpforigem { get; set; }
        public string numeroDestino { get; set; }
        public string cpfDestino { get; set; }

        public TestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(GetBaseUrl()),
            };

            Factory = new ApiAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public IEnumerable<ContaViewModel> ObterClientesVariados()
        {
            var clientes = new List<ContaViewModel>();
            clientes.AddRange(GerarContas(2).ToList());

            return clientes;
        }
        private IEnumerable<ContaViewModel> GerarContas(int quantidade)
        {
            Random randNum = new Random();
            var conta = new Faker<ContaViewModel>("pt_BR")
                    .CustomInstantiator(f => new ContaViewModel(
                           randNum.Next(10000, 90000).ToString(),
                           5000,
                           new TitularViewModel(f.Person.FirstName, f.Person.Cpf().OnlyNumbers())
                           ));

          return   conta.Generate(quantidade);

        }
        public LancamentoViewModel GerarLancamento()
        {

            var transf = new LancamentoViewModel()
            {
                Valor = valor,
                ContaOrigem = new ContaOrigemViewModel()
                {
                    Numero = numeroOrigem,
                    Cpf = cpforigem
                },
                ContaDestino = new ContaDestinoViewModel()
                {
                    Numero = numeroDestino,
                    Cpf = cpfDestino
                }
            };

            return transf;
        }

        private string GetBaseUrl()
        {
            return "https://localhost:44369/";
        }
        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
