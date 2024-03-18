# Rider Settings
- -n: New
- -e: Every Time
---
## Code Style (-n)
    1. Settings → Editor → Code Style
    2. HTML → Other
        2.1 Do not indent children of: 取调 body
---
## TODO (-n)
    1. Settings → Editor → TODO
        1.1 Patterns → +
        1.2 Pattern: (?<=\W|^)(?<TAG>TODO\(LJH\))(\W|$)(.*)
        1.3 Use color scheme TODO default colors 取消勾选
        1.4 Bold 勾选
        1.5 Foreground #CC0033
    2. Settings → Editor → Live Templates → C#
        2.1 New Tempalte
        2.2 Shortcut: todoljh
        2.3 Description: TODO(LJH)
        2.4 // TODO(LJH): $date$ $todo$
        2.5 Edit variables → date →
            2.5.1 Change macro → Current date and time in specified format → OK
            2.5.2 d
---
## Toolset and Build
    1. 安装 .NET Core SDK 3.1 / .NET SDK 6.0 / .NET SDK 8.0
    2. 查看是否添加了环境变量
    3. Settings → Build, Execution, Deployment → Toolset and Build → Toolset
        3.1 .NET Core CLI executable path: Custom - %DOTNET_HOME%\dotnet.exe
        3.2 Use MSBuild Version: Auto detected
---
## External Symbols
    1. Settings → Tools → External Symbols
    2. Allow downloading symbols from remote locations 取消勾选
---
## NuGet (-e)
    1. Alt + Shift + 7
    2. Sources → Properties
        2.1 Global packages folder: D:\dev\.nuget\packages
        2.2 Local packages folder: D:\dev\.nuget\packages
---
