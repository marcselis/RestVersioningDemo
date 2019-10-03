using System.Collections.Generic;
using System.Linq;
using VersioningDemo.Domain;

namespace VersioningDemo.DataAccess
{
    public static class DataAccess
    {
        private static readonly List<Concern> Concerns = new List<Concern>
        {
            new Concern("1000", "Total"),
            new Concern("2000", "Fina"),
            new Concern("3000", "Q8"),
            new Concern("SHEL","Shell")
        };

        public static IEnumerable<Concern> GetConcerns()
        {
            //TODO: get concerns from database
            return Concerns;
        }

        public static Concern GetConcern(string nr)
        {
            return Concerns.FirstOrDefault(c => c.Number == nr);
        }
    }
}
