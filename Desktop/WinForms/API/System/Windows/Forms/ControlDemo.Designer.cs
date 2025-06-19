using System.ComponentModel;

namespace WinForms.API.System.Windows.Forms;

partial class ControlDemo
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        button1 = new Button();
        dataGridView1 = new DataGridView();
        dataGridView2 = new DataGridView();
        label1 = new Label();
        label2 = new Label();
        ((ISupportInitialize)dataGridView1).BeginInit();
        ((ISupportInitialize)dataGridView2).BeginInit();
        SuspendLayout();
        //
        // button1
        //
        button1.Location = new Point(335, 320);
        button1.Name = "button1";
        button1.Size = new Size(120, 29);
        button1.TabIndex = 0;
        button1.Text = "查询";
        button1.UseVisualStyleBackColor = true;
        button1.Click += callerOnDiffThread_Click;
        //
        // dataGridView1
        //
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(50, 50);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(320, 250);
        dataGridView1.TabIndex = 2;
        //
        // dataGridView2
        //
        dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView2.Location = new Point(420, 50);
        dataGridView2.Name = "dataGridView2";
        dataGridView2.RowHeadersWidth = 51;
        dataGridView2.Size = new Size(320, 250);
        dataGridView2.TabIndex = 3;
        //
        // label1
        //
        label1.AutoSize = true;
        label1.Location = new Point(50, 20);
        label1.Name = "label1";
        label1.Size = new Size(69, 20);
        label1.TabIndex = 4;
        label1.Text = "班级列表";
        //
        // label2
        //
        label2.AutoSize = true;
        label2.Location = new Point(420, 20);
        label2.Name = "label2";
        label2.Size = new Size(69, 20);
        label2.TabIndex = 4;
        label2.Text = "学员列表";
        //
        // ControlDemo
        //
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(790, 370);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(dataGridView2);
        Controls.Add(dataGridView1);
        Controls.Add(button1);
        Name = "ControlDemo";
        Text = "ControlDemo";
        ((ISupportInitialize)dataGridView1).EndInit();
        ((ISupportInitialize)dataGridView2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private DataGridView dataGridView1;
    private DataGridView dataGridView2;
    private Label label1;
    private Label label2;
}
