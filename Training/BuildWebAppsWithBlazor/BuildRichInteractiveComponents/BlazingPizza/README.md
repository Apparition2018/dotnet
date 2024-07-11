## 在 Blazor Web 应用中构建丰富的交互式组件
### [JavaScript 与 Blazor 的互操作性](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/2-create-user-interfaces-blazor-components)
- 在 Blazor 应用中加载 JavaScript 代码
    - [JavaScript 位置](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/javascript-interoperability/#javascript-location)
    - [将 \<script> 元素动态注入 Pages/_Host.cshtml 页面](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/fundamentals/startup)
- [从 .NET 代码调用 JavaScript](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet)：使用 `IJSRuntime`
- [从 JavaScript 调用 .NET 代码](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/javascript-interoperability/call-dotnet-from-javascript)：使用 DotNet 实用工具类（JS 互操作库的一部分）运行 Blazor 代码定义的 .NET 方法
### [练习 - 在 Blazor 应用中使用 JavaScript 库](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/3-exercise-use-javascript-libraries-blazor-apps)
- 克隆项目 `git clone https://github.com/MicrosoftDocs/mslearn-build-interactive-components-blazor.git BlazingPizza`
- 重构订单流程（订单中的披萨），@see [Index.razor](Pages/Index.razor)
    ```razor
    @inject IJSRuntime JavaScript
    ……
                        <button type="button" class="close text-danger" aria-label="Close"
                             @onclick="@(async () => await RemovePizzaConfirmation(configuredPizza))">
                             <span aria-hidden="true">&times;</span>
                        </button>
    ……
    @code {
        ……
        async Task RemovePizzaConfirmation(Pizza removePizza)
        {
            // 调用 JavaScript confirm 函数
            if (await JavaScript.InvokeAsync<bool>(
                    "confirm",
                    $"""Do you want to remove the "{removePizza.Special!.Name}" from your order?"""))
            {
                OrderState.RemoveConfiguredPizza(removePizza);
            }
        }
    }
    ```
- 将第三方 JavaScript 库添加到 Blazor 应用
    - @see [_Host.cshtml](Pages/_Host.cshtml)
        ```cshtml
        <script src="https://cdn.jsdelivr.net/npm/sweetalert@latest/dist/sweetalert.min.js"></script>
        ```
    - @see [Index.razor](Pages/Index.razor)
        ```razor
        async Task RemovePizzaConfirmation(Pizza removePizza)
        {
            var messageParams = new
            {
                title = "Remove Pizza?",
                text = $"""Do you want to remove the "{removePizza.Special!.Name}" from your order?""",
                icon = "warning",
                buttons = new
                {
                    abort = new { text = "No, leave it in my order", value = false },
                    confirm = new { text = "Yes, remove pizza", value = true }
                },
                dangerMode = true
            };

            /// 调用 SweetAlert 的 swal 函数
            if (await JavaScript.InvokeAsync<bool>("swal", messageParams))
            {
                OrderState.RemoveConfiguredPizza(removePizza);
            }
        }
        ```
- 更新订单页以显示实时订单状态，@see [OrderDetail.razor](Pages/OrderDetail.razor)
    ```razor
    @implements IDisposable
    ……
                        @if (IsOrderIncomplete)
                        {
                            <div class="spinner-grow text-danger float-right" role="status">
                                <span class="sr-only">Checking your order status...</span>
                            </div>
                        }
    ……
    @code {
        ……
        bool IsOrderIncomplete => orderWithStatus is null || orderWithStatus.IsDelivered == false;
        PeriodicTimer timer = new(TimeSpan.FromSeconds(3));
        ……
        protected override async Task OnParametersSetAsync() => await GetLatestOrderStatusUpdatesAsync();

        protected override Task OnAfterRenderAsync(bool firstRender) =>
            firstRender ? StartPollingTimerAsync() : Task.CompletedTask;

        async Task GetLatestOrderStatusUpdatesAsync() { …… }

        async Task StartPollingTimerAsync() { …… }

        public void Dispose() => timer.Dispose();
    }
    ```
### [了解 Blazor 组件生命周期](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/4-improve-app-interactivity-lifecycle-events)
- Blazor 组件生命周期
![component-lifecycle](https://learn.microsoft.com/zh-cn/training/aspnetcore/blazor-build-rich-interactive-components/media/4-component-lifecycle.png)
    - Blazor 组件表示 Blazor 应用程序中的视图，这些视图定义布局和 UI 逻辑
    - Blazor 组件都来自 ComponentBase 类或 IComponent，后者提供方法的默认行为
- 了解生命周期方法

| 生命周期方法                                                                                                                                                                                                                                  | 说明                                                           |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------|
| [SetParametersAsync](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/4-improve-app-interactivity-lifecycle-events#the-setparametersasync-method)                                            | 从 render tree 中组件的父级设置参数                                     |
| [OnInitialized / OnInitializedAsync](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/4-improve-app-interactivity-lifecycle-events#the-oninitialized-and-oninitializedasync-methods)         | 在组件已准备好启动时发生                                                 |
| [OnParametersSet / OnParametersSetAsync](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/4-improve-app-interactivity-lifecycle-events#the-onparametersset-and-onparameterssetasync-methods) | 在组件接收到参数并分配了属性时发生                                            |
| [OnAfterRender / OnAfterRenderAsync](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/4-improve-app-interactivity-lifecycle-events#the-onafterrender-and-onafterrenderasync-methods)         | 在组件 render 后发生                                               |
| [Dispose / DisposeAsync](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/4-improve-app-interactivity-lifecycle-events#the-dispose-and-disposeasync-methods)                                 | 如果组件实现 IDisposable 或 IAsyncDisposable，则相应的一次性操作会作为销毁组件的一部分发生 |
- [处理生命周期方法中的异常](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/fundamentals/handle-errors)
### [练习 - 利用生命周期事件提高应用交互性](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/5-exercise-improve-app-interactivity-lifecycle-events)
- 创建新的家庭装披萨
    - @see [PizzaSpecial.cs](Models/PizzaSpecial.cs)：`public int? FixedSize { get; set; }`
    - @see [Pizza.cs](Models/Pizza.cs)
        ```csharp
        public decimal GetBasePrice() =>
            Special is { FixedSize: not null }
                ? Special.BasePrice : (decimal)Size / DefaultSize * Special?.BasePrice ?? 1;
        ```
    - @see [SeedData.cs](Data/SeedData.cs)
        ```csharp
        new()
        {
            Id = 9,
            Name = "Margherita Family Size",
            Description = "24\" of pure tomatoes and basil",
            BasePrice = 14.99m,
            ImageUrl = "img/pizzas/margherita.jpg",
            FixedSize = 24
        }
        ```
- 删除大小滑块，@see [ConfigurePizzaDialog.razor](Shared/ConfigurePizzaDialog.razor)
    ```razor
                    @if (supportSizing)
    ……
    @code {
        ……
        bool supportSizing = true;
        protected override void OnInitialized()
        {
            if (Pizza is { Special.FixedSize: not null })
            {
                Pizza.Size = Pizza.Special.FixedSize.Value;
                supportSizing = false;
            }
        }
    }
    ```
### [了解模板组件](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/6-reuse-components-creating-templates)
### [练习 - 通过创建模板重用组件](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-rich-interactive-components/7-exercise-reuse-components-creating-templates)
- 创建分页模板组件：@see [PaginationComponent.razor](Components/PaginationComponent.razor)
- 更新 MyOrders 组件L，@see [MyOrders,.razor](Pages/MyOrders.razor)，替换 if / else if / else 逻辑块中 else 分支代码
    ```razor
    @using BlazingPizza.Components
    ```
### Reference
- [Blazor - App building workshop](https://github.com/dotnet-presentations/blazor-workshop)
- [Blazor 模板化组件](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/templated-components)
- [Razor 组件生命周期](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/lifecycle)
---
