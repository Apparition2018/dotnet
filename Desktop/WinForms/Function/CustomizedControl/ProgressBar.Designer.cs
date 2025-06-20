namespace WinForms.Function.CustomizedControl;

partial class ProgressBar
{
    /// <summary>
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region 组件设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要修改
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
        lblLong = new Label();
        lblShort = new Label();
        SuspendLayout();
        //
        // lblLong
        //
        lblLong.BackColor = SystemColors.ButtonFace;
        lblLong.BorderStyle = BorderStyle.FixedSingle;
        lblLong.Location = new Point(0, 0);
        lblLong.Name = "lblLong";
        lblLong.Size = new Size(400, 20);
        lblLong.TabIndex = 0;
        //
        // lblShort
        //
        lblShort.BackColor = Color.DeepPink;
        lblShort.BorderStyle = BorderStyle.FixedSingle;
        lblShort.Location = new Point(0, 0);
        lblShort.Name = "lblShort";
        lblShort.Size = new Size(50, 20);
        lblShort.TabIndex = 0;
        //
        // ProgressBar
        //
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblShort);
        Controls.Add(lblLong);
        Name = "ProgressBar";
        Size = new Size(400, 20);
        ResumeLayout(false);
    }

    #endregion

    private Label lblLong;
    private Label lblShort;
}
