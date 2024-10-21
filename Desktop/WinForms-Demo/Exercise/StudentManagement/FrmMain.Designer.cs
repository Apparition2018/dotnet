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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            menuStrip1 = new MenuStrip();
            系统ToolStripMenuItem = new ToolStripMenuItem();
            tsmiPwdModify = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            退出系统ToolStripMenuItem = new ToolStripMenuItem();
            学院管理MToolStripMenuItem = new ToolStripMenuItem();
            添加学员AToolStripMenuItem = new ToolStripMenuItem();
            批量导入学院IToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            学员信息管理ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            mainContainer = new SplitContainer();
            button6 = new Button();
            button8 = new Button();
            button5 = new Button();
            button7 = new Button();
            button4 = new Button();
            btnStuManagement = new Button();
            button2 = new Button();
            btnAddStudent = new Button();
            monthCalendar1 = new MonthCalendar();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainContainer).BeginInit();
            mainContainer.Panel1.SuspendLayout();
            mainContainer.Panel2.SuspendLayout();
            mainContainer.SuspendLayout();
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
            系统ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiPwdModify, toolStripSeparator2, 退出系统ToolStripMenuItem });
            系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            系统ToolStripMenuItem.Size = new Size(72, 24);
            系统ToolStripMenuItem.Text = "系统(S&)";
            //
            // tsmiPwdModify
            //
            tsmiPwdModify.Image = Properties.Resources.UserPsw_Image;
            tsmiPwdModify.Name = "tsmiPwdModify";
            tsmiPwdModify.Size = new Size(171, 26);
            tsmiPwdModify.Text = "密码修改(&P)";
            tsmiPwdModify.Click += TsmiPwdModify_Click;
            //
            // toolStripSeparator2
            //
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(168, 6);
            //
            // 退出系统ToolStripMenuItem
            //
            退出系统ToolStripMenuItem.Image = Properties.Resources.Close_Image;
            退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            退出系统ToolStripMenuItem.Size = new Size(171, 26);
            退出系统ToolStripMenuItem.Text = "退出系统(&E)";
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
            添加学员AToolStripMenuItem.Image = Properties.Resources.Purchase_Image;
            添加学员AToolStripMenuItem.Name = "添加学员AToolStripMenuItem";
            添加学员AToolStripMenuItem.Size = new Size(224, 26);
            添加学员AToolStripMenuItem.Text = "添加学员(&A)";
            //
            // 批量导入学院IToolStripMenuItem
            //
            批量导入学院IToolStripMenuItem.Image = Properties.Resources.CustomerOrder2_Image;
            批量导入学院IToolStripMenuItem.Name = "批量导入学院IToolStripMenuItem";
            批量导入学院IToolStripMenuItem.Size = new Size(224, 26);
            批量导入学院IToolStripMenuItem.Text = "批量导入学员(&I)";
            //
            // toolStripSeparator1
            //
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            //
            // 学员信息管理ToolStripMenuItem
            //
            学员信息管理ToolStripMenuItem.Image = Properties.Resources.Student_Image;
            学员信息管理ToolStripMenuItem.Name = "学员信息管理ToolStripMenuItem";
            学员信息管理ToolStripMenuItem.Size = new Size(224, 26);
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
            // mainContainer
            //
            mainContainer.BorderStyle = BorderStyle.Fixed3D;
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.FixedPanel = FixedPanel.Panel1;
            mainContainer.Location = new Point(0, 28);
            mainContainer.Margin = new Padding(4);
            mainContainer.Name = "mainContainer";
            //
            // mainContainer.Panel1
            //
            mainContainer.Panel1.Controls.Add(button6);
            mainContainer.Panel1.Controls.Add(button8);
            mainContainer.Panel1.Controls.Add(button5);
            mainContainer.Panel1.Controls.Add(button7);
            mainContainer.Panel1.Controls.Add(button4);
            mainContainer.Panel1.Controls.Add(btnStuManagement);
            mainContainer.Panel1.Controls.Add(button2);
            mainContainer.Panel1.Controls.Add(btnAddStudent);
            mainContainer.Panel1.Controls.Add(monthCalendar1);
            //
            // mainContainer.Panel2
            //
            mainContainer.Panel2.BackgroundImage = (Image)resources.GetObject("mainContainer.Panel2.BackgroundImage");
            mainContainer.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
            mainContainer.Panel2.Controls.Add(label1);
            mainContainer.Size = new Size(1263, 667);
            mainContainer.SplitterDistance = 328;
            mainContainer.SplitterWidth = 5;
            mainContainer.TabIndex = 2;
            //
            // button6
            //
            button6.Image = Properties.Resources.App_Image;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(179, 330);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(100, 50);
            button6.TabIndex = 1;
            button6.Text = "考勤打卡 ";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = true;
            //
            // button8
            //
            button8.Image = Properties.Resources.Modify_Image;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
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
            button5.Image = Properties.Resources.About2_Image;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
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
            button7.Image = Properties.Resources.Close_Image;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
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
            button4.Image = Properties.Resources.CustomerOrder2_Image;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(179, 400);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(100, 50);
            button4.TabIndex = 1;
            button4.Text = "成绩浏览 ";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = true;
            //
            // btnStuManagement
            //
            btnStuManagement.Image = Properties.Resources.People_Image;
            btnStuManagement.ImageAlign = ContentAlignment.MiddleLeft;
            btnStuManagement.Location = new Point(49, 330);
            btnStuManagement.Margin = new Padding(4);
            btnStuManagement.Name = "btnStuManagement";
            btnStuManagement.Size = new Size(100, 50);
            btnStuManagement.TabIndex = 1;
            btnStuManagement.Text = "学员管理 ";
            btnStuManagement.TextAlign = ContentAlignment.MiddleRight;
            btnStuManagement.UseVisualStyleBackColor = true;
            btnStuManagement.Click += BtnStuManagement_Click;
            //
            // button2
            //
            button2.Image = Properties.Resources.DataBase2_Image;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(179, 260);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(100, 50);
            button2.TabIndex = 1;
            button2.Text = "批量导入 ";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            //
            // btnAddStudent
            //
            btnAddStudent.Image = Properties.Resources.MngIncdown_Image;
            btnAddStudent.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddStudent.Location = new Point(49, 260);
            btnAddStudent.Margin = new Padding(4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(100, 50);
            btnAddStudent.TabIndex = 1;
            btnAddStudent.Text = "添加学员 ";
            btnAddStudent.TextAlign = ContentAlignment.MiddleRight;
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += BtnAddStudent_Click;
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
            Controls.Add(mainContainer);
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
            mainContainer.Panel1.ResumeLayout(false);
            mainContainer.Panel2.ResumeLayout(false);
            mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainContainer).EndInit();
            mainContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 系统ToolStripMenuItem;
        private ToolStripMenuItem tsmiPwdModify;
        private ToolStripMenuItem 退出系统ToolStripMenuItem;
        private ToolStripMenuItem 学院管理MToolStripMenuItem;
        private ToolStripMenuItem 添加学员AToolStripMenuItem;
        private ToolStripMenuItem 批量导入学院IToolStripMenuItem;
        private ToolStripMenuItem 学员信息管理ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private SplitContainer mainContainer;
        private MonthCalendar monthCalendar1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button btnStuManagement;
        private Button button2;
        private Button btnAddStudent;
        private Button button8;
        private Button button7;
        private Label label1;
    }
}
