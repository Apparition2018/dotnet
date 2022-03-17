# ContosoCrafts
- [ASP.NET Core 101](https://www.youtube.com/watch?v=lE8NdaX97m0&list=PLdo4fOcmZ0oW8nviYduHq7bmKode-p8Wy&ab_channel=dotNET)
---
## Gists
- 创建 ASP.NET Core -  Web APP
- 读取 json 数据
    - @see Product.cs：`[JsonPropertyName("img")]`
    - @see JsonFileProductService.cs：`Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");`
    - @see Startup.cs：`services.AddTransient<JsonFileProductService>();`
- Razor Page：@see Index.cshtml，@see Index.cshtml.cs
- Simple API：@see Startup.cs
    ```
    endpoints.MapGet("/products", (context) =>
    {
        var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
        var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
        return context.Response.WriteAsync(json);
    });
    ```
- Web API
    - @See ProductController.cs
    - @See Startup.cs：`services.AddControllers();`，`endpoints.MapControllers();`
- Blazor
    - @see ProductList.razor：
        ```
        @using Microsoft.AspNetCore.Components.Web
        @inject JsonFileProductService _productService
        ```
    - @see Startup.cs：`services.AddServerSideBlazor();`，`endpoints.MapBlazorHub();`
    - @see Index.cshtml：
        ```
        @(await Html.RenderComponentAsync<ProductList>(RenderMode.ServerPrerendered))
        <script src="_framework/blazor.server.js"></script>
        ```
- 发布到 Azure
---