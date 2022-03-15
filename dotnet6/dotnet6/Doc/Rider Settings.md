# Rider Settings

---
## dotnet
    1. 安装 .NET Core SDK 3.1 / .NET SDK 5.0 / .NET SDK 6.0
    2. 查看是否添加了环境变量
    3. Settings → Build, Execution, Deployment → Toolset and Build → Toolset
        2.1 .NET Core CLI executable path: Custom - %DOTNET_HOME%\dotnet.exe
        2.2 Use MSBuild Version: Auto detected
---
## NuGet
    1. Alt + Shift + 7
    2. Sources → Properties
    3. Global packages folder: D:\dev\.nuget\packages
---
## Solution
    1. Settings → Appearance & Behavior → System Settings
    2. Solution
        2.1 Open project in New window
        2.2 Default project directory: D:\Liang\git
---
## External Symbols
    1. Settings → Tools → External Symbols
    2. Allow downloading symbols from remote locations 取消勾选
---
## TODO
    1. Settings → Editor → TODO
    2. Patterns → +
        2.1 Pattern: (?<=\W|^)(?<TAG>TODO-LJH)(\W|$)(.*)
        2.2 Use color scheme TODO default colors 取消勾选
        2.3 Bold 勾选
        2.4 Foreground #CC0033
    3. Settings → Editor → Live Templates → C#
        3.1 // TODO-LJH: $date$ $todo$
        3.2 Shortcut: toduljh
        3.3 Description: TODO-LJH
---