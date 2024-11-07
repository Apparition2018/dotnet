using WinForms_Demo.Exercise.ExamQuestion.Model;

namespace WinForms_Demo.Exercise.ExamQuestion;

public partial class FrmMain : Form
{
    private readonly Paper _paper = new();
    private int _questionIndex;
    public FrmMain()
    {
        InitializeComponent();
    }

    // 抽取试题
    private void btnExtract_Click(object sender, EventArgs e) {
        _paper.ExtractQuestions();
        panelPaper.Visible = false;
        btnExtract.Visible = false;
        ShowQuestion();
    }

    private void ShowQuestion()
    {
        lblTitle.Text = _paper.Questions[_questionIndex].Title;
        lblA.Text = _paper.Questions[_questionIndex].OptionA;
        lblB.Text = _paper.Questions[_questionIndex].OptionB;
        lblC.Text = _paper.Questions[_questionIndex].OptionC;
        lblD.Text = _paper.Questions[_questionIndex].OptionD;
    }

    // 上一题
    private void btnPre_Click(object sender, EventArgs e)
    {
        if (_questionIndex == 0) return;
        SaveAnswer();
        _questionIndex--;
        ShowQuestion();
        ResetAnswer();
    }

    // 下一题
    private void btnNext_Click(object sender, EventArgs e)
    {
        if (_questionIndex == _paper.Questions.Count - 1) return;
        SaveAnswer();
        _questionIndex++;
        ShowQuestion();
        ResetAnswer();
    }

    private void SaveAnswer()
    {
        string answer = string.Empty;
        if (ckbA.Checked) answer += "A";
        if (ckbB.Checked) answer += "B";
        if (ckbC.Checked) answer += "C";
        if (ckbD.Checked) answer += "D";
        _paper.Questions[_questionIndex].QAnswer.SelectedAnswer = answer;
    }

    private void ResetAnswer()
    {
        ckbA.Checked = _paper.Questions[_questionIndex].QAnswer.SelectedAnswer.Contains('A');
        ckbB.Checked = _paper.Questions[_questionIndex].QAnswer.SelectedAnswer.Contains('B');
        ckbC.Checked = _paper.Questions[_questionIndex].QAnswer.SelectedAnswer.Contains('C');
        ckbD.Checked = _paper.Questions[_questionIndex].QAnswer.SelectedAnswer.Contains('D');
    }

    // 提交试卷
    private void btnSubmit_Click(object sender, EventArgs e) {
        SaveAnswer();
        int score = _paper.SubmitPaper();
        panelPaper.Visible = true;
        lblInfo.Text = $@"您当前成绩为：{score}分！";
    }

    // 关闭窗体
    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
