namespace WinForms_Demo.Exercise.StudentManagement
{
    partial class FrmAddStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddStudent));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label8 = new Label();
            label6 = new Label();
            label9 = new Label();
            label7 = new Label();
            label5 = new Label();
            label2 = new Label();
            button5 = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.Purple;
            label1.Location = new Point(40, 25);
            label1.Name = "label1";
            label1.Size = new Size(205, 48);
            label1.TabIndex = 0;
            label1.Text = "添加新学员";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(40, 95);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 250);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(520, 95);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 250);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(355, 95);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 2;
            button1.Text = "启动摄像头";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.ForeColor = Color.Black;
            button2.Location = new Point(355, 165);
            button2.Name = "button2";
            button2.Size = new Size(100, 40);
            button2.TabIndex = 2;
            button2.Text = "开始拍照";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.ForeColor = Color.Black;
            button3.Location = new Point(355, 235);
            button3.Name = "button3";
            button3.Size = new Size(100, 40);
            button3.TabIndex = 2;
            button3.Text = "清除照片";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.ForeColor = Color.Black;
            button4.Location = new Point(355, 305);
            button4.Name = "button4";
            button4.Size = new Size(100, 40);
            button4.TabIndex = 2;
            button4.Text = "选择图片";
            button4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(40, 380);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(730, 240);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "[学员基本信息]";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(90, 90);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(220, 28);
            comboBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(560, 40);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(170, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.ForeColor = Color.Black;
            radioButton2.Location = new Point(418, 41);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(45, 24);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "女";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.ForeColor = Color.Black;
            radioButton1.Location = new Point(374, 41);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(45, 24);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "男";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(480, 140);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(250, 27);
            textBox4.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(480, 91);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(90, 190);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(640, 27);
            textBox5.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(90, 140);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(220, 27);
            textBox3.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 27);
            textBox1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(325, 43);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 0;
            label3.Text = "性别：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(467, 43);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 0;
            label4.Text = "出生日期：";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(385, 143);
            label8.Name = "label8";
            label8.Size = new Size(84, 20);
            label8.TabIndex = 0;
            label8.Text = "联系电话：";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(385, 94);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 0;
            label6.Text = "身份证号：";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(0, 193);
            label9.Name = "label9";
            label9.Size = new Size(84, 20);
            label9.TabIndex = 0;
            label9.Text = "家庭地址：";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(0, 143);
            label7.Name = "label7";
            label7.Size = new Size(84, 20);
            label7.TabIndex = 0;
            label7.Text = "考勤卡号：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(0, 94);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 0;
            label5.Text = "所在班级：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 43);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 0;
            label2.Text = "学员姓名：";
            // 
            // button5
            // 
            button5.ForeColor = Color.Black;
            button5.Image = Properties.Resources.MngIncdown_Image;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(520, 29);
            button5.Name = "button5";
            button5.Size = new Size(100, 40);
            button5.TabIndex = 2;
            button5.Text = "确认添加 ";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.ForeColor = Color.Black;
            btnClose.Image = Properties.Resources.Close2_Image;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(670, 29);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "关闭窗口 ";
            btnClose.TextAlign = ContentAlignment.MiddleRight;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // FrmAddStudent
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 653);
            Controls.Add(groupBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnClose);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmAddStudent";
            Text = "添加新学员";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox1;
        private RadioButton radioButton1;
        private Label label3;
        private RadioButton radioButton2;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private ComboBox comboBox1;
        private Label label6;
        private TextBox textBox2;
        private Label label7;
        private TextBox textBox3;
        private Label label8;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label9;
        private Button button5;
        private Button btnClose;
    }
}
