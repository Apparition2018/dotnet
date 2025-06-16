namespace WinForms.Function.ThreadInWinForm;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ButtonClick(textBox1, 100);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        ButtonClick(textBox2, 100);
    }

    private void ButtonClick(TextBox label, int sleepMs)
    {
        int a = 0;
        Thread thread = new Thread(delegate()
        {
            for (int i = 0; i <= 20; i++)
            {
                a += i;
                // 调用方线程是否位与创建控件的的线程不相同
                if (label.InvokeRequired)
                {
                    label.Invoke(new Action<string>(s => label.Text = s), a.ToString());
                }
                else
                {
                    label.Text = a.ToString();
                }
                Thread.Sleep(sleepMs);
            }
        })
        {
            IsBackground = true
        };
        thread.Start();
    }
}
