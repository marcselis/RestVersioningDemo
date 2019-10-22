using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VersioningDemoCore.Mapping;
using VersioningDemo.Domain;
using VersioningDemo.DataAccess;
using ConcernModel = VersioningDemoCore.V1.Models.Concern;
using System.Globalization;

namespace VersioningDemoCore.V1.Controllers
{
    /// <summary>
    /// Controller that handles version 1 of the Concern access
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Route( "v{version:apiVersion}/[controller]" )]
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
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ConcernModel>), 200)]
        [HttpGet]
        public IEnumerable<ConcernModel> GetConcerns()
        {
            return _outMapper.MapAll(DataAccess.GetConcerns());
        }

        /// <summary>
        /// Returns the requested concern.
        /// </summary>
        /// <param name="id">The id of the concern to get.</param>
        /// <returns>A <see cref="ConcernModel"/> instance with the data about the requested concern.</returns>
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( ConcernModel ), 200 )]
        [ProducesResponseType( 404 )]
        [HttpGet("{id:int}")]
        public ActionResult<ConcernModel> GetConcern(int id)
        {
            Concern input = DataAccess.GetConcern(id.ToString("D4", CultureInfo.InvariantCulture));
            if (input == null)
                return NotFound();
            ConcernModel? concern = _outMapper.Map(input);
            if (concern == null)
                return NotFound();
            return concern;
        }

    }
}
