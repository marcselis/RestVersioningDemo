using System.Collections.Generic;
using System.Web.Http;
using VersioningDemo.Domain;
using VersioningDemo.Mapping;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace VersioningDemo.Controllers.V2_0
#pragma warning restore CA1707 // Identifiers should not contain underscores
{
    [RoutePrefix("Concerns")]
    public class ConcernController : ApiController
    {
        private readonly IMapper<Concern, Models.V2.Concern> _outMapper;

        public ConcernController(IMapper<Concern, Models.V2.Concern> outMapper)
        {
            _outMapper = outMapper;
        }

        [Route]
        public IEnumerable<Models.V2.Concern> GetConcerns()
        {
            return _outMapper.MapAll(DataAccess.DataAccess.GetConcerns());
        }
    }
}
