namespace ExamSys.Options
{
    partial class PlatformStyle
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
            this.lbDisplay = new System.Windows.Forms.Label();
            this.drpFonts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numFontPxiel = new System.Windows.Forms.NumericUpDown();
            this.lbOptionColor = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbBackColor = new System.Windows.Forms.Label();
            this.labelOption = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFontPxiel)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDisplay
            // 
            this.lbDisplay.BackColor = System.Drawing.Color.White;
            this.lbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDisplay.Location = new System.Drawing.Point(13, 90);
            this.lbDisplay.Name = "lbDisplay";
            this.lbDisplay.Size = new System.Drawing.Size(402, 51);
            this.lbDisplay.TabIndex = 12;
            this.lbDisplay.Text = "文字样例 Font examples";
            this.lbDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drpFonts
            // 
            this.drpFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpFonts.FormattingEnabled = true;
            this.drpFonts.IntegralHeight = false;
            this.drpFonts.Location = new System.Drawing.Point(58, 21);
            this.drpFonts.MaxDropDownItems = 10;
            this.drpFonts.Name = "drpFonts";
            this.drpFonts.Size = new System.Drawing.Size(161, 20);
            this.drpFonts.TabIndex = 10;
            this.drpFonts.SelectedIndexChanged += new System.EventHandler(this.drpFonts_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "字体：";
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBold.Location = new System.Drawing.Point(123, 56);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(51, 21);
            this.chkBold.TabIndex = 17;
            this.chkBold.Text = "粗体";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.Click += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label4.Location = new System.Drawing.Point(10, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "字号：";
            // 
            // numFontPxiel
            // 
            this.numFontPxiel.DecimalPlaces = 1;
            this.numFontPxiel.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numFontPxiel.Location = new System.Drawing.Point(58, 55);
            this.numFontPxiel.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numFontPxiel.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFontPxiel.Name = "numFontPxiel";
            this.numFontPxiel.Size = new System.Drawing.Size(49, 21);
            this.numFontPxiel.TabIndex = 11;
            this.numFontPxiel.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numFontPxiel.Click += new System.EventHandler(this.numFontPxiel_ValueChanged);
            // 
            // lbOptionColor
            // 
            this.lbOptionColor.BackColor = System.Drawing.Color.SteelBlue;
            this.lbOptionColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOptionColor.Location = new System.Drawing.Point(287, 52);
            this.lbOptionColor.Name = "lbOptionColor";
            this.lbOptionColor.Size = new System.Drawing.Size(30, 21);
            this.lbOptionColor.TabIndex = 12;
            this.lbOptionColor.Visible = false;
            this.lbOptionColor.Click += new System.EventHandler(this.lbOptionColor_Click);
            // 
            // lbColor
            // 
            this.lbColor.BackColor = System.Drawing.Color.SteelBlue;
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Location = new System.Drawing.Point(287, 23);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(30, 21);
            this.lbColor.TabIndex = 12;
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // lbBackColor
            // 
            this.lbBackColor.BackColor = System.Drawing.Color.Silver;
            this.lbBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBackColor.Location = new System.Drawing.Point(381, 23);
            this.lbBackColor.Name = "lbBackColor";
            this.lbBackColor.Size = new System.Drawing.Size(34, 21);
            this.lbBackColor.TabIndex = 12;
            this.lbBackColor.Click += new System.EventHandler(this.lbBackColor_Click);
            // 
            // labelOption
            // 
            this.labelOption.AutoSize = true;
            this.labelOption.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelOption.Location = new System.Drawing.Point(225, 56);
            this.labelOption.Name = "labelOption";
            this.labelOption.Size = new System.Drawing.Size(56, 17);
            this.labelOption.TabIndex = 1;
            this.labelOption.Text = "选项色：";
            this.labelOption.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label5.Location = new System.Drawing.Point(225, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "前景色：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label6.Location = new System.Drawing.Point(323, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "背景色：";
            // 
            // PlatformStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbDisplay);
            this.Controls.Add(this.drpFonts);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkBold);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelOption);
            this.Controls.Add(this.numFontPxiel);
            this.Controls.Add(this.lbBackColor);
            this.Controls.Add(this.lbOptionColor);
            this.Name = "PlatformStyle";
            this.Size = new System.Drawing.Size(437, 170);
            ((System.ComponentModel.ISupportInitialize)(this.numFontPxiel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDisplay;
        private System.Windows.Forms.ComboBox drpFonts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numFontPxiel;
        private System.Windows.Forms.Label lbOptionColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbBackColor;
        private System.Windows.Forms.Label labelOption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
