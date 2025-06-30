namespace WinForms.Function.Paging;

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
        dgv = new DataGridView();
        StudentIdNo = new DataGridViewTextBoxColumn();
        StudentName = new DataGridViewTextBoxColumn();
        Gender = new DataGridViewTextBoxColumn();
        Birthday = new DataGridViewTextBoxColumn();
        PhoneNumber = new DataGridViewTextBoxColumn();
        groupBox1 = new GroupBox();
        lblTotalCount = new Label();
        lblPageNum = new Label();
        lblTotalPage = new Label();
        label5 = new Label();
        label4 = new Label();
        btnLast = new Button();
        btnNext = new Button();
        btnPre = new Button();
        btnFirst = new Button();
        btnGoTo = new Button();
        txtGoTo = new TextBox();
        label2 = new Label();
        cbPageSize = new ComboBox();
        label1 = new Label();
        groupBox2 = new GroupBox();
        btnQuery = new Button();
        label3 = new Label();
        dptBirthday = new DateTimePicker();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // dgv
        // 
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.Columns.AddRange(new DataGridViewColumn[] { StudentIdNo, StudentName, Gender, Birthday, PhoneNumber });
        dgv.Location = new Point(12, 12);
        dgv.Name = "dgv";
        dgv.RowHeadersWidth = 51;
        dgv.Size = new Size(670, 350);
        dgv.TabIndex = 0;
        // 
        // StudentIdNo
        // 
        StudentIdNo.DataPropertyName = "StudentIdNo";
        StudentIdNo.HeaderText = "学号";
        StudentIdNo.MinimumWidth = 6;
        StudentIdNo.Name = "StudentIdNo";
        StudentIdNo.Width = 190;
        // 
        // StudentName
        // 
        StudentName.DataPropertyName = "StudentName";
        StudentName.HeaderText = "姓名";
        StudentName.MinimumWidth = 6;
        StudentName.Name = "StudentName";
        StudentName.Width = 75;
        // 
        // Gender
        // 
        Gender.DataPropertyName = "Gender";
        Gender.HeaderText = "性别";
        Gender.MinimumWidth = 6;
        Gender.Name = "Gender";
        Gender.Width = 70;
        // 
        // Birthday
        // 
        Birthday.DataPropertyName = "Birthday";
        Birthday.HeaderText = "出生日期";
        Birthday.MinimumWidth = 6;
        Birthday.Name = "Birthday";
        Birthday.Width = 125;
        // 
        // PhoneNumber
        // 
        PhoneNumber.DataPropertyName = "PhoneNumber";
        PhoneNumber.HeaderText = "联系电话";
        PhoneNumber.MinimumWidth = 6;
        PhoneNumber.Name = "PhoneNumber";
        PhoneNumber.Width = 135;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(lblTotalCount);
        groupBox1.Controls.Add(lblPageNum);
        groupBox1.Controls.Add(lblTotalPage);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(btnLast);
        groupBox1.Controls.Add(btnNext);
        groupBox1.Controls.Add(btnPre);
        groupBox1.Controls.Add(btnFirst);
        groupBox1.Controls.Add(btnGoTo);
        groupBox1.Controls.Add(txtGoTo);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(cbPageSize);
        groupBox1.Controls.Add(label1);
        groupBox1.Location = new Point(12, 373);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(670, 70);
        groupBox1.TabIndex = 1;
        groupBox1.TabStop = false;
        groupBox1.Text = "[分页显示]";
        // 
        // lblTotalCount
        // 
        lblTotalCount.AutoSize = true;
        lblTotalCount.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblTotalCount.ForeColor = SystemColors.HotTrack;
        lblTotalCount.Location = new Point(354, 1);
        lblTotalCount.Name = "lblTotalCount";
        lblTotalCount.Size = new Size(18, 19);
        lblTotalCount.TabIndex = 7;
        lblTotalCount.Text = "0";
        // 
        // lblPageNum
        // 
        lblPageNum.AutoSize = true;
        lblPageNum.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblPageNum.ForeColor = SystemColors.HotTrack;
        lblPageNum.Location = new Point(228, 1);
        lblPageNum.Name = "lblPageNum";
        lblPageNum.Size = new Size(18, 19);
        lblPageNum.TabIndex = 7;
        lblPageNum.Text = "0";
        // 
        // lblTotalPage
        // 
        lblTotalPage.AutoSize = true;
        lblTotalPage.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        lblTotalPage.ForeColor = SystemColors.HotTrack;
        lblTotalPage.Location = new Point(141, 1);
        lblTotalPage.Name = "lblTotalPage";
        lblTotalPage.Size = new Size(18, 19);
        lblTotalPage.TabIndex = 7;
        lblTotalPage.Text = "0";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(284, 0);
        label5.Name = "label5";
        label5.Size = new Size(84, 20);
        label5.TabIndex = 6;
        label5.Text = "记录总数：";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(96, 0);
        label4.Name = "label4";
        label4.Size = new Size(174, 20);
        label4.TabIndex = 6;
        label4.Text = "[总计：  页 当前第：  页]";
        // 
        // btnLast
        // 
        btnLast.Location = new Point(591, 28);
        btnLast.Name = "btnLast";
        btnLast.Size = new Size(70, 29);
        btnLast.TabIndex = 5;
        btnLast.Text = "最后页";
        btnLast.UseVisualStyleBackColor = true;
        btnLast.Click += btnLast_Click;
        // 
        // btnNext
        // 
        btnNext.Location = new Point(508, 28);
        btnNext.Name = "btnNext";
        btnNext.Size = new Size(70, 29);
        btnNext.TabIndex = 5;
        btnNext.Text = "下一页";
        btnNext.UseVisualStyleBackColor = true;
        btnNext.Click += btnNext_Click;
        // 
        // btnPre
        // 
        btnPre.Location = new Point(425, 28);
        btnPre.Name = "btnPre";
        btnPre.Size = new Size(70, 29);
        btnPre.TabIndex = 5;
        btnPre.Text = "上一页";
        btnPre.UseVisualStyleBackColor = true;
        btnPre.Click += btnPre_Click;
        // 
        // btnFirst
        // 
        btnFirst.Location = new Point(342, 28);
        btnFirst.Name = "btnFirst";
        btnFirst.Size = new Size(70, 29);
        btnFirst.TabIndex = 5;
        btnFirst.Text = "第一页";
        btnFirst.UseVisualStyleBackColor = true;
        btnFirst.Click += btnFirst_Click;
        // 
        // btnGoTo
        // 
        btnGoTo.Location = new Point(285, 28);
        btnGoTo.Name = "btnGoTo";
        btnGoTo.Size = new Size(40, 29);
        btnGoTo.TabIndex = 4;
        btnGoTo.Text = "GO";
        btnGoTo.UseVisualStyleBackColor = true;
        btnGoTo.Click += btnGoTo_Click;
        // 
        // txtGoTo
        // 
        txtGoTo.Location = new Point(212, 29);
        txtGoTo.Name = "txtGoTo";
        txtGoTo.Size = new Size(50, 27);
        txtGoTo.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(157, 32);
        label2.Name = "label2";
        label2.Size = new Size(129, 20);
        label2.TabIndex = 2;
        label2.Text = "跳转到               页";
        // 
        // cbPageSize
        // 
        cbPageSize.FormattingEnabled = true;
        cbPageSize.Items.AddRange(new object[] { "5", "10", "20", "50", "100" });
        cbPageSize.Location = new Point(76, 28);
        cbPageSize.Name = "cbPageSize";
        cbPageSize.Size = new Size(50, 28);
        cbPageSize.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(6, 32);
        label1.Name = "label1";
        label1.Size = new Size(144, 20);
        label1.TabIndex = 0;
        label1.Text = "每页显示               条";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(btnQuery);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(dptBirthday);
        groupBox2.Location = new Point(12, 454);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(388, 70);
        groupBox2.TabIndex = 2;
        groupBox2.TabStop = false;
        groupBox2.Text = "[查询条件]";
        // 
        // btnQuery
        // 
        btnQuery.Location = new Point(263, 28);
        btnQuery.Name = "btnQuery";
        btnQuery.Size = new Size(94, 29);
        btnQuery.TabIndex = 1;
        btnQuery.Text = "提交查询";
        btnQuery.UseVisualStyleBackColor = true;
        btnQuery.Click += btnQuery_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(6, 32);
        label3.Name = "label3";
        label3.Size = new Size(69, 20);
        label3.TabIndex = 0;
        label3.Text = "出生日期";
        // 
        // dptBirthday
        // 
        dptBirthday.Location = new Point(76, 29);
        dptBirthday.Name = "dptBirthday";
        dptBirthday.Size = new Size(146, 27);
        dptBirthday.TabIndex = 2;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(694, 534);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Controls.Add(dgv);
        Name = "FrmMain";
        Text = "FrmMain";
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgv;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label label1;
    private ComboBox cbPageSize;
    private Label label2;
    private TextBox txtGoTo;
    private Button btnGoTo;
    private Button btnFirst;
    private Button btnLast;
    private Button btnNext;
    private Button btnPre;
    private Button btnQuery;
    private Label label3;
    private DateTimePicker dptBirthday;
    private DataGridViewTextBoxColumn StudentIdNo;
    private DataGridViewTextBoxColumn StudentName;
    private DataGridViewTextBoxColumn Gender;
    private DataGridViewTextBoxColumn Birthday;
    private DataGridViewTextBoxColumn PhoneNumber;
    private Label label4;
    private Label label5;
    private Label lblTotalPage;
    private Label lblTotalCount;
    private Label lblPageNum;
}
