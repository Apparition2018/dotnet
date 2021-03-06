using System;
using dotnet6.L;
using NUnit.Framework;

namespace dotnet6Tests.API.System;

public class ArrayTests : Demo
{
    [Test]
    public void Test()
    {
        Array.Reverse(Ints);
        Console.WriteLine(string.Join(",", Ints)); // 9,8,7,6,5,4,3,2,1
        Array.Reverse(Ints);

        // static void      Clear(Array array, int index, int length)
        Array.Clear(Ints, 0, 2);
        Console.WriteLine(string.Join(",", Ints)); // 0,0,3,4,5,6,7,8,9

        // static void      Resize<T>([NotNull] ref T[]? array, int newSize)
        Array.Resize(ref Ints, 11);
        Console.WriteLine(string.Join(",", Ints)); // 0,0,3,4,5,6,7,8,9,0,0
    }
}