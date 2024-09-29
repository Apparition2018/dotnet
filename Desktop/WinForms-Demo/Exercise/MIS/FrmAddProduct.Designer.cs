namespace WinForms_Demo.Exercise.MIS
{
    partial class FrmAddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddProduct));
            label1 = new Label();
            button2 = new Button();
            BtnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(-1, 38);
            label1.Name = "label1";
            label1.Size = new Size(1047, 1);
            label1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(34, 155, 252);
            button2.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(739, 10);
            button2.Name = "button2";
            button2.Size = new Size(140, 28);
            button2.TabIndex = 1;
            button2.Text = "      保存到数据库";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.FromArgb(34, 155, 252);
            BtnClose.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BtnClose.ForeColor = Color.White;
            BtnClose.Image = (Image)resources.GetObject("BtnClose.Image");
            BtnClose.ImageAlign = ContentAlignment.MiddleLeft;
            BtnClose.Location = new Point(935, 10);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(100, 28);
            BtnClose.TabIndex = 1;
            BtnClose.Text = "      关闭窗口";
            BtnClose.TextAlign = ContentAlignment.MiddleLeft;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // FrmAddProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 255, 255);
            ClientSize = new Size(1047, 640);
            Controls.Add(BtnClose);
            Controls.Add(button2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAddProduct";
            Text = "FrmProduct";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button2;
        private Button BtnClose;
    }
}
