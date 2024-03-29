﻿using System.Collections.Generic;
using System.Web.Http;
using JetBrains.Annotations;
using VersioningDemo.Domain;
using VersioningDemo.Mapping;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace VersioningDemo.Controllers.V1_0
#pragma warning restore CA1707 // Identifiers should not contain underscores
{
    [RoutePrefix("Concerns")]
    public class ConcernController : ApiController
    {
        private readonly IMapper<Concern, Models.V1.Concern> _outMapper;

        public ConcernController([NotNull]IMapper<Concern, Models.V1.Concern> outMapper)
        {
            _outMapper = outMapper;
        }

        [Route]
        public IEnumerable<Models.V1.Concern> GetConcerns()
        {
            return _outMapper.MapAll(DataAccess.DataAccess.GetConcerns());
        }

    }
}
