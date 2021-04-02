using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Model;

namespace EFD.SysCenter
{
    public partial class MaterialWnd : Form
    {
        public MaterialWnd()
        {
            InitializeComponent();
            treeMaterial.BindOutlineList();

        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnOpen":
                    using (FolderBrowserDialog ofd = new FolderBrowserDialog())
                    {
                        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            listFiles.BindFiles(ofd.SelectedPath);
                        }
                    }
                    return;
                case "btnAdd":
                    if (treeMaterial.SelectedNode == null)
                        return;

                    TreeNode tn = new TreeNode();
                    tn.Text = txtTitle.Text;

                    OutlineInfo materialInfo = new OutlineInfo();
                    materialInfo.Title = tn.Text;
                    materialInfo.PID = treeMaterial.SelectedNodeID;
                    materialInfo.Content = txtContent.Text.Replace("\n","\r\n");

                    if (listFiles.FileInfo != null)
                    {
                        if (listFiles.FileInfo.Extension.ToLower() == ".htm" || listFiles.FileInfo.Extension.ToLower() == ".html")
                            materialInfo.ContentType = 1;
                        else
                            materialInfo.ContentType = 0;
                    }
                    else
                    {
                        materialInfo.ContentType = cbIsHtml.Checked?1:0;
                    }

                    Exam.Outline.Add(materialInfo);
                    treeMaterial.SelectedNode.Nodes.Add(tn.Text);

                    return;
                case "btnAddBatch":
                    if (treeMaterial.SelectedNode == null)
                        return;
                    //for (int i = 0; i < listFiles.Items.Count; i++)
                    //{
                    //    TreeNode treeNode = new TreeNode();
                    //    treeNode.Text = Path.GetFileNameWithoutExtension(listFiles.Text);
                    //    outlineInfo.Title = treeNode.Text;
                    //    outlineInfo.PID = treeMaterial.SelectedNodeID;
                    //    FileInfo fi = listFiles.SelectedItem as FileInfo;
                    //    outlineInfo.Content = txtContent.Text.Replace("\n","\r\n");
                    //    treeMaterial.SelectedNode.Nodes.Add(treeNode.Text);
                    //}

                    return;
                case "btnUpdate":

                    if (treeMaterial.SelectedNode == null)
                        return;

                    OutlineInfo outInfo = new OutlineInfo();
                    outInfo.ID = treeMaterial.SelectedNodeID;
                    outInfo.Content =txtContent.Text.Replace("\n","\r\n");

                    outInfo.ContentType = cbIsHtml.Checked ? 1 : 0;

                    Exam.Outline.Update(outInfo);
                    return;
            }
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTitle.Text = Path.GetFileNameWithoutExtension(listFiles.Text);
            txtContent.Text = listFiles.Content;
        }

        private void treeMaterial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OutlineInfo oi = Exam.Outline.GetModel(treeMaterial.SelectedNodeID);
            txtContent.Text = oi.Content;
        }




    }
}
