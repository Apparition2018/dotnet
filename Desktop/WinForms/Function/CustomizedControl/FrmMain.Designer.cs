namespace WinForms.Function.CustomizedControl
{
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
            components = new System.ComponentModel.Container();
            txtName = new SuperTextBox(components);
            label1 = new Label();
            txtAge = new SuperTextBox(components);
            label2 = new Label();
            btnAdd = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(86, 26);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "姓名：";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(296, 26);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(125, 27);
            txtAge.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(240, 30);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "年龄：";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(178, 125);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "添加";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // progressBar
            // 
            progressBar.BorderColor = SystemColors.ControlDark;
            progressBar.Location = new Point(25, 79);
            progressBar.Name = "progressBar";
            progressBar.ProgressColor = Color.Orchid;
            progressBar.Size = new Size(400, 20);
            progressBar.TabIndex = 3;
            progressBar.TextColor = Color.Black;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 180);
            Controls.Add(progressBar);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAge);
            Controls.Add(txtName);
            Name = "FrmMain";
            Text = "FrmMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SuperTextBox txtName;
        private Label label1;
        private SuperTextBox txtAge;
        private Label label2;
        private Button btnAdd;
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar;
    }
}
