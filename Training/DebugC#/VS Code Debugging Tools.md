## [实现针对 C# 的 Visual Studio Code 调试工具](https://learn.microsoft.com/zh-cn/training/modules/implement-visual-studio-code-debugging-tools/)
### [VS Code 调试器用户界面](https://learn.microsoft.com/zh-cn/training/modules/implement-visual-studio-code-debugging-tools/2-examine-visual-studio-code-debugger)
- “运行”菜单选项
- “运行和调试”视图用户界面
    1. “运行和调试”控制面板：配置和启动调试会话
    2. “变量”部分：在调试会话期间查看和管理变量状态；可以双击变量名称设置值
    3. “监视”部分：监视变量或表达式
    4. “调用堆栈”部分：跟踪正在运行的应用程序内的当前执行点
    5. “断点”部分
    6. “调试”工具栏：控制调试过程中的代码执行
    7. 当前执行步骤
    8. 调试控制台：显示来自调试器的消息
### 在调试环境运行代码
- Ctrl + Shift + P → .NET 生成用于生成和调试的资产：`.net: g`
### 断点配置选项
- 右键断点 → 编辑断点…：①条件断点（表达式） ②命中次数 ③日志点（日志消息） ④等待断点
### [launch 配置文件](https://learn.microsoft.com/zh-cn/training/modules/implement-visual-studio-code-debugging-tools/6-examine-launch-configurations)
- 适应控制台输入：`"console": "integratedTerminal",`
- [适应多应用程序](https://learn.microsoft.com/zh-cn/training/modules/implement-visual-studio-code-debugging-tools/6-examine-launch-configurations#update-the-launch-configuration-to-accommodate-multiple-applications)
### Reference
- [Debugging in Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)
- [Configuring C# debugging](https://code.visualstudio.com/docs/csharp/debugger-settings)
- [vscode-csharp/debugger.md](https://github.com/dotnet/vscode-csharp/blob/main/debugger.md)
---
