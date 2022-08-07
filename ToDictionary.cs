using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Converts <paramref name="source"/> to a <see cref="Dictionary{TKey,TValue}"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of key-value pairs to convert.</param>
        /// <typeparam name="TKey">The <see cref="Type"/> of keys.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of values.</typeparam>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> containing keys and values from <paramref name="source"/>.</returns>
        [Pure]
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TKey : notnull
        {
            return source.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
    }
}