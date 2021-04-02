namespace EFD.SysCenter.Include
{
    partial class Media
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
            this.drpMainSubject = new EFD.SysCenter.drpMainSubject(this.components);
            this.dgList = new EFD.SysCenter.DataGridAdvanced(this.components);
            this.ctxtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtSImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtAImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cimgSImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.cimgAImage = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // drpMainSubject
            // 
            this.drpMainSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drpMainSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpMainSubject.FormattingEnabled = true;
            this.drpMainSubject.Location = new System.Drawing.Point(466, 14);
            this.drpMainSubject.Name = "drpMainSubject";
            this.drpMainSubject.Size = new System.Drawing.Size(146, 20);
            this.drpMainSubject.TabIndex = 0;
            this.drpMainSubject.SelectedIndexChanged += new System.EventHandler(this.drpMainSubject_SelectedIndexChanged);
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtID,
            this.ctxtSImage,
            this.ctxtAImage,
            this.ctxtSubject,
            this.ctxtKey,
            this.cimgSImage,
            this.cimgAImage});
            this.dgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgList.ExamQuery = null;
            this.dgList.Location = new System.Drawing.Point(22, 55);
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersWidth = 35;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(590, 290);
            this.dgList.TabIndex = 1;
            this.dgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellContentClick);
            this.dgList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgList_CellMouseUp);
            // 
            // ctxtID
            // 
            this.ctxtID.DataPropertyName = "ID";
            this.ctxtID.HeaderText = "ID";
            this.ctxtID.Name = "ctxtID";
            this.ctxtID.Visible = false;
            // 
            // ctxtSImage
            // 
            this.ctxtSImage.DataPropertyName = "SImage";
            this.ctxtSImage.HeaderText = "SImage";
            this.ctxtSImage.Name = "ctxtSImage";
            this.ctxtSImage.Visible = false;
            // 
            // ctxtAImage
            // 
            this.ctxtAImage.DataPropertyName = "AImage";
            this.ctxtAImage.HeaderText = "AImage";
            this.ctxtAImage.Name = "ctxtAImage";
            this.ctxtAImage.Visible = false;
            // 
            // ctxtSubject
            // 
            this.ctxtSubject.DataPropertyName = "Subject";
            this.ctxtSubject.HeaderText = "主题";
            this.ctxtSubject.Name = "ctxtSubject";
            this.ctxtSubject.Width = 200;
            // 
            // ctxtKey
            // 
            this.ctxtKey.DataPropertyName = "Key";
            this.ctxtKey.HeaderText = "答案";
            this.ctxtKey.Name = "ctxtKey";
            // 
            // cimgSImage
            // 
            this.cimgSImage.HeaderText = "主题图片";
            this.cimgSImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cimgSImage.Name = "cimgSImage";
            // 
            // cimgAImage
            // 
            this.cimgAImage.HeaderText = "答案图片";
            this.cimgAImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cimgAImage.Name = "cimgAImage";
            this.cimgAImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Media
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgList);
            this.Controls.Add(this.drpMainSubject);
            this.Name = "Media";
            this.Size = new System.Drawing.Size(636, 418);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private drpMainSubject drpMainSubject;
        private DataGridAdvanced dgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtSImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtAImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtKey;
        private System.Windows.Forms.DataGridViewImageColumn cimgSImage;
        private System.Windows.Forms.DataGridViewImageColumn cimgAImage;
    }
}
