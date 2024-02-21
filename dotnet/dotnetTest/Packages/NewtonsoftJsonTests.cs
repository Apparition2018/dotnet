using Newtonsoft.Json;

namespace dotnetTest.Packages;

/// <summary>
/// <a href="https://www.newtonsoft.com/json">Newtonsoft Json</a>
/// </summary>
/// <remarks>
/// <a href="https://www.nuget.org/packages/Newtonsoft.Json">NuGet Gallery</a>
/// </remarks>
public class NewtonsoftJsonTests
{
    class Account
    {
        public string? Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string>? Roles { get; set; }
    }

    /// <summary>使用格式将指定的对象序列化为 JSON 字符串</summary>
    [Test]
    public void SerializeObject()
    {
        Account account = new Account
        {
            Email = "james@example.com",
            Active = true,
            CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
            Roles = new List<string>
            {
                "User",
                "Admin"
            }
        };

        Console.WriteLine(JsonConvert.SerializeObject(account, Formatting.Indented));
    }
}
