using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class HomeTest
    {
        private readonly TestApplication app;

        public HomeTest()
        {
            app = new TestApplication();
        }

        [Fact(Skip = "not implememted")]
        public async Task Should_pass_helth_check()
        {
            using var client = app.CreateClient();
            var query = new Dictionary<string, string> { ["name"] = "test" };

            using var response = await client.GetAsync(QueryHelpers.AddQueryString("/", query!));

            var message = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Hello, test!", message);
        }
    }
}