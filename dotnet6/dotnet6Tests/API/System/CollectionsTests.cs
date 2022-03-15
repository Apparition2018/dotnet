using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace dotnet6Tests.API.System;

/// <summary>集合</summary>
/// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/collections</remarks>
public class Collections
{
    [Test]
    public void List()
    {
        var list = new List<int> {1, 2};
        list.RemoveAt(1);
        list.ForEach(Console.WriteLine); // 1
    }

    [Test]
    public void Dictionary()
    {
        var dic = new Dictionary<string, int>
        {
            {"A", 1},
            {"B", 2}
        };
        foreach (var (key, value) in dic)
        {
            Console.WriteLine(key + "-" + value);
        }
    }

    [Test]
    public void Stack()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        Console.WriteLine(stack.Peek()); // 2
        stack.Pop();
        Console.WriteLine(stack.Peek()); // 1
    }

    [Test]
    public void Queue()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Console.WriteLine(queue.Dequeue()); // 1
        Console.WriteLine(queue.Dequeue()); // 2
    }
}