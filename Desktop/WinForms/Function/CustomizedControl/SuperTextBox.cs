using System.ComponentModel;
using System.Text.RegularExpressions;

namespace WinForms.Function.CustomizedControl;

// 新建组件，继承需要扩展的组件 TextBox
public partial class SuperTextBox : TextBox
{
    public SuperTextBox()
    {
        InitializeComponent();
    }

    public SuperTextBox(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }

    public bool CheckEmpty()
    {
        if (Text.Trim() == string.Empty)
        {
            errorProvider.SetError(this, "必填项不能为空！");
            return false;
        }
        else
        {
            errorProvider.SetError(this, string.Empty);
            return true;
        }
    }

    public bool CheckByRegex(string pattern, string errorMsg)
    {
        if (!CheckEmpty()) return false;
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        if (!regex.IsMatch(Text.Trim()))
        {
            errorProvider.SetError(this, errorMsg);
            return false;
        }
        else
        {
            errorProvider.SetError(this, string.Empty);
            return true;
        }
    }
}
