using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matech.Common.Scaffolding.Core.Entities;
using Matech.Common.Scaffolding.Core.RepositoryInterfaces;
using Matech.Common.Scaffolding.Core.ServiceInterfaces;
using Matech.Common.Scaffolding.Core.UnitOfWorks;
using RestSharp;

namespace Matech.Common.Scaffolding.Service.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TestService(ITestRepository testRepository, IUnitOfWork unitOfWork)
        {
            _testRepository = testRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<TestEntity> GetAsQueryable()
        {
            return _testRepository.GetAsQueryable();
        }

        public async Task<IEnumerable<TestEntity>> GetAsync()
        {
            return await _testRepository.GetAsync();
        }

        public async Task InsertAsync(TestEntity entity)
        {
            await _unitOfWork.TestRepository.InsertAsync(entity);

            await _unitOfWork.SaveAsync();
        }
    }
}
