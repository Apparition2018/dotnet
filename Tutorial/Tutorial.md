# Tutorials

---
## [控制台应用模板-生成顶级语句](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/top-level-templates)
### [使用新的程序样式](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/top-level-templates#use-the-new-program-style)
1. [顶级语句](../dotnet/dotnet/Program.cs)
2. [全局 using 指令](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/top-level-templates#global-using-directives)
    1. 添加 \<Using> 项
        ```.csproj
        <ItemGroup>
            <Using Include="My.Awesome.Namespace"/>
        </ItemGroup>
        ```
    2. `global using`
3. [隐式 using 指令](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/top-level-templates#implicit-using-directives)
    ```.csproj
    <PropertyGroup>
        <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup
    ```
---
## 使用 VS Code
1. [创建控制台应用](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/with-visual-studio-code)
    1. 创建 HelloWorld 文件夹：文件夹名称将是项目名称和命名空间名称
    2. 右键文件夹 → 在集成终端打开 → 输入 `dotnet new console --framework net8.0 --use-program-main`
       - [--use-program-main](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/top-level-templates#use-the-old-program-style)：使用旧程序样式
    3. 运行应用：`dotnet run`
2. [调试应用](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/debugging-with-visual-studio-code)
    - [设置条件断点](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/debugging-with-visual-studio-code)
        1. 右键断点 → 编辑断点…
        2. 在下拉选择框选择 Expression，输入 `String.IsNullOrEmpty(name)`
3. [发布应用](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/publishing-with-visual-studio-code)
    - 使用 Release 构建配置：`dotnet run --configuration Release`
    - [构建生成的文件](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/publishing-with-visual-studio-code)
    - 运行已发布的应用：`dotnet HelloWorld.dll`
4. [创建类库](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/library-with-visual-studio-code)
    1. 创建解决方案
        1. 创建 ClassLibraryProjects 文件夹
        2. 创建解决方案文件：`dotnet new sln`
    2. 创建类库：`dotnet new classlib -o StringLibrary`
        1. 将类库项目添加到解决方案：`dotnet sln add StringLibrary/StringLibrary.csproj`
        2. 修改 Class1.cs 内容并保存
        3. 构建解决方案并验证项目的编译是否没有错误：`dotnet build`
    3. 将控制台应用添加到解决方案
        1. 创建控制台应用：`dotnet new console -o ShowCase`
        2. `dotnet sln add ShowCase/ShowCase.csproj`
        3. 修改 Programs.cs 内容并保存
    4. 添加项目引用：`dotnet add ShowCase/ShowCase.csproj reference StringLibrary/StringLibrary.csproj`
    5. 运行应用：`dotnet run --project ShowCase/ShowCase.csproj`
5. [测试类库](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/testing-library-with-visual-studio-code)
    1. 创建 unit 测试项目
        1. 在 ClassLibraryProjects 项目下创建 unit 测试项目：`dotnet new mstest -o StringLibraryTest`
        2. 将测试项目添加到解决方案：`dotnet sln add StringLibraryTest/StringLibraryTest.csproj`
    2. 添加项目引用：`dotnet add StringLibraryTest/StringLibraryTest.csproj reference StringLibrary/StringLibrary.csproj`
    3. 添加并运行 unit 测试方法
        1. 修改 UnitTest1.cs 内容并保存
        2. 运行测试：`dotnet test StringLibraryTest/StringLibraryTest.csproj`
    4. 使用 Release 构建配置运行测试：`dotnet test StringLibraryTest/StringLibraryTest.csproj --configuration Release`
6. 安装包：`dotnet add package`
7. [创建和发布包](https://learn.microsoft.com/zh-cn/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli?toc=%2Fdotnet%2Ffundamentals%2Ftoc.json&bc=%2Fdotnet%2Fbreadcrumb%2Ftoc.json)
    1. 将包元数据添加到项目文件
    2. 运行 pack 命令：`dotnet pack`
    3. 发布包
---
