using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VersioningDemo.Models.V1;
#nullable enable

namespace VersioningDemo.Mapping
{
    public class V1ToConcernMapper : IMapper<Concern, Domain.Concern>
    {
        public Domain.Concern? Map(Concern? input)
        {
            if (input == null) return null;
            return new Domain.Concern(input.Number.ToString("D4",CultureInfo.InvariantCulture), input.Name);
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