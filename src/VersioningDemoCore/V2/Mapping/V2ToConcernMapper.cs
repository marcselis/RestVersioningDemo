using System.Collections.Generic;
using System.Linq;
using VersioningDemoCore.Mapping;
using VersioningDemo.Domain;

namespace VersioningDemoCore.V2.Mapping
{
    /// <summary>
    /// Mapper class to map incoming instances of version 2 of the <see cref="Concern"/> DTO to <see cref="Concern"/> business objects.
    /// </summary>
    public class V2ToConcernMapper : IMapper<Models.Concern, Concern>
    {
        /// <summary>
        /// Maps a <see cref="Models.Concern"/> DTO to a <see cref="Concern"/> business object.
        /// </summary>
        /// <param name="input">The object to map.</param>
        /// <returns>The mapped <see cref="Concern"/> instance.</returns>
        public Concern? Map(Models.Concern? input)
        {
            if (input == null) return null;
            return new Concern(input.Nr, input.Name);
        }

        /// <summary>
        /// Maps a enumerable list of <see cref="Models.Concern"/> DTOs to an enumerable list of <see cref="Concern"/> instances.
        /// </summary>
        /// <param name="input">The list of objects to map.</param>
        /// <returns>A list of <see cref="Concern"/> instances.</returns>
        public IEnumerable<Concern> MapAll(IEnumerable<Models.Concern>? input)
        {
            if (input == null) yield break;
            foreach (var e in input.Select(Map))
            {
                if (e != null)
                    yield return e;
            }
        }
    }

}