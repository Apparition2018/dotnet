# PizzaStore
- [使用 ASP.NET Core、最小 API 和 .NET 6 创建 Web 应用和服务](https://learn.microsoft.com/zh-cn/learn/paths/aspnet-core-minimal-api/)
---
## Gists
- 创建项目：`dotnet new web -o PizzaStore -f net6.0`
- Swagger：`dotnet add package Swashbuckle.AspNetCore`
    - @see Program.cs
- EF Core In Memory：`dotnet add package Microsoft.EntityFrameworkCore.InMemory`
    - @see PizzaDb.cs
    - @see Program.cs：`builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));`
- EF Core SQLite：`dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
    - [.NET Core CLI](https://learn.microsoft.com/zh-cn/ef/core/cli/dotnet)
        ```
        dotnet add package Microsoft.EntityFrameworkCore.Design
        
        dotnet tool install --global dotnet-ef
            dotnet ef migrations add InitialCreate
            dotnet ef database update
        ```
    - @see Program.cs
        ```
        var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";
        builder.Services.AddDbContext<PizzaDb>(options => options.UseSqlite(connectionString));
        ```
- CORS：@see Program.cs
    ```
    const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
    builder.Services.AddCors(options =>
        options.AddPolicy(name: myAllowSpecificOrigins, corsPolicyBuilder => { corsPolicyBuilder.WithOrigins("*"); }));
    app.UseCors(myAllowSpecificOrigins);
    ```
---
