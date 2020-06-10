namespace Shakespeareanator.Tests.Integration
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.Hosting;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class BasicIntegrationTest
    {
        [Theory]
        [InlineData("pokemon", "ditto", "foe's genetic code", 200)]
        [InlineData("pokemon", "marco", "There was an error while processing your request", 404)]
        //[InlineData("pokemon", "marco", "There was an error while processing your request", 200)]
        public async Task CanGetPokemonDescription(string endpoint, string name, string responseMessage, int statusCode)
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<Api.Startup>();
                });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync($"/{endpoint}/{name}");

            // Assert
            if (response.StatusCode != HttpStatusCode.TooManyRequests)
            {
                response.StatusCode.Should().Be(statusCode);
                var responseString = await response.Content.ReadAsStringAsync();
                responseString.Should().Contain(responseMessage);
            }
        }
    }
}
