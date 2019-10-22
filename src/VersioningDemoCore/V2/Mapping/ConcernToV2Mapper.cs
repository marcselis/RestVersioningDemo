using System.Collections.Generic;
using System.Linq;
using VersioningDemoCore.Mapping;
using VersioningDemo.Domain;

namespace VersioningDemoCore.V2.Mapping
{
    /// <summary>
    /// Mapper class to map <see cref="Concern"/> business object instances to version 2 of the <see cref="Models.Concern"/> DTOs.
    /// </summary>
    public class ConcernToV2Mapper : IMapper<Concern, Models.Concern>
    {
        /// <summary>
        /// Maps a <see cref="Concern"/> business object instance to a <see cref="Models.Concern"/> instance.
        /// </summary>
        /// <param name="input">The object to map.</param>
        /// <returns>A <see cref="Models.Concern"/> instance.</returns>
        public V2.Models.Concern? Map(Concern? input)
        {
            if (input == null) return null;
            return new V2.Models.Concern {Name = input.Name, Nr = input.Number};
        }

        /// <summary>
        /// Maps a enumerable list of <see cref="Concern"/> business object instances to an enumerable list of <see cref="Models.Concern"/> instances.
        /// </summary>
        /// <param name="input">The list of objects to map.</param>
        /// <returns>A list of <see cref="Models.Concern"/> instances.</returns>
        public IEnumerable<V2.Models.Concern> MapAll(IEnumerable<Concern>? input)
        {
            if (input == null) yield break;
            foreach(var e in input.Select(Map))
            {
                if (e != null)
                    yield return e;
            }
        }
    }
}