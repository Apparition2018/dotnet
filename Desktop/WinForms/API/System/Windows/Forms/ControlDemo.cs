using System.Data;
using DAL.Helper;

namespace WinForms.API.System.Windows.Forms;

public partial class ControlDemo : Form
{
    public ControlDemo()
    {
        InitializeComponent();
    }
    private void callerOnDiffThread_Click(object sender, EventArgs e)
    {
        Thread thread = new Thread(() =>
        {
            DataSet dataSet = SQLiteHelper.GetDataSet("select * from StudentClass; select StudentName, Gender from Student");
            DataTable dt1 = dataSet.Tables[0];
            DataTable dt2 = dataSet.Tables[1];
            // 调用方线程与创建控件的的线程不相同时，调用方须使用 Invoke 方法
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action<DataTable>(dt => dataGridView1.DataSource = dt), dt1);
                dataGridView2.Invoke(new Action<DataTable>(dt => dataGridView2.DataSource = dt), dt2);
            }
            else
            {
                dataGridView1.DataSource = dt1;
                dataGridView2.DataSource = dt2;
            }
        })
        {
            IsBackground = true
        };
        thread.Start();
    }
}
