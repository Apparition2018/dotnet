# Base Types

---
## [在匿名类型和元组类型之间进行选择](https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/choosing-between-anonymous-and-tuple#key-differences)
| 名称              | 访问修饰符    | 类型     | 自定义成员变量 | 析构支持 | 表达式树支持 |
|-----------------|----------|--------|:-------:|:----:|:------:|
| Anonymous Types | internal | class  |    √    |  ×   |   √    |
| Tuple           | public   | class  |    ×    |  ×   |   √    |
| ValueTuple      | public   | struct |    √    |  √   |   ×    |
---
