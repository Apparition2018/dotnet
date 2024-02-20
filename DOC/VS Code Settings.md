# VS Code Settings

---
## Reference
1. [vscode 配置教程](https://zhuanlan.zhihu.com/p/113222681)
---
## Extensions
- 自定义安装位置：快捷方式目标后添加 `--extensions-dir "D:\dev\.vscode\extensions"`
---
## Settings JSON
```json5
{
    "files.autoSave": "afterDelay",
    "git.path": "D:\\Git\\cmd\\git.exe",
    "emmet.includeLanguages": {
        "vue-html": "html",
        "javascript": "javascriptreact",
        "plaintext": "jade"
    },
    // 设置 Terminal 默认为 Git-Bash
    "terminal.integrated.profiles.windows": {
        "PowerShell": {
            "source": "PowerShell",
            "icon": "terminal-powershell"
        },
        "Command Prompt": {
            "path": [
                "${env:windir}\\Sysnative\\cmd.exe",
                "${env:windir}\\System32\\cmd.exe"
            ],
            "args": [],
            "icon": "terminal-cmd"
        },
        "Git-Bash": {
            "path": "D:\\Git\\bin\\bash.exe",
            "args": []
        },
        "Windows PowerShell": {
            "path": "C:\\WINDOWS\\System32\\WindowsPowerShell\\v1.0\\powershell.exe"
        }
    },
    "terminal.integrated.defaultProfile.windows": "Git-Bash"
}
```
---
## [Tasks](https://code.visualstudio.com/docs/editor/tasks)
```json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "Run HTML file with Chrome",
            "type": "process",
            "command": "Chrome",
            "args": ["${file}"],
            "windows": {
                "command": "E:/Chrome/App/chrome.exe"
            },
            "group": "build",
            "presentation": {
                "reveal": "never"
            },
            "problemMatcher": "$msCompile"
        }
    ]
}
```
---
