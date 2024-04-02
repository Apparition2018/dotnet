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
    using PizzaStore.DB;
    ……
    app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
    app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
    app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
    app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
    app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));
    ```
    - `http://localhost:{PORT}/swagger`
---
## [结合使用数据库和最小 API、Entity Framework Core 和 ASP.NET Core](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-database/)
### [练习 - 将 EF Core 添加到最小 API](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-database/3-exercise-add-entity-framework-core)
- 添加 Model：@see [Pizza.cs](Models/Pizza.cs)
- 将 EF Core 添加到项目
    - 添加 EF Core InMemory 包：`dotnet add package Microsoft.EntityFrameworkCore.InMemory`
    - 设置内存数据库：@see [Pizza.cs](Models/Pizza.cs)
    ```
    class PizzaDb : DbContext
    {
        public PizzaDb(DbContextOptions options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; } = null!;
    }
    ```
    - @see [Program.cs](Program.cs)：`builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));`
- 创建新项
    - @see [Program.cs](Program.cs)
    ```csharp
    app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
    {
        await db.Pizzas.AddAsync(pizza);
        await db.SaveChangesAsync();
        return Results.Created($"/pizza/{pizza.Id}", pizza);
    });
    ```
    - `http://localhost:{PORT}/swagger` → POST /pizza
    ```json
    {
        "name": "Pepperoni",
        "description": "A classic pepperoni pizza"
    }
    ```
- RUD：@see [Program.cs](Program.cs)
```csharp
app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.Name = updatepizza.Name;
    pizza.Description = updatepizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null)
    {
        return Results.NotFound();
    }
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});
```
### [添加新数据库提供程序的步骤](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-database/4-add-sqlite-database-provider)
1. 将一个或多个 NuGet 包添加到项目中，以包含数据库提供程序。
2. 配置数据库连接。
3. 在 ASP.NET Core 服务中配置数据库提供程序。
4. 执行数据库迁移。
### [练习 - 将 SQLite 数据库提供程序与 EF Core 结合使用](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-database/5-exercise-use-sqlite-database)
- 设置 SQLite 数据库
    - 添加 EF Core SQLite 包：`dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
    - 安装 EF Core 工具：`dotnet tool install --global dotnet-ef`
    - 添加 EF Core Design 包：`dotnet add package Microsoft.EntityFrameworkCore.Design`
- 启用数据库创建
    - @see [Program.cs](Program.cs)
    ```csharp
    var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";
    builder.Services.AddSqlite<PizzaDb>(connectionString);
    ```
    - 添加一个名为 `InitialCreate` 数据库迁移：`dotnet ef migrations add InitialCreate`
    - 将迁移应用到数据库：`dotnet ef database update`
### 继续了解最小 API
- [最小 API 入门](https://minimal-apis.github.io/)
- [最小 API playground](https://github.com/DamianEdwards/MinimalApiPlayground)
---
