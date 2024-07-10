## [实现针对 C# 的 Visual Studio Code 调试工具](https://learn.microsoft.com/zh-cn/training/modules/implement-visual-studio-code-debugging-tools/)
### [VS Code 调试器用户界面中的调试功能](https://learn.microsoft.com/zh-cn/training/modules/implement-visual-studio-code-debugging-tools/2-examine-visual-studio-code-debugger)
- “运行”菜单选项
- “运行和调试”视图用户界面
### 在调试环境运行代码
- Ctrl + Shift + P → `.net:g`：生成用于生成和调试的资产
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
