using Matech.Common.Scaffolding.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matech.Common.Scaffolding.Repository.Context
{
    public interface ITestDbContext
    {
        DbSet<TestEntity> TestEntities { get; set; }
    }
}
