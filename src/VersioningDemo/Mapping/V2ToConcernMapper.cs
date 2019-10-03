using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Models.V2;

namespace VersioningDemo.Mapping
{
    public class V2ToConcernMapper : IMapper<Concern, Domain.Concern>
    {
        public Domain.Concern Map(Concern input)
        {
            return new Domain.Concern(input.Nr, input.Name);
        }

        public IEnumerable<Domain.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map);
    }

}