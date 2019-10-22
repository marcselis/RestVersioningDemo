using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Domain;
using ConcernModel = VersioningDemo.Models.V1.Concern;
#nullable enable

namespace VersioningDemo.Mapping
{
    public class ConcernToV1Mapper : IMapper<Concern, ConcernModel>
    {
        /// <summary>
        /// Maps a <see cref="Concern"/> business object instance to a <see cref="Models.Concern"/> instance.
        /// </summary>
        /// <param name="input">The object to map.</param>
        /// <returns>A <see cref="Models.Concern"/> instance.</returns>
        public ConcernModel? Map(Concern? input)
        {
            if (input == null) return null;
            return uint.TryParse(input.Number, out var number) ? new ConcernModel { Name = input.Name, Number = number } : null;
        }

        /// <summary>
        /// Maps a enumerable list of <see cref="Concern"/> business object instances to an enumerable list of <see cref="Models.Concern"/> instances.
        /// </summary>
        /// <param name="input">The list of objects to map.</param>
        /// <returns>A list of <see cref="Models.Concern"/> instances.</returns>
        public IEnumerable<ConcernModel> MapAll(IEnumerable<Concern>? input)
        {
            if (input == null) yield break;
            foreach (var e in input.Select(Map))
                if (e != null)
                    yield return e;
        }
    }
}