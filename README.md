# Iterators

## Intro

A library to provide exclusive iterators (.NET `IEnumerable`) balancing performance and design. Currently, there are the following implementations:
* `JaggedArrayEnumerable` - an enumerable, sequential forward-only access, for jagged arrays (i.e. `int[][]`)
* `MultidimensionalArrayEnumerable` - an enumerable, sequential forward-only access, for matrixies

Both implementations use `ref struct` to avoid GC pressure (allocating on heap memory).

State: alpha
