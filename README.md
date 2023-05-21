# MoreLinq

A C# library that provides useful LINQ extension methods.

Located in the `System.Linq.EnumerableExtensions` static class, **MoreLinq**'s extension methods cover many common use cases related to `IEnumerable<T>`, including but not limited to:

- Getting all elements after or before a value
- Getting all elements between two indexes
- Using lambda expressions and method groups syntax for one-liner `foreach` loops
- Inserting a value at an index
- Interspersing a value between every element
- Getting all elements that are not `null`
- Getting all possible combinations of pairs of elements
- Getting a random element
- Shuffling all elements

and more.

Almost all extension methods are pure and declarative, keeping to true LINQ and functional programming spirit.

# Installation

**MoreLinq** is available as a [NuGet package](https://www.nuget.org/packages/Carnagion.MoreLinq/) for .NET 6.0