namespace EFD.SysCenter
{
    partial class AddNode
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbRand = new System.Windows.Forms.CheckBox();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.rbExam = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbIsBatch = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbRand);
            this.groupBox3.Controls.Add(this.rbCategory);
            this.groupBox3.Controls.Add(this.rbExam);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 99);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "节点类型(&N)";
            // 
            // cbRand
            // 
            this.cbRand.AutoSize = true;
            this.cbRand.Checked = true;
            this.cbRand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRand.Location = new System.Drawing.Point(34, 42);
            this.cbRand.Name = "cbRand";
            this.cbRand.Size = new System.Drawing.Size(120, 16);
            this.cbRand.TabIndex = 8;
            this.cbRand.Text = "是否推荐随机测试";
            this.cbRand.UseVisualStyleBackColor = true;
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(15, 64);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(47, 16);
            this.rbCategory.TabIndex = 6;
            this.rbCategory.Text = "分类";
            this.rbCategory.UseVisualStyleBackColor = true;
            // 
            // rbExam
            // 
            this.rbExam.AutoSize = true;
            this.rbExam.Checked = true;
            this.rbExam.Location = new System.Drawing.Point(15, 20);
            this.rbExam.Name = "rbExam";
            this.rbExam.Size = new System.Drawing.Size(47, 16);
            this.rbExam.TabIndex = 6;
            this.rbExam.TabStop = true;
            this.rbExam.Text = "试题";
            this.rbExam.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIsBatch);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 145);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "试题/分类内容";
            // 
            // cbIsBatch
            // 
            this.cbIsBatch.AutoSize = true;
            this.cbIsBatch.Location = new System.Drawing.Point(15, 20);
            this.cbIsBatch.Name = "cbIsBatch";
            this.cbIsBatch.Size = new System.Drawing.Size(72, 16);
            this.cbIsBatch.TabIndex = 8;
            this.cbIsBatch.Text = "批量添加";
            this.cbIsBatch.UseVisualStyleBackColor = true;
            this.cbIsBatch.CheckedChanged += new System.EventHandler(this.cbIsBatch_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(34, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 21);
            this.txtName.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(107, 268);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(188, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 305);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Name = "AddNode";
            this.Text = "AddNode";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbExam;
        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox cbIsBatch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbRand;
    }
}