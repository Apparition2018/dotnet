using System;
using NUnit.Framework;

namespace dotnet3Tests.Knowledge
{
    public class ObjectOriented
    {
        [Test]
        public void Test()
        {
            Pet pet = new Dog("James");
            pet.PrintName();
            ++pet;
            pet.ShowAge();

            Console.WriteLine("----------");
            var dog = new Dog("Jack");
            dog.PrintName();
            dog.Speak();
            dog.Feed();
            Cat dogCat = dog;
            dogCat.Speak();

            Console.WriteLine("----------");
            var cat = new Cat("Tom");
            cat.Speak();
            cat.CatchMice();
            cat.ClimbTree();

            Console.WriteLine("----------");
            var cage = new Cage<Pet>(1);
            cage.PutIn(new Dog("A"));
            cage.PutIn(new Cat("B"));
            var pet2 = cage.TakeOut();
            pet2.Speak();
        }
    }

    public abstract class Pet
    {
        protected readonly string Name;
        private int _age;

        protected Pet(string name)
        {
            Name = name;
            _age = 0;
        }

        public void PrintName()
        {
            Console.WriteLine("Pet's name is " + Name);
        }

        public void ShowAge()
        {
            Console.WriteLine(Name + "'s Age = " + _age);
        }

        // virtual 虚拟 (方法、属性、索引器、事件)
        // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/virtual
        // public virtual void Speak()
        // {
        //     Console.WriteLine("Pet is speaking");
        // }

        /// <summary>abstract 抽象 (类、方法、属性、索引、事件)</summary>
        /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/abstract</remarks>
        public abstract void Speak();

        /// <summary>运算符重载</summary>
        /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/operator-overloading</remarks>
        public static Pet operator ++(Pet pet)
        {
            ++pet._age;
            return pet;
        }
    }

    /// <summary>
    /// 扩展方法
    /// 1.非嵌套、非泛型静态类
    /// 2.静态方法
    /// 3.第一个参数指定扩展那个类型，参数前面加 this
    /// </summary>
    /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/extension-methods</remarks>
    internal static class PetGuide
    {
        public static void Feed(this Dog dog)
        {
            Console.WriteLine("Feed dog ...");
        }
    }


    public class Dog : Pet
    {
        public delegate void Handler();

        public static event Handler NewDog;

        public Dog(string name) : base(name)
        {
            NewDog?.Invoke();
        }

        /// <summary>new 显示隐藏基类成员</summary>
        /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/new-modifier</remarks>
        public new void PrintName()
        {
            Console.WriteLine("Dog's name is " + Name);
        }

        /// <summary>sealed 密闭</summary>
        /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/sealed</remarks>
        public sealed override void Speak()
        {
            Console.WriteLine(Name + " is speaking: wow");
        }

        /// <summary>
        /// implicit 隐式转换
        /// explicit 显示转换
        /// </summary>
        /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/user-defined-conversion-operators</remarks>
        public static implicit operator Cat(Dog dog)
        {
            return new Cat(dog.Name);
        }

        public void WagTail()
        {
            Console.WriteLine(Name + " Wag tail");
        }
    }

    internal interface ICatchMice
    {
        void CatchMice();
    }

    public interface IClimbTree
    {
        void ClimbTree();
    }

    public class Cat : Pet, ICatchMice, IClimbTree
    {
        public Cat(string name) : base(name)
        {
        }

        /// <summary>override 重写 (方法、属性、索引器、事件)</summary>
        /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/override</remarks>
        public override void Speak()
        {
            Console.WriteLine(Name + " is speaking: meow");
        }

        public void CatchMice()
        {
            Console.WriteLine(Name + " catch mice");
        }

        public void ClimbTree()
        {
            Console.WriteLine(Name + " climb tree");
        }
    }

    /// <summary>struct 结构类型</summary>
    /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct</remarks>
    internal readonly struct Fish
    {
        public Fish(double weight)
        {
            Weight = weight;
        }

        private double Weight { get; }
        public override string ToString() => $"({Weight})";
    }

    /// <summary>where 泛型类型约束</summary>
    /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/where-generic-type-constraint</remarks>
    internal class Cage<T> where T : Pet
    {
        private readonly T[] _array;
        private readonly int _size;
        private int _num;

        public Cage(int size)
        {
            _size = size;
            _num = 0;
            _array = new T[_size];
        }

        public void PutIn(T pet)
        {
            if (_num < _size)
            {
                _array[_num++] = pet;
            }
            else
            {
                Console.WriteLine("Cage is full");
            }
        }

        public T TakeOut()
        {
            if (_num > 0)
            {
                return _array[--_num];
            }
            else
            {
                Console.WriteLine("Cage is empty");
                return default!;
            }
        }
    }

    internal class Client
    {
        public void WantDog()
        {
            Console.WriteLine("I Want a dog");
        }
    }
}