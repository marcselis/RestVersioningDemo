using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Mapping;
using VersioningDemo.Domain;

namespace VersioningDemo.V2.Mapping
{
    public class ConcernToV2Mapper : IMapper<Concern, V2.Models.Concern>
    {
        public V2.Models.Concern Map(Concern input)
        {
            return new V2.Models.Concern {Name = input.Name, Nr = input.Number};
        }

        public IEnumerable<V2.Models.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map);
    }
}