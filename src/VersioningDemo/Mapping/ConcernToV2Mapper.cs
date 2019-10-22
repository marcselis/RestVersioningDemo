using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Domain;
using ConcernModel = VersioningDemo.Models.V2.Concern;
#nullable enable

namespace VersioningDemo.Mapping
{
    public class ConcernToV2Mapper : IMapper<Concern, ConcernModel>
    {
        public ConcernModel? Map(Concern? input)
        {
            if (input == null)
                return null;
            return new ConcernModel { Name = input.Name, Nr = input.Number};
        }

        public IEnumerable<ConcernModel> MapAll(IEnumerable<Concern> input)
        {
            if (input == null) yield break;
            foreach (var e in input.Select(Map))
                if (e != null)
                    yield return e;

        }
    }
}