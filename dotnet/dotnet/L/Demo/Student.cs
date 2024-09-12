namespace dotnet.L.Demo;

/// <summary>学生</summary>
public class Student
{
    /// <summary>名字</summary>
    public required string FirstName { get; init; }
    /// <summary>姓氏</summary>
    public required string LastName { get; init; }
    /// <summary>ID</summary>
    public required int ID { get; init; }
    /// <summary>年级</summary>
    public required GradeLevel Year { get; init; }
    /// <summary>分数</summary>
    public required List<int> Scores { get; init; }
    /// <summary>部门ID</summary>
    public required int DepartmentID { get; init; }
}
