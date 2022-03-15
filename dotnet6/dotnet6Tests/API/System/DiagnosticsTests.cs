using System.Diagnostics;
using NUnit.Framework;

namespace dotnet6Tests.API.System;

public class DiagnosticsTests
{
    [Test]
    public void Test()
    {
        // static void          WriteLineIf(bool condition, string? message)
        Debug.WriteLineIf(true, "true");

        // static void          Assert([DoesNotReturnIf(false)] bool condition, string? message)
        Debug.Assert(true, "true");
    }
}