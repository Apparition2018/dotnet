## [使用 Visual Studio 将 Web 应用发布到 Azure](https://learn.microsoft.com/zh-cn/training/modules/publish-azure-web-app-with-visual-studio/)
### 安装必要的工作负载
- 安装 Visual Studio 工作负荷
    - 开始菜单 → Visual Studio Installer → 修改
    - 工作负载 → Web 和云 → 勾选 “ASP.NET 和 Web 开发” 和 “Azure 开发” → 修改
### 练习 - 创建新的 ASP.NET Core 应用
- 创建 ASP.NET Core 项目 (Visual Studio 2022)
    1. 创建新项目
    2. 模板选择 ASP.NET Core Web 应用 → 下一步
    3. 项目名称：AlpineSkiHouse → 下一步
    4. 框架：.NET 6.0 → 创建
- 在本地计算机上 build 和 test
    ```
    F5          build the project and run in debug mode
    Ctrl + F5   build the project and run without attaching the debugger
    ```
### [探索 Azure 应用服务](https://learn.microsoft.com/zh-cn/training/modules/publish-azure-web-app-with-visual-studio/4-explore-the-azure-app-service)
### [练习 - 从 Visual Studio 发布 ASP.NET 应用](https://learn.microsoft.com/zh-cn/training/modules/publish-azure-web-app-with-visual-studio/5-exercise-publish-an-asp.net-app-from-visual-studio)
- 将 ASP.NET Core Web 应用发布到 Azure
    - 右键项目 → 发布
    - 目标：Azure → 下一步
    - 特定目标：Azure 应用服务(Windows) → 下一步
---
