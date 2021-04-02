namespace EFD.SysCenter
{
    partial class MaterialWnd
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddBatch = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbIsHtml = new System.Windows.Forms.CheckBox();
            this.listFiles = new EFD.SysCenter.ListFile(this.components);
            this.treeMaterial = new EFD.SysCenter.SysTreeNode();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(705, 378);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(55, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(479, 378);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBatch.Location = new System.Drawing.Point(632, 379);
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Size = new System.Drawing.Size(67, 22);
            this.btnAddBatch.TabIndex = 6;
            this.btnAddBatch.Text = "批量添加";
            this.btnAddBatch.UseVisualStyleBackColor = true;
            this.btnAddBatch.Click += new System.EventHandler(this.Btn_Click);
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(213, 21);
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtContent.Size = new System.Drawing.Size(321, 352);
            this.txtContent.TabIndex = 7;
            this.txtContent.Text = "";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(417, 378);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(56, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.Btn_Click);
            // 
            // cbIsHtml
            // 
            this.cbIsHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIsHtml.AutoSize = true;
            this.cbIsHtml.Location = new System.Drawing.Point(339, 383);
            this.cbIsHtml.Name = "cbIsHtml";
            this.cbIsHtml.Size = new System.Drawing.Size(72, 16);
            this.cbIsHtml.TabIndex = 9;
            this.cbIsHtml.Text = "html格式";
            this.cbIsHtml.UseVisualStyleBackColor = true;
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listFiles.Content = null;
            this.listFiles.FileInfo = null;
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 12;
            this.listFiles.Location = new System.Drawing.Point(540, 21);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(220, 352);
            this.listFiles.TabIndex = 1;
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
            // 
            // treeMaterial
            // 
            this.treeMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeMaterial.LabelEdit = true;
            this.treeMaterial.Location = new System.Drawing.Point(12, 21);
            this.treeMaterial.Name = "treeMaterial";
            this.treeMaterial.Size = new System.Drawing.Size(195, 357);
            this.treeMaterial.TabIndex = 0;
            this.treeMaterial.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMaterial_AfterSelect);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(213, 378);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(120, 21);
            this.txtTitle.TabIndex = 10;
            // 
            // MaterialWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 415);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cbIsHtml);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnAddBatch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.treeMaterial);
            this.Name = "MaterialWnd";
            this.Text = "MaterialWnd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SysTreeNode treeMaterial;
        private ListFile listFiles;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddBatch;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox cbIsHtml;
        private System.Windows.Forms.TextBox txtTitle;
    }
}