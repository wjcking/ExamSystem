namespace EFD.SysCenter.Include
{
    partial class AddChoice
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbMultiple = new System.Windows.Forms.CheckBox();
            this.webChoice = new System.Windows.Forms.WebBrowser();
            this.rbBreakType0 = new System.Windows.Forms.RadioButton();
            this.rbBreakType2 = new System.Windows.Forms.RadioButton();
            this.rbBreakType1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChoices = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.btnOrganize = new System.Windows.Forms.Button();
            this.cbBreak = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbMultiple
            // 
            this.cbMultiple.AutoSize = true;
            this.cbMultiple.Location = new System.Drawing.Point(24, 55);
            this.cbMultiple.Name = "cbMultiple";
            this.cbMultiple.Size = new System.Drawing.Size(84, 16);
            this.cbMultiple.TabIndex = 10;
            this.cbMultiple.Text = "多选选择题";
            this.cbMultiple.UseVisualStyleBackColor = true;
            // 
            // webChoice
            // 
            this.webChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webChoice.Location = new System.Drawing.Point(296, 55);
            this.webChoice.MinimumSize = new System.Drawing.Size(20, 20);
            this.webChoice.Name = "webChoice";
            this.webChoice.Size = new System.Drawing.Size(575, 502);
            this.webChoice.TabIndex = 9;
            // 
            // rbBreakType0
            // 
            this.rbBreakType0.AutoSize = true;
            this.rbBreakType0.Location = new System.Drawing.Point(24, 116);
            this.rbBreakType0.Name = "rbBreakType0";
            this.rbBreakType0.Size = new System.Drawing.Size(59, 16);
            this.rbBreakType0.TabIndex = 8;
            this.rbBreakType0.Text = "不换行";
            this.rbBreakType0.UseVisualStyleBackColor = true;
            this.rbBreakType0.Click += new System.EventHandler(this.rbBreakType_Click);
            // 
            // rbBreakType2
            // 
            this.rbBreakType2.AutoSize = true;
            this.rbBreakType2.Location = new System.Drawing.Point(176, 116);
            this.rbBreakType2.Name = "rbBreakType2";
            this.rbBreakType2.Size = new System.Drawing.Size(83, 16);
            this.rbBreakType2.TabIndex = 8;
            this.rbBreakType2.Text = "每两个选项";
            this.rbBreakType2.UseVisualStyleBackColor = true;
            this.rbBreakType2.Click += new System.EventHandler(this.rbBreakType_Click);
            // 
            // rbBreakType1
            // 
            this.rbBreakType1.AutoSize = true;
            this.rbBreakType1.Checked = true;
            this.rbBreakType1.Location = new System.Drawing.Point(89, 116);
            this.rbBreakType1.Name = "rbBreakType1";
            this.rbBreakType1.Size = new System.Drawing.Size(71, 16);
            this.rbBreakType1.TabIndex = 8;
            this.rbBreakType1.TabStop = true;
            this.rbBreakType1.Text = "每个选项";
            this.rbBreakType1.UseVisualStyleBackColor = true;
            this.rbBreakType1.Click += new System.EventHandler(this.rbBreakType_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Location = new System.Drawing.Point(286, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2, 580);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(205, 457);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(781, 563);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加选择题";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前所添加选择题总数：0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "选项内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "换行";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "是否多选";
            // 
            // txtChoices
            // 
            this.txtChoices.AllowDrop = true;
            this.txtChoices.Location = new System.Drawing.Point(11, 235);
            this.txtChoices.Multiline = true;
            this.txtChoices.Name = "txtChoices";
            this.txtChoices.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChoices.Size = new System.Drawing.Size(269, 216);
            this.txtChoices.TabIndex = 11;
            // 
            // btnOrganize
            // 
            this.btnOrganize.Location = new System.Drawing.Point(124, 457);
            this.btnOrganize.Name = "btnOrganize";
            this.btnOrganize.Size = new System.Drawing.Size(75, 23);
            this.btnOrganize.TabIndex = 12;
            this.btnOrganize.Text = "整理";
            this.btnOrganize.UseVisualStyleBackColor = true;
            this.btnOrganize.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbBreak
            // 
            this.cbBreak.AutoSize = true;
            this.cbBreak.Location = new System.Drawing.Point(205, 207);
            this.cbBreak.Name = "cbBreak";
            this.cbBreak.Size = new System.Drawing.Size(72, 16);
            this.cbBreak.TabIndex = 13;
            this.cbBreak.Text = "选项换行";
            this.cbBreak.UseVisualStyleBackColor = true;
            // 
            // AddChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbBreak);
            this.Controls.Add(this.btnOrganize);
            this.Controls.Add(this.txtChoices);
            this.Controls.Add(this.cbMultiple);
            this.Controls.Add(this.webChoice);
            this.Controls.Add(this.rbBreakType0);
            this.Controls.Add(this.rbBreakType2);
            this.Controls.Add(this.rbBreakType1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AddChoice";
            this.Size = new System.Drawing.Size(893, 609);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbBreakType1;
        private System.Windows.Forms.RadioButton rbBreakType0;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.WebBrowser webChoice;
        private System.Windows.Forms.RadioButton rbBreakType2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbMultiple;
        private System.Windows.Forms.Label label4;
        private TextboxAdvanced txtChoices;
        private System.Windows.Forms.Button btnOrganize;
        private System.Windows.Forms.CheckBox cbBreak;
    }
}
