namespace WinForms_Demo.Exercise.Lottery
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
            panel1 = new Panel();
            panel2 = new Panel();
            BtnMin = new Button();
            BtnMax = new Button();
            BtnClose = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 63, 123);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(10, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 415);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(BtnMin);
            panel2.Controls.Add(BtnMax);
            panel2.Controls.Add(BtnClose);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(650, 40);
            panel2.TabIndex = 1;
            // 
            // BtnMin
            // 
            BtnMin.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            BtnMin.FlatStyle = FlatStyle.Flat;
            BtnMin.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnMin.ForeColor = Color.White;
            BtnMin.Location = new Point(538, 5);
            BtnMin.Name = "BtnMin";
            BtnMin.Size = new Size(30, 30);
            BtnMin.TabIndex = 0;
            BtnMin.Text = "▁";
            BtnMin.UseVisualStyleBackColor = true;
            BtnMin.Click += BtnMin_Click;
            // 
            // BtnMax
            // 
            BtnMax.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            BtnMax.FlatStyle = FlatStyle.Flat;
            BtnMax.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnMax.ForeColor = Color.White;
            BtnMax.Location = new Point(574, 5);
            BtnMax.Name = "BtnMax";
            BtnMax.Size = new Size(30, 30);
            BtnMax.TabIndex = 0;
            BtnMax.Text = "□";
            BtnMax.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            BtnClose.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(610, 5);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(30, 30);
            BtnClose.TabIndex = 0;
            BtnClose.Text = "×";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(650, 475);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "6+1体育彩票选号器";
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button BtnClose;
        private Button BtnMin;
        private Button BtnMax;
    }
}