using dotnet.L.Demo;
using dotnetTest.Guide.LanguageReference.Keywords;
using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;
using dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

namespace dotnetTest.Guide;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/">指南</a>
/// </summary>
public class Guide : Demo
{
    [Test]
    public void Test()
    {
        Pet pet = new Dog("James");
        pet.PrintName();
        ++pet;
        pet.ShowAge();

        DividingLine();
        var dog = new Dog("Jack");
        dog.PrintName();
        dog.Speak();
        dog.Feed();
        Cat dogCat = dog;
        dogCat.Speak();

        DividingLine();
        var cat = new Cat("Tom");
        cat.Speak();
        cat.CatchMice();
        cat.ClimbTree();

        DividingLine();
        var cage = new Cage<Pet>(1);
        cage.PutIn(new Dog("A"));
        cage.PutIn(new Cat("B"));
        var pet2 = cage.TakeOut();
        pet2.Speak();
    }
}

public class Pet
{
    public readonly string Name;
    private int _age;

    public Pet(string name)
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

    /// <seealso cref="Modifiers.Virtual"/>
    public virtual void Speak()
    {
        Console.WriteLine("Pet is speaking");
    }

    /// <seealso cref="OperatorsAndExpressions.OperatorOverloading"/>
    public static Pet operator ++(Pet pet)
    {
        ++pet._age;
        return pet;
    }
}

/// <seealso cref="Method.ExtensionMethods"/>
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
    // https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/new-modifier
    public new void PrintName()
    {
        Console.WriteLine("Dog's name is " + Name);
    }

    /// <seealso cref="Modifiers.Sealed"/>
    public sealed override void Speak()
    {
        Console.WriteLine(Name + " is speaking: wow");
    }

    // 用户定义转换运算符
    // https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
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
    // https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/override
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

/// <seealso cref="Keywords.GenericTypeConstraintKeywords.Where"/>
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
