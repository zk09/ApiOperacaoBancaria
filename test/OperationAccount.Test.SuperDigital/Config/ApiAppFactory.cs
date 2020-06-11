using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace OperationAccount.Test.SuperDigital.Config
{
    public class ApiAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.UseStartup<TStartup>();

        }

        protected override TestServer CreateServer(IWebHostBuilder builder)
        {

             return base.CreateServer(builder);
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var host = new WebHostBuilder()
               .ConfigureAppConfiguration((context, config) =>
               {

                   var builtConfig = config.Build();
               });

            return host;
        }
    }
}
