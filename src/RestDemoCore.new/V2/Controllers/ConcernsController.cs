using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VersioningDemo.Domain;
using VersioningDemo.Mapping;

namespace VersioningDemo.V2.Controllers
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
            return _outMapper.MapAll(DataAccess.DataAccess.GetConcerns());
        }

        [HttpGet("{id}")]
        public Models.Concern GetConcern(string id)
        {
            return _outMapper.Map(DataAccess.DataAccess.GetConcern(id));
        }
    }
}