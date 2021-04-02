using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Model;
using System.Drawing;

namespace EFD.SysCenter
{
    public partial class SysTreeNode : TreeView
    {

        private readonly ImageList imglistExam = new ImageList();
        private readonly ImageList imglistOutline = new ImageList();
        private readonly ImageList imglistFile = new ImageList();

        private List<OutlineInfo> outlineList = null;
        private List<ExamInfo> examInfoList = null;
        private SysTreeNodeType sysTreeNodeType = SysTreeNodeType.ExamInfo;

        public SysTreeNode()
        {
            InitializeComponent(); 
        }
        public void InitalizeImageList()
        {   imglistExam.Images.Add(Image.FromFile("Treeview/folders.gif"));
            imglistExam.Images.Add(Image.FromFile("Treeview/doc.gif"));
            imglistExam.Images.Add(Image.FromFile("Treeview/doc.gif"));
            
            imglistOutline.Images.Add(Image.FromFile("Treeview/doc.gif"));
            imglistOutline.Images.Add(Image.FromFile("Treeview/doc.gif"));
            imglistOutline.Images.Add(Image.FromFile("Treeview/doc.gif"));
        }

        public enum SysTreeNodeType : int
        {
            ExamInfo = 1,
            Outline = 2
        }


        /// <summary>
        /// 用户examinfoid 或者 outlineid
        /// </summary>
        public int SelectedNodeID
        {
            get { return SelectedNode == null ? -1 : Convert.ToInt32(SelectedNode.Name); }
        }

        #region 数据缓存,以及私有函数

        // 根据pid获取试卷数据缓存
        private List<ExamInfo> GetExamListByPid(int currentPid)
        {
            if (examInfoList == null)
                return null;

            List<ExamInfo> temp = new List<ExamInfo>();

            foreach (ExamInfo ei in examInfoList)
                if (ei.PID == currentPid)
                    temp.Add(ei);

            return temp;
        }

        // 根据pid获取资料数据缓存       
        private List<OutlineInfo> GetOutlineListByPid(int currentPid)
        {
            if (outlineList == null)
                return null;

            List<OutlineInfo> temp = new List<OutlineInfo>();

            foreach (OutlineInfo oi in outlineList)
            {
                if (oi.PID == currentPid)
                    temp.Add(oi);
            }

            return temp;
        }


        private void BindExamInfo(int parentId, TreeNode parentNode)
        {
            List<ExamInfo> examList = GetExamListByPid(parentId);

            if (examList == null)
                return;

            foreach (ExamInfo ei in examList)
            {
                TreeNode myNode = new TreeNode(ei.ID.ToString());
                //   myNode.ContextMenuStrip = menuExam;
                myNode.Name = ei.ID.ToString();
                myNode.Text = ei.Name.Trim();
                myNode.Tag = ei.IsMaterial;
                if (ei.IsMaterial)
                {
                    myNode.ImageIndex = 1;
                }
                else
                {
                    myNode.ImageIndex = 0;
                    myNode.SelectedImageIndex = 0;
                }


                parentNode.Nodes.Add(myNode);

                BindExamInfo(ei.ID, myNode);

            }
        }
        private void BindOutlineInfo(int parentId, TreeNode parentNode)
        {
            List<OutlineInfo> outlineList = GetOutlineListByPid(parentId);

            if (outlineList == null)
                return;

            foreach (OutlineInfo oi in outlineList)
            {
                TreeNode myNode = new TreeNode(oi.ID.ToString());
                //   myNode.ContextMenuStrip = menuOutline;
                myNode.Name = oi.ID.ToString();
                myNode.Text = oi.Title;

                parentNode.Nodes.Add(myNode);
                BindOutlineInfo(oi.ID, myNode);
            }
        }
        #endregion

        /// <summary>
        /// 绑定考试题目
        /// </summary>
        public void BindExamInfoList()
        {
            InitalizeImageList();
            sysTreeNodeType = SysTreeNodeType.ExamInfo;
            ImageList = imglistExam;
            Nodes.Clear();
            examInfoList = Exam.ExamSys.GetListArray(" 100 = 100 ORDER BY [ID] ASC ");

            TreeNode rootNode = new TreeNode(Exam.SelectedFileName);

            rootNode.Name = "-1";
            rootNode.SelectedImageIndex = 0;
            BindExamInfo(0, rootNode);

            Nodes.Add(rootNode);
            SelectedImageIndex = 2;
            try
            {
                if (this.Nodes[0] != null)
                {
                    this.Nodes[0].Expand();

                    if (this.Nodes[0].Nodes[0] != null)
                    {
                        this.Nodes[0].Nodes[0].Expand();
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 绑定资料
        /// </summary>
        public void BindOutlineList()
        {
            if (Exam.Outline == null)
                return;

            InitalizeImageList();
            sysTreeNodeType = SysTreeNodeType.Outline;
            Nodes.Clear();
            ImageList = imglistOutline;
            outlineList = Exam.Outline.GetListArray(string.Empty);

            TreeNode rootNode = new TreeNode("文档");
            rootNode.Name = "-1";
            BindOutlineInfo(0, rootNode);
            this.Nodes.Add(rootNode);

            if (this.Nodes[0] != null)
                this.Nodes[0].Expand();
        }


        /// <summary>
        /// 右击树节点并选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeFileView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedNode = e.Node;
            }
        }

        private void SysTreeNode_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label))
                return;
            //如果是试卷操作
            if (sysTreeNodeType == SysTreeNodeType.ExamInfo)
                Exam.Access.ExecuteNonQuery(String.Format("UPDATE ExamInfo SET [name] = '{0}' WHERE ID= {1} ", e.Label, e.Node.Name));
            else if (sysTreeNodeType == SysTreeNodeType.Outline)
                Exam.Access.ExecuteNonQuery(String.Format("UPDATE Outline SET [Title] = '{0}' WHERE ID= {1} ", e.Label, e.Node.Name));
        }

        private void Delete()
        {
            if (sysTreeNodeType == SysTreeNodeType.ExamInfo)
            {

                if (MessageBox.Show("确定吗(这将会删除该试卷下所有试题？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (Exam.ExamSys.Delete(SelectedNodeID) == -100)
                    {
                        MessageBox.Show("请删除该类下所有试卷");
                        return;
                    }
                    SelectedNode.Remove();
                }
            }
            else
            {
                  if (MessageBox.Show("确定吗(这将会删除该大纲资料下所有？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    Exam.Outline.Delete(SelectedNodeID);
                    
                    SelectedNode.Remove();
                }
            }
        }
        private void SysTreeNode_KeyUp(object sender, KeyEventArgs e)
        {
            if (SelectedNode == null)
                return;

            if (e.KeyData == Keys.F2)
                SelectedNode.BeginEdit();
            else if (e.KeyData == Keys.Delete)
                Delete();

        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsmAdd":

                    if (sysTreeNodeType == SysTreeNodeType.ExamInfo)
                    {
                        if (DialogResult.OK == Decorator.ShowDialog(new AddNode(SelectedNodeID)))
                        {
                            BindExamInfoList();
                            ExpandAll();
                        }
                    }
                    
                    return;
                case "tsmDelete":
                    Delete();
                    return;
            }
        }

    }
}
