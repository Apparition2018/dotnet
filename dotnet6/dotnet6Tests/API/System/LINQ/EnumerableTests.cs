using System.Linq;
using NUnit.Framework;

namespace dotnet6Tests.API.System.LINQ;

public class EnumerableTests
{
    [Test]
    public void Test()
    {
        Enumerable.Range(1, 10);
    }
}