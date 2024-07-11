## [使用 Blazor 生成可重用组件](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-reusable-components/)
### [Razor 类库创建和概念](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-reusable-components/2-concepts-razor-class-library)
- [客户端浏览器兼容性分析器](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/class-libraries?tabs=visual-studio#client-side-browser-compatibility-analyzer)：@see [FirstClassLibrary.csproj](FirstClassLibrary/FirstClassLibrary.csproj)
    ```razor
        <ItemGroup>
            <SupportedPlatform Include="browser"/>
        </ItemGroup>
    ```
- 静态资产交付 [wwwroot](wwwroot)
    - 可供根目录下的组件（及其 CSS 文件）进行相对引用
    - 可供托管 Blazor 应用程序引用，绝对文件夹引用的格式如：`/_content/{PACKAGE_ID}/{PATH_AND_FILENAME_INSIDE_WWWROOT}`
### [创建 Razor 类库](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-reusable-components/3-create-razor-class-library)
- 创建 Razor 类库项目：`dotnet new razorclasslib -o FirstClassLibrary -f net8.0`
- 生成 modal 对话框组件：@see [Modal.razor](FirstClassLibrary/Modal.razor)、[Modal.razor.css](FirstClassLibrary/Modal.razor.css)
- 引用和使用 modal 组件
    - 创建新 Blazor Server 项目：`dotnet new blazor -o MyBlazorApp -f net8.0`
    - 引用 FirstClassLibrary：`dotnet add reference ../FirstClassLibrary`
    - @see [_Imports.razor](MyBlazorApp/Components/_Imports.razor)：`@using FirstClassLibrary`
    - @see [Home.razor](MyBlazorApp/Components/Pages/Home.razor)
        ```razor
        <Modal Title="My first Modal dialog" Show="true">
            <p>
                This is my first modal dialog
            </p>
        </Modal>
        ```
### [创建 NuGet 包](https://learn.microsoft.com/zh-cn/training/modules/blazor-build-reusable-components/5-nuget-package)
- 向 FirstClassLibrary 添加包属性：@see [FirstClassLibrary.csproj](FirstClassLibrary/FirstClassLibrary.csproj)
    ```csproj
    <PropertyGroup>
        <PackageId>My.FirstClassLibrary</PackageId>
        <Version>0.1.0</Version>
        <Authors>LJH</Authors>
        <Company>LJH</Company>
        <Description>This is a Razor component library with a cool modal window component.</Description>
    </PropertyGroup>
    ```
- 打包库以便重用：`dotnet pack`
- 在 MyBlazorServer 中添加对 NuGet 包的引用
    - 删除 [MyBlazorApp.csproj](MyBlazorApp/MyBlazorApp.csproj) 代码
        ```
        <ItemGroup>
            <ProjectReference Include="..\FirstClassLibrary\FirstClassLibrary.csproj"/>
        </ItemGroup>
        ```
    - `dotnet add package My.FirstClassLibrary -s ../FirstClassLibrary/bin/Release`
### Reference
- [使用 Razor 类库 (RCL) 中的 ASP.NET Core Razor 组件](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/class-libraries)
---
