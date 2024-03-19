# ContosoPizza

---
## [使用 ASP.NET Core 控制器创建 Web API](https://learn.microsoft.com/zh-cn/learn/modules/build-web-api-aspnet-core/)
### [ASP.NET Core 中的 REST](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-aspnet-core/2-what-is-rest-in-aspnet)
- 在 ASP.NET Core 中创建 API 的好处
    - 简单的序列化：Endpoints 自动将类序列化为正确格式的 JSON
    - 身份验证和授权：API endpoints 内置了对行业标准 JSON Web Tokens（JWT）的支持
    - 与代码一起路由：可以使用 attributes 来定义与代码内联的路由和谓词
    - 默认使用 HTTPS
### [练习 - 创建 Web API 项目](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-aspnet-core/3-exercise-create-web-api)
- 创建并浏览 Web API 项目
    - 创建 ContosoPizza 文件夹 → `dotnet new webapi -controllers -f net8.0`
- 生成并测试 Web API
    - `dotnet run` → https://localhost:7261/weatherforecast
- 命令行 [HTTP REPL](https://learn.microsoft.com/zh-cn/aspnet/core/web-api/http-repl/)
    - `dotnet tool install -g Microsoft.dotnet-httprepl`
    - 连接 web API：`httprepl https://localhost:7261` or
      `httprepl` → `(Disconnected)> connect https://localhost:7261`
    - 可用 endpoints：`ls`
    - 转到 WeatherForecast endpoint：`cd WeatherForecast`
    - 发出 GET 请求：`get`
    - 结束 HttpRepl 会话：`end`
### [Web API 控制器](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-aspnet-core/4-aspnet-controllers)
- @see [PizzaController.cs](Controllers/WeatherForecastController.cs)
- 继承自 ControllerBase
- API 控制器类属性：
    - [[ApiController]](https://learn.microsoft.com/zh-cn/aspnet/core/web-api#apicontroller-attribute)
    - \[Route]：定义路由模式 [controller]，控制器的名称将替换 定义路由模式 [controller] token
### 练习 - 添加数据存储
- Models：@see [Pizza.cs](Models/Pizza.cs)
- Services：@see [PizzaService.cs](Services/PizzaService.cs)
### [练习 - 添加控制器](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-aspnet-core/6-exercise-add-controller)
- @see [PizzaController.cs](Controllers/PizzaController.cs)
- 返回类型 ActionResult：所有 action results 的基类
- 使用 [.http 文件](ContosoPizza.http) 测试控制器
### 练习 - CRUD 操作
- 返回类型 IActionResult：可让客户端知道请求是否成功
### 总结
- [videos](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-aspnet-core/9-summary#videos-for-learning-more)
- [articles](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-aspnet-core/9-summary#articles-for-learning-more)
---
