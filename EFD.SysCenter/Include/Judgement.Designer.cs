namespace EFD.SysCenter.Include
{
    partial class Judgement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddAnalysis = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.txtAnalysis = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.dgList = new EFD.SysCenter.DataGridAdvanced(this.components);
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.drpMainSubject = new EFD.SysCenter.drpMainSubject(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.btnAddKey = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Location = new System.Drawing.Point(304, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2, 543);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // btnAddAnalysis
            // 
            this.btnAddAnalysis.Location = new System.Drawing.Point(229, 530);
            this.btnAddAnalysis.Name = "btnAddAnalysis";
            this.btnAddAnalysis.Size = new System.Drawing.Size(52, 23);
            this.btnAddAnalysis.TabIndex = 29;
            this.btnAddAnalysis.Text = "更新";
            this.btnAddAnalysis.UseVisualStyleBackColor = true;
            this.btnAddAnalysis.Click += new System.EventHandler(this.ButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "试题分析";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "主要内容";
            // 
            // txtSubject
            // 
            this.txtSubject.AllowDrop = true;
            this.txtSubject.Location = new System.Drawing.Point(19, 51);
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSubject.Size = new System.Drawing.Size(263, 122);
            this.txtSubject.TabIndex = 33;
            // 
            // txtAnalysis
            // 
            this.txtAnalysis.AllowDrop = true;
            this.txtAnalysis.Location = new System.Drawing.Point(19, 400);
            this.txtAnalysis.Multiline = true;
            this.txtAnalysis.Name = "txtAnalysis";
            this.txtAnalysis.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAnalysis.Size = new System.Drawing.Size(262, 124);
            this.txtAnalysis.TabIndex = 34;
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgList.ExamQuery = null;
            this.dgList.Location = new System.Drawing.Point(314, 51);
            this.dgList.Name = "dgList";
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(429, 473);
            this.dgList.TabIndex = 35;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(230, 179);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(52, 23);
            this.btnAddSubject.TabIndex = 29;
            this.btnAddSubject.Text = "添加";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.ButtonClick);
            // 
            // drpMainSubject
            // 
            this.drpMainSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drpMainSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpMainSubject.FormattingEnabled = true;
            this.drpMainSubject.Location = new System.Drawing.Point(622, 24);
            this.drpMainSubject.Name = "drpMainSubject";
            this.drpMainSubject.Size = new System.Drawing.Size(121, 20);
            this.drpMainSubject.TabIndex = 42;
            this.drpMainSubject.SelectedIndexChanged += new System.EventHandler(this.drpMainSubject_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(668, 530);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(587, 530);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 44;
            this.btnUpdate.Text = "更新所有";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.ButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "答案";
            // 
            // txtKey
            // 
            this.txtKey.AllowDrop = true;
            this.txtKey.Location = new System.Drawing.Point(18, 228);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtKey.Size = new System.Drawing.Size(263, 122);
            this.txtKey.TabIndex = 33;
            // 
            // btnAddKey
            // 
            this.btnAddKey.Location = new System.Drawing.Point(229, 356);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(52, 23);
            this.btnAddKey.TabIndex = 29;
            this.btnAddKey.Text = "添加";
            this.btnAddKey.UseVisualStyleBackColor = true;
            this.btnAddKey.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Judgement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.drpMainSubject);
            this.Controls.Add(this.dgList);
            this.Controls.Add(this.txtAnalysis);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddKey);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.btnAddAnalysis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "Judgement";
            this.Size = new System.Drawing.Size(762, 595);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddAnalysis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private TextboxAdvanced txtSubject;
        private TextboxAdvanced txtAnalysis;
        private DataGridAdvanced dgList;
        private System.Windows.Forms.Button btnAddSubject;
        private drpMainSubject drpMainSubject;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private TextboxAdvanced txtKey;
        private System.Windows.Forms.Button btnAddKey;
    }
}
