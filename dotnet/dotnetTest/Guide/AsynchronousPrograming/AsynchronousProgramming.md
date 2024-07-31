# [异步编程](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/)

---
## [异步编程场景](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/async-scenarios)
### [要点](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/async-scenarios#key-pieces-to-understand)
- 异步代码可用于 I/O 绑定和 CPU 绑定代码，但在每个方案中有所不同。
- 异步代码使用 Task<T> 和 Task，它们是对后台所完成的工作进行建模的结构。
- async 关键字将方法转换为异步方法，这使你能在其正文中使用 await 关键字。
- 应用 await 关键字后，它将挂起调用方法，并将控制权返还给调用方，直到等待的任务完成。
- 仅允许在异步方法中使用 await
### [识别 CPU 绑定和 I/O 绑定工作](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/async-scenarios#recognize-cpu-bound-and-io-bound-work)
1. I/O 绑定：“等待”某些内容，例如数据库中的数据
    - 使用 async 和 await
    - 不使用任务并行库
2. CPU 绑定：执行开销巨大的计算
    - 使用 async 和 await，在另一个线程上使用 Task.Run 生成工作
    - 如果该工作同时适用于并发和并行，还应考虑使用任务并行库
### [重要信息和建议](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/async-scenarios#important-info-and-advice)

---
## [异步编程模型](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)
### [典型区域](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model#BKMK_WhentoUseAsynchrony)
| Application area | .NET types                                                               | Windows Runtime types                            |
|------------------|--------------------------------------------------------------------------|--------------------------------------------------|
| Web access       | HttpClient                                                               | Windows.Web.Http.HttpClient<br>SyndicationClient |
| Files            | JsonSerializer<br>StreamReader<br>StreamWriter<br>XmlReader<br>XmlWriter | StorageFile                                      |
| Images           |                                                                          | MediaCapture<br>BitmapEncoder<br>BitmapDecoder   |
| WCF              | Synchronous and Asynchronous Operations                                  |                                                  |
### [运行机制](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model#BKMK_WhatHappensUnderstandinganAsyncMethod)
### [async](../LanguageReference/Keywords/Modifiers.cs)
### [await](../LanguageReference/OperatorsAndExpressions/OperatorsAndExpressions.cs)
### [命名约定](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model#BKMK_NamingConvention)
- 返回可唤醒类型的方法（例如，Task、Task<T>、ValueTask、ValueTask<T>）应以 Async 结尾
- 不返回可唤醒类型的方法不应以 Async 结尾，而可以使用 Begin、start 或其他动词开头
- 约定中的事件、基类或接口，可以忽略此约定，如事件处理程序 OnButtonClick
---
## [异步返回类型](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/async-return-types)
1. Task：不返回值
2. Task<TResult>：返回值
3. void：事件处理程序
4. 通用返回类型：任何具有可访问的 GetAwaiter 方法的类型
    - Task 和 Task<Result> 是引用类型，通用返回类型是值类型，从而避免额外的内存分配
    - ValueTask<TResult>：轻量级实现
5. IAsyncEnumerable<T>：返回异步流
---
## Reference
- [基于任务的异步模式](https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap)
---
