namespace WinForms.Exercise.MIS
{
    partial class FrmAdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminLogin));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            BtnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            //
            // pictureBox1
            //
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(390, 90);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // label1
            //
            label1.BackColor = Color.FromArgb(0, 155, 213);
            label1.Font = new Font("微软雅黑", 24F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 18);
            label1.Name = "label1";
            label1.Size = new Size(325, 55);
            label1.TabIndex = 1;
            label1.Text = "企业级MIS综合平台";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(75, 122);
            label2.Name = "label2";
            label2.Size = new Size(80, 17);
            label2.TabIndex = 2;
            label2.Text = "管理员账号：";
            //
            // textBox1
            //
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(157, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(160, 23);
            textBox1.TabIndex = 3;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(75, 159);
            label3.Name = "label3";
            label3.Size = new Size(80, 17);
            label3.TabIndex = 2;
            label3.Text = "管理员密码：";
            //
            // textBox2
            //
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(157, 156);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(160, 23);
            textBox2.TabIndex = 3;
            textBox2.UseSystemPasswordChar = true;
            //
            // checkBox1
            //
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            checkBox1.Location = new Point(79, 188);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(158, 21);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "记住密码（10天内保存）";
            checkBox1.UseVisualStyleBackColor = true;
            //
            // button1
            //
            button1.BackColor = Color.FromArgb(9, 163, 220);
            button1.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button1.ForeColor = Color.White;
            button1.Location = new Point(157, 218);
            button1.Name = "button1";
            button1.Size = new Size(160, 30);
            button1.TabIndex = 5;
            button1.Text = "登  录  系  统";
            button1.UseVisualStyleBackColor = false;
            //
            // BtnClose
            //
            BtnClose.BackColor = Color.FromArgb(0, 155, 213);
            BtnClose.FlatAppearance.BorderColor = Color.FromArgb(0, 155, 213);
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(359, 1);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(30, 30);
            BtnClose.TabIndex = 6;
            BtnClose.Text = "×";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            //
            // FrmAdminLogin
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(390, 280);
            Controls.Add(BtnClose);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAdminLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            MouseDown += FrmAD_MouseDown;
            MouseMove += FrmAD_MouseMove;
            MouseUp += FrmAD_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private CheckBox checkBox1;
        private Button button1;
        private Button BtnClose;
    }
}
