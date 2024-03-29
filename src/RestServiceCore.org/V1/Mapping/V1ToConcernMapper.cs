﻿using System.Collections.Generic;
using System.Linq;
using RestServiceCore.Mapping;
using RestServiceCore.V1.Models;

namespace RestServiceCore.V1.Mapping
{
    public class V1ToConcernMapper : IMapper<Concern, VersioningDemo.Domain.Concern>
    {
        public VersioningDemo.Domain.Concern Map(Concern input)
        {
            return new VersioningDemo.Domain.Concern(input.Number.ToString(), input.Name);
        }

        public IEnumerable<VersioningDemo.Domain.Concern> MapAll(IEnumerable<Concern> input) => input.Select(Map);
    }
}