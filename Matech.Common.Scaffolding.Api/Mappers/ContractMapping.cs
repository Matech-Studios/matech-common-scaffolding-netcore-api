using AutoMapper;
using Matech.Common.Scaffolding.Api.Contracts.Requests;
using Matech.Common.Scaffolding.Api.Contracts.Responses;
using Matech.Common.Scaffolding.Core.Entities;

namespace Matech.Common.Scaffolding.Api.Mappers
{
    public class ContractMapping : Profile
    {
        public ContractMapping()
        {
            CreateMap<TestEntity,TestGetResponse>();

            CreateMap<TestPostRequest, TestEntity>();
        }
    }
}
