using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matech.Common.Scaffolding.Core.Entities;

namespace Matech.Common.Scaffolding.Core.RepositoryInterfaces
{
    public interface ITestRepository
    {
        IQueryable<TestEntity> GetAsQueryable();

        Task<IEnumerable<TestEntity>> GetAsync();

        Task InsertAsync(TestEntity entity);
    }
}
