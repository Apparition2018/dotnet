namespace WinForms_Demo.Exercise.ExamQuestion.Models;

/// <summary>
/// 试题类
/// </summary>
[Serializable]
public class Question
{
    public Question() => QAnswer = new Answer();

    public int QuestionId { get; set; }
    public string Title { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public Answer QAnswer { get; set; }
}
