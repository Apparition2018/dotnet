namespace Models;

/// <summary>
/// 成绩类
/// </summary>
[Serializable]
public class ScoreList
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CSharp { get; set; }
    public int SQLServerDB { get; set; }
    public DateTime UpdateTime { get; set; }
}
