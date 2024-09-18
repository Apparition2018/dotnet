# [VS SHORTCUTS](https://learn.microsoft.com/zh-cn/visualstudio/ide/default-keyboard-shortcuts-in-visual-studio)
- 工具 → 选项 → 环境 → 键盘
- `Ctrl + K, K (user)`
---
## Build（生成）
```
Ctrl + B                        BuildSelection                      生成选定内容
Ctrl + Shift + B                BuildSolution                       生成解决方案
Ctrl + F7                       Compile                             编译
```
---
## Debug（调试）
```
F5                              Start                               启动
Shift + F5                      StopDebugging                       停止调试
Ctrl + Shift + F5               Restart                             重新启动
F10                             StepOver                            逐过程
F11                             StepInto                            逐语句
Shift + F11                     StepOut                             跳出
F9                              ToggleBreakpoint                    切换断点
Ctrl + F9                       EnableBreakpoint                    启用断点
Ctrl + Alt + B                  Breakpoints                         断点
Ctrl + F10                      RunToCursor                         运行到光标处
Ctrl + Shift + F10              SetNextStatement                    设置下一条语句
```
---
## Edit（编辑）
```
Alt + `                         ShowNavigateMenu                    显示导航菜单
Alt + F12                       PeekDefinition                      速览定义
Ctrl + J                        ListMembers                         列出成员
Ctrl + K, Ctrl + D              FormatDocument                      设置文档的格式
Ctrl + K, Ctrl + F              FormatSelection                     设置选定内容的格式
Ctrl + K, Ctrl + H              ToogleTaskListShortcut              切换任务列表快捷方式
Ctrl + K, Ctrl + I              QuickInfo                           快速信息
Ctrl + K, Ctrl + S              SurroundWith                        外侧代码
Ctrl + W                        SelectCurrentWord                   选择当前字
Ctrl + Shift + ↑/↓              Previous/NextHighlightedReference   上/下一个突出显示的引用
Shift + F12                     FindAllReferences                   查找所有引用
Shift + Alt + E                 ExpandSelectionToEntireLine         将所选内容扩展到行
Shift + Alt + -/=               Contract/ExpandSelection            收缩/展开选定内容
Shift + Alt + L, Shift + Alt + JJoinLines                           联接行
Shift + Alt + ↑/↓               LineUp/DownExtendColumn             上/下移行扩张列
```
### Bookmark（书签）
```
Ctrl + K, Ctrl + K              ToggleBookmark                      切换书签
Ctrl + K, Ctrl + L              ClearBookmarks                      清除书签
Ctrl + K, Ctrl + P              PreviousBookmark                    上一书签
Ctrl + K, Ctrl + N              NextBookmark                        下一书签
```
### Comment（注释）
```
Ctrl + K, Ctrl + C              CommentSelection                    注释选定内容
Ctrl + K, Ctrl + U              UncommentSelection                  取消注释选定内容
Ctrl + K, Ctrl + /              ToggleLineComment                   切换行注释
Ctrl + Shift + /                ToggleBlockComment                  切换块注释
```
### GoTo（转到）
```
Ctrl + G                        GoTo                                转到
Ctrl + , | Ctrl + T             GoToAll                             转到所有
Ctrl + 1, F | Ctrl + Shift + T  GoToFile                            转到文件
Ctrl + 1, M | Alt + \           GoToMember                          转到成员
Ctrl + 1, R                     GoToRecentFile                      转到最近的文件
Ctrl + 1, S                     GoToSymbol                          转到符号
Ctrl + 1, T                     GoToType                            转到类型
Ctrl + K, Ctrl + Shift + T      GoToTypeDefinition                  转到类型定义
Ctrl + ]                        GotoBrace                           转到大括号
Ctrl + Shift + ]                GotoBraceExtend                     扩展转到大括号
Ctrl + D                        GoToFindCombo                       转到“查找”组合框
F12                             GoToDefinition                      转到定义
Ctrl + F12                      GoToImplementation                  转到声明
Ctrl + Shift + Bkspce           GoToLastEditLocation                转到上一个编辑位置
Alt + Home                      GoToBase                            转到基础映像
Alt + PgUp/PgDn                 GoToPrevious/NextIssueinFile        转到上/下个问题
Shift + Alt + F                 GotToText                           转到文本
```
### Line（行）
```
Alt + ↑/↓                       MoveSelectedLineUp/Down             将选定行上/下移
Ctrl + L                        LineCut                             剪切行
Ctrl + Shift + L                LineDelete                          删除行
Ctrl + Enter                    LineOpenAbove                       上开新行
Ctrl + Shift + Enter            LineOpenBelow                       下开新行
```
### Outlining（大纲）
```
Ctrl + M, Ctrl + O              CollapsetoDefinitions               折叠到定义
Ctrl + M, Ctrl + A              CollapseAllOutlining                折叠所有大纲显示
Ctrl + M, Ctrl + X              ExpandAllOutlining                  展开所有大纲显示
Ctrl + M, Ctrl + M              ToggleOutliningExpansion            切换大纲显示展开
Ctrl + M, Ctrl + L              ToggleAllOutlining                  切换所有大纲显示
Ctrl + M, Ctrl + P              StopOulining                        停止大纲显示
Ctrl + M, Ctrl + H              HideSelection                       隐藏选定内容
Ctrl + M, Ctrl + U              StopHidingCurrent                   停止隐藏当前区域
```
---
## EditorContextMenus（编辑器上下文菜单）
### CodeWindow（代码窗口）
```
Ctrl + K, T						ViewCallHierarchy                   查看调用层次结构
```
### FileHealthIndicator（文件运行状况指示器）
```
Ctrl + K, Ctrl + E              RunDefaultCodenup                   运行默认代码清理
```
---
## Project（项目）
```
Ctrl + Shift + A                AddNewItem                          添加新项目
Shift + Alt + A                 AddExistingItem                     添加现有项
```
---
## Refactor（重构）
```
Ctrl + R, Ctrl + E              EncapsulateField                    封装字段
Ctrl + R, Ctrl + M              ExtractMethod                       提取方法
Ctrl + R, Ctrl + R              Rename                              重命名
```
## SolutionExplorer（解决方案）
```
Ctrl + [, O                     OpenFilesFilter                     打开文件筛选器
Ctrl + [, P                     PendingChangesFilter                挂起更改筛选器
Ctrl + [, S                     SyncWithActiveDocument              与活动文档同步
```
---
## TestExplorer
```
Ctrl + R, T						RunSelectedTests                    测试资源管理器
```
## Tools（工具）
```
Ctrl + K, K                     CustomizeKeyboard (user)            自定义键盘
```
---
## View（视图）
```
F7                              ViewCode                            查看代码
Shift + F7                      ViewDesigner                        查看设计器
Ctrl + . | Alt + Enter          QuickActions                        快速操作和重构
Ctrl + -                        NavigateBackward                    向后导航
Ctrl + Shift + -                NavigateForward                     向前导航
Ctrl + Shift + F12              NextError                           下一次错误
Ctrl + Shift + .                ZoomIn                              缩小
Ctrl + Shift + ,                ZoomOut                             放大
Shift + Alt + Enter             FullScreen                          全屏幕

F4                              PropertiesWindow                    属性窗口
Ctrl + K, Ctrl + W              BookmarkWindow                      书签窗口
Ctrl + 0, G                     GitWindow                           Git 更改
Ctrl + 0, R                     GitRepositoryWindow                 Git 存储库
Ctrl + `                        Terimianl                           终端
Ctrl + \, D						CodeDefinitionWindow                代码定义窗口
Ctrl + \, E                     ErrorList                           错误列表
Ctrl + \, T                     TaskList                            任务列表
Ctrl + \, Ctrl + N              Notifications                       通知
Ctrl + Alt + J					ObjectBrowser                       对象浏览器
Ctrl + Alt + K					CallHierarchy                       调用层次结构
Ctrl + Alt + L                  SolutionExplorer                    解决方案资源管理器
Ctrl + Alt + O                  Output                              输出
Ctrl + Alt + T					DocumentOutline                     文档大纲
Ctrl + Alt + X                  Toolbox                             工具箱
Ctrl + Alt + F3                 Branch                              分支
Ctrl + Alt + F4                 Repository                          存储库
Ctrl + Shift + C				ClassView                           类视图
```
---
## Window（窗口）
```
Alt + `                         WindowSearch                        窗口搜索
Ctrl + K, H                     HideShowAllToolWindows (user)       隐藏显示所有工具窗口
Ctrl + Q                        QuickLaunch                         快速启动
Ctrl + ;                        SolutionExplorerSearch              解决方案资源管理器搜索
Ctrl + Tab                      NextDocumentWindowNav               下一个文档窗口导航栏
Ctrl + Alt + ↓                  ShowEzMDIFileList                   显示EzMDI文件列表
Ctrl + Alt + PgUp/PgDn          Previous/NextTab                    上/下一个选项卡
Ctrl + Alt + Home               KeepTabOpen                         将选项卡保持打开状态
Shift + Esc                     Close                               关闭
```
---
## [Window management](https://learn.microsoft.com/zh-cn/visualstudio/ide/productivity-shortcuts#window-management)（窗口管理）
```
Win + ↑/↓                       Maximize/minimize windows           最大化/最小化窗口
Win + ←/→                       Move/dock floating windows          移动/停靠浮动窗口
```
---
## [ACCESS TOOLBARS](https://learn.microsoft.com/zh-cn/visualstudio/ide/reference/accessibility-tips-and-tricks#access-toolbars-by-using-keyboard-shortcuts)（访问工具栏）
```         
Alt                             IDE toolbars                        选择“标准”工具栏上的第一个按钮
Shift + Alt                     Tool window toolbars                将焦点移动到工具窗口中的工具栏
Ctrl + Tab                      Toolbars                            转到下一工具栏中的第一项
```
## [Other](https://learn.microsoft.com/zh-cn/visualstudio/ide/reference/accessibility-tips-and-tricks#other-useful-keyboard-shortcuts)（其他）
```
Shift + F10                     Context menus                       打开上下文菜单（右键单击）
Ctrl + E, Ctrl + C              Network Operations Menu             
```
---
