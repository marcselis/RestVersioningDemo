using System.Collections.Generic;
#nullable enable

namespace VersioningDemo.Mapping
{
    public interface IMapper<in TIn, out TOut> where TIn:class where TOut : class
    {
        TOut? Map(TIn? input);
        IEnumerable<TOut> MapAll(IEnumerable<TIn> input);
    }
}