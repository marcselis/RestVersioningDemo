using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Models.V1;

namespace VersioningDemo.Mapping
{
    public class V1ToConcernMapper : IMapper<Concern, Domain.Concern>
    {
        public Domain.Concern Map(Concern input)
        {
            return new Domain.Concern(input.Number.ToString(), input.Name);
        }

        public IEnumerable<Domain.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map);
    }
}