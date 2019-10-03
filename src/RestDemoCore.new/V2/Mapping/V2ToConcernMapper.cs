using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Mapping;
using VersioningDemo.V2.Models;

namespace VersioningDemo.V2.Mapping
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