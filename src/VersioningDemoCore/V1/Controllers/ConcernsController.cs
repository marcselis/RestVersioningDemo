﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VersioningDemoCore.Mapping;
using VersioningDemo.Domain;

namespace VersioningDemoCore.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route( "v{version:apiVersion}/[controller]" )]
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
            return _outMapper.MapAll(VersioningDemo.DataAccess.DataAccess.GetConcerns());
        }

    }
}
