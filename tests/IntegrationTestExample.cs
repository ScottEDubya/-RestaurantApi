using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RestaurantApi;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests
{
    public class IntegrationTestExample : IDisposable
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public IntegrationTestExample()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Development"));
            _client = _server.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Fact]
        public async Task GetMeals_WhenNoneExist_ReturnsEmptyArray()
        {
            //Arrange
            //set up empty db TODO

            // Act
            var response = await _client.GetAsync("/api/meals");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains(responseString, "[]");
        }
    }
}