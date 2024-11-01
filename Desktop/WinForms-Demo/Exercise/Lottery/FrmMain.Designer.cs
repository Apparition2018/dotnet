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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            BtnPrint = new Button();
            BtnWriteSelf = new Button();
            BtnSelect = new Button();
            BtnClear = new Button();
            BtnDel = new Button();
            BtnStart = new Button();
            BtnGroupSelect = new Button();
            TxtGroup = new TextBox();
            label8 = new Label();
            TxtNum7 = new TextBox();
            TxtNum6 = new TextBox();
            TxtNum5 = new TextBox();
            TxtNum3 = new TextBox();
            TxtNum4 = new TextBox();
            TxtNum2 = new TextBox();
            TxtNum1 = new TextBox();
            LbNumList = new ListBox();
            LbNum7 = new Label();
            LbNum6 = new Label();
            LbNum5 = new Label();
            LbNum3 = new Label();
            LbNum4 = new Label();
            LbNum2 = new Label();
            LbNum1 = new Label();
            Title = new Label();
            panel2 = new Panel();
            PbIcon = new PictureBox();
            BtnMin = new Button();
            BtnMax = new Button();
            BtnClose = new Button();
            RandomTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbIcon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 63, 123);
            panel1.Controls.Add(BtnPrint);
            panel1.Controls.Add(BtnWriteSelf);
            panel1.Controls.Add(BtnSelect);
            panel1.Controls.Add(BtnClear);
            panel1.Controls.Add(BtnDel);
            panel1.Controls.Add(BtnStart);
            panel1.Controls.Add(BtnGroupSelect);
            panel1.Controls.Add(TxtGroup);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TxtNum7);
            panel1.Controls.Add(TxtNum6);
            panel1.Controls.Add(TxtNum5);
            panel1.Controls.Add(TxtNum3);
            panel1.Controls.Add(TxtNum4);
            panel1.Controls.Add(TxtNum2);
            panel1.Controls.Add(TxtNum1);
            panel1.Controls.Add(LbNumList);
            panel1.Controls.Add(LbNum7);
            panel1.Controls.Add(LbNum6);
            panel1.Controls.Add(LbNum5);
            panel1.Controls.Add(LbNum3);
            panel1.Controls.Add(LbNum4);
            panel1.Controls.Add(LbNum2);
            panel1.Controls.Add(LbNum1);
            panel1.Controls.Add(Title);
            panel1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(10, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 415);
            panel1.TabIndex = 0;
            // 
            // BtnPrint
            // 
            BtnPrint.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnPrint.ForeColor = Color.Black;
            BtnPrint.Image = Properties.Resources.Print_Image;
            BtnPrint.ImageAlign = ContentAlignment.MiddleLeft;
            BtnPrint.Location = new Point(507, 280);
            BtnPrint.Name = "BtnPrint";
            BtnPrint.Size = new Size(94, 114);
            BtnPrint.TabIndex = 6;
            BtnPrint.Text = "打印彩票";
            BtnPrint.TextAlign = ContentAlignment.MiddleRight;
            BtnPrint.UseVisualStyleBackColor = true;
            BtnPrint.Click += BtnPrint_Click;
            // 
            // BtnWriteSelf
            // 
            BtnWriteSelf.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnWriteSelf.ForeColor = Color.Black;
            BtnWriteSelf.Image = Properties.Resources.Modify_Image;
            BtnWriteSelf.ImageAlign = ContentAlignment.MiddleLeft;
            BtnWriteSelf.Location = new Point(507, 211);
            BtnWriteSelf.Name = "BtnWriteSelf";
            BtnWriteSelf.Size = new Size(94, 45);
            BtnWriteSelf.TabIndex = 6;
            BtnWriteSelf.Text = "手写号码";
            BtnWriteSelf.TextAlign = ContentAlignment.MiddleRight;
            BtnWriteSelf.UseVisualStyleBackColor = true;
            BtnWriteSelf.Click += BtnWriteSelf_Click;
            // 
            // BtnSelect
            // 
            BtnSelect.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnSelect.ForeColor = Color.Black;
            BtnSelect.Image = Properties.Resources.CheckMark_Image;
            BtnSelect.ImageAlign = ContentAlignment.MiddleLeft;
            BtnSelect.Location = new Point(398, 280);
            BtnSelect.Name = "BtnSelect";
            BtnSelect.Size = new Size(94, 45);
            BtnSelect.TabIndex = 6;
            BtnSelect.Text = "确认选号";
            BtnSelect.TextAlign = ContentAlignment.MiddleRight;
            BtnSelect.UseVisualStyleBackColor = true;
            BtnSelect.Click += BtnSelect_Click;
            // 
            // BtnClear
            // 
            BtnClear.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnClear.ForeColor = Color.Black;
            BtnClear.Image = Properties.Resources.Delete_Image;
            BtnClear.ImageAlign = ContentAlignment.MiddleLeft;
            BtnClear.Location = new Point(398, 349);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(94, 45);
            BtnClear.TabIndex = 6;
            BtnClear.Text = "清空选号";
            BtnClear.TextAlign = ContentAlignment.MiddleRight;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnDel
            // 
            BtnDel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnDel.ForeColor = Color.Black;
            BtnDel.Image = Properties.Resources.Exit_Image;
            BtnDel.ImageAlign = ContentAlignment.MiddleLeft;
            BtnDel.Location = new Point(290, 349);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(94, 45);
            BtnDel.TabIndex = 6;
            BtnDel.Text = "删除选号";
            BtnDel.TextAlign = ContentAlignment.MiddleRight;
            BtnDel.UseVisualStyleBackColor = true;
            BtnDel.Click += BtnDel_Click;
            // 
            // BtnStart
            // 
            BtnStart.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnStart.ForeColor = Color.Black;
            BtnStart.Image = Properties.Resources.Random2_Image;
            BtnStart.ImageAlign = ContentAlignment.MiddleLeft;
            BtnStart.Location = new Point(290, 280);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(94, 45);
            BtnStart.TabIndex = 6;
            BtnStart.Text = "随机选号";
            BtnStart.TextAlign = ContentAlignment.MiddleRight;
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnGroupSelect
            // 
            BtnGroupSelect.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnGroupSelect.ForeColor = Color.Black;
            BtnGroupSelect.Image = Properties.Resources.Random_Image;
            BtnGroupSelect.ImageAlign = ContentAlignment.MiddleLeft;
            BtnGroupSelect.Location = new Point(398, 211);
            BtnGroupSelect.Name = "BtnGroupSelect";
            BtnGroupSelect.Size = new Size(94, 45);
            BtnGroupSelect.TabIndex = 6;
            BtnGroupSelect.Text = "随机组选";
            BtnGroupSelect.TextAlign = ContentAlignment.MiddleRight;
            BtnGroupSelect.UseVisualStyleBackColor = true;
            BtnGroupSelect.Click += BtnGroupSelect_Click;
            // 
            // TxtGroup
            // 
            TxtGroup.BackColor = Color.FromArgb(224, 224, 224);
            TxtGroup.Location = new Point(349, 215);
            TxtGroup.Name = "TxtGroup";
            TxtGroup.Size = new Size(35, 37);
            TxtGroup.TabIndex = 4;
            TxtGroup.Tag = "";
            TxtGroup.Text = "5";
            TxtGroup.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label8.Location = new Point(290, 226);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 3;
            label8.Text = "组个数：";
            // 
            // TxtNum7
            // 
            TxtNum7.BackColor = Color.FromArgb(255, 128, 0);
            TxtNum7.ForeColor = Color.White;
            TxtNum7.Location = new Point(566, 150);
            TxtNum7.Name = "TxtNum7";
            TxtNum7.Size = new Size(35, 37);
            TxtNum7.TabIndex = 2;
            TxtNum7.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtNum6
            // 
            TxtNum6.BackColor = Color.FromArgb(224, 224, 224);
            TxtNum6.Location = new Point(510, 150);
            TxtNum6.Name = "TxtNum6";
            TxtNum6.Size = new Size(35, 37);
            TxtNum6.TabIndex = 2;
            TxtNum6.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtNum5
            // 
            TxtNum5.BackColor = Color.FromArgb(224, 224, 224);
            TxtNum5.Location = new Point(466, 150);
            TxtNum5.Name = "TxtNum5";
            TxtNum5.Size = new Size(35, 37);
            TxtNum5.TabIndex = 2;
            TxtNum5.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtNum3
            // 
            TxtNum3.BackColor = Color.FromArgb(224, 224, 224);
            TxtNum3.Location = new Point(378, 150);
            TxtNum3.Name = "TxtNum3";
            TxtNum3.Size = new Size(35, 37);
            TxtNum3.TabIndex = 2;
            TxtNum3.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtNum4
            // 
            TxtNum4.BackColor = Color.FromArgb(224, 224, 224);
            TxtNum4.Location = new Point(422, 150);
            TxtNum4.Name = "TxtNum4";
            TxtNum4.Size = new Size(35, 37);
            TxtNum4.TabIndex = 2;
            TxtNum4.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtNum2
            // 
            TxtNum2.BackColor = Color.FromArgb(224, 224, 224);
            TxtNum2.Location = new Point(334, 150);
            TxtNum2.Name = "TxtNum2";
            TxtNum2.Size = new Size(35, 37);
            TxtNum2.TabIndex = 2;
            TxtNum2.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtNum1
            // 
            TxtNum1.BackColor = Color.FromArgb(224, 224, 224);
            TxtNum1.Location = new Point(290, 150);
            TxtNum1.Name = "TxtNum1";
            TxtNum1.Size = new Size(35, 37);
            TxtNum1.TabIndex = 2;
            TxtNum1.TextAlign = HorizontalAlignment.Center;
            // 
            // LbNumList
            // 
            LbNumList.BackColor = SystemColors.HotTrack;
            LbNumList.BorderStyle = BorderStyle.FixedSingle;
            LbNumList.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNumList.ForeColor = Color.White;
            LbNumList.FormattingEnabled = true;
            LbNumList.ItemHeight = 27;
            LbNumList.Location = new Point(25, 150);
            LbNumList.Name = "LbNumList";
            LbNumList.Size = new Size(245, 245);
            LbNumList.TabIndex = 1;
            // 
            // LbNum7
            // 
            LbNum7.AutoSize = true;
            LbNum7.BackColor = Color.FromArgb(255, 128, 0);
            LbNum7.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNum7.ForeColor = Color.White;
            LbNum7.Location = new Point(559, 75);
            LbNum7.Name = "LbNum7";
            LbNum7.Size = new Size(42, 48);
            LbNum7.TabIndex = 0;
            LbNum7.Text = "0";
            LbNum7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LbNum6
            // 
            LbNum6.AutoSize = true;
            LbNum6.BackColor = Color.FromArgb(224, 224, 224);
            LbNum6.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNum6.ForeColor = Color.Black;
            LbNum6.Location = new Point(450, 75);
            LbNum6.Name = "LbNum6";
            LbNum6.Size = new Size(42, 48);
            LbNum6.TabIndex = 0;
            LbNum6.Text = "0";
            LbNum6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LbNum5
            // 
            LbNum5.AutoSize = true;
            LbNum5.BackColor = Color.FromArgb(224, 224, 224);
            LbNum5.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNum5.ForeColor = Color.Black;
            LbNum5.Location = new Point(365, 75);
            LbNum5.Name = "LbNum5";
            LbNum5.Size = new Size(42, 48);
            LbNum5.TabIndex = 0;
            LbNum5.Text = "0";
            LbNum5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LbNum3
            // 
            LbNum3.AutoSize = true;
            LbNum3.BackColor = Color.FromArgb(224, 224, 224);
            LbNum3.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNum3.ForeColor = Color.Black;
            LbNum3.Location = new Point(195, 75);
            LbNum3.Name = "LbNum3";
            LbNum3.Size = new Size(42, 48);
            LbNum3.TabIndex = 0;
            LbNum3.Text = "0";
            LbNum3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LbNum4
            // 
            LbNum4.AutoSize = true;
            LbNum4.BackColor = Color.FromArgb(224, 224, 224);
            LbNum4.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNum4.ForeColor = Color.Black;
            LbNum4.Location = new Point(280, 75);
            LbNum4.Name = "LbNum4";
            LbNum4.Size = new Size(42, 48);
            LbNum4.TabIndex = 0;
            LbNum4.Text = "0";
            LbNum4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LbNum2
            // 
            LbNum2.AutoSize = true;
            LbNum2.BackColor = Color.FromArgb(224, 224, 224);
            LbNum2.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNum2.ForeColor = Color.Black;
            LbNum2.Location = new Point(110, 75);
            LbNum2.Name = "LbNum2";
            LbNum2.Size = new Size(42, 48);
            LbNum2.TabIndex = 0;
            LbNum2.Text = "0";
            LbNum2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LbNum1
            // 
            LbNum1.AutoSize = true;
            LbNum1.BackColor = Color.FromArgb(224, 224, 224);
            LbNum1.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LbNum1.ForeColor = Color.Black;
            LbNum1.Location = new Point(25, 75);
            LbNum1.Name = "LbNum1";
            LbNum1.Size = new Size(42, 48);
            LbNum1.TabIndex = 0;
            LbNum1.Text = "0";
            LbNum1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Microsoft YaHei UI", 15F);
            Title.ForeColor = Color.White;
            Title.Location = new Point(206, 20);
            Title.Name = "Title";
            Title.Size = new Size(238, 32);
            Title.TabIndex = 0;
            Title.Text = "6+1体育彩票选号器";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(PbIcon);
            panel2.Controls.Add(BtnMin);
            panel2.Controls.Add(BtnMax);
            panel2.Controls.Add(BtnClose);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(650, 40);
            panel2.TabIndex = 1;
            panel2.MouseDown += FrmMain_MouseDown;
            panel2.MouseMove += FrmMain_MouseMove;
            panel2.MouseUp += FrmMain_MouseUp;
            // 
            // PbIcon
            // 
            PbIcon.Image = Properties.Resources.Icon_Image;
            PbIcon.Location = new Point(10, 5);
            PbIcon.Name = "PbIcon";
            PbIcon.Size = new Size(30, 30);
            PbIcon.SizeMode = PictureBoxSizeMode.Zoom;
            PbIcon.TabIndex = 1;
            PbIcon.TabStop = false;
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
            // RandomTimer
            // 
            RandomTimer.Interval = 50;
            RandomTimer.Tick += RandomTimer_Tick;
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
            MouseDown += FrmMain_MouseDown;
            MouseMove += FrmMain_MouseMove;
            MouseUp += FrmMain_MouseUp;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button BtnClose;
        private Button BtnMin;
        private Button BtnMax;
        private PictureBox PbIcon;
        private Label Title;
        private Label LbNum1;
        private Label LbNum7;
        private Label LbNum6;
        private Label LbNum5;
        private Label LbNum3;
        private Label LbNum4;
        private Label LbNum2;
        private ListBox LbNumList;
        private TextBox TxtNum1;
        private TextBox TxtNum6;
        private TextBox TxtNum5;
        private TextBox TxtNum3;
        private TextBox TxtNum4;
        private TextBox TxtNum2;
        private TextBox TxtNum7;
        private Label label8;
        private TextBox TxtGroup;
        private Button BtnPrint;
        private Button BtnGroupSelect;
        private Button BtnWriteSelf;
        private Button BtnStart;
        private Button BtnSelect;
        private Button BtnDel;
        private Button BtnClear;
        private System.Windows.Forms.Timer RandomTimer;
    }
}
