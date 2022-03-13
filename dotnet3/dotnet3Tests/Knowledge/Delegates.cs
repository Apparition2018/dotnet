using System;
using NUnit.Framework;

namespace dotnet3Tests.Knowledge
{
    /// <summary>委托</summary>
    /// <remarks>https://docs.microsoft.com/en-us/dotnet/csharp/delegates-overview</remarks>
    public class Delegates
    {
        private delegate void Action();

        [Test]
        public void Test()
        {
            var dog = new Dog("A");
            var cat = new Cat("B");
            Action action = dog.WagTail;
            action += cat.CatchMice;
            action += () => { Console.WriteLine("do nothing"); };
            action();
        }
    }
}