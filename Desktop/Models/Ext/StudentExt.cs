namespace Models.Ext;

/// <summary>
/// 学员信息扩展实体
/// </summary>
public class StudentExt : Student
{
    public string ClassName { get; set; }
    public string CSharp { get; set; }
    public string SQLServerDB { get; set; }
    public DateTime DTime { get; set; }
    public bool cc { get; set; }
}
