## [与 ASP.NET Core 最小 API 交互](https://learn.microsoft.com/zh-cn/training/modules/interact-api/)
### [ASP.NET Core 支持两种创建 API 的方法](https://learn.microsoft.com/zh-cn/training/modules/interact-api/2-explore-asp-net-core-api)
1. 基于控制器的 API
    ```csharp
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    ```
2. 精简 API
    ```csharp
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    app.MapGet("/users/{userId}/books/{bookId}",
        (int userId, int bookId) => $"The user id is {userId} and book id is {bookId}");
    app.Run();
    ```
### [使用 Swashbuckle 记录 API](https://learn.microsoft.com/zh-cn/training/modules/interact-api/3-document-api-swashbuckle)
- 安装 Swashbuckle NuGet 包：`dotnet add <name>.csproj package Swashbuckle.AspNetCore -v 6.5.0`
- 添加并配置 Swagger 中间件：@see [Program.cs](FruitAPI/Program.cs)
    - 将 Swagger 生成器添加到服务集合
        ```csharp
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        ```
    - 启用中间件为生成的 JSON 文档和 Swagger UI 提供服务
        ```csharp
        app.UseSwagger();
        if (app.Environment.IsDevelopment())
        {
            app.app.UseSwaggerUI();
        }
        ```
    - Swagger UI 默认终结点：`http:<hostname>:<port>/swagger`
- 自定义和扩展 Swagger 文档：@see [Program.cs](FruitAPI/Program.cs)
    - 传递给 AddSwaggerGen 方法的配置操作可以通过 OpenApiInfo 类包含额外信息
        ```csharp
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Fruit API",
                Description = "API for managing a list of fruit their stock status.",
                TermsOfService = new Uri("https://example.com/terms")
            });
        });
        ```
    - 可以使用 .WithTags 选项将描述性标题添加到 API 中的不同函数
        ```csharp
        app.MapPost("/fruitlist", async (Fruit fruit, FruitDb db) =>
        {
            db.Fruits.Add(fruit);
            await db.SaveChangesAsync();

            return Results.Created($"/fruitlist/{fruit.Id}", fruit);
        })
            .WithTags("Add fruit to list");
        ```
### [练习 - 与 API 交互](https://microsoftlearning.github.io/APL-2002-develop-aspnet-core-consumes-api/Instructions/Labs/01-interact-with-an-api.html)
- 下载 API 代码：[FruitAPI project code](https://raw.githubusercontent.com/MicrosoftLearning/APL-2002-develop-aspnet-core-consumes-api/master/Allfiles/Downloads/FruitAPI.zip)
- 在本地运行API：`dotnet run`
- 在浏览器中打开API文档：http://localhost:5050/swagger
---
