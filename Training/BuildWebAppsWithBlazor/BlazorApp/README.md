## [使用 Blazor 生成第一个 Web 应用](https://learn.microsoft.com/zh-cn/training/modules/build-your-first-blazor-web-app/)
### 练习 - 创建并运行 Blazor Web 应用
- 创建
    - C# Dev Kit：Ctrl + Shift + P → `.net:n`：新建项目… → Blazor Web 应用 → BlazorApp
    - .NET CLI：创建 BlazorApp 文件夹 → `dotnet new blazor`
- 运行
    - 集成调试器
    - `dotnet watch`
### Razor 组件
- 主页 [Home.razor](Components/Pages/Home.razor)
```razor
@* 指定页面的路由 *@
@page "/"

@* 一个 Blazor 组件，用于设置当前页面的标题 *@
<PageTitle>Home</PageTitle>
```
- 使用组件：添加一个 HTML-style tag，名称与组件的名称一致，`<MyButton />`
- 组件参数：通过向具有 `[Parameter]` 属性的组件添加公共 C# 属性来定义
- @code：跟踪组件状态、添加组件参数、实现组件生命周期事件和定义事件处理程序
### [练习 - 修改组件](https://learn.microsoft.com/zh-cn/training/modules/build-your-first-blazor-web-app/5-exercise-add-component#modify-a-component)
- 在 [Counter 组件](Components/Pages/Counter.razor) 上定义一个参数，用于指定每次单击按钮时递增的量
```Counter.razor
[Parameter]
public int IncrementAmount { get; set; } = 1;

private void IncrementCount()
{
    currentCount += IncrementAmount;
}
```
```Home.razor
<Counter IncrementAmount="10"/>
```
### Reference
- [Blazor 项目结构](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/project-structure)
---
## [使用 Blazor 生成一个待办事项列表](https://learn.microsoft.com/zh-cn/training/modules/build-blazor-todo-list/)
### 数据绑定和事件
- 呈现 C# 表达式值：使用前导 `@` 字符，如 `@currentCount`
- 控制流：`@if`、`@foreach`
- 处理事件：`@on`
- 数据绑定：`@bind`
- 启用交互性：`@rendermode` or `<Counter @rendermode="InteractiveServer"/>`
### 练习 - 创建待办事项列表
- 创建 [Todo 组件](Components/Pages/Todo.razor)：`dotnet new razorcomponent -n Todo -o Components/Pages`，顶部添加代码
```razor
@page "/todo"
@rendermode InteractiveServer
```
- 将待办事项页面添加[导航菜单](Components/Layout/NavMenu.razor)
```razor
<nav class="flex-column">
    ……
    <div class="nav-item px-3">
        <NavLink class="nav-link" href="todo">
            <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Todo
        </NavLink>
    </div>
</nav>
```
- 生成待办事项列表
    - @see [TodoItem.cs](TodoItem.cs)
    - @see [Todo.razor](Components/Pages/Todo.razor)
    ```razor
    <ul>
        @foreach (var todo in todos)
        {
            <li>@todo.Title</li>
        }
    </ul>

    @code {
        private List<TodoItem> todos = new();
    }
    ```
- 添加待办事项，@see [Todo.razor](Components/Pages/Todo.razor)
```razor
<input @bind="newTodo"/>
<button @onclick="AddTodo">Add todo</button>

@code {
    private List<TodoItem> todos = new();
    string newTodo = "";

    void AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(newTodo))
        {
            todos.Add(new TodoItem { Title = newTodo });
            newTodo = string.Empty;
        }
    }
}
```
- 添加复选框并计算未完成的待办事项，@see [Todo.razor](Components/Pages/Todo.razor)
```razor
<h3>Todo (@todos.Count(todo => !todo.IsDone))</h3>
……
<ul>
    @foreach (var todo in todos)
    {
        <li>
            <input type="checkbox" @bind="todo.IsDone"/>
            <input @bind="todo.Title"/>
        </li>
    }
</ul>
```
### Reference
- [Razor 语法参考](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor)
- [Blazor 呈现模式](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/render-modes)
---
