namespace ExamSys
{
    partial class Regroup
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
            this.components = new System.ComponentModel.Container();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tabDisplayStyle = new System.Windows.Forms.TabPage();
            this.rbDisplayStyle0 = new System.Windows.Forms.RadioButton();
            this.rbDisplayStyle1 = new System.Windows.Forms.RadioButton();
            this.tabExamStyle = new System.Windows.Forms.TabPage();
            this.numLimitedTIme = new System.Windows.Forms.NumericUpDown();
            this.rbTestWay6 = new System.Windows.Forms.RadioButton();
            this.rbTestWay5 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbTestWay3 = new System.Windows.Forms.RadioButton();
            this.rbTestWay2 = new System.Windows.Forms.RadioButton();
            this.tabSubjectNumber = new System.Windows.Forms.TabPage();
            this.subjectNumberPicker = new ExamSys.SubjectNumberPicker(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.categoryPicker = new ExamSys.CategoryPicker(this.components);
            this.tabDisplayStyle.SuspendLayout();
            this.tabExamStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitedTIme)).BeginInit();
            this.tabSubjectNumber.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(595, 399);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.Text = "进入考场";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStatus.Location = new System.Drawing.Point(0, 434);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(699, 25);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDisplayStyle
            // 
            this.tabDisplayStyle.Controls.Add(this.rbDisplayStyle0);
            this.tabDisplayStyle.Controls.Add(this.rbDisplayStyle1);
            this.tabDisplayStyle.Location = new System.Drawing.Point(4, 22);
            this.tabDisplayStyle.Name = "tabDisplayStyle";
            this.tabDisplayStyle.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplayStyle.Size = new System.Drawing.Size(379, 346);
            this.tabDisplayStyle.TabIndex = 1;
            this.tabDisplayStyle.Text = "试卷显示模式";
            // 
            // rbDisplayStyle0
            // 
            this.rbDisplayStyle0.AutoSize = true;
            this.rbDisplayStyle0.Checked = true;
            this.rbDisplayStyle0.Location = new System.Drawing.Point(21, 36);
            this.rbDisplayStyle0.Name = "rbDisplayStyle0";
            this.rbDisplayStyle0.Size = new System.Drawing.Size(71, 16);
            this.rbDisplayStyle0.TabIndex = 0;
            this.rbDisplayStyle0.TabStop = true;
            this.rbDisplayStyle0.Text = "列表模式";
            this.rbDisplayStyle0.UseVisualStyleBackColor = true;
            this.rbDisplayStyle0.CheckedChanged += new System.EventHandler(this.rbDisplayStyle_CheckedChanged);
            // 
            // rbDisplayStyle1
            // 
            this.rbDisplayStyle1.AutoSize = true;
            this.rbDisplayStyle1.Location = new System.Drawing.Point(21, 75);
            this.rbDisplayStyle1.Name = "rbDisplayStyle1";
            this.rbDisplayStyle1.Size = new System.Drawing.Size(269, 16);
            this.rbDisplayStyle1.TabIndex = 0;
            this.rbDisplayStyle1.Text = "逐个模式（人机对话模式,鼠标右键换下一题）";
            this.rbDisplayStyle1.UseVisualStyleBackColor = true;
            this.rbDisplayStyle1.CheckedChanged += new System.EventHandler(this.rbDisplayStyle_CheckedChanged);
            // 
            // tabExamStyle
            // 
            this.tabExamStyle.Controls.Add(this.numLimitedTIme);
            this.tabExamStyle.Controls.Add(this.rbTestWay6);
            this.tabExamStyle.Controls.Add(this.rbTestWay5);
            this.tabExamStyle.Controls.Add(this.label4);
            this.tabExamStyle.Controls.Add(this.label3);
            this.tabExamStyle.Controls.Add(this.label1);
            this.tabExamStyle.Controls.Add(this.label5);
            this.tabExamStyle.Controls.Add(this.label2);
            this.tabExamStyle.Controls.Add(this.rbTestWay3);
            this.tabExamStyle.Controls.Add(this.rbTestWay2);
            this.tabExamStyle.Location = new System.Drawing.Point(4, 22);
            this.tabExamStyle.Name = "tabExamStyle";
            this.tabExamStyle.Padding = new System.Windows.Forms.Padding(3);
            this.tabExamStyle.Size = new System.Drawing.Size(379, 346);
            this.tabExamStyle.TabIndex = 3;
            this.tabExamStyle.Text = "测试模式";
            this.tabExamStyle.UseVisualStyleBackColor = true;
            // 
            // numLimitedTIme
            // 
            this.numLimitedTIme.Location = new System.Drawing.Point(41, 123);
            this.numLimitedTIme.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numLimitedTIme.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLimitedTIme.Name = "numLimitedTIme";
            this.numLimitedTIme.Size = new System.Drawing.Size(78, 21);
            this.numLimitedTIme.TabIndex = 5;
            this.numLimitedTIme.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // rbTestWay6
            // 
            this.rbTestWay6.AutoSize = true;
            this.rbTestWay6.Location = new System.Drawing.Point(22, 218);
            this.rbTestWay6.Name = "rbTestWay6";
            this.rbTestWay6.Size = new System.Drawing.Size(71, 16);
            this.rbTestWay6.TabIndex = 3;
            this.rbTestWay6.Text = "错题重做";
            this.rbTestWay6.UseVisualStyleBackColor = true;
            this.rbTestWay6.CheckedChanged += new System.EventHandler(this.rbTestWay_CheckedChanged);
            // 
            // rbTestWay5
            // 
            this.rbTestWay5.AutoSize = true;
            this.rbTestWay5.Location = new System.Drawing.Point(22, 162);
            this.rbTestWay5.Name = "rbTestWay5";
            this.rbTestWay5.Size = new System.Drawing.Size(71, 16);
            this.rbTestWay5.TabIndex = 4;
            this.rbTestWay5.Text = "我的收藏";
            this.rbTestWay5.UseVisualStyleBackColor = true;
            this.rbTestWay5.CheckedChanged += new System.EventHandler(this.rbTestWay_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(39, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 35);
            this.label4.TabIndex = 4;
            this.label4.Text = "从选中试卷下抽取考生做错的试题进行测试。可以显示答案和分析";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(39, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "从选中试卷下抽取考生收藏的试题进行测试。可以显示答案和分析";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "不可以显示答案，分析等，不限制时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "分钟";
            this.label5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "交卷前不可以显示答案，分析等，并且限制时间";
            // 
            // rbTestWay3
            // 
            this.rbTestWay3.AutoSize = true;
            this.rbTestWay3.Checked = true;
            this.rbTestWay3.Location = new System.Drawing.Point(22, 33);
            this.rbTestWay3.Name = "rbTestWay3";
            this.rbTestWay3.Size = new System.Drawing.Size(71, 16);
            this.rbTestWay3.TabIndex = 1;
            this.rbTestWay3.TabStop = true;
            this.rbTestWay3.Text = "正式考试";
            this.rbTestWay3.UseVisualStyleBackColor = true;
            this.rbTestWay3.CheckedChanged += new System.EventHandler(this.rbTestWay_CheckedChanged);
            // 
            // rbTestWay2
            // 
            this.rbTestWay2.AutoSize = true;
            this.rbTestWay2.Location = new System.Drawing.Point(22, 80);
            this.rbTestWay2.Name = "rbTestWay2";
            this.rbTestWay2.Size = new System.Drawing.Size(71, 16);
            this.rbTestWay2.TabIndex = 2;
            this.rbTestWay2.Text = "计时考试";
            this.rbTestWay2.UseVisualStyleBackColor = true;
            this.rbTestWay2.CheckedChanged += new System.EventHandler(this.rbTestWay_CheckedChanged);
            // 
            // tabSubjectNumber
            // 
            this.tabSubjectNumber.Controls.Add(this.subjectNumberPicker);
            this.tabSubjectNumber.Location = new System.Drawing.Point(4, 22);
            this.tabSubjectNumber.Name = "tabSubjectNumber";
            this.tabSubjectNumber.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubjectNumber.Size = new System.Drawing.Size(379, 346);
            this.tabSubjectNumber.TabIndex = 0;
            this.tabSubjectNumber.Text = "试题个数";
            // 
            // subjectNumberPicker
            // 
            this.subjectNumberPicker.AutoScroll = true;
            this.subjectNumberPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectNumberPicker.Location = new System.Drawing.Point(3, 3);
            this.subjectNumberPicker.Name = "subjectNumberPicker";
            this.subjectNumberPicker.Size = new System.Drawing.Size(373, 340);
            this.subjectNumberPicker.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSubjectNumber);
            this.tabControl.Controls.Add(this.tabExamStyle);
            this.tabControl.Controls.Add(this.tabDisplayStyle);
            this.tabControl.Location = new System.Drawing.Point(287, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(387, 372);
            this.tabControl.TabIndex = 6;
            // 
            // categoryPicker
            // 
            this.categoryPicker.CheckOnClick = true;
            this.categoryPicker.FormattingEnabled = true;
            this.categoryPicker.Location = new System.Drawing.Point(12, 12);
            this.categoryPicker.Name = "categoryPicker";
            this.categoryPicker.Size = new System.Drawing.Size(261, 372);
            this.categoryPicker.TabIndex = 0;
            // 
            // Regroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 459);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.categoryPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Regroup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模拟考试";
            this.tabDisplayStyle.ResumeLayout(false);
            this.tabDisplayStyle.PerformLayout();
            this.tabExamStyle.ResumeLayout(false);
            this.tabExamStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitedTIme)).EndInit();
            this.tabSubjectNumber.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CategoryPicker categoryPicker;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.TabPage tabDisplayStyle;
        private System.Windows.Forms.RadioButton rbDisplayStyle0;
        private System.Windows.Forms.RadioButton rbDisplayStyle1;
        private System.Windows.Forms.TabPage tabExamStyle;
        private System.Windows.Forms.RadioButton rbTestWay6;
        private System.Windows.Forms.RadioButton rbTestWay5;
        private System.Windows.Forms.RadioButton rbTestWay3;
        private System.Windows.Forms.RadioButton rbTestWay2;
        private System.Windows.Forms.TabPage tabSubjectNumber;
        private SubjectNumberPicker subjectNumberPicker;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numLimitedTIme;
        private System.Windows.Forms.Label label5;
    }
}