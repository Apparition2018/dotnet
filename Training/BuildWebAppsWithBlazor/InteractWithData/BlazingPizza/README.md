# BlazingPizza

---
## [与 Blazor Web 应用中的数据交互](https://learn.microsoft.com/zh-cn/training/modules/interact-with-data-blazor-web-apps/)
### 使用 Blazor 组件创建用户界面
- 两种托管模型
    1. Blazor Server：在 ASP.NET Core 应用的 Web 服务器上执行。（本模块）
    2. Blazor WebAssembly：Blazor 应用、其依赖项以及 .NET 运行时均在浏览器中下载并运行
- 创建 Blazor 组件
    - 创建 Blazor 服务器应用：`dotnet new blazorserver -o BlazingPizzaSite --no-https -f net6.0`
    - 将新组件添加到现有 Web 应用：`dotnet new razorcomponent -n PizzaBrowser -o Pages -f net6.0`
- 克隆项目 [Blazing Pizza](https://github.com/MicrosoftDocs/mslearn-interact-with-data-blazor-web-apps)
    - 修改 [Index.razor](Pages/Index.razor) 内容
### [从 Blazor 组件访问数据](https://learn.microsoft.com/zh-cn/training/modules/interact-with-data-blazor-web-apps/5-exercise-access-data-from-blazor-components)
- 添加包以支持数据库访问
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.8
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.8
dotnet add package System.Net.Http.Json --version 6.0.0
```
- 添加数据库上下文：@see [PizzaStoreContext.cs](Data/PizzaStoreContext.cs)
- 添加控制器：@see [SpecialsController.cs](Controllers/SpecialsController.cs)
- 将数据加载到数据库中
    - @see [SeedData.cs](Data/SeedData.cs)
    - @see [Program.cs](Program.cs)
    ```csharp
    builder.Services.AddHttpClient();
    builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");
    ……
    // Initialize the database
    var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
        if (db.Database.EnsureCreated())
        {
            SeedData.Initialize(db);
        }
    }
    ```
- 使用数据库显示披萨
    - @see [Index.razor](Pages/Index.razor)
    ```razor
    @inject HttpClient HttpClient
    @inject NavigationManager NavigationManager
    ……
    @code {
        protected override async Task OnInitializedAsync()
        {
            specials = await HttpClient.GetFromJsonAsync<List<PizzaSpecial>>(NavigationManager.BaseUri + "specials");
        }
    }
    ```
    - @see [Program.cs](Program.cs)：`app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");`
### 在 Blazor 应用程序中共享数据
- 共享信息方式
    1. 组件参数：`[Parameter]`
    2. 级联参数：在父组件中使用 `<CascadingValue>` tag，tag 内的所有组件都能访问该值
        ```fathor.razor
        <CascadingValue Name="DealName" Value="Throwback Thursday">
            <!-- Any descendant component rendered here will be able to access the cascading value. -->
        </CascadingValue>
        ```
        ```son.razor
        @code {
            [CascadingParameter(Name="DealName")]
            private string DealName { get; set; }
        }
        ```
    3. [AppState](https://learn.microsoft.com/zh-cn/training/modules/interact-with-data-blazor-web-apps/6-share-data-in-blazor-applications#share-information-by-using-appstate)
- 添加新的订单配置对话框：@see [ConfigurePizzaDialog.razor](Shared/ConfigurePizzaDialog.razor)
- 订购披萨：@see [Index.razor](Pages/Index.razor)
```razor
                <li @onclick="@(() => ShowConfigurePizzaDialog(special))" style="background-image: url('@special.ImageUrl')">
……
@if (showingConfigureDialog)
{
    <ConfigurePizzaDialog Pizza="configuringPizza" />
}
@code {
    Pizza configuringPizza;
    bool showingConfigureDialog;
    ……
    void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        configuringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize
        };

        showingConfigureDialog = true;
    }
}
```
- 处理订单的状态
    - @see [OrderState.cs](Services/OrderState.cs)
    - @see [Program.cs](Program.cs)
    ```csharp
    builder.Services.AddScoped<OrderState>();
    ```
    - @see [Index.razor](Pages/Index.razor)：先移除先前的 `configuringPizza`、`showingConfigureDialog`、`ShowConfigurePizzaDialog()`、@if 代码块
    ```razor
    @inject OrderState OrderState
                    <li @onclick="@(() => OrderState.ShowConfigurePizzaDialog(special))" style="background-image: url('@special.ImageUrl')">
    ……
    @if (OrderState.ShowingConfigureDialog)
    {
        <ConfigurePizzaDialog Pizza="OrderState.ConfiguringPizza"/>
    }
    ```
- 取消和进行披萨订购
    - @see [ConfigurePizzaDialog.razor](Shared/ConfigurePizzaDialog.razor)
    ```razor
                <button class="btn btn-secondary mr-auto" @onclick="OnCancel">Cancel</button>
                <button class="btn btn-success ml-auto" @onclick="OnConfirm">Order ></button>
    ……
    @code {
        [Parameter] public EventCallback OnCancel { get; set; }
        [Parameter] public EventCallback OnConfirm { get; set; }
    }
    ```
    - @see [Index.razor](Pages/Index.razor)
    ```razor
    @if (OrderState.ShowingConfigureDialog)
    {
        <ConfigurePizzaDialog
            Pizza="OrderState.ConfiguringPizza"
            OnCancel="OrderState.CancelConfigurePizzaDialog"
            OnConfirm="OrderState.ConfirmConfigurePizzaDialog" />
    }
    ```
### 在 Blazor 应用程序中将控件绑定到数据
- `@bind` 使用样例
```razor
<input @bind="favPizza" />
<input @bind-value="favPizza" @bind-value:event="oninput" />
<input @bind="birthdate" @bind:format="dd-MM-yyyy" />
<input @bind="ApprovalRating" />
@code {
    private decimal approvalRating = 1.0;
    private NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
    private CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

    private string ApprovalRating
    {
        get => approvalRating.ToString("0.000", culture);
        set
        {
            if (Decimal.TryParse(value, style, culture, out var number))
            {
                approvalRating = Math.Round(number, 3);
            }
        }
    }
}
```
- 显示客户的披萨订单：@see [Index.razor](Pages/Index.razor)
```razor
<div class="sidebar"/>
……
@code {
    Order order => OrderState.Order;
}
```
- 从客户订单中删除披萨
    - @see [OrderState.cs](Services/OrderState.cs) `RemoveConfiguredPizza()`
    - @see [Index.razor](Pages/Index.razor)
    ```razor
    <a @onclick="@(() => OrderState.RemoveConfiguredPizza(configuredPizza))" class="delete-item">x</a>
    ```
- 动态配置披萨大小
    - @see [ConfigurePizzaDialog.razor](Shared/ConfigurePizzaDialog.razor)
    ```razor
    <input type="range" min="@Pizza.MinimumSize" max="@Pizza.MaximumSize" step="1" @bind="Pizza.Size" @bind:event="oninput" />
    ……
    Price: <span class="price">@(Pizza.GetFormattedTotalPrice())</span>
    ```
### Reference
- [Blazor](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/)
- [Razor 组件](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/)
- [Blazor 托管模型](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/hosting-models)
- [Blazor 级联值和参数](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/cascading-values-and-parameters)
- [Blazor 数据绑定](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/data-binding)
- [Blazor - App building workshop](https://github.com/dotnet-presentations/blazor-workshop)
---
