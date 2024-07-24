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
### [Restriction operators](RestrictionOperators.cs): `where`
### [Projection operators](ProjectionOperators.cs): `select`
### [Partition operators](PartitionOperators.cs): `Take`, `Skip`, `TakeWhile`, `SkipWhile`
### [Ordering operators](OrderingOperators.cs): `orderby`
### [Grouping operators](GroupingOperators.cs): `group … by … into`
### [Set Operators](SetOperators.cs): `Distinct`, `Union`, `Intersect`, `Except`
### [Conversion operators](ConversionOperators.cs): `ToArray`, `ToList`, `ToDictionary`, `OfType`
### [Element operators](ElementOperators.cs): `First`, `FirstOrDefault`, `ElementAt`
### [Generate sequences](GenerateSequences.cs): `Range`, `Repeat`
### [Quantifying members](QuantifyingMembers.cs): `Any`, `All`
### [Aggregator operators](AggregatorOperators.cs): `Count`, `Sum`, `Min`, `Max`, `Average`, `Aggregate`
### [Sequence operations](SequenceOperations.cs): `SequenceEqual`, `Concat`, `Zip`
### [Eager and lazy query execution](EagerAndLazyQueryExecution.cs)
### [Join operations](JoinOperations.cs): `join`

---
