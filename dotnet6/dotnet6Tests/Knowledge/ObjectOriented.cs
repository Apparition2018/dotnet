using NUnit.Framework;

namespace dotnet6Tests.Knowledge;

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

    // virtual 虚拟 (方法、属性、索引器、事件)，使其在派生类中被重写
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/virtual
    // public virtual void Speak()
    // {
    //     Console.WriteLine("Pet is speaking");
    // }

    // abstract 抽象 (方法、属性、索引器、事件)
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/abstract
    public abstract void Speak();

    // 运算符重载 (Operator overloading)
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/operator-overloading
    public static Pet operator ++(Pet pet)
    {
        ++pet._age;
        return pet;
    }
}

// 扩展方法 (Extension Methods)
//  1.非嵌套、非泛型静态类
//  2.静态方法
//  3.第一个参数指定扩展那个类型，参数前面加 this
// https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
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

    public static event Handler? NewDog;

    public Dog(string name) : base(name)
    {
        NewDog?.Invoke();
    }

    // new 可以显式隐藏从基类继承的成员
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/new-modifier
    public new void PrintName()
    {
        Console.WriteLine("Dog's name is " + Name);
    }

    // sealed 密闭，可阻止其他类继承自该类
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/sealed
    public sealed override void Speak()
    {
        Console.WriteLine(Name + " is speaking: wow");
    }

    // 用户定义转换运算符
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
    // implicit 隐式转换
    // explicit 显示转换
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

    // override 重写 (方法、属性、索引器、事件)
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/override
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

// struct 结构类型，一种可封装数据和相关功能的值类型
// https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct
internal readonly struct Fish
{
    public Fish(double weight)
    {
        Weight = weight;
    }

    private double Weight { get; }
    public override string ToString() => $"({Weight})";
}

// where (generic type constraint 泛型类型约束)
// https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
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