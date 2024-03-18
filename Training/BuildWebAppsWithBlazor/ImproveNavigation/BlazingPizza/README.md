## [使用页面、路由和布局改进 Blazor 导航](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/)
### [使用 Blazor 路由器组件控制应用的导航](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/2-use-router-component-control-apps-navigation)
- [使用路由模板](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/2-use-router-component-control-apps-navigation#using-route-templates)：@see [App.razor](App.razor)
- 使用 `@page` 指令
- [获取位置信息，并使用 NavigationManager 导航](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/2-use-router-component-control-apps-navigation#obtaining-location-information-and-navigating-with-navigationmanager)
- [使用 NavLink 组件](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/2-use-router-component-control-apps-navigation#use-navlink-components)
### [使用 @page 指令更改 Blazor 应用中的导航](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/3-exercise-change-navigation-blazor-using-page-directive)
- 克隆项目 `git clone https://github.com/MicrosoftDocs/mslearn-blazor-navigation.git BlazingPizza`
- 添加结账页
    - @see [Checkout.razor](Pages/Checkout.razor)
    - @see [Index.razor](Pages/Index.razor)
    ```
    <div class="top-bar">
        <a class="logo" href="">
            <img src="img/logo.svg"/>
        </a>

        <a href="" class="nav-tab active">
            <img src="img/pizza-slice.svg"/>
            <div>Get Pizza</div>
        </a>
    </div>
    ```
- 允许客户下单：@see [Checkout.razor](Pages/Checkout.razor)
```razor
    <button class="checkout-button btn btn-warning" @onclick="PlaceOrder" disabled=@isSubmitting>
        Place order
    </button>
……
@code {
    ……
    bool isSubmitting;

    async Task PlaceOrder()
    {
        isSubmitting = true;
        var response = await HttpClient.PostAsJsonAsync(NavigationManager.BaseUri + "orders", OrderState.Order);
        var newOrderId = await response.Content.ReadFromJsonAsync<int>();
        OrderState.ResetOrder();
        NavigationManager.NavigateTo("/");
    }
}
```
- 为订单和披萨添加实体框架支持
    - @see [PizzaStoreContext.cs](PizzaStoreContext.cs)
    - @see [OrdersController.cs](OrdersController.cs)：`[Route("orders")]` Blazor 属性允许此类处理对 /orders 和 /orders/{orderId} 的传入 HTTP 请求
    - @see [OrderState.cs](OrderState.cs)：`ResetOrder()`
- 添加订单页
    - @see [MyOrders.razor](Pages/MyOrders.razor)
    - 使用 NavLink 组件，替换 [MyOrders.razor](Pages/MyOrders.razor)、[Checkout.razor](Pages/Checkout.razor)、[Index.razor](Pages/Index.razor) 导航。
      active css 类现在由 NavLink 组件自动添加到页面
    ```razor
    <div class="top-bar">
        <a class="logo" href="">
            <img src="img/logo.svg"/>
        </a>

        <NavLink href="" class="nav-tab" Match="NavLinkMatch.All">
            <img src="img/pizza-slice.svg"/>
            <div>Get Pizza</div>
        </NavLink>

        <NavLink href="myorders" class="nav-tab">
            <img src="img/bike.svg"/>
            <div>My Orders</div>
        </NavLink>
    </div>
    ```
    - @see [Checkout.razor](Pages/Checkout.razor)
    ```razor
    async Task PlaceOrder()
    {
        isSubmitting = true;
        var response = await HttpClient.PostAsJsonAsync($"{NavigationManager.BaseUri}orders", OrderState.Order);
        var newOrderId = await response.Content.ReadFromJsonAsync<int>();
        OrderState.ResetOrder();
        NavigationManager.NavigateTo("/myorders");
    }
    ```
### [路由参数如何影响 Blazor 应用的路由](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/4-explore-route-parameters-effect-apps-routing)
- 路由参数/可选路由参数：http://www.contoso.com/favoritepizza/hawaiian
```razor
@page "/FavoritePizzas/{favorite?}"

<h1>Choose a Pizza</h1>
<p>Your favorite pizza is: @Favorite</p>

@code {
	[Parameter]
	public string Favorite { get; set; }

	protected override void OnInitialized()
	{
		Favorite ??= "Fiorentina";
	}
}
```
- 路由约束：http://www.contoso.com/favoritepizza/2
```razor
@page "/FavoritePizza/{preferredsize:int}"
```
- 捕获全部路由参数：http://www.contoso.com/favoritepizza/margherita/hawaiian
```razor
@page "/FavoritePizza/{*favorites}"
```
### [使用路由参数改进应用导航](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/5-exercise-route-parameters-improve-apps-navigation)
- 创建订单详情页
    - @see [OrderDetail.razor](Pages/OrderDetail.razor)
    - @see [OrdersController.cs](OrdersController.cs) `GetOrderWithStatus(int orderId)`
    - @see [Checkout.razor](Pages/Checkout.razor) `NavigationManager.NavigateTo($"myorders/{newOrderId}");`
- 将路由参数限制为正确的数据类型：@see [OrderDetail.razor](Pages/OrderDetail.razor) `@page "/myorders/{orderId:int}"`
- 更新订单页：@see [MyOrders.razor](Pages/MyOrders.razor) `<a href="myorders/@item.Order.OrderId" class="btn btn-success">`
### [使用布局生成可重用 Blazor 组件](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/6-build-reusable-component-using-layouts)
- 编写 Blazor 布局
    - 必须继承 LayoutComponentBase 类
    - 必须在要呈现发起引用的组件内容的位置包含 `@Body` 指令
- 从 Blazor 项目模板创建了 Blazor 应用，则默认布局为 Shared/MainLayout.razor 组件
- 在 Blazor 组件中使用布局
    - 使用 `@layout` 指令引用布局，组件的 HTML 将在 `@Body` 指令的位置呈现
    - [_Imports.razor](_Imports.razor)：Blazor 编译器找到此文件时，会自动在文件夹中的所有组件中包含其指令
    - 默认布局：@see [App.razor](App.razor) `<RouteView RouteData="@routeData" DefaultLayout="@typeof(BlazingPizzasMainLayout)"/>`
### [添加 Blazor 布局以减少代码中的重复](https://learn.microsoft.com/zh-cn/training/modules/use-pages-routing-layouts-control-blazor-navigation/7-exercise-add-blazor-layouts-reduce-duplicate-code)
- 添加 MainLayout 组件
    - @see [MainLayout.razor](Shared/MainLayout.razor)
    - @see [_Host.cshtml](Pages/_Host.cshtml) `<component type="typeof(App)" render-mode="ServerPrerendered"/>`
- 更新所有页面以使用新布局
    - 删除 [MyOrders.razor](Pages/MyOrders.razor)、[Checkout.razor](Pages/Checkout.razor)、[Index.razor](Pages/Index.razor)、[OrderDetail.razor](Pages/OrderDetail.razor) top-bar div 元素
    - @see [App.razor](App.razor)
### Reference
- [Blazor 路由](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/fundamentals/routing)
- [Blazor 布局](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/layouts)
---
