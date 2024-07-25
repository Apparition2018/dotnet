# LINQ
- Language Integrated Query
---
## Reference
1. [语言集成查询 (LINQ) | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/)
2. [C# 高级 | Microsoft Learn](https://learn.microsoft.com/zh-cn/shows/c-advanced/)
---
## try-samples
- 安装 dotnet-try
    ```shell
    dotnet tool install -g Microsoft.dotnet-try
    dotnet tool uninstall -g Microsoft.dotnet-try
    dotnet tool update -g Microsoft.dotnet-try
    ```
- [克隆项目](https://github.com/dotnet/try-samples)
- `cd %TRY_SAMPLES_HOME%` → `dotnet try`
- [101 LINQ Samples](https://localhost:6291/101-linq-samples/index.md)
### [Restriction operators](RestrictionOperators.cs)
| Method Name | C# Query Expression Syntax |
|-------------|----------------------------|
| OfType      |                            |
| Where       | where                      |
### [Projection operators](ProjectionOperators.cs)
| Method Name | C# Query Expression Syntax  |
|-------------|-----------------------------|
| Select      | select                      |
| SelectMany  | Use multiple `from` clauses |
| Zip         |                             |
### [Partition operators](PartitionOperators.cs)
- `Skip`, `SkipWhile`, `Take`, `TakeWhile`, `Chunk`
### [Ordering operators](OrderingOperators.cs)
| Method Name       | C# Query Expression Syntax |
|-------------------|----------------------------|
| OrderBy           | orderby                    |
| OrderByDescending | orderby … descending       |
| ThenBy            | orderby …, …               |
| ThenByDescending  | orderby …, … descending    |
| Reverse           |                            |
### [Grouping operators](GroupingOperators.cs)
| Method Name | C# Query Expression Syntax            |
|-------------|---------------------------------------|
| GroupBy     | `group … by` or `group … by … into …` |
| ToLookup    |                                       |
### [Set Operators](SetOperators.cs)
- `Distinct`, `DistinctBy`, `Except`, `ExceptBy`, `Intersect`, `IntersectBy`, `Union`, `UnionBy`
### [Conversion operators](ConversionOperators.cs)
- `AsENumberable`, `AsQueryable`, `OfType`, `ToArray`, `ToDictionary`, `ToList`, `ToLookup`

| Method Name  | C# Query Expression Syntax                                              |
|--------------|-------------------------------------------------------------------------|
| Cast         | Use an explicitly typed range variable (eg: `from string str in words`) |
### [Element operators](ElementOperators.cs)
- `First`, `FirstOrDefault`, `ElementAt`
### [Generate sequences](GenerateSequences.cs)
- `Range`, `Repeat`
### [Quantifying members](QuantifyingMembers.cs)
- `Any`, `All`， `Contains`
### [Aggregator operators](AggregatorOperators.cs)
- `Count`, `Sum`, `Min`, `Max`, `Average`, `Aggregate`
### [Sequence operations](SequenceOperations.cs)
- `SequenceEqual`, `Concat`, `Zip`
### [Eager and lazy query execution](EagerAndLazyQueryExecution.cs)
### [Join operations](JoinOperations.cs)
| Method Name | C# Query Expression Syntax       |
|-------------|----------------------------------|
| Join        | join … in … on … equals …        |
| GroupJoin   | join … in … on … equals … into … |
---
