using Matech.Common.Scaffolding.Core.ServiceInterfaces;
using Matech.Common.Scaffolding.Repository.Context;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Matech.Common.Scaffolding.IntegrationTests
{
    public abstract class TestBase : TestInitialization
    {   
        protected IServiceScope scope;

        [SetUp]
        public void TestSetUp()
        {
            scope = ScopeFactory.CreateScope();
            scope.ServiceProvider.GetRequiredService<TestDbContext>();
        }

        protected ITestService GetTestService()
        {
            return scope.ServiceProvider.GetRequiredService<ITestService>();
        }
    }
}
