## [使用 React 和适用于 ASP.NET Core 的最小 API 创建全栈应用程序](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-spa/)
### [练习 - 创建前端应用](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-spa/3-exercise-create-front-end?tabs=github-codespaces)
- [搭建应用的基架](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-spa/3-exercise-create-front-end?tabs=github-codespaces#scaffold-an-app)
    - 创建应用：`npm create vite@latest PizzaClient --template react`
    ```
    Package name        pizzaclient
    Select a framework  React
    Select a variant    JavaScript
    ```
    - 安装依赖项：`cd PizzaClient` → `npm install`
    - 更新 [vite.config.js](vite.config.js) 以提供一致的前端端口：`port: 3000`
    - 启动应用：`npm run dev`
- 生成 [Pizza 组件](src/Pizza.jsx)：负责管理数据并将其传递给 PizzaList 子组件
    - useState 钩子用于管理 data 和 maxId
    - useEffect 钩子用于设置初始页面请求上的数据
- 生成 [Pizza 列表组件](src/PizzaList.jsx)：呈现窗体以创建和编辑 Pizza 项
- 将 Pizza 添加到应用：[main.jsx](src/main.jsx)
```jsx
ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <Pizza />
  </React.StrictMode>,
)
```
### [练习 - 创建 API](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-spa/5-exercise-create-api)
- 准备代码以从模拟服务器提取数据
    - 通过调用模拟的 API 来提取数据：@see [Pizza.jsx](src/Pizza.jsx)
    ```jsx
    const API_URL = '/pizza';
    // ……
    fetch(API_URL, {})
    ```
    - @see [db.json](db.json)
- 准备到模拟服务器的代理：@see [vite.config.js](vite.config.js) proxy
- 启动模拟服务器：`npx json-server --watch --port 5181 db.json`
- 准备代码以从 .NET API 服务器提取数据
    - 启用 CORS：@see [Program.cs](../../PizzaStore/Program.cs)
    ```csharp
    // 1) define a unique string
    string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    // 2) define allowed domains, in this case "http://example.com" and "*" = all
    //    domains, for testing purposes only.
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
          builder =>
          {
              builder.WithOrigins(
                "http://example.com", "*");
          });
    });
    ……

    // 3) use the capability
    app.UseCors(MyAllowSpecificOrigins);
    ```
    - 启动 .NET Core API 服务器：`dotnet run`
---
### [练习 - 在应用中使用设计系统](https://learn.microsoft.com/zh-cn/training/modules/build-web-api-minimal-spa/7-exercise-use-design-system)
- 安装 Material UI：`cd PizzaClient` → `npm install @mui/material @emotion/react @emotion/styled @mui/icons-material`
- 导入 Material UI：@see [main.jsx](src/main.jsx)
```jsx
import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
const theme = createTheme();
// ……
ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <ThemeProvider theme={theme}>
            <CssBaseline />
            <Pizza className="Pizza"/>
        </ThemeProvider>
    </React.StrictMode>,
)
```
- @see [PizzaList.jsx](src/PizzaList.jsx)
---
