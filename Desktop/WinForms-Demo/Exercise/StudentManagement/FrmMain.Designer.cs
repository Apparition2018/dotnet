namespace WinForms_Demo.Exercise.StudentManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            menuStrip1 = new MenuStrip();
            系统ToolStripMenuItem = new ToolStripMenuItem();
            tsmi_PwdModify = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            推出系统ToolStripMenuItem = new ToolStripMenuItem();
            学院管理MToolStripMenuItem = new ToolStripMenuItem();
            添加学员AToolStripMenuItem = new ToolStripMenuItem();
            批量导入学院IToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            学员信息管理ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            button6 = new Button();
            imageList1 = new ImageList(components);
            button8 = new Button();
            button5 = new Button();
            button7 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            monthCalendar1 = new MonthCalendar();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 系统ToolStripMenuItem, 学院管理MToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1263, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            系统ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmi_PwdModify, toolStripSeparator2, 推出系统ToolStripMenuItem });
            系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            系统ToolStripMenuItem.Size = new Size(72, 24);
            系统ToolStripMenuItem.Text = "系统(S&)";
            // 
            // tsmi_PwdModify
            // 
            tsmi_PwdModify.Image = (Image)resources.GetObject("tsmi_PwdModify.Image");
            tsmi_PwdModify.Name = "tsmi_PwdModify";
            tsmi_PwdModify.Size = new Size(171, 26);
            tsmi_PwdModify.Text = "密码修改(&P)";
            tsmi_PwdModify.Click += tsmi_PwdModify_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(168, 6);
            // 
            // 推出系统ToolStripMenuItem
            // 
            推出系统ToolStripMenuItem.Image = (Image)resources.GetObject("推出系统ToolStripMenuItem.Image");
            推出系统ToolStripMenuItem.Name = "推出系统ToolStripMenuItem";
            推出系统ToolStripMenuItem.Size = new Size(171, 26);
            推出系统ToolStripMenuItem.Text = "推出系统(&E)";
            // 
            // 学院管理MToolStripMenuItem
            // 
            学院管理MToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 添加学员AToolStripMenuItem, 批量导入学院IToolStripMenuItem, toolStripSeparator1, 学员信息管理ToolStripMenuItem });
            学院管理MToolStripMenuItem.Name = "学院管理MToolStripMenuItem";
            学院管理MToolStripMenuItem.Size = new Size(108, 24);
            学院管理MToolStripMenuItem.Text = "学院管理(&M)";
            // 
            // 添加学员AToolStripMenuItem
            // 
            添加学员AToolStripMenuItem.Image = (Image)resources.GetObject("添加学员AToolStripMenuItem.Image");
            添加学员AToolStripMenuItem.Name = "添加学员AToolStripMenuItem";
            添加学员AToolStripMenuItem.Size = new Size(196, 26);
            添加学员AToolStripMenuItem.Text = "添加学员(&A)";
            // 
            // 批量导入学院IToolStripMenuItem
            // 
            批量导入学院IToolStripMenuItem.Image = (Image)resources.GetObject("批量导入学院IToolStripMenuItem.Image");
            批量导入学院IToolStripMenuItem.Name = "批量导入学院IToolStripMenuItem";
            批量导入学院IToolStripMenuItem.Size = new Size(196, 26);
            批量导入学院IToolStripMenuItem.Text = "批量导入学员(&I)";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(193, 6);
            // 
            // 学员信息管理ToolStripMenuItem
            // 
            学员信息管理ToolStripMenuItem.Image = (Image)resources.GetObject("学员信息管理ToolStripMenuItem.Image");
            学员信息管理ToolStripMenuItem.Name = "学员信息管理ToolStripMenuItem";
            学员信息管理ToolStripMenuItem.Size = new Size(196, 26);
            学员信息管理ToolStripMenuItem.Text = "学员信息管理";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 695);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1263, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(101, 20);
            toolStripStatusLabel1.Text = "版本号：V2.0";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(127, 20);
            toolStripStatusLabel2.Text = "   [当前用户：***]";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 28);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button6);
            splitContainer1.Panel1.Controls.Add(button8);
            splitContainer1.Panel1.Controls.Add(button5);
            splitContainer1.Panel1.Controls.Add(button7);
            splitContainer1.Panel1.Controls.Add(button4);
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(monthCalendar1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(1263, 667);
            splitContainer1.SplitterDistance = 328;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // button6
            // 
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.ImageIndex = 5;
            button6.ImageList = imageList1;
            button6.Location = new Point(179, 330);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(100, 50);
            button6.TabIndex = 1;
            button6.Text = "考勤打卡 ";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "about.ico");
            imageList1.Images.SetKeyName(1, "Close.ico");
            imageList1.Images.SetKeyName(2, "CustomerOrder.ico");
            imageList1.Images.SetKeyName(3, "MngIncdown.bmp");
            imageList1.Images.SetKeyName(4, "people.ico");
            imageList1.Images.SetKeyName(5, "PROPS.ICO");
            imageList1.Images.SetKeyName(6, "Sells.ico");
            imageList1.Images.SetKeyName(7, "SysIco.ico");
            imageList1.Images.SetKeyName(8, "TABLE.ICO");
            imageList1.Images.SetKeyName(9, "修改.bmp");
            // 
            // button8
            // 
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.ImageIndex = 9;
            button8.ImageList = imageList1;
            button8.Location = new Point(49, 590);
            button8.Margin = new Padding(4);
            button8.Name = "button8";
            button8.Size = new Size(100, 50);
            button8.TabIndex = 1;
            button8.Text = "密码修改 ";
            button8.TextAlign = ContentAlignment.MiddleRight;
            button8.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.ImageIndex = 0;
            button5.ImageList = imageList1;
            button5.Location = new Point(49, 400);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(100, 50);
            button5.TabIndex = 1;
            button5.Text = "成绩分析 ";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.ImageIndex = 1;
            button7.ImageList = imageList1;
            button7.Location = new Point(179, 590);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(100, 50);
            button7.TabIndex = 1;
            button7.Text = "退出系统 ";
            button7.TextAlign = ContentAlignment.MiddleRight;
            button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.ImageIndex = 8;
            button4.ImageList = imageList1;
            button4.Location = new Point(179, 400);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(100, 50);
            button4.TabIndex = 1;
            button4.Text = "成绩浏览 ";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.ImageIndex = 4;
            button3.ImageList = imageList1;
            button3.Location = new Point(49, 330);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(100, 50);
            button3.TabIndex = 1;
            button3.Text = "学员管理 ";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImageIndex = 2;
            button2.ImageList = imageList1;
            button2.Location = new Point(179, 260);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(100, 50);
            button2.TabIndex = 1;
            button2.Text = "批量导入 ";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImageIndex = 3;
            button1.ImageList = imageList1;
            button1.Location = new Point(49, 260);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(100, 50);
            button1.TabIndex = 1;
            button1.Text = "添加学员 ";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(33, 33);
            monthCalendar1.Margin = new Padding(12, 11, 12, 11);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("SimHei", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(234, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(459, 44);
            label1.TabIndex = 0;
            label1.Text = "欢迎使用学员管理系统";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 721);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMain";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学员信息管理系统";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 系统ToolStripMenuItem;
        private ToolStripMenuItem tsmi_PwdModify;
        private ToolStripMenuItem 推出系统ToolStripMenuItem;
        private ToolStripMenuItem 学院管理MToolStripMenuItem;
        private ToolStripMenuItem 添加学员AToolStripMenuItem;
        private ToolStripMenuItem 批量导入学院IToolStripMenuItem;
        private ToolStripMenuItem 学员信息管理ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private SplitContainer splitContainer1;
        private MonthCalendar monthCalendar1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button8;
        private Button button7;
        private ImageList imageList1;
        private Label label1;
    }
}
