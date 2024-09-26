namespace WinForms_Demo
{
    partial class FrmDemo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn = new Button();
            btnMinus = new Button();
            btnPlus = new Button();
            Andy = new Button();
            Carry = new Button();
            Coco = new Button();
            MsgBoxShow = new Button();
            SuspendLayout();
            // 
            // btn
            // 
            btn.Location = new Point(80, 60);
            btn.Name = "btn";
            btn.Size = new Size(94, 29);
            btn.TabIndex = 0;
            btn.Text = "btn";
            btn.UseVisualStyleBackColor = true;
            btn.Click += Btn_Click;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(200, 60);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(94, 29);
            btnMinus.TabIndex = 1;
            btnMinus.Text = "btn -";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += BtnMinus_Click;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(320, 60);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(94, 29);
            btnPlus.TabIndex = 2;
            btnPlus.Text = "btn +";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += BtnPlus_Click;
            // 
            // Andy
            // 
            Andy.Location = new Point(80, 120);
            Andy.Name = "Andy";
            Andy.Size = new Size(94, 29);
            Andy.TabIndex = 4;
            Andy.Text = "Andy";
            Andy.UseVisualStyleBackColor = true;
            // 
            // Carry
            // 
            Carry.Location = new Point(200, 120);
            Carry.Name = "Carry";
            Carry.Size = new Size(94, 29);
            Carry.TabIndex = 4;
            Carry.Text = "Carry";
            Carry.UseVisualStyleBackColor = true;
            // 
            // Coco
            // 
            Coco.Location = new Point(320, 120);
            Coco.Name = "Coco";
            Coco.Size = new Size(94, 29);
            Coco.TabIndex = 4;
            Coco.Text = "Coco";
            Coco.UseVisualStyleBackColor = true;
            // 
            // MsgBoxShow
            // 
            MsgBoxShow.Location = new Point(80, 180);
            MsgBoxShow.Name = "MsgBoxShow";
            MsgBoxShow.Size = new Size(150, 29);
            MsgBoxShow.TabIndex = 5;
            MsgBoxShow.Text = "MsgBoxShow";
            MsgBoxShow.UseVisualStyleBackColor = true;
            MsgBoxShow.Click += MsgBoxShow_Click;
            // 
            // FrmDemo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MsgBoxShow);
            Controls.Add(Coco);
            Controls.Add(Carry);
            Controls.Add(Andy);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(btn);
            Name = "FrmDemo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDemo";
            ResumeLayout(false);
        }

        #endregion

        private Button btn;
        private Button btnMinus;
        private Button btnPlus;
        private Button Andy;
        private Button Carry;
        private Button Coco;
        private Button MsgBoxShow;
    }
}
