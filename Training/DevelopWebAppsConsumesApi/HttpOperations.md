## [在 ASP.NET Razor Pages 中实现 HTTP 操作](https://learn.microsoft.com/zh-cn/training/modules/implement-http-operations-asp-razor/)
### [在 .NET Core 中探索 HTTP 客户端](https://learn.microsoft.com/zh-cn/training/modules/implement-http-operations-asp-razor/2-explore-http-clients)
- 使用 HttpClient 类实现
    ```csharp
    var handler = new SocketsHttpHandler
    {
        // Recreate every 15 minutes
        PooledConnectionLifetime = TimeSpan.FromMinutes(15)
    };
    var sharedClient = new HttpClient(handler);
    ```
- [使用 IHttpClientFactory 实现](https://learn.microsoft.com/zh-cn/training/modules/implement-http-operations-asp-razor/2-explore-http-clients)（本练习实现方式）
### [在 Razor Pages 中执行 HTTP 操作](https://learn.microsoft.com/zh-cn/training/modules/implement-http-operations-asp-razor/3-make-http-requests)
### [练习 - 在 Razor Pages 中实现 HTTP 操作](https://microsoftlearning.github.io/APL-2002-develop-aspnet-core-consumes-api/Instructions/Labs/02-implement-http-operations.html)
- 下载 web app 项目：[Fruit web app code-behind](https://raw.githubusercontent.com/MicrosoftLearning/APL-2002-develop-aspnet-core-consumes-api/master/Allfiles/Downloads/FruitWebApp-codebehind.zip)
- 实现 HTTP 客户端：将 IHttpClientFactory 和相关服务添加到 IServiceCollection，@see [Program.cs](FruitWebApp/Program.cs)
    ```csharp
     // Add IHttpClientFactory to the container and set the name of the factory
     // to "FruitAPI". The base address for API requests is also set.
     builder.Services.AddHttpClient("FruitAPI", httpClient =>
     {
         httpClient.BaseAddress = new Uri("http://localhost:5050/fruitlist/");
     });
    ```
- 实现 GET 操作：@see [Index.cshtml.cs](FruitWebApp/Pages/Index.cshtml.cs)
    ```csharp
    // OnGet() is async since HTTP requests should be performed async
    public async Task OnGet()
    {
        // Create the HTTP client using the FruitAPI named factory
        var httpClient = _httpClientFactory.CreateClient("FruitAPI");
        // Perform the GET request and store the response. The empty parameter
        // in GetAsync doesn't modify the base address set in the client factory
        using HttpResponseMessage response = await httpClient.GetAsync("");
        // If the request is successful deserialize the results into the data model
        if (response.IsSuccessStatusCode)
        {
            using var contentStream = await response.Content.ReadAsStreamAsync();
            FruitModels = await JsonSerializer.DeserializeAsync<IEnumerable<FruitModel>>(contentStream);
        }
    }
    ```
- 实现 POST 操作：@see [Add.cshtml.cs](FruitWebApp/Pages/Add.cshtml.cs)
    ```csharp
    public async Task<IActionResult> OnPost()
    {
        // Serialize the information to be added to the database
        var jsonContent = new StringContent(JsonSerializer.Serialize(FruitModels),
            Encoding.UTF8,
            "application/json");

        // Create the HTTP client using the FruitAPI named factory
        var httpClient = _httpClientFactory.CreateClient("FruitAPI");

        // Execute the POST request and store the response. The parameters in PostAsync
        // direct the POST to use the base address and passes the serialized data to the API
        using HttpResponseMessage response = await httpClient.PostAsync("", jsonContent);

        // Return to the home (Index) page and add a temporary success/failure
        // message to the page.
        if (response.IsSuccessStatusCode)
        {
            TempData["success"] = "Data was added successfully.";
            return RedirectToPage("Index");
        }
        else
        {
            TempData["failure"] = "Operation was not successful";
            return RedirectToPage("Index");
        }
    }
    ```
- 实现 PUT 操作：@see [Edit.cshtml.cs](FruitWebApp/Pages/Edit.cshtml.cs)
    ```csharp
    public async Task<IActionResult> OnPost()
    {
        // Serialize the information to be edited in the database
        var jsonContent = new StringContent(JsonSerializer.Serialize(FruitModels),
            Encoding.UTF8,
            "application/json");

        // Create the HTTP client using the FruitAPI named factory
        var httpClient = _httpClientFactory.CreateClient("FruitAPI");

        // Execute the PUT request and store the response. The parameters in PutAsync
        // appends the item Id to the base address and passes the serialized data to the API
        using HttpResponseMessage response = await httpClient.PutAsync(FruitModels.id.ToString(), jsonContent);

        // Return to the home (Index) page and add a temporary success/failure
        // message to the page.
        if (response.IsSuccessStatusCode)
        {
            TempData["success"] = "Data was edited successfully.";
            return RedirectToPage("Index");
        }
        else
        {
            TempData["failure"] = "Operation was not successful";
            return RedirectToPage("Index");
        }

    }
    ```
- 实现 DELETE 操作：@see [Delete.cshtml.cs](FruitWebApp/Pages/Delete.cshtml.cs)
    ```csharp
    public async Task<IActionResult> OnPost()
    {
        // Create the HTTP client using the FruitAPI named factory
        var httpClient = _httpClientFactory.CreateClient("FruitAPI");

        // Appends the data Id for deletion to the base address and performs the operation
        using HttpResponseMessage response = await httpClient.DeleteAsync(FruitModels.id.ToString());

        // Return to the home (Index) page and add a temporary success/failure
        // message to the page.
        if (response.IsSuccessStatusCode)
        {
            TempData["success"] = "Data was deleted successfully.";
            return RedirectToPage("Index");
        }
        else
        {
            TempData["failure"] = "Operation was not successful";
            return RedirectToPage("Index");
        }

    }
    ```
- 分别启动 [FruitAPI](FruitAPI) 和 [FruitWebApp](FruitWebApp) 项目
---
