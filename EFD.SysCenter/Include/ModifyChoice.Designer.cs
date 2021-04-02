namespace EFD.SysCenter.Include
{
    partial class ModifyChoice
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
            this.dgList = new EFD.SysCenter.DataGridAdvanced(this.components);
            this.txtAnalysis = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.txtKey = new EFD.SysCenter.TextboxAdvanced(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateAnalysis = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateKeys = new System.Windows.Forms.Button();
            this.drpMainSubject = new EFD.SysCenter.drpMainSubject(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateAll = new System.Windows.Forms.Button();
            this.btnOrganizChoice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
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
            this.dgList.Location = new System.Drawing.Point(285, 68);
            this.dgList.Name = "dgList";
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(464, 481);
            this.dgList.TabIndex = 0;
            // 
            // txtAnalysis
            // 
            this.txtAnalysis.AllowDrop = true;
            this.txtAnalysis.Location = new System.Drawing.Point(14, 243);
            this.txtAnalysis.Multiline = true;
            this.txtAnalysis.Name = "txtAnalysis";
            this.txtAnalysis.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAnalysis.Size = new System.Drawing.Size(244, 122);
            this.txtAnalysis.TabIndex = 40;
            // 
            // txtKey
            // 
            this.txtKey.AllowDrop = true;
            this.txtKey.Location = new System.Drawing.Point(13, 68);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtKey.Size = new System.Drawing.Size(245, 122);
            this.txtKey.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Location = new System.Drawing.Point(277, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2, 543);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // btnUpdateAnalysis
            // 
            this.btnUpdateAnalysis.Location = new System.Drawing.Point(213, 371);
            this.btnUpdateAnalysis.Name = "btnUpdateAnalysis";
            this.btnUpdateAnalysis.Size = new System.Drawing.Size(45, 23);
            this.btnUpdateAnalysis.TabIndex = 37;
            this.btnUpdateAnalysis.Text = "更新";
            this.btnUpdateAnalysis.UseVisualStyleBackColor = true;
            this.btnUpdateAnalysis.Click += new System.EventHandler(this.btnUpdateAnalysis_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "试题分析";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "批量答案更新";
            // 
            // btnUpdateKeys
            // 
            this.btnUpdateKeys.Location = new System.Drawing.Point(213, 196);
            this.btnUpdateKeys.Name = "btnUpdateKeys";
            this.btnUpdateKeys.Size = new System.Drawing.Size(45, 23);
            this.btnUpdateKeys.TabIndex = 37;
            this.btnUpdateKeys.Text = "更新";
            this.btnUpdateKeys.UseVisualStyleBackColor = true;
            this.btnUpdateKeys.Click += new System.EventHandler(this.btnUpdateKeys_Click);
            // 
            // drpMainSubject
            // 
            this.drpMainSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drpMainSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpMainSubject.FormattingEnabled = true;
            this.drpMainSubject.Location = new System.Drawing.Point(628, 36);
            this.drpMainSubject.Name = "drpMainSubject";
            this.drpMainSubject.Size = new System.Drawing.Size(121, 20);
            this.drpMainSubject.TabIndex = 41;
            this.drpMainSubject.SelectedIndexChanged += new System.EventHandler(this.drpMainSubject_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(674, 555);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 42;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateAll.Location = new System.Drawing.Point(593, 555);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateAll.TabIndex = 45;
            this.btnUpdateAll.Text = "更新所有";
            this.btnUpdateAll.UseVisualStyleBackColor = true;
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // btnOrganizChoice
            // 
            this.btnOrganizChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrganizChoice.Location = new System.Drawing.Point(525, 555);
            this.btnOrganizChoice.Name = "btnOrganizChoice";
            this.btnOrganizChoice.Size = new System.Drawing.Size(62, 23);
            this.btnOrganizChoice.TabIndex = 46;
            this.btnOrganizChoice.Text = "整理选项";
            this.btnOrganizChoice.UseVisualStyleBackColor = true;
            this.btnOrganizChoice.Click += new System.EventHandler(this.btnOrganizChoice_Click);
            // 
            // ModifyChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOrganizChoice);
            this.Controls.Add(this.btnUpdateAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.drpMainSubject);
            this.Controls.Add(this.txtAnalysis);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdateKeys);
            this.Controls.Add(this.btnUpdateAnalysis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgList);
            this.Name = "ModifyChoice";
            this.Size = new System.Drawing.Size(762, 595);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridAdvanced dgList;
        private TextboxAdvanced txtAnalysis;
        private TextboxAdvanced txtKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateAnalysis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateKeys;
        private drpMainSubject drpMainSubject;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateAll;
        private System.Windows.Forms.Button btnOrganizChoice;
    }
}
