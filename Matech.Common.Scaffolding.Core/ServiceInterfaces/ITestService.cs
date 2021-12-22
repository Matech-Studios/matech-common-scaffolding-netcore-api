using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matech.Common.Scaffolding.Core.Entities;

namespace Matech.Common.Scaffolding.Core.ServiceInterfaces
{
    public interface ITestService
    {
        Task<IEnumerable<TestEntity>> GetAsync();

        Task InsertAsync(TestEntity entity);

        IQueryable<TestEntity> GetAsQueryable();
    }
}
