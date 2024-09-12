namespace dotnet.L.Demo;

/// <summary>部门</summary>
public class Department
{
    /// <summary>名称</summary>
    public required string Name { get; init; }
    /// <summary>ID</summary>
    public int ID { get; init; }
    /// <summary>教师ID</summary>
    public required int TeacherID { get; init; }
}
