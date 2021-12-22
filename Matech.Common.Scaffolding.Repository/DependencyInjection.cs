using System;
using Matech.Common.Scaffolding.Core.RepositoryInterfaces;
using Matech.Common.Scaffolding.Core.UnitOfWorks;
using Matech.Common.Scaffolding.Repository.Context;
using Matech.Common.Scaffolding.Repository.Repositories;
using Matech.Common.Scaffolding.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Matech.Common.Scaffolding.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<TestDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"));
            }
            else
            {
                services.AddDbContext<TestDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"), opts =>
                         opts.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2), new string[] { })));
            }

            services.AddScoped<ITestDbContext>(provider => provider.GetService<TestDbContext>());

            services.AddReppositories();

            services.AddUnitOfWorks();

            return services;
        }

        private static IServiceCollection AddReppositories(this IServiceCollection services)
        {
            services.AddTransient<ITestRepository, TestRepository>();

            return services;
        }

        private static IServiceCollection AddUnitOfWorks(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
