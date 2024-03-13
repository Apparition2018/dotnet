# ContosoCrafts.WebSite

---
## [ASP.NET Core 101](https://learn.microsoft.com/zh-cn/shows/ASPNET-Core-101/)
- [YouTube](https://www.youtube.com/watch?v=lE8NdaX97m0&list=PLdo4fOcmZ0oW8nviYduHq7bmKode-p8Wy&ab_channel=dotnet)
- [GitHub](https://github.com/dotnet-presentations/ContosoCrafts)
### Making an ASP.NET Core Website [2 of 13]
- New Solution… → ASP.NET Core Web Application
    - Put solution and project in the same directory 不勾选
    - SDK: 3.1
    - Type: Web App
### Adding Data [3 of 13]
- @see [products.json](wwwroot/data/products.json)
- `[JsonPropertyName("img")]`，@see [Product.cs](Models/Product.cs)
### Adding a Service [4 of 13]
- wwwroot 绝对路径：`WebHostEnvironment.WebRootPath`，@see [JsonFileProductService.cs](Services/JsonFileProductService.cs)
- 将 JsonFileProductService 服务添加到容器，@see [Startup.cs](Startup.cs) `services.AddTransient<JsonFileProductService>();`
### Data in a Razor Page [5 of 13]
- 在 Razor Page 使用服务，@see [Index.cshtml.cs](Pages/Index.cshtml.cs)
    ```csharp
    public IndexModel(JsonFileProductService productService) { ProductService = productService;}
    public void OnGet() => Products = ProductService.GetProducts();
    ```
### Styling a Razor Page [6 of 13]
- 布局页面 [_Layout.cshtml](Pages/Shared/_Layout.cshtml)
- 修改默认引入的 [site.css](wwwroot/css/site.css)
- 引入字体
    ```cshtml
    <link href="https://fonts.googleapis.com/css?family=Yellowtail&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Nunito&display=swap" rel="stylesheet">
    ```
    ```css
    a.navbar-brand { font-family: 'Yellowtail', cursive; }
    ```
### Making a Simple API [7 of 13]
- 配置 HTTP 请求管道，@see [Startup.cs](Startup.cs)
    ```csharp
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/products", (context) =>
        {
            var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
            var json = JsonSerializer.Serialize(products);
            return context.Response.WriteAsync(json);
        });
    });
    ```
### Enhancing your Web API [8/9 of 13]
- Add → Scaffolded Item… → API Controller，@see [ProductsControllers.cs](Controller/ProductsController.cs)
- 将控制器的服务添加到 IServiceCollection，@see [Startup.cs](Startup.cs) `services.AddControllers();`
- 将控制器操作的终结点添加到 IEndpointRouteBuilder，而不指定任何路由，@see [Startup.cs](Startup.cs) `endpoints.MapControllers();`
- 将 Blazor Hub 映射到默认路径，@see [Startup.cs](Startup.cs) `endpoints.MapBlazorHub();`
- 增加评级，@see [JsonFileProductService.cs](Services/JsonFileProductService.cs) AddRating，@see [ProductsControllers.cs](Controller/ProductsController.cs) Patch
### Introducing Blazor [10/11/12 of 13]
- Add → Blazor Component → Component，@see [ProductList.razor](Components/ProductList.razor)
- 将服务器端 Blazor 服务添加到服务集合，@see [Startup.cs](Startup.cs) `services.AddServerSideBlazor();`
- @see Index.cshtml：
    ```
    @(await Html.RenderComponentAsync<ProductList>(RenderMode.ServerPrerendered))
    <script src="_framework/blazor.server.js"></script>
    ```
### Publishing an Website to Azure [13 of 13]

---
