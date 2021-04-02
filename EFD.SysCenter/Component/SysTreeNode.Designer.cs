using System.Windows.Forms;
namespace EFD.SysCenter
{
    partial class SysTreeNode
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



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(119, 48);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(118, 22);
            this.tsmAdd.Text = "添加(&N)";
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(118, 22);
            this.tsmDelete.Text = "删除(&D)";
            // 
            // SysTreeNode
            // 
            this.ContextMenuStrip = this.contextMenu;
            this.LabelEdit = true;
            this.LineColor = System.Drawing.Color.Black;
            this.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.SysTreeNode_AfterLabelEdit);
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFileView_NodeMouseClick);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SysTreeNode_KeyUp);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem tsmDelete;
        private ToolStripMenuItem tsmAdd;
    }
}
