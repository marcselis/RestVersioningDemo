using System.Collections.Generic;
using System.Linq;
using RestServiceCore.Mapping;
using VersioningDemo.Domain;

namespace RestServiceCore.V1.Mapping
{
    public class ConcernToV1Mapper : IMapper<Concern, V1.Models.Concern>
    {
        public V1.Models.Concern Map(Concern input)
        {
            return uint.TryParse(input.Number, out var number) ? new V1.Models.Concern {Name = input.Name, Number = number} : null;
        }

        public IEnumerable<V1.Models.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map).Where(concern => concern!=null);
    }
}