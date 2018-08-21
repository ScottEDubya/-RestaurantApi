using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestaurantApi;
using RestaurantApi.Data;
using System;
using System.Net.Http;

namespace tests
{
    public class TestFixture : IDisposable
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;
        protected readonly AppDbContext _db;

        public TestFixture()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Development"));
            _client = _server.CreateClient();

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(connection);

            _db = new AppDbContext(optionsBuilder.Options);
            _db.Database.OpenConnection();
            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }
    }
}