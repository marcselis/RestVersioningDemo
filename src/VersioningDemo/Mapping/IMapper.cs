using System.Collections.Generic;

namespace VersioningDemo.Mapping
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn input);
        IEnumerable<TOut> MapAll(IEnumerable<TIn> input);
    }
}