namespace WinForms_Demo.Exercise.MIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel1 = new Panel();
            BtnClose = new Button();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            splitContainer = new SplitContainer();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            BtnProductManagement = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(BtnClose);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1280, 74);
            panel1.TabIndex = 0;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.FromArgb(6, 58, 122);
            BtnClose.FlatAppearance.BorderColor = Color.FromArgb(111, 184, 213);
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(1186, 0);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(94, 29);
            BtnClose.TabIndex = 3;
            BtnClose.Text = "退出系统";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(6, 58, 122);
            button1.FlatAppearance.BorderColor = Color.FromArgb(111, 184, 213);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1093, 0);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "使用帮助";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(33, 61, 124);
            label1.Font = new Font("Microsoft YaHei", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.White;
            label1.Location = new Point(4, 5);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(418, 65);
            label1.TabIndex = 2;
            label1.Text = "企业级MIS综合平台";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(54, 78, 111);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 728);
            panel2.Name = "panel2";
            panel2.Size = new Size(1280, 40);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(47, 10);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 1;
            label3.Text = "企业级MIS综合平台";
            // 
            // label2
            // 
            label2.Image = Properties.Resources.Project_Image;
            label2.Location = new Point(0, 8);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 0;
            // 
            // splitContainer
            // 
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.IsSplitterFixed = true;
            splitContainer.Location = new Point(7, 81);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.BackColor = Color.FromArgb(16, 109, 176);
            splitContainer.Panel1.Controls.Add(button5);
            splitContainer.Panel1.Controls.Add(button4);
            splitContainer.Panel1.Controls.Add(button3);
            splitContainer.Panel1.Controls.Add(BtnProductManagement);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.BackColor = Color.FromArgb(239, 255, 255);
            splitContainer.Size = new Size(1266, 640);
            splitContainer.SplitterDistance = 215;
            splitContainer.TabIndex = 2;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(9, 163, 220);
            button5.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.Info_Image;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(19, 160);
            button5.Name = "button5";
            button5.Size = new Size(180, 30);
            button5.TabIndex = 0;
            button5.Text = "      商 品 信 息 管 理";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(9, 163, 220);
            button4.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button4.ForeColor = Color.White;
            button4.Image = Properties.Resources.Info_Image;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(19, 120);
            button4.Name = "button4";
            button4.Size = new Size(180, 30);
            button4.TabIndex = 0;
            button4.Text = "      商 品 信 息 管 理";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(9, 163, 220);
            button3.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.Info_Image;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(19, 55);
            button3.Name = "button3";
            button3.Size = new Size(180, 30);
            button3.TabIndex = 0;
            button3.Text = "      供 应 商 信 息 管 理";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // BtnProductManagement
            // 
            BtnProductManagement.BackColor = Color.FromArgb(9, 163, 220);
            BtnProductManagement.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            BtnProductManagement.FlatStyle = FlatStyle.Flat;
            BtnProductManagement.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnProductManagement.ForeColor = Color.White;
            BtnProductManagement.Image = Properties.Resources.Info_Image;
            BtnProductManagement.ImageAlign = ContentAlignment.MiddleLeft;
            BtnProductManagement.Location = new Point(19, 15);
            BtnProductManagement.Name = "BtnProductManagement";
            BtnProductManagement.Size = new Size(180, 30);
            BtnProductManagement.TabIndex = 0;
            BtnProductManagement.Text = "      商 品 信 息 管 理";
            BtnProductManagement.TextAlign = ContentAlignment.MiddleLeft;
            BtnProductManagement.UseVisualStyleBackColor = false;
            BtnProductManagement.Click += BtnProductManagement_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(111, 184, 213);
            ClientSize = new Size(1280, 768);
            Controls.Add(splitContainer);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMain";
            Text = " ";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private Button BtnClose;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private SplitContainer splitContainer;
        private Button BtnProductManagement;
        private Button button5;
        private Button button4;
        private Button button3;
    }
}
