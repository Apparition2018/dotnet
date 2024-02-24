namespace dotnetTest.Guide.ProgrammingGuide.ProgrammingConcepts;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/covariance-contravariance/">协变和逆变</a>
/// 协变和逆变能够实现数组类型、委托类型和泛型类型参数的隐式引用转换。
/// 协变保留分配兼容性，逆变则反之。
/// </summary>
public class CovarianceAndContravariance
{
    [Test]
    public void Test()
    {
        // 协变 Covariance
        IEnumerable<Dog> dogs = [new Dog("A"), new Dog("B")];
        IEnumerable<Pet> pets = dogs;
        pets.ToList().ForEach(p => p.Speak());

        // 逆变 Contravariance
        Action<Pet> petAction = pet => { pet.Speak(); };
        Action<Dog> dogAction = petAction;
        dogAction(new Dog("A"));
    }

    static object GetObject()
    {
        return null;
    }

    static void SetObject(object obj)
    {
    }

    static string GetString()
    {
        return "";
    }

    static void SetString(string str)
    {
    }

    [Test]
    public void Test2()
    {
        // 协变 Covariance
        Func<object> del = GetString;

        // 逆变 Contravariance
        Action<string> del2 = SetObject;
    }
}
