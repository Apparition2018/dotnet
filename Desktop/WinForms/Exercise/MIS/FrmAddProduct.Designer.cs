namespace WinForms.Exercise.MIS
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
            label1 = new Label();
            Save = new Button();
            Close3 = new Button();
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
            // Save
            //
            Save.BackColor = Color.FromArgb(34, 155, 252);
            Save.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            Save.FlatStyle = FlatStyle.Flat;
            Save.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Save.ForeColor = Color.White;
            Save.Image = Properties.Resources.Save_Image;
            Save.ImageAlign = ContentAlignment.MiddleLeft;
            Save.Location = new Point(739, 10);
            Save.Name = "Save";
            Save.Size = new Size(140, 28);
            Save.TabIndex = 1;
            Save.Text = "      保存到数据库";
            Save.TextAlign = ContentAlignment.MiddleLeft;
            Save.UseVisualStyleBackColor = false;
            //
            // Close3
            //
            Close3.BackColor = Color.FromArgb(34, 155, 252);
            Close3.FlatAppearance.BorderColor = Color.FromArgb(9, 163, 220);
            Close3.FlatStyle = FlatStyle.Flat;
            Close3.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Close3.ForeColor = Color.White;
            Close3.Image = Properties.Resources.Close3_Image;
            Close3.ImageAlign = ContentAlignment.MiddleLeft;
            Close3.Location = new Point(935, 10);
            Close3.Name = "Close3";
            Close3.Size = new Size(100, 28);
            Close3.TabIndex = 1;
            Close3.Text = "      关闭窗口";
            Close3.TextAlign = ContentAlignment.MiddleLeft;
            Close3.UseVisualStyleBackColor = false;
            Close3.Click += BtnClose_Click;
            //
            // FrmAddProduct
            //
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 255, 255);
            ClientSize = new Size(1047, 640);
            Controls.Add(Close3);
            Controls.Add(Save);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAddProduct";
            Text = "FrmProduct";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button Save;
        private Button Close3;
    }
}
