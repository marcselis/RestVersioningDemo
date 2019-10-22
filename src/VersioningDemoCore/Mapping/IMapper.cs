using System.Collections.Generic;

namespace VersioningDemoCore.Mapping
{
    /// <summary>
    /// Generic mapper interface to map business objects to DTO's or vice versa.
    /// </summary>
    /// <typeparam name="TIn">The input type to map from.</typeparam>
    /// <typeparam name="TOut">The output type to map to</typeparam>
    public interface IMapper<in TIn, out TOut> where TIn : class where TOut : class
    {
        /// <summary>
        /// Maps the input object to the type. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        TOut? Map(TIn? input);
        /// <summary>
        /// Maps an <see cref="IEnumerable{TIn}"/> with input type instances to an <see cref="IEnumerable{TOut}"/> of output types.
        /// </summary>
        /// <param name="input">The object to map</param>
        /// <returns>The mapped result</returns>
        IEnumerable<TOut> MapAll(IEnumerable<TIn>? input);
    }
}