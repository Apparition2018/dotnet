namespace WinForms.Exercise.ExamQuestion.Model;

/// <summary>
/// 答案类
/// </summary>
[Serializable]
public class Answer
{
    public string RightAnswer { get; set; } = string.Empty;
    public string SelectedAnswer { get; set; } = string.Empty;
    public string AnswerAnalysis { get; set; } = string.Empty;
}
