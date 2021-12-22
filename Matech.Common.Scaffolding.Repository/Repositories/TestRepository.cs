using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matech.Common.Repositories.Lib.EntityFramework;
using Matech.Common.Scaffolding.Core.Entities;
using Matech.Common.Scaffolding.Core.RepositoryInterfaces;
using Matech.Common.Scaffolding.Repository.Context;

namespace Matech.Common.Scaffolding.Repository.Repositories
{
    public class TestRepository : BaseRepository<TestEntity>, ITestRepository
    {
        private readonly TestDbContext _context;

        public TestRepository(TestDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TestEntity>> GetAsync()
        {
            return await base.GetAsync().ConfigureAwait(false);
        }

        public IQueryable<TestEntity> GetAsQueryable()
        {
            return  _context.TestEntities.AsQueryable();
        }

        public async Task InsertAsync(TestEntity entity)
        {
          await base.InsertAsync(entity).ConfigureAwait(false);
        }
    }
}
