using Matech.Common.Scaffolding.Core.ServiceInterfaces;
using Matech.Common.Scaffolding.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Matech.Common.Scaffolding.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<ITestService, TestService>();

            return services;
       }
    }
}
