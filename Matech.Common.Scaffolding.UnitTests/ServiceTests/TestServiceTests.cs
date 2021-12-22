using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Matech.Common.Scaffolding.Core.Entities;
using Matech.Common.Scaffolding.Core.RepositoryInterfaces;
using Matech.Common.Scaffolding.Core.ServiceInterfaces;
using Matech.Common.Scaffolding.Core.UnitOfWorks;
using Matech.Common.Scaffolding.Service.Services;
using Moq;
using NUnit.Framework;

namespace Matech.Common.Scaffolding.UnitTests.ServiceTests
{
    public class TestServiceTests
    {
        private readonly Mock<ITestRepository> _testRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ITestService _testService;

        public TestServiceTests()
        {
            _testRepository = new Mock<ITestRepository>(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _testService = new TestService(_testRepository.Object, _unitOfWork.Object);
        }

        [Test]
        public async Task GetShouldReturnMockedValues()
        {
            _testRepository.Setup(x => x.GetAsync()).ReturnsAsync(new List<TestEntity> { new TestEntity { Id = 1, TestProperty = "TestValue" } });
           
            var result = await _testService.GetAsync();

            result.Should().HaveCount(1);

            VerifyAll();
        }

        [Test]
        public async Task InsertShouldPersistMockedValues()
        {
            var testEntity = new TestEntity { TestProperty = "TestValue" };

            _testRepository.Setup(x => x.InsertAsync(It.Is<TestEntity>(p => p.TestProperty == testEntity.TestProperty)))
                .Returns(Task.CompletedTask);

            _unitOfWork.SetupGet(x => x.TestRepository).Returns(_testRepository.Object);

            _unitOfWork.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            await _testService.InsertAsync(testEntity);           

            VerifyAll();
        }
        

        private void VerifyAll()
        {
            _testRepository.VerifyAll();
            _unitOfWork.VerifyAll();
        }
    }
}
