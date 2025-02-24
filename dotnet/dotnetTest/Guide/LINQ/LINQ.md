# [LINQ](https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/)
- Language Integrated Query（语言集成查询）
---
## [查询表达式](https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/get-started/query-expression-basics)
- 定义：以 Query Syntax（查询语法）表示的查询
- 必须以 `from` 子句开头，且必须以 `select` 或 `group` 子句结尾
### [查询关键字](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/query-keywords)
- `into` 上下文关键字创建临时标识符，将 `group`、`join` 或 `select` 子句的结果存储至新标识符
- `let` 关键字创建一个新的范围变量，并通过提供的表达式结果初始化该变量
### 查询变量
- 定义：存储查询，而不是存储查询结果。始终是可枚举类型
- @see [EagerAndLazyQueryExecution](EagerAndLazyQueryExecution.cs) `LazyQuery` vs `EagerQuery`
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
## [并行 LINQ (PLINQ)](https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/introduction-to-plinq)

---
