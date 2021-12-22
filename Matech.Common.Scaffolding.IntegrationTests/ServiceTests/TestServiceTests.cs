using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Matech.Common.Scaffolding.Core.Entities;
using NUnit.Framework;

namespace Matech.Common.Scaffolding.IntegrationTests.ServiceTests
{
    public class TestServiceTests : TestBase
    {
        [Test]
        public async Task InsertShouldPersistAndEnsureData()
        {
            var service = GetTestService();

            await service.InsertAsync(new TestEntity { TestProperty = "test", Id = 10 });

            var results = await service.GetAsync();

            var toStringList = results.Select(x => x.TestProperty).ToList();

            toStringList.Should().Contain("test");
        }      
    }
}
