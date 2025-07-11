namespace WinForms.Function.NPOI;

public partial class FrmMain : Form
{
    private List<Product> exportProductList = null;

    public FrmMain()
    {
        InitializeComponent();
        dgvProducts1.AutoGenerateColumns = false;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> columnNames = new Dictionary<string, string>();
        columnNames.Add("ProductId", "商品编号");
        columnNames.Add("ProductName", "商品名称");
        columnNames.Add("Unit", "计量单位");
        columnNames.Add("UnitPrice", "商品单价");
        columnNames.Add("Discount", "商品折扣");
    }
}
