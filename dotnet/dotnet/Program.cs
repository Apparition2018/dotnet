// 顶级语句 (Top-level statements)：省略 Program 类和 Main 方法
// https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/program-structure/top-level-statements

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
