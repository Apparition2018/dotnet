# Rider Settings
- n: New Project
- o: Optional
---
## Build, Execution, Deployment
## Toolset and Build
    1 安装 .NET Core SDK 3.1 / .NET SDK 6.0 / .NET SDK 8.0
    2 查看是否添加了环境变量
    3 Toolset and Build → Toolset
        3.1 .NET Core CLI executable path: Custom - %DOTNET_HOME%\dotnet.exe
        3.2 Use MSBuild Version: Auto detected
---
## Editor
### Code Style (-o)
    1 HTML → Other → Do not indent children of: 取消 body
### TODO
    1 Settings → Editor → TODO
        1.1 Patterns → +
        1.2 Pattern: (?<=\W|^)(?<TAG>TODO\(LJH\))(\W|$)(.*)
        1.3 Use color scheme TODO default colors 取消勾选
        1.4 Bold 勾选, Italic 取消勾选
        1.5 Foreground #CC0033
    2 Settings → Editor → Live Templates → C#
        2.1 New Tempalte
        2.2 Shortcut: todoljh
        2.3 Description: TODO(LJH)
        2.4 // TODO(LJH): $date$ $todo$
        2.5 Edit variables → date → Change macro →
            Current date and time in specified format → OK → Done
---
## Tools
### External Symbols (-o)
    1 Allow downloading symbols from remote locations 取消勾选
---
## NuGet (-e)
    1 Alt + Shift + 7
    2 Sources →
        2.1 NuGet.Config → Properties
            2.2.1 Global packages folder: D:\dev\.nuget\packages
            2.2.2 Local packages folder: D:\dev\.nuget\packages
        2.1 Microsoft.VisualStudio.Offline.config → Feeds
            2.1.1 Microsoft Visual Studio Offline Packages：D:\dev\.nuget\offline_packages
---
