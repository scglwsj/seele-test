using ConsighmentService.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace IntegrationTest
{
    public class TestApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(sp =>
                {
                    return new DbContextOptionsBuilder<PaymentContext>()
                    .UseInMemoryDatabase("ApiTests")
                    .UseApplicationServiceProvider(sp)
                    .Options;
                });
            });

            return base.CreateHost(builder);
        }
    }

}