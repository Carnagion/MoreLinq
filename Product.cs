using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="byte"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static byte Product(this IEnumerable<byte> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => (byte)(current * next));
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="sbyte"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static sbyte Product(this IEnumerable<sbyte> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => (sbyte)(current * next));
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="short"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static short Product(this IEnumerable<short> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => (short)(current * next));
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="ushort"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static ushort Product(this IEnumerable<ushort> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => (ushort)(current * next));
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="int"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static int Product(this IEnumerable<int> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => current * next);
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="uint"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static uint Product(this IEnumerable<uint> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => current * next);
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="long"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static long Product(this IEnumerable<long> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => current * next);
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="ulong"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static ulong Product(this IEnumerable<ulong> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => current * next);
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="float"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static float Product(this IEnumerable<float> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => current * next);
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="double"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static double Product(this IEnumerable<double> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => current * next);
        }

        /// <summary>
        /// Computes the product of all elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> whose elements' product is to be computed.</param>
        /// <returns>The product of elements in <paramref name="source"/> as a <see cref="decimal"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static decimal Product(this IEnumerable<decimal> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Aggregate((current, next) => current * next);
        }
    }
}