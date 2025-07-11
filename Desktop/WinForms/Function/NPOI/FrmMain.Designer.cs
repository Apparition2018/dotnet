namespace WinForms.Function.NPOI;

partial class FrmMain
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        btnExport = new Button();
        dgvProducts1 = new DataGridView();
        商品编号 = new DataGridViewTextBoxColumn();
        商品名称 = new DataGridViewTextBoxColumn();
        计量单位 = new DataGridViewTextBoxColumn();
        商品单价 = new DataGridViewTextBoxColumn();
        商品折扣 = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvProducts1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(21, 21);
        label1.Name = "label1";
        label1.Size = new Size(95, 20);
        label1.TabIndex = 0;
        label1.Text = "导出到 Excel";
        // 
        // btnExport
        // 
        btnExport.Location = new Point(606, 17);
        btnExport.Name = "btnExport";
        btnExport.Size = new Size(94, 29);
        btnExport.TabIndex = 1;
        btnExport.Text = "导出";
        btnExport.UseVisualStyleBackColor = true;
        btnExport.Click += btnExport_Click;
        // 
        // dgvProducts1
        // 
        dgvProducts1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts1.Columns.AddRange(new DataGridViewColumn[] { 商品编号, 商品名称, 计量单位, 商品单价, 商品折扣 });
        dgvProducts1.Location = new Point(21, 58);
        dgvProducts1.Name = "dgvProducts1";
        dgvProducts1.RowHeadersWidth = 51;
        dgvProducts1.Size = new Size(679, 248);
        dgvProducts1.TabIndex = 2;
        // 
        // 商品编号
        // 
        商品编号.HeaderText = "Column1";
        商品编号.MinimumWidth = 6;
        商品编号.Name = "商品编号";
        商品编号.Width = 125;
        // 
        // 商品名称
        // 
        商品名称.HeaderText = "Column1";
        商品名称.MinimumWidth = 6;
        商品名称.Name = "商品名称";
        商品名称.Width = 125;
        // 
        // 计量单位
        // 
        计量单位.HeaderText = "Column1";
        计量单位.MinimumWidth = 6;
        计量单位.Name = "计量单位";
        计量单位.Width = 125;
        // 
        // 商品单价
        // 
        商品单价.HeaderText = "Column1";
        商品单价.MinimumWidth = 6;
        商品单价.Name = "商品单价";
        商品单价.Width = 125;
        // 
        // 商品折扣
        // 
        商品折扣.HeaderText = "Column1";
        商品折扣.MinimumWidth = 6;
        商品折扣.Name = "商品折扣";
        商品折扣.Width = 125;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(718, 628);
        Controls.Add(dgvProducts1);
        Controls.Add(btnExport);
        Controls.Add(label1);
        Name = "FrmMain";
        Text = "FrmMain";
        ((System.ComponentModel.ISupportInitialize)dgvProducts1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Button btnExport;
    private DataGridView dgvProducts1;
    private DataGridViewTextBoxColumn 商品编号;
    private DataGridViewTextBoxColumn 商品名称;
    private DataGridViewTextBoxColumn 计量单位;
    private DataGridViewTextBoxColumn 商品单价;
    private DataGridViewTextBoxColumn 商品折扣;
}
