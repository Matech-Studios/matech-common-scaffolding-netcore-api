using System.IO;
using Matech.Common.Scaffolding.Api;
using Matech.Common.Scaffolding.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Matech.Common.Scaffolding.IntegrationTests
{
    [TestFixture]
    public abstract class TestInitialization
    {
        private IConfigurationRoot _configuration;
        protected IServiceScopeFactory ScopeFactory;
       
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {           
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();
                      
            services.AddLogging();

            startup.ConfigureServices(services);

            ScopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
              
            EnsureDatabase();
        }

        private void EnsureDatabase()
        {
            using var scope = ScopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<TestDbContext>();
          
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            using var scope = ScopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<TestDbContext>();

            context.Database.EnsureDeleted();         
        }
    }
}
