using System;
using AutoMapper;
using Matech.Common.Scaffolding.Api.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Matech.Common.Scaffolding.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddMappers(this IServiceCollection services)
        {
           services.AddAutoMapper(new Type[] { typeof(ContractMapping) });
        }
    }
}
