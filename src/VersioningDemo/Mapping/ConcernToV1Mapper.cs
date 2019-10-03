using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Domain;

namespace VersioningDemo.Mapping
{
    public class ConcernToV1Mapper : IMapper<Concern, Models.V1.Concern>
    {
        public Models.V1.Concern Map(Concern input)
        {
            return uint.TryParse(input.Number, out var number) ? new Models.V1.Concern {Name = input.Name, Number = number} : null;
        }

        public IEnumerable<Models.V1.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map).Where(concern => concern!=null);
    }
}