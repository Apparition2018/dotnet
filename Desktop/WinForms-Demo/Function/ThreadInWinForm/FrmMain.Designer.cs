using System.ComponentModel;

namespace WinForms_Demo.Function.ThreadInWinForm;

partial class FrmMain
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
        button2 = new Button();
        label1 = new Label();
        label2 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(45, 75);
        button1.Name = "button1";
        button1.Size = new Size(120, 29);
        button1.TabIndex = 0;
        button1.Text = "执行任务【1】";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(217, 75);
        button2.Name = "button2";
        button2.Size = new Size(120, 29);
        button2.TabIndex = 1;
        button2.Text = "执行任务【2】";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(45, 140);
        label1.Name = "label1";
        label1.Size = new Size(93, 20);
        label1.TabIndex = 2;
        label1.Text = "任务1结果：";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(217, 140);
        label2.Name = "label2";
        label2.Size = new Size(93, 20);
        label2.TabIndex = 3;
        label2.Text = "任务2结果：";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(127, 137);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(38, 27);
        textBox1.TabIndex = 4;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(299, 137);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(38, 27);
        textBox2.TabIndex = 4;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(382, 253);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "FrmMain";
        Text = "FrmMain";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button button2;
    private Label label1;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
}
