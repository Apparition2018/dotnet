namespace dotnetTest.API.System.Collections.Generic;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic">System.Collections.Generic</a>
/// </summary>
public class CollectionsGenericTests
{
    [Test]
    public void List()
    {
        var list = new List<int> { 1, 2 };
        list.RemoveAt(1);
        list.ForEach(Console.WriteLine);
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
        Assert.That(stack.Peek(), Is.EqualTo(2));
        stack.Pop();
        Assert.That(stack.Peek(), Is.EqualTo(1));
    }

    [Test]
    public void Queue()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Assert.That(queue.Dequeue(), Is.EqualTo(1));
        Assert.That(queue.Dequeue(), Is.EqualTo(2));
    }
}
