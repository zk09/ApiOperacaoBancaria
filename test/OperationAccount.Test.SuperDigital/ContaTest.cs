using Newtonsoft.Json;
using OperationAccount.Api.SuperDigital;
using OperationAccount.Test.SuperDigital.Config;
using OperationAccount.Test.SuperDigital.ResponseTest;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OperationAccount.Test.SuperDigital
{
    [TestCaseOrderer("OperationAccount.Test.SuperDigital.Config.PriorityOrderer", "OperationAccount.Test.SuperDigital")]
    [Collection(nameof(ApiTestsFixtureCollection))]
    public class ContaTest
    {
        private readonly TestsFixture<StartupApiTest> _testsFixture;
        public ContaTest(TestsFixture<StartupApiTest> testsFixture)
        {
            _testsFixture = testsFixture;
        }


        [Fact(DisplayName = "Realizar transferencia bancaria com sucesso"), TestPriority(2)]
        [Trait("Conta", "Integração Api v1 - Conta")]
        public async Task Conta_RealizarTransferencia_Sucesso()
        {
            //Arrange
            var url = $"api/v1/conta/Transferencia";
            var userViewModel = _testsFixture.GerarLancamento();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            var postRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            // Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);

            // Assert
            postResponse.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<Response>(await postResponse.Content.ReadAsStringAsync());
            var isOk = result.success;
            Assert.True(isOk);
        }

        [Fact(DisplayName = "Realizar criação de conta bancaria com sucesso"),TestPriority(1)]
        [Trait("Conta", "Integração Api v1 - Conta")]
        public async Task Conta_CriarConta_Sucesso()
        {
            //Arrange
            var url = $"api/v1/conta/CriarConta";
            var userViewModel = _testsFixture.ObterClientesVariados();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            var postRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            // Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);

            // Assert
            postResponse.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<ResponseConta>(await postResponse.Content.ReadAsStringAsync());
            var isOk = result.success;
            var contaArray = result.data.ToArray();
         
                _testsFixture.numeroOrigem = contaArray[0].Numero;
                _testsFixture.cpforigem = contaArray[0].Cliente.Cpf;

                _testsFixture.numeroDestino = contaArray[1].Numero;
                _testsFixture.cpfDestino = contaArray[1].Cliente.Cpf;

            Assert.True(isOk);

        }
    }
}
