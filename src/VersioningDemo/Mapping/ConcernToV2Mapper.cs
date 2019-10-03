using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Domain;

namespace VersioningDemo.Mapping
{
    public class ConcernToV2Mapper : IMapper<Concern, Models.V2.Concern>
    {
        public Models.V2.Concern Map(Concern input)
        {
            return new Models.V2.Concern {Name = input.Name, Nr = input.Number};
        }

        public IEnumerable<Models.V2.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map);
    }
}