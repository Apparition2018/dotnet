using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace dotnet6Tests.Packages;

/// <summary>Newtonsoft Json</summary>
/// <remarks>https://www.newtonsoft.com/json</remarks>
public class NewtonsoftJsonTests
{
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

public class Account
{
    public string? Email { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public IList<string>? Roles { get; set; }
}