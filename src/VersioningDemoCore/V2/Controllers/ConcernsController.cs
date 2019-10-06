using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VersioningDemoCore.Mapping;
using VersioningDemo.DataAccess;
using VersioningDemo.Domain;

namespace VersioningDemoCore.V2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ConcernsController : ControllerBase
    {
        private readonly IMapper<Concern, Models.Concern> _outMapper;

        public ConcernsController(IMapper<Concern, Models.Concern> outMapper)
        {
            _outMapper = outMapper;
        }

        [HttpGet]
        public IEnumerable<Models.Concern> GetConcerns()
        {
            return _outMapper.MapAll(DataAccess.GetConcerns());
        }

        [HttpGet("{id}")]
        public Models.Concern GetConcern(string id)
        {
            return _outMapper.Map(DataAccess.GetConcern(id));
        }
    }
}