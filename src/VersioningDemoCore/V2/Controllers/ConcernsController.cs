using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VersioningDemoCore.Mapping;
using VersioningDemo.DataAccess;
using VersioningDemo.Domain;
using ConcernModel = VersioningDemoCore.V2.Models.Concern;

namespace VersioningDemoCore.V2.Controllers
{
    /// <summary>
    /// Controller that handles version 2 of the Concern access
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ConcernsController : ControllerBase
    {
        private readonly IMapper<Concern, ConcernModel> _outMapper;

        /// <summary>
        /// Creates a new ConcernsController instance.
        /// </summary>
        /// <param name="outMapper">An <see cref="IMapper{Concern, ConcernModel}"/> instance to do the mapping between the business objecs and the DTOs."</param>
        public ConcernsController(IMapper<Concern, ConcernModel> outMapper)
        {
            _outMapper = outMapper;
        }

        /// <summary>
        /// Gets a list of all available concerns
        /// </summary>
        /// <returns>an <see cref="IEnumerable{ConcernModel}"/> containging all available concerns</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ConcernModel>), 200)]
        public IEnumerable<ConcernModel> GetConcerns()
        {
            return _outMapper.MapAll(DataAccess.GetConcerns());
        }

        /// <summary>
        /// Returns the requested concern.
        /// </summary>
        /// <param name="id">The id of the concern to get.</param>
        /// <returns>A <see cref="ConcernModel"/> instance with the data about the requested concern.</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ConcernModel), 200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ConcernModel GetConcern(string id)
        {
            return _outMapper.Map(DataAccess.GetConcern(id));
        }
    }
}