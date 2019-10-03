using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VersioningDemoCore.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Route("api/v{version:apiVersion}/[controller]" )]
    public class ConcernsController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> GetConcerns()
        {
            return new[] { "Hello", "you" };
        }
    }
}