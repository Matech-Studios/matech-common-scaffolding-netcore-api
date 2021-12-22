using System.Threading.Tasks;
using Matech.Common.Scaffolding.Core.RepositoryInterfaces;
using Matech.Common.Scaffolding.Core.UnitOfWorks;
using Matech.Common.Scaffolding.Repository.Context;

namespace Matech.Common.Scaffolding.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDbContext _context;

        public UnitOfWork(TestDbContext context, ITestRepository testRepository)
        {
            _context = context;
            TestRepository = testRepository;
        }

        public ITestRepository TestRepository { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
