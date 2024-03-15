## [使用 ASP.NET Core 创建 Web UI](https://learn.microsoft.com/zh-cn/training/modules/create-razor-pages-aspnet-core/)
### [了解使用 Razor Pages 的时机和原因](https://learn.microsoft.com/zh-cn/training/modules/create-razor-pages-aspnet-core/2-why-when-use-razor-pages)
- [Razor](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor) Pages 的优势：
    - 使用 HTML、CSS 和 C# 轻松设置动态 Web 应用
    - 按功能整理文件，以便于维护
    - 使用 Razor 语法将标记与服务器端 C# 代码相结合
- 分离关注点：使用 C# PageModel 类强制分离关注点，封装其 Razor 页面范围内的数据属性和逻辑操作，并为HTTP请求定义页面处理程序。
- 使用时机：
    - 想要生成动态 Web UI
    - 更喜欢也页面为中心的方法（page-focused approach）
    - 希望减少部分视图（partial views）的重复
### [自定义项目](https://learn.microsoft.com/zh-cn/training/modules/create-razor-pages-aspnet-core/3-exercise-customize-project)
- 克隆项目 [mslearn-create-razor-pages-aspnet-core](https://github.com/MicrosoftDocs/mslearn-create-razor-pages-aspnet-core)
- `dotnet new webapp` 生成的项目结构：
    - Pages/：Razor Pages 及其支持文件。每个 Razor 页面都有一个 .cshtml 文件和一个 .cshtml.cs PageModel 类文件
        - Pages 目录结构和路由请求

      | URL                            | Maps to Razor page           |
              |--------------------------------|------------------------------|
      | www.domain.com                 | Pages/Index.cshtml           |
      | www.domain.com/Index           | Pages/Index.cshtml           |
      | www.domain.com/Privacy         | Pages/Privacy.cshtml         |
      | www.domain.com/Error           | Pages/Error.cshtml           |
      | www.domain.com/Products        | Pages/Products/Index.cshtml  |
      | www.domain.com/Products/Create | Pages/Products/Create.cshtml |
        - 布局和其他共享文件

      | File                                          | Description                            |
              |-----------------------------------------------|----------------------------------------|
      | _ViewImports.cshtml                           | 导入跨多个页面使用的命名空间和类                       |
      | _ViewStart.cshtml                             | 指定所有 Razor 页面的默认布局                     |
      | Pages/Shared/_Layout.cshtml                   | _ViewStart.cshtml文件指定的布局。跨多个页面实现通用布局元素 |
      | Pages/Shared/_ValidationScriptsPartial.cshtml | 为所有页面提供验证功能                            |
    - wwwroot/：静态资产文件
    - ContosoPizza.csproj：项目配置元数据
    - Program.cs：充当应用的入口点，并配置应用行为
- 自定义登录页面
    - [Index.cshtml](Pages/Index.cshtml)，将 C# 代码块的代码替换为
    ```cshtml
    ViewData["Title"] = "The Home for Pizza Lovers";
    TimeSpan timeInBusiness = DateTime.Now - new DateTime(2018, 8, 14);
    ```
    - 修改 HTML
    ```cshtml
    <h1 class="display-4">Welcome to Contoso Pizza</h1>
    <p class="lead">The best pizza in town for @Convert.ToInt32(timeInBusiness.TotalDays) days!</p>
    ```
### 添加新的 Razor 页面
- 创建 [PizzaList](Pages/PizzaList.cshtml) 页面：`dotnet new page --name PizzaList --namespace ContosoPizza.Pages --output
  Pages`
- 将 PizzaList 页面添加到导航菜单：@see [_Layout.cshtml](Pages/Shared/_Layout.cshtml)
```cshtml
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-page="/PizzaList">Pizza List 🍕</a>
</li>
```
- 向依赖注入容器，注册 PizzaService 类，@see [Program.cs](Program.cs) `builder.Services.AddScoped<PizzaService>();`
- 显示 PizzaList
    - @see [PizzaList.cshtml.cs](Pages/PizzaList.cshtml.cs)
    - @see [PizzaList.cshtml](Pages/PizzaList.cshtml) `<table>`
### 了解 Tag Helpers 和 Page Handles
- [Tag Helpers](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/tag-helpers/intro)
    - [Partial](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/tag-helpers/built-in/partial-tag-helper)
    - [Label](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/working-with-forms#the-label-tag-helper)
    - [Input](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/working-with-forms#the-input-tag-helper)
    - [Validation Summary Message](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/working-with-forms#the-validation-summary-tag-helper)
- Page Handles：PageModel 为 HTTP 请求和用于呈现页面的数据定义 page handles
    1. OnGet：页面初始化
    2. OnPost：表单请求
### 添加新的 Pizza 表单
- 向 [PizzaList.cshtml.cs](Pages/PizzaList.cshtml.cs) 添加属性
```csharp
// 将 NewPizza 属性绑定到 Razor 页面，发出 HTTP POST 请求时，将使用用户输入填充 NewPizza 属性
[BindProperty]
public Pizza NewPizza { get; set; } = default!;
```
- 向 [PizzaList.cshtml.cs](Pages/PizzaList.cshtml.cs) 添加 page handles
```csharp
public IActionResult OnPost()
{
    // ModelState.IsValid 属性用于确定用户输入是否有效
    // 验证规则是根据 Models\Pizza.cs 中 Pizza 类上的特性（例如 Required 和 Range）推断出来的
    // 如果用户输入无效，则调用 Page 方法来重新呈现页面
    if (!ModelState.IsValid || NewPizza == null)
    {
        return Page();
    }

    _service.AddPizza(NewPizza);
    // 将用户重定向到 Get page handles
    return RedirectToAction("Get");
}
```
- [添加表单](https://learn.microsoft.com/zh-cn/training/modules/create-razor-pages-aspnet-core/6-exercise-add-new-pizza-form#add-a-form-to-create-new-pizzas)，@see [PizzaList.cshtml](Pages/PizzaList.cshtml) `<form>`
    - `asp-validation-summary`：显示整个 Model 的验证错误
    - `asp-for`：绑定 NewPizza 属性
    - `asp-validation-for`：显示每个表单字段的任何验证错误
    - `@Html.DisplayNameFor`：显示属性的 display name
- 将客户端验证脚本注入页面，@see [PizzaList.cshtml](Pages/PizzaList.cshtml)
```cshtml
@section Scripts {
<partial name="_ValidationScriptsPartial" />
}
```
- 向 [PizzaList.cshtml.cs](Pages/PizzaList.cshtml.cs) 添加 用于删除 Pizza 的 page handles
```csharp
// PizzaList.cshtml 中“删除”按钮上的 asp-page-handler 属性已设置为 Delete
// PizzaList.cshtml 中“删除”按钮上的 asp-route-id 属性将 id 参数绑定到 URL 中的 id 路由值
public IActionResult OnPostDelete(int id)
{
    _service.DeletePizza(id);

    return RedirectToAction("Get");
}
```
### 总结
- [Next Steps](https://learn.microsoft.com/zh-cn/training/modules/create-razor-pages-aspnet-core/7-summary#next-steps)
---
