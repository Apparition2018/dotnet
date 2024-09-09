namespace Models;

/// <summary>
/// 学员实体类
/// </summary>
[Serializable]
public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Gender { get; set; }
    private DateTime birthday = DateTime.Now;
    public DateTime Birthday
    {
        get => birthday;
        set => birthday = value;
    }
    public string StudentIdNo { get; set; }
    public int Age { get; set; }
    public string StuImage { get; set; }
    public string PhoneNumber { get; set; }
    public string StudentAddress { get; set; }
    public string CardNo { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}
