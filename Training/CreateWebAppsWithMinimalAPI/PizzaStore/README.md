## [使用最小 API、ASP.NET Core 和 .NET 生成 Web API](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-api/)
### [什么是最小 API？](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-api/2-what-is-minimal-api)
- controller-based vs minimal API
    - 简化 Program.cs
        - controller-based 的 Web API 模板使用 `AddControllers` 方法连接控制器
        - controller-based 的 Web API 模板连接 Swagger 以提供 OpenAPI 支持
    - 路由
        - controller-based
        ```csharp
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            // add my own routes
        });
        ```
        - minimal API：`app.MapGet("/", () => "Hello World!");`
### [练习 - 创建最小 API](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-api/3-exercise-create-minimal-api)
- 创建项目的基架：`dotnet new web -o PizzaStore -f net8.0`
- 添加 Swagger
    - 安装 Swashbuckle 包：`dotnet add package Swashbuckle.AspNetCore --version 6.5.0`
    - @see [Program.cs](Program.cs)
    ```csharp
    using Microsoft.OpenApi.Models;
    ……
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
    });
    ……
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
    ```
    - `http://localhost:{PORT}/swagger`
### [练习 - 添加路由](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-api/5-exercise-advanced-commands)
- 添加数据：@see [DB.cs](Db.cs)
- 将数据连接到路由
    - @see [Program.cs](Program.cs)
    ```csharp
    using PizzaStore;
    ……
    app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
    app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
    app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
    app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
    app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));
    ```
    - `http://localhost:{PORT}/swagger`
---
