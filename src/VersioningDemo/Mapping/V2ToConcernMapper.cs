using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Models.V2;
#nullable enable

namespace VersioningDemo.Mapping
{
    public class V2ToConcernMapper : IMapper<Concern, Domain.Concern>
    {
        public Domain.Concern? Map(Concern? input)
        {
            if (input == null) return null;
            return new Domain.Concern(input.Nr, input.Name);
        }

        public IEnumerable<Domain.Concern> MapAll(IEnumerable<Concern> input)
        {
            if (input == null) yield break;
            foreach (var e in input.Select(Map))
                if (e != null)
                    yield return e;
        }
    }

}