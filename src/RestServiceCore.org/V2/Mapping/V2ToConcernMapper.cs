using System.Collections.Generic;
using System.Linq;
using RestServiceCore.Mapping;
using RestServiceCore.V2.Models;

namespace RestServiceCore.V2.Mapping
{
    public class V2ToConcernMapper : IMapper<Concern, VersioningDemo.Domain.Concern>
    {
        public VersioningDemo.Domain.Concern Map(Concern input)
        {
            return new VersioningDemo.Domain.Concern(input.Nr, input.Name);
        }

        public IEnumerable<VersioningDemo.Domain.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map);
    }

}