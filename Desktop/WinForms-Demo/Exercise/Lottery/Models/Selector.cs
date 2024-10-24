using System.Text;

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
    public List<string[]> SelectedNums { get; set; } = [];

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
    public void CreateGroupNums(int count)
    {
        SelectedNums.Clear();
        for (int i = 0; i < count; i++)
        {
            SelectedNums.Add(CreateNum());
        }
    }

    /// <summary>
    /// 获取打印格式的号码列表
    /// </summary>
    public List<string> GetPrintedNums()
    {
        List<string> numList = [];
        for (int i = 0; i < SelectedNums.Count; i++)
        {
            StringBuilder printedNum = new StringBuilder();
            printedNum.Append($"第{(i < 9 ? "0" : "")}{i + 1}组：");
            for (int j = 0; j < SelectedNums[i].Length; j++)
            {
                printedNum.Append(SelectedNums[i][j]);
                printedNum.Append(j == 5 ? "   " : " ");
            }

            numList.Add(printedNum.ToString());
        }

        return numList;
    }
}
