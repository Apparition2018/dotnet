namespace WinForms_Demo.Exercise.QRCodeAndVCard
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
            groupBox1 = new GroupBox();
            tbUrl = new TextBox();
            tbEmail = new TextBox();
            label9 = new Label();
            label8 = new Label();
            tbTelephone = new TextBox();
            label7 = new Label();
            tbMobilePhone = new TextBox();
            label6 = new Label();
            tbAddress = new TextBox();
            label5 = new Label();
            tbCompany = new TextBox();
            label4 = new Label();
            tbDepartment = new TextBox();
            label3 = new Label();
            tbName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbPost = new TextBox();
            btnCreate = new Button();
            pbQRCode = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbQRCode).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbUrl);
            groupBox1.Controls.Add(tbEmail);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(tbTelephone);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(tbMobilePhone);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbAddress);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbCompany);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbDepartment);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 385);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "[名片信息]";
            // 
            // tbUrl
            // 
            tbUrl.Location = new Point(51, 346);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(312, 27);
            tbUrl.TabIndex = 1;
            tbUrl.Text = "www.lin-chong.com";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(51, 301);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(312, 27);
            tbEmail.TabIndex = 1;
            tbEmail.Text = "LinChong@163.com";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 349);
            label9.Name = "label9";
            label9.Size = new Size(54, 20);
            label9.TabIndex = 0;
            label9.Text = "网址：";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 304);
            label8.Name = "label8";
            label8.Size = new Size(54, 20);
            label8.TabIndex = 0;
            label8.Text = "邮箱：";
            // 
            // tbTelephone
            // 
            tbTelephone.Location = new Point(51, 256);
            tbTelephone.Name = "tbTelephone";
            tbTelephone.Size = new Size(312, 27);
            tbTelephone.TabIndex = 1;
            tbTelephone.Text = "0537-88888888";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 259);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 0;
            label7.Text = "座机：";
            // 
            // tbMobilePhone
            // 
            tbMobilePhone.Location = new Point(51, 211);
            tbMobilePhone.Name = "tbMobilePhone";
            tbMobilePhone.Size = new Size(312, 27);
            tbMobilePhone.TabIndex = 1;
            tbMobilePhone.Text = "13888888888";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 214);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 0;
            label6.Text = "手机：";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(51, 166);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(312, 27);
            tbAddress.TabIndex = 1;
            tbAddress.Text = "山东省济宁市梁山县城东南隅";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 169);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 0;
            label5.Text = "地址：";
            // 
            // tbCompany
            // 
            tbCompany.Location = new Point(51, 121);
            tbCompany.Name = "tbCompany";
            tbCompany.Size = new Size(312, 27);
            tbCompany.TabIndex = 1;
            tbCompany.Text = "梁山";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 124);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 0;
            label4.Text = "公司：";
            // 
            // tbDepartment
            // 
            tbDepartment.Location = new Point(51, 76);
            tbDepartment.Name = "tbDepartment";
            tbDepartment.Size = new Size(312, 27);
            tbDepartment.TabIndex = 1;
            tbDepartment.Text = "小卖部";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 79);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 0;
            label3.Text = "部门：";
            // 
            // tbName
            // 
            tbName.Location = new Point(51, 31);
            tbName.Name = "tbName";
            tbName.Size = new Size(125, 27);
            tbName.TabIndex = 1;
            tbName.Text = "林冲";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "姓名：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 54);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 0;
            label2.Text = "职位：";
            // 
            // tbPost
            // 
            tbPost.Location = new Point(258, 51);
            tbPost.Name = "tbPost";
            tbPost.Size = new Size(125, 27);
            tbPost.TabIndex = 1;
            tbPost.Text = "打杂";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(350, 420);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 40);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "开始生成";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // pbQRCode
            // 
            pbQRCode.Location = new Point(434, 52);
            pbQRCode.Name = "pbQRCode";
            pbQRCode.Size = new Size(320, 320);
            pbQRCode.TabIndex = 3;
            pbQRCode.TabStop = false;
            // 
            // FrmMain
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(pbQRCode);
            Controls.Add(btnCreate);
            Controls.Add(tbPost);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Name = "FrmMain";
            Text = "使用C#基于二维码的名片制作";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbQRCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox tbUrl;
        private TextBox tbEmail;
        private Label label9;
        private Label label8;
        private TextBox tbTelephone;
        private Label label7;
        private TextBox tbMobilePhone;
        private Label label6;
        private TextBox tbAddress;
        private Label label5;
        private TextBox tbCompany;
        private Label label4;
        private TextBox tbDepartment;
        private Label label3;
        private TextBox tbName;
        private Label label2;
        private TextBox tbPost;
        private Button btnCreate;
        private PictureBox pbQRCode;
    }
}
