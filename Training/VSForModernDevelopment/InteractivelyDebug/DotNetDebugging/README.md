## [使用 Visual Studio 调试器，以交互方式调试 .NET 应用](https://learn.microsoft.com/zh-cn/training/modules/dotnet-debug-visual-studio/)
### 什么是调试器？
- 调试器两个最重要的功能：①控制程序执行；②管擦和程序的状态
### [了解 Visual Studio 中的 .NET 调试器](https://learn.microsoft.com/zh-cn/training/modules/dotnet-debug-visual-studio/3-analyze-your-program-state)
### [练习 - 使用 Visual Studio 进行调试](https://learn.microsoft.com/zh-cn/training/modules/dotnet-debug-visual-studio/4-use-visual-studio-debugger)
- 创建示例 .NET 项目以进行调试：新建一个名为 [DotNetDebugging](../DotNetDebugging) 的控制台应用
### [Visual Studio 调试的提示和技巧](https://learn.microsoft.com/zh-cn/training/modules/dotnet-debug-visual-studio/5-visual-studio-tips-tricks)
### [.NET 应用程序中的日志记录和跟踪](https://learn.microsoft.com/zh-cn/training/modules/dotnet-debug-visual-studio/6-logging-and-tracing)
### [练习 - 日志记录和跟踪](https://learn.microsoft.com/zh-cn/training/modules/dotnet-debug-visual-studio/7-use-logging-and-tracing)
- @see [Program.cs](Program.cs)
    - WriteLieIf：`Debug.Assert(n2 == 5, "The return value is not 5 and it should be.");`
    - 更新为 `Fibonacci(6)`
    - Debug 配置：`dotnet run`，应用程序在断言失败后终止，并将错误信息输出
    - Release 配置：`dotnet run --configuration Release`，应用程序成功运行，因为不处于 Debug 配置中
### Reference
- [教程：使用 Visual Studio 调试 .NET Core 控制台应用程序](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/debugging-with-visual-studio)
---
