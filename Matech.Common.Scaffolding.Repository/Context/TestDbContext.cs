using System.Reflection;
using Matech.Common.Scaffolding.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Matech.Common.Scaffolding.Repository.Context
{
    public class TestDbContext : DbContext, ITestDbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<TestEntity> TestEntities { get; set; }

        public TestDbContext(IConfiguration configuration)
         : base()
        {
            this.configuration = configuration;
        }

        public TestDbContext(IConfiguration configuration, DbContextOptions<TestDbContext> options)
            : base(options)
        {
            this.configuration = configuration;
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TestEntity>().HasData(
                new TestEntity { Id = 1, TestProperty = "TestPropertyOne", AnotherProperty = "AnotherPropertyOne" },
                new TestEntity { Id = 2, TestProperty = "TestPropertyTwo", AnotherProperty = "AnotherPropertyTwo" },
                new TestEntity { Id = 3, TestProperty = "TestPropertyThree", AnotherProperty = "AnotherPropertyThree" },
                new TestEntity { Id = 4, TestProperty = null, AnotherProperty = "AnotherPropertyFour" },
                new TestEntity { Id = 5, TestProperty = " ", AnotherProperty = "AnotherProperty" },
                new TestEntity { Id = 6, TestProperty = string.Empty, AnotherProperty = null },
                new TestEntity { Id = 7, TestProperty = "TestPropertyOne", AnotherProperty = "7" },
                new TestEntity { Id = 8, TestProperty = "TestPropertYEight", AnotherProperty = "AnotherPropertyOne" });

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
