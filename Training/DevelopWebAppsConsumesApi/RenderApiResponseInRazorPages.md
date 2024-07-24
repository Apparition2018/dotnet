## [在 ASP.NET Core Razor Pages 中呈现 API 响应](https://learn.microsoft.com/zh-cn/training/modules/render-api-responses-razor-pages/)
### Razor Pages 项目结构
- @see [ContosoPizza/README.md Razor#Razor Pages 项目结构](../BuildWebAppsWithAsp.NetCore/CreateWebUI/ContosoPizza/README.md#练习---自定义项目)
### [发现 Razor Pages 语法](https://learn.microsoft.com/zh-cn/training/modules/render-api-responses-razor-pages/3-discover-razor-syntax)
- [Razor 语法](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor#razor-syntax)
```cshtml
<!- 使用 @ 符号从 HTML 转换为 C#；在 HTML 输出中呈现 @Username 的值 ->
<p>@Username</p>

<!- 对 @ 符号进行转义；在 HTML 输出中呈现 @Username ->
<p>@@Username</p>

<!- 包含电子邮件地址的 HTML 属性和内容不将 @ 符号视为转换字符 ->
<a href="mailto:Support@contoso.com">Support@contoso.com</a>
```
- @see [BlazorApp/README.md#数据绑定和事件](../BuildWebAppsWithBlazor/BlazorApp/README.md#数据绑定和事件)
### [练习 - 在 Razor Pages 中呈现 API 响应](https://microsoftlearning.github.io/APL-2002-develop-aspnet-core-consumes-api/Instructions/Labs/03-render-api-results-razor-pages.html)
- 分别启动 [FruitAPI](FruitAPI) 和 [FruitWebApp](FruitWebApp) 项目
- 实现代码以在索引页面上呈现数据：@see [Index.cshtml](FruitWebApp/Pages/Index.cshtml) render API data code block
- 实现代码以处理添加到列表功能：@see [Add.cshtml](FruitWebApp/Pages/Add.cshtml) render Add code block
- 实现代码以处理编辑功能：@see [Edit.cshtml](FruitWebApp/Pages/Edit.cshtml) render Edit code block
- 实现代码以处理删除功能：@see [Delete.cshtml](FruitWebApp/Pages/Edit.cshtml) render Delete code block
### Reference
- [ASP.NET Core 的 Razor 语法参考](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/views/razor)
- [使用 Razor 语法进行 ASP.NET Web 编程 (C#) 简介](https://learn.microsoft.com/zh-cn/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c#the-top-8-programming-tips)
---
