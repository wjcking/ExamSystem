namespace ExamSys.Options
{
    partial class Misc
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
            this.chkSplash = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.rbApple = new System.Windows.Forms.RadioButton();
            this.rbClassic = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numLimitedTime = new System.Windows.Forms.NumericUpDown();
            this.cbSound = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitedTime)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSplash
            // 
            this.chkSplash.AutoSize = true;
            this.chkSplash.Checked = true;
            this.chkSplash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSplash.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSplash.Location = new System.Drawing.Point(19, 155);
            this.chkSplash.Name = "chkSplash";
            this.chkSplash.Size = new System.Drawing.Size(180, 16);
            this.chkSplash.TabIndex = 3;
            this.chkSplash.Text = "系统启动时，显示初始化画面";
            this.chkSplash.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "系统皮肤";
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Checked = true;
            this.rbDefault.Location = new System.Drawing.Point(53, 89);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(95, 16);
            this.rbDefault.TabIndex = 8;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "EFD Standard";
            this.rbDefault.UseVisualStyleBackColor = true;
            this.rbDefault.CheckedChanged += new System.EventHandler(this.rbDefault_CheckedChanged);
            this.rbDefault.Click += new System.EventHandler(this.rbDefault_CheckedChanged);
            // 
            // rbApple
            // 
            this.rbApple.AutoSize = true;
            this.rbApple.Location = new System.Drawing.Point(53, 111);
            this.rbApple.Name = "rbApple";
            this.rbApple.Size = new System.Drawing.Size(71, 16);
            this.rbApple.TabIndex = 8;
            this.rbApple.Text = "苹果用户";
            this.rbApple.UseVisualStyleBackColor = true;
            this.rbApple.Click += new System.EventHandler(this.rbDefault_CheckedChanged);
            // 
            // rbClassic
            // 
            this.rbClassic.AutoSize = true;
            this.rbClassic.Location = new System.Drawing.Point(53, 133);
            this.rbClassic.Name = "rbClassic";
            this.rbClassic.Size = new System.Drawing.Size(95, 16);
            this.rbClassic.TabIndex = 8;
            this.rbClassic.Text = "Windows 经典";
            this.rbClassic.UseVisualStyleBackColor = true;
            this.rbClassic.Click += new System.EventHandler(this.rbDefault_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "考试时间（分钟）";
            // 
            // numLimitedTime
            // 
            this.numLimitedTime.Location = new System.Drawing.Point(53, 37);
            this.numLimitedTime.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numLimitedTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLimitedTime.Name = "numLimitedTime";
            this.numLimitedTime.Size = new System.Drawing.Size(95, 21);
            this.numLimitedTime.TabIndex = 9;
            this.numLimitedTime.Value = new decimal(new int[] {
            55,
            0,
            0,
            0});
            // 
            // cbSound
            // 
            this.cbSound.AutoSize = true;
            this.cbSound.Location = new System.Drawing.Point(245, 40);
            this.cbSound.Name = "cbSound";
            this.cbSound.Size = new System.Drawing.Size(72, 16);
            this.cbSound.TabIndex = 10;
            this.cbSound.Text = "系统声效";
            this.cbSound.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "开启/关闭系统声效";
            // 
            // Misc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSound);
            this.Controls.Add(this.numLimitedTime);
            this.Controls.Add(this.rbClassic);
            this.Controls.Add(this.rbApple);
            this.Controls.Add(this.rbDefault);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSplash);
            this.Name = "Misc";
            this.Size = new System.Drawing.Size(419, 188);
            ((System.ComponentModel.ISupportInitialize)(this.numLimitedTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSplash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDefault;
        private System.Windows.Forms.RadioButton rbApple;
        private System.Windows.Forms.RadioButton rbClassic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numLimitedTime;
        private System.Windows.Forms.CheckBox cbSound;
        private System.Windows.Forms.Label label3;
    }
}
