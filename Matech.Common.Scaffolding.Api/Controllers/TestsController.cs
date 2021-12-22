using System.Linq;
using System.Net;
using AutoMapper;
using Matech.Common.Scaffolding.Api.Contracts.Requests;
using Matech.Common.Scaffolding.Core.Entities;
using Matech.Common.Scaffolding.Core.ServiceInterfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Matech.Common.Scaffolding.Api.Controllers
{
    /// <summary>
    /// Comments 
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]    
    public class TestsController : ControllerBase
    {
        private readonly ILogger<TestsController> _logger;
        private readonly ITestService _testService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="testService"></param>
        /// <param name="mapper"></param>
        public TestsController(ILogger<TestsController> logger, ITestService testService, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _testService = testService;
        }

        /// <summary>
        /// OData GET Example endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IQueryable<TestEntity> Get()
        {
            return _testService.GetAsQueryable();
        }

        /// <summary>
        /// Endpoint to add a new example resource
        /// </summary>
        /// <param name="request"> request object to add a new resource </param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Post(TestPostRequest request)
        {
            _testService.InsertAsync(_mapper.Map<TestEntity>(request));

            return Ok();
        }
    }
}
