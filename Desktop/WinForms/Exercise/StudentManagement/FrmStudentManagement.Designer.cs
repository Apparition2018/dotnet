namespace WinForms.Exercise.StudentManagement
{
    partial class FrmStudentManagement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStudentManagement));
            label1 = new Label();
            btnClose = new Button();
            groupBox1 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button5 = new Button();
            comboBox1 = new ComboBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            button10 = new Button();
            comboBox2 = new ComboBox();
            label2 = new Label();
            button6 = new Button();
            dataGridView1 = new DataGridView();
            StudentId = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            Birthday = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.Purple;
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(242, 48);
            label1.TabIndex = 1;
            label1.Text = "学员信息管理";
            //
            // btnClose
            //
            btnClose.ForeColor = Color.Black;
            btnClose.Image = Properties.Resources.Close2_Image;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(685, 29);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "关闭窗口 ";
            btnClose.TextAlign = ContentAlignment.MiddleRight;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            //
            // groupBox1
            //
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(25, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 80);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "[按照班级查询]";
            //
            // button4
            //
            button4.ForeColor = Color.Red;
            button4.Image = Properties.Resources.Delete_Image;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(670, 30);
            button4.Name = "button4";
            button4.Size = new Size(90, 30);
            button4.TabIndex = 5;
            button4.Text = "删除学员";
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = true;
            //
            // button3
            //
            button3.ForeColor = Color.Black;
            button3.Image = Properties.Resources.Modify_Image;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(570, 31);
            button3.Name = "button3";
            button3.Size = new Size(90, 30);
            button3.TabIndex = 5;
            button3.Text = "修改学员";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = true;
            //
            // button2
            //
            button2.ForeColor = Color.Black;
            button2.Image = Properties.Resources.MngDowndown_Image;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(460, 31);
            button2.Name = "button2";
            button2.Size = new Size(90, 30);
            button2.TabIndex = 5;
            button2.Text = "学号降序";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            //
            // button1
            //
            button1.ForeColor = Color.Black;
            button1.Image = Properties.Resources.MngDowndown_Image;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(360, 31);
            button1.Name = "button1";
            button1.Size = new Size(90, 30);
            button1.TabIndex = 5;
            button1.Text = "姓名降序";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            //
            // button5
            //
            button5.ForeColor = Color.Black;
            button5.Image = Properties.Resources.Query2_Image;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(250, 31);
            button5.Name = "button5";
            button5.Size = new Size(90, 30);
            button5.TabIndex = 5;
            button5.Text = "查询 ";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = true;
            //
            // comboBox1
            //
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(91, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 28);
            comboBox1.TabIndex = 6;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(5, 36);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 5;
            label5.Text = "所在班级：";
            //
            // groupBox2
            //
            groupBox2.Controls.Add(button10);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(25, 175);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(380, 80);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "[按学号精确查询]";
            //
            // button10
            //
            button10.ForeColor = Color.Black;
            button10.Location = new Point(278, 31);
            button10.Name = "button10";
            button10.Size = new Size(90, 30);
            button10.TabIndex = 5;
            button10.Text = "提交查询";
            button10.UseVisualStyleBackColor = true;
            //
            // comboBox2
            //
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(99, 32);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(170, 28);
            comboBox2.TabIndex = 6;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(5, 36);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 5;
            label2.Text = "请输入学号：";
            //
            // button6
            //
            button6.ForeColor = Color.Black;
            button6.Image = Properties.Resources.Print_Image;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(635, 206);
            button6.Name = "button6";
            button6.Size = new Size(150, 30);
            button6.TabIndex = 5;
            button6.Text = "打印当前学员信息";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = true;
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { StudentId, StudentName, Gender, Birthday, Column2 });
            dataGridView1.Location = new Point(25, 270);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 355);
            dataGridView1.TabIndex = 6;
            //
            // StudentId
            //
            StudentId.HeaderText = "学号";
            StudentId.MinimumWidth = 6;
            StudentId.Name = "StudentId";
            StudentId.ReadOnly = true;
            StudentId.Width = 155;
            //
            // StudentName
            //
            StudentName.HeaderText = "姓名";
            StudentName.MinimumWidth = 6;
            StudentName.Name = "StudentName";
            StudentName.ReadOnly = true;
            StudentName.Width = 155;
            //
            // Gender
            //
            Gender.HeaderText = "性别";
            Gender.MinimumWidth = 6;
            Gender.Name = "Gender";
            Gender.ReadOnly = true;
            Gender.Width = 80;
            //
            // Birthday
            //
            Birthday.HeaderText = "出生日期";
            Birthday.MinimumWidth = 6;
            Birthday.Name = "Birthday";
            Birthday.ReadOnly = true;
            Birthday.Width = 155;
            //
            // Column2
            //
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "所在班级";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            //
            // FrmStudentManagement
            //
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 653);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox2);
            Controls.Add(button6);
            Controls.Add(groupBox1);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmStudentManagement";
            Text = "学员信息管理";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnClose;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label5;
        private Button button5;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
        private GroupBox groupBox2;
        private Button button10;
        private ComboBox comboBox2;
        private Label label2;
        private Button button6;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn StudentId;
        private DataGridViewTextBoxColumn StudentName;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn Birthday;
        private DataGridViewTextBoxColumn Column2;
    }
}
