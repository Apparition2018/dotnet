# simple-website

---
## [使用 Visual Studio Code 进行 Web 开发](https://learn.microsoft.com/zh-cn/training/modules/get-started-with-web-development/)
### 设置 web 应用结构
- Ctrl + N 新建文件：index.html、main.css、app.js
### 添加 HTML
- HTML5 模板代码：`html:5`
- 修改 [index.html](index.html) 内容
- [UTF-8 字符集](https://webhint.io/docs/user-guide/hints/hint-meta-charset-utf-8/)
- Alt + B 在默认浏览器打开
- Ctrl + Shift + I 打开开发者工具
### 使用 CSS 设置 HTML 样式
- 外部 CSS：`<link rel="stylesheet" href="main.css">`
- 修改 [main.css](main.css) 内容
- `:root` 选择器表示 `<html>` 元素，通常使用其定义全局 CSS 变量
### 使用 Javascript 添加交互
- [index.html](index.html)
    - 在 \<body> 末尾添加 `<script src="app.js"></script>`
    - 添加容错：`<noscript>You need to enable JavaScript to view the full site.</noscript>`
- 修改 [app.js](app.js) 内容
- [严格模式](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Strict_mode)：`'use strict';`
### [总结](https://learn.microsoft.com/zh-cn/training/modules/get-started-with-web-development/7-summary)

---
