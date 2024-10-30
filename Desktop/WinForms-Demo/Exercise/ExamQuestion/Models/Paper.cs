using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace WinForms_Demo.Exercise.ExamQuestion.Models;

/// <summary>
/// 试卷类
/// </summary>
public class Paper
{
    private List<Question> _questions = [];

    public List<Question> Questions => _questions;

    /// <summary>
    /// 抽取全部试题
    /// </summary>
    public void ExtractQuestions()
    {
        // questions.txt 放在 bin/Debug/net8.0-windows/
        using FileStream fs = new FileStream("questions.txt", FileMode.Open);
        using StreamReader sr = new StreamReader(fs, Encoding.Default);
        string content = sr.ReadToEnd();
        string[] questionArray = content.Split(Convert.ToChar("&"));
        foreach (string item in questionArray)
        {
            string[] question = item.Trim().Split(Convert.ToChar("\r"));
            _questions.Add(new Question
            {
                Title = question[0].Trim(),
                OptionA = question[1].Trim(),
                OptionB = question[2].Trim(),
                OptionC = question[3].Trim(),
                OptionD = question[4].Trim(),
                QAnswer = new Answer { RightAnswer = question[5].Trim() }
            });
        }
    }

    [Obsolete("Obsolete")]
    private void SavePaper()
    {
        using FileStream fs = new FileStream("questions.obj", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, _questions);
    }

    [Obsolete("Obsolete")]
    public void ExtractQuestions2()
    {
        using FileStream fs = new FileStream("questions.obj", FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        _questions = (List<Question>)bf.Deserialize(fs);
    }

    public int SubmitPaper()
    {
        return (from item in _questions where item.QAnswer.SelectedAnswer != string.Empty where item.QAnswer.RightAnswer.Equals(item.QAnswer.SelectedAnswer) select 5).Sum();
    }
}
