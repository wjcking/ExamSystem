using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Model;

namespace ExamSys.Util
{
    public class PopulateNode
    {
        private TreeView treeView;
        private readonly ImageList imglistExam = new ImageList();
        private readonly ImageList imglistOutline = new ImageList();
        private readonly ImageList imglistFile = new ImageList();
        private NodeListType nodeType = NodeListType.ExamInfo;

        public PopulateNode(TreeView treeView)
        {
            this.treeView = treeView;

            imglistExam.Images.Add(Image.FromFile("images/folders.gif"));
            imglistExam.Images.Add(Image.FromFile("images/doc.gif"));
            imglistExam.Images.Add(Image.FromFile("images/selecteddoc.gif"));

            imglistFile.Images.Add(Image.FromFile("images/folders.gif"));
            imglistFile.Images.Add(Image.FromFile("images/doc.gif"));
            imglistFile.Images.Add(Image.FromFile("images/selectedout.gif"));

            imglistOutline.Images.Add(Image.FromFile("images/doc.gif"));
            imglistOutline.Images.Add(Image.FromFile("images/selecteddoc.gif"));
            imglistOutline.Images.Add(Image.FromFile("images/doc.gif"));

            this.treeView.ShowLines = false;
        }

        public enum NodeListType : int
        {
            ExamInfo = 1,
            Outline = 2,
            MyFile = 3,
            Memo = 4
        }

        public NodeListType CurrentNodeType
        {
            get
            {
                return nodeType;
            }
        }


        /// <summary>
        /// 绑定目录包括文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="searchText">关键字</param>
        /// <param name="tn"></param>
        private void BindDirectories(string path, string searchText, TreeNode tn)
        {
            if (!Directory.Exists(path))
                return;

            string[] fileNames = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);

            Application.DoEvents();

            foreach (string dir in directories)
            {
                TreeNode subtn = new TreeNode();

                subtn.ImageIndex = 0;
                subtn.Name = dir;
                subtn.Text = Path.GetFileName(dir);
                BindDirectories(dir, searchText, subtn);
                tn.Nodes.Add(subtn);
            }

            foreach (string file in fileNames)
            {
                TreeNode subtn = new TreeNode();
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                string fileName = Path.GetFileName(file);
                subtn.ImageIndex = 1;

                subtn.SelectedImageIndex = 2;
                if (string.IsNullOrEmpty(searchText))
                {
                    subtn.Name = file;
                    subtn.Text = fileName;
                    subtn.ToolTipText = fileName;
                    tn.Nodes.Add(subtn);
                    continue;
                }

                if (fileName.ToLower().IndexOf(searchText.ToLower()) > -1)
                {
                    subtn.Name = file;
                    subtn.Text = fileName;
                    subtn.ToolTipText = fileName;
                    tn.Nodes.Add(subtn);
                }
            }
        }
 

        private void BindExamInfo(int parentId, TreeNode parentNode)
        {
            List<ExamInfo> examList = SysData.GetExamListByPid(parentId);

            foreach (ExamInfo ei in examList)
            {
                TreeNode myNode = new TreeNode(ei.ID.ToString());
                myNode.Name = ei.ID.ToString();
                myNode.Text = ei.Name.Trim();

                if (ei.IsMaterial)
                {
                    
                    myNode.ImageIndex = 1;
                }
                else
                {
                    myNode.ImageIndex = 1;
                    myNode.SelectedImageIndex = 0;
                }

             
                    parentNode.Nodes.Add(myNode);

                BindExamInfo(ei.ID, myNode);

            }
        }

        /// <summary>
        /// 绑定文件
        /// </summary>
        /// <param name="searchText">文件名搜索</param>
        public void BindFileList(string searchText)
        {
            treeView.ImageList = imglistFile;
            nodeType = NodeListType.MyFile;
            treeView.Nodes.Clear();

            TreeNode tn = new TreeNode();

            tn.ImageIndex = 0;

            tn.Text = "我的资料";
            tn.Name = SysConfig.SettingsHelper.GetValue(Options.FileFolder.LibraryPath);

            if (string.IsNullOrEmpty(tn.Name) || !Directory.Exists(tn.Name))
            {
                string myfile = AppDomain.CurrentDomain.BaseDirectory + "MyFile";

                if (!Directory.Exists(myfile))
                    Directory.CreateDirectory(myfile);

                SysConfig.SettingsHelper.SetValue(Options.FileFolder.LibraryPath, myfile);
                tn.Name = myfile;
            }

            tn.ToolTipText = tn.Name;
            try
            {
                BindDirectories(tn.Name, searchText, tn);
            }
            catch (Exception e)
            {
                tn.Text = e.Message;
            }

            treeView.Nodes.Add(tn);
            treeView.SelectedImageIndex = 2;

            if (treeView.Nodes[0] != null)
                treeView.Nodes[0].Expand();

        }

        /// <summary>
        /// 绑定考试题目
        /// </summary>
        public void BindExamInfoList()
        {
            treeView.ImageList = imglistExam;
            nodeType = NodeListType.ExamInfo;
            treeView.Nodes.Clear();


            TreeNode rootNode = new TreeNode(Valid.AccessRegisterInfo.ProductName);

            rootNode.Name = "-1";
            rootNode.SelectedImageIndex = 0;
            BindExamInfo(0, rootNode);

            treeView.Nodes.Add(rootNode);
            treeView.SelectedImageIndex = 2;

            try
            {
                if (treeView.Nodes[0] != null)
                {
                    treeView.Nodes[0].Expand();

                    if (treeView.Nodes[0].Nodes[0] != null)
                    {
                        treeView.Nodes[0].Nodes[0].Expand();
                    }
                }
            }
            catch
            {

            }


        }

        private void BindOutlineInfo(int parentId, TreeNode parentNode)
        {
            List<OutlineInfo> outlineList = SysData.GetOutlineListByPid(parentId);

            foreach (OutlineInfo oi in outlineList)
            {
                TreeNode myNode = new TreeNode(oi.ID.ToString());

                myNode.Name = oi.ID.ToString();
                myNode.Text = oi.Title;
 

                parentNode.Nodes.Add(myNode);
                BindOutlineInfo(oi.ID, myNode);
            }
        }

        /// <summary>
        /// 绑定资料
        /// </summary>
        public void BindOutlineList()
        {
            treeView.Nodes.Clear();
            nodeType = NodeListType.Outline;
            treeView.ImageList = imglistOutline;

            TreeNode rootNode = new TreeNode("文档");
            rootNode.Name = "-1";
            BindOutlineInfo(0, rootNode);
            treeView.Nodes.Add(rootNode);

            if (treeView.Nodes[0] != null)
                treeView.Nodes[0].Expand();

        }

        public void DataBind(NodeListType nodeListType)
        {
            switch (nodeListType)
            {
                case NodeListType.ExamInfo:
                    BindExamInfoList();
                    return;

                case NodeListType.MyFile:
                    BindFileList(string.Empty);
                    return;

                case NodeListType.Outline:
                    BindOutlineList();
                    return;

                default:
                    return;
            }
        }
    }
}
