namespace WinForms_Demo.Exercise.Lottery.Models;

/// <summary>
/// 选号器
/// </summary>
public class Selector
{
    private readonly Random _rnd = new();

    /// <summary>
    /// 选择的号码
    /// </summary>
    private List<string[]> SelectedNums { get; set; }

    public Selector()
    {
        SelectedNums = new List<string[]>();
    }

    /// <summary>
    /// 生成7个随机号码
    /// </summary>
    public string[] CreateNum()
    {
        string[] numList = new string[7];
        for (int i = 0; i < numList.Length; i++)
        {
            numList[i] = _rnd.Next(10).ToString();
        }
        return numList;
    }

    /// <summary>
    /// 生成指定组数的随机号码
    /// </summary>
    /// <param name="count"></param>
    public void CreateGroupNums(int count) {
        SelectedNums.Clear();
        for (int i = 0; i < count; i++)
        {
            SelectedNums.Add(CreateNum());
        }
    }
}
