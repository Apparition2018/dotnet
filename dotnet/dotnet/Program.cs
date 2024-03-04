// 顶级语句 (Top-level statements)
// 编译器生成一个带有入口点方法的 Program 类，并将所有顶级语句放置在该方法中，生成的方法的名称不是 Main
// https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/program-structure/top-level-statements

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
