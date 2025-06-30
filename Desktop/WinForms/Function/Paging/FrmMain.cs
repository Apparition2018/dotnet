using DAL.Helper;

namespace WinForms.Function.Paging;

public partial class FrmMain : Form
{
    private readonly Page _page;

    public FrmMain()
    {
        InitializeComponent();
        dptBirthday.Text = @"1900-01-01";
        _page = new Page
        {
            TableName = "Student",
            FiledName = "StudentIdNo, StudentName, Gender, Birthday, PhoneNumber",
            PageNum = 1,
            Sort = "StudentId ASC"
        };

        cbPageSize.SelectedIndex = 1;
        dgv.AutoGenerateColumns = false;
        BtnToggle(false);
    }

    private void Query()
    {
        _page.Condition = $"Birthday > '{dptBirthday.Text}'";
        _page.PageSize = Convert.ToInt32(cbPageSize.Text.Trim());
        dgv.DataSource = _page.GetData();
        lblTotalCount.Text = _page.TotalCount.ToString();
        lblTotalPage.Text = _page.TotalPage.ToString();
        lblPageNum.Text = _page.TotalPage == 0 ? "0" : _page.PageNum.ToString();
        BtnToggle(true);
        if (_page.TotalPage is 0 or 1)
        {
            BtnToggle(false);
        }
        else
        {
            btnGoTo.Enabled = true;
        }
    }

    private void BtnToggle(bool toggle)
    {
        btnFirst.Enabled = toggle;
        btnPre.Enabled = toggle;
        btnNext.Enabled = toggle;
        btnLast.Enabled = toggle;
        btnGoTo.Enabled = toggle;
    }

    private void btnQuery_Click(object sender, EventArgs e)
    {
        _page.PageNum = 1;
        Query();
        btnPre.Enabled = false;
        btnFirst.Enabled = false;
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
        _page.PageNum = 1;
        Query();
        btnPre.Enabled = false;
        btnFirst.Enabled = false;
    }

    private void btnPre_Click(object sender, EventArgs e)
    {
        _page.PageNum -= 1;
        Query();
        if (_page.PageNum != 1) return;
        btnPre.Enabled = false;
        btnFirst.Enabled = false;
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        _page.PageNum += 1;
        Query();
        if (_page.PageNum != _page.TotalPage) return;
        btnNext.Enabled = false;
        btnLast.Enabled = false;
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
        _page.PageNum = _page.TotalPage;
        Query();
        btnNext.Enabled = false;
        btnLast.Enabled = false;
    }

    private void btnGoTo_Click(object sender, EventArgs e)
    {
        if (txtGoTo.Text.Trim().Length == 0)
        {
            MessageBox.Show(@"请输入要跳转的页码！", @"提示");
            txtGoTo.Focus();
            return;
        }
        int goTo = Convert.ToInt32(txtGoTo.Text.Trim());
        if (goTo > _page.TotalPage)
        {
            MessageBox.Show(@"跳转的页数不能大于总页数！", @"提示");
            txtGoTo.Focus();
            txtGoTo.SelectAll();
            return;
        }
        _page.PageNum = goTo;
        Query();
        if (_page.PageNum == 1)
        {
            btnPre.Enabled = false;
            btnFirst.Enabled = false;

        } else if (_page.PageNum == _page.TotalCount)
        {
            btnNext.Enabled = false;
            btnLast.Enabled = false;
        }
    }
}
