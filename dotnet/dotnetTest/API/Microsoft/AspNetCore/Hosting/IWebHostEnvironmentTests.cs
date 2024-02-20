namespace dotnetTest.API.Microsoft.AspNetCore.Hosting;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.aspnetcore.hosting.iwebhostenvironment">IWebHostEnvironment</a>
/// 提供有关运行应用程序的 Web 托管环境的信息
/// </summary>
public interface IWebHostEnvironmentTests
{
    /// <summary>获取或设置包含 Web 可服务应用程序内容文件的目录的绝对路径。 这默认为“wwwroot”子文件夹</summary>
    [Test]
    public void WebRootPath()
    {
    }
}
