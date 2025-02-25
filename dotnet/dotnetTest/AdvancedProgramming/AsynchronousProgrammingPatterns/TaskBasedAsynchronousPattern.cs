using dotnetTest.AdvancedProgramming.ParallelProgramming.TaskParallelLibrary;
using dotnetTest.API.System.Threading.Tasks;
using dotnetTest.Guide.LanguageReference.Keywords;

namespace dotnetTest.AdvancedProgramming.AsynchronousProgrammingPatterns;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap">基于任务的异步模式</a>
/// <list type="bullet">
/// <item>基于 <see cref="Task"/> 和 <see cref="Task{TResult}"/>，用于表示异步操作</item>
/// <item>异步方法的操作名称后面添加 Async 后缀</item>
/// </list>
/// <para>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/implementing-the-task-based-asynchronous-pattern#generating-tap-methods">三种方式实现 TAP</a>
/// <list type="number">
/// <item>编译器：<see cref="Modifiers.Async">async</see></item>
/// <item>手动生成：<see cref="TaskCompletionSource{TResult}"/></item>
/// <item>混合：编译器 + 手动实现</item>
/// </list>
/// </para>
/// <para>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/implementing-the-task-based-asynchronous-pattern#workloads">工作负载</a>
/// <list type="number">
/// <item>计算密集型任务：<see cref="Task"/></item>
/// <item>IO 密集型任务：<see cref="TaskCompletionSource{TResult}"/></item>
/// </list>
/// </para>
/// </summary>
/// <seealso cref="TaskBasedAsynchronous"/>
/// <seealso cref="TaskTests"/>
public class TaskBasedAsynchronousPattern;
