namespace WinForms_Demo.Exercise.ExamQuestion
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            lblTitle = new Label();
            lblA = new Label();
            btnPre = new Button();
            ckbA = new CheckBox();
            ckbB = new CheckBox();
            ckbC = new CheckBox();
            ckbD = new CheckBox();
            lblB = new Label();
            lblC = new Label();
            lblD = new Label();
            btnNext = new Button();
            btnSubmit = new Button();
            panel1 = new Panel();
            label1 = new Label();
            btnClose = new Button();
            panel2 = new Panel();
            panelPaper = new Panel();
            lblInfo = new Label();
            btnExtract = new Button();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelPaper.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(46, 27);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(168, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "题目：等待开始答题......";
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblA.ForeColor = Color.Navy;
            lblA.Location = new Point(84, 83);
            lblA.Margin = new Padding(4, 0, 4, 0);
            lblA.Name = "lblA";
            lblA.Size = new Size(20, 19);
            lblA.TabIndex = 0;
            lblA.Text = "A";
            // 
            // btnPre
            // 
            btnPre.BackColor = Color.FromArgb(87, 193, 253);
            btnPre.FlatStyle = FlatStyle.Flat;
            btnPre.ForeColor = Color.White;
            btnPre.Image = (Image)resources.GetObject("btnPre.Image");
            btnPre.ImageAlign = ContentAlignment.MiddleLeft;
            btnPre.Location = new Point(52, 330);
            btnPre.Margin = new Padding(4, 5, 4, 5);
            btnPre.Name = "btnPre";
            btnPre.Size = new Size(122, 50);
            btnPre.TabIndex = 4;
            btnPre.Text = "  上一题";
            btnPre.UseVisualStyleBackColor = false;
            btnPre.Click += btnPre_Click;
            // 
            // ckbA
            // 
            ckbA.AutoSize = true;
            ckbA.FlatStyle = FlatStyle.Popup;
            ckbA.Font = new Font("Microsoft YaHei", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ckbA.Location = new Point(58, 88);
            ckbA.Margin = new Padding(4, 5, 4, 5);
            ckbA.Name = "ckbA";
            ckbA.Size = new Size(15, 14);
            ckbA.TabIndex = 0;
            ckbA.UseVisualStyleBackColor = true;
            // 
            // ckbB
            // 
            ckbB.AutoSize = true;
            ckbB.FlatStyle = FlatStyle.Popup;
            ckbB.Font = new Font("Microsoft YaHei", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ckbB.Location = new Point(58, 142);
            ckbB.Margin = new Padding(4, 5, 4, 5);
            ckbB.Name = "ckbB";
            ckbB.Size = new Size(15, 14);
            ckbB.TabIndex = 1;
            ckbB.UseVisualStyleBackColor = true;
            // 
            // ckbC
            // 
            ckbC.AutoSize = true;
            ckbC.FlatStyle = FlatStyle.Popup;
            ckbC.Font = new Font("Microsoft YaHei", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ckbC.Location = new Point(58, 195);
            ckbC.Margin = new Padding(4, 5, 4, 5);
            ckbC.Name = "ckbC";
            ckbC.Size = new Size(15, 14);
            ckbC.TabIndex = 2;
            ckbC.UseVisualStyleBackColor = true;
            // 
            // ckbD
            // 
            ckbD.AutoSize = true;
            ckbD.FlatStyle = FlatStyle.Popup;
            ckbD.Font = new Font("Microsoft YaHei", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ckbD.Location = new Point(58, 248);
            ckbD.Margin = new Padding(4, 5, 4, 5);
            ckbD.Name = "ckbD";
            ckbD.Size = new Size(15, 14);
            ckbD.TabIndex = 3;
            ckbD.UseVisualStyleBackColor = true;
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblB.ForeColor = Color.Navy;
            lblB.Location = new Point(86, 137);
            lblB.Margin = new Padding(4, 0, 4, 0);
            lblB.Name = "lblB";
            lblB.Size = new Size(19, 19);
            lblB.TabIndex = 0;
            lblB.Text = "B";
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblC.ForeColor = Color.Navy;
            lblC.Location = new Point(86, 190);
            lblC.Margin = new Padding(4, 0, 4, 0);
            lblC.Name = "lblC";
            lblC.Size = new Size(19, 19);
            lblC.TabIndex = 0;
            lblC.Text = "C";
            // 
            // lblD
            // 
            lblD.AutoSize = true;
            lblD.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblD.ForeColor = Color.Navy;
            lblD.Location = new Point(86, 243);
            lblD.Margin = new Padding(4, 0, 4, 0);
            lblD.Name = "lblD";
            lblD.Size = new Size(21, 19);
            lblD.TabIndex = 0;
            lblD.Text = "D";
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(87, 193, 253);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.ForeColor = Color.White;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageAlign = ContentAlignment.MiddleLeft;
            btnNext.Location = new Point(189, 330);
            btnNext.Margin = new Padding(4, 5, 4, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(122, 50);
            btnNext.TabIndex = 5;
            btnNext.Text = "  下一题";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(87, 193, 253);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Image = (Image)resources.GetObject("btnSubmit.Image");
            btnSubmit.ImageAlign = ContentAlignment.MiddleLeft;
            btnSubmit.Location = new Point(714, 330);
            btnSubmit.Margin = new Padding(4, 5, 4, 5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(141, 50);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "   提交试卷";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(70, 135, 248);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(921, 63);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(277, 29);
            label1.TabIndex = 0;
            label1.Text = "计算机等级考试模拟练习";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(87, 193, 253);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(87, 193, 253);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(860, 10);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(48, 42);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(246, 246, 246);
            panel2.Controls.Add(panelPaper);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(lblA);
            panel2.Controls.Add(btnSubmit);
            panel2.Controls.Add(ckbD);
            panel2.Controls.Add(btnPre);
            panel2.Controls.Add(btnNext);
            panel2.Controls.Add(lblB);
            panel2.Controls.Add(ckbC);
            panel2.Controls.Add(lblC);
            panel2.Controls.Add(ckbB);
            panel2.Controls.Add(lblD);
            panel2.Controls.Add(ckbA);
            panel2.Location = new Point(14, 78);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(894, 425);
            panel2.TabIndex = 0;
            // 
            // panelPaper
            // 
            panelPaper.BorderStyle = BorderStyle.FixedSingle;
            panelPaper.Controls.Add(lblInfo);
            panelPaper.Controls.Add(btnExtract);
            panelPaper.Location = new Point(42, 27);
            panelPaper.Margin = new Padding(4, 5, 4, 5);
            panelPaper.Name = "panelPaper";
            panelPaper.Size = new Size(812, 370);
            panelPaper.TabIndex = 8;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Microsoft YaHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblInfo.ForeColor = Color.FromArgb(0, 0, 192);
            lblInfo.Location = new Point(94, 148);
            lblInfo.Margin = new Padding(4, 0, 4, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(327, 35);
            lblInfo.TabIndex = 8;
            lblInfo.Text = "试卷密封中！等待抽题......";
            // 
            // btnExtract
            // 
            btnExtract.BackColor = Color.FromArgb(87, 193, 253);
            btnExtract.FlatStyle = FlatStyle.Flat;
            btnExtract.ForeColor = Color.White;
            btnExtract.Image = (Image)resources.GetObject("btnExtract.Image");
            btnExtract.ImageAlign = ContentAlignment.MiddleLeft;
            btnExtract.Location = new Point(584, 148);
            btnExtract.Margin = new Padding(4, 5, 4, 5);
            btnExtract.Name = "btnExtract";
            btnExtract.Size = new Size(141, 50);
            btnExtract.TabIndex = 7;
            btnExtract.Text = "    抽取试题";
            btnExtract.UseVisualStyleBackColor = false;
            btnExtract.Click += btnExtract_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 122, 204);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 520);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(921, 52);
            panel3.TabIndex = 2;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 57, 85);
            ClientSize = new Size(921, 572);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "计算机考试模拟试卷客户端";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelPaper.ResumeLayout(false);
            panelPaper.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.CheckBox ckbA;
        private System.Windows.Forms.CheckBox ckbB;
        private System.Windows.Forms.CheckBox ckbC;
        private System.Windows.Forms.CheckBox ckbD;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelPaper;
        private System.Windows.Forms.Label lblInfo;
    }
}
