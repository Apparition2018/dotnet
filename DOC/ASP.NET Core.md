# ASP.NET Core

---
## Reference
1. [ASP.NET 文档 | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/)
2. [ASP.NET Core 101 | Microsoft Learn](https://learn.microsoft.com/zh-cn/shows/ASPNET-Core-101/)：@see ContosoCrafts/README.md
    - [repository](https://github.com/dotnet-presentations/ContosoCrafts)
3. [了解 ASP.NET Core](https://dotnet.microsoft.com/zh-cn/learn/aspnet)
    - [什么是 ASP.NET Core?](https://dotnet.microsoft.com/zh-cn/learn/aspnet/what-is-aspnet-core)
---
## [ASP.NET 4.x vs ASP.NET Core](https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/choose-aspnet-framework)
1. [ASP.NET 概述 | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/overview)
2. [什么是 ASP.NET?](https://dotnet.microsoft.com/zh-cn/learn/aspnet/what-is-aspnet)
---
## [Routing](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/controllers/routing)
### [Routing Fundamental](https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/routing)
### [Conventional Route](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/controllers/routing#attribute-routing-for-rest-apis)
```
/** Program.cs */
app.MapControllerRoute(
    "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 简写
// app.MapDefaultControllerRoute();
```
### [Attribute Route](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/controllers/routing#attribute-routing-for-rest-apis)
```
/** Program.cs */
app.MapControllers();
```
- Token replacement：标记替换，`[controller]`，`[action]`，`[area]`
```
/** XxxController.cs */
[ApiController]
[Route("[controller]/[action]", Name = "[controller]_[action]")]
public class XxxController : ControllerBase { ... }
```
---
## Web API apps
### [ApiController](https://learn.microsoft.com/zh-cn/aspnet/core/web-api/#apicontroller-attribute)
1. Attribute routing requirement：属性路由要求，`[Route("[controller]")]`
2. Automatic HTTP 400 responses：自动 HTTP 400 响应
3. Binding source parameter inference：绑定原参数推理
    - `[FromBody]`,`[FromForm]`,`[FromHeader]`,`[FromQuery]`,`[FromRoute]`,`[FromServices]`
4. Multipart/form-data request inference：Multipart/form-data 请求推理
5. Problem details for error status codes：错误状态码的问题详细信息
### [HttpRepl](https://learn.microsoft.com/zh-cn/aspnet/core/web-api/http-repl/)
```shell
# 安装
dotnet tool install -g Microsoft.dotnet-httprepl

# 帮助
httprepl -h
# 启动
httprepl
# 连接 ContosoPizza
connect https://localhost:44365
# 手动指向 openapi
connect https://localhost:44365 --openapi /swagger/v1/swagger.json
# 启用详细输出
connect https://localhost:44365 --verbose
```
---
