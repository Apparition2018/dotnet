namespace dotnetTest.API.System.LINQ.Model;

/// <summary>教师</summary>
public class Teacher
{
    /// <summary>名字</summary>
    public required string First { get; init; }
    /// <summary>姓氏</summary>
    public required string Last { get; init; }
    /// <summary>ID</summary>
    public required int ID { get; init; }
    /// <summary>城市</summary>
    public required string City { get; init; }
}
