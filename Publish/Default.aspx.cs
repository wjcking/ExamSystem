using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Model;
using DataUtility;
using System.Text;

namespace Publish
{
    public partial class _Default : PageBase
    {
        private ExamSys examsys = EasyConfig.DataSys;

        protected void Page_Load(object sender, EventArgs e)
        { 

            if (!IsPostBack)
            {
                GetDatabaseList();

                try
                {
                    InitlializeMaterials();
                }
                catch (Exception exp)
                {
                    litInfo.Text = exp.Message;
                }
            }

        }
     


        private void InitlializeMaterials()
        {
            treeFileView.Nodes.Clear();

            TreeNode rootNode = new TreeNode(EasyConfig.DBName);
            rootNode.Value = "0";

            AddExamInfo(0, rootNode);
            treeFileView.Nodes.Add(rootNode);
        }

        private List<ExamInfo> examlist(int currentpid)
        {
            List<ExamInfo> temp = new List<ExamInfo>();

            List<ExamInfo> examInfoList = examsys.GetListArray(string.Empty);

            foreach (ExamInfo ei in examInfoList)
                if (ei.PID == currentpid)
                    temp.Add(ei);

            return temp;
        }

        /// <summary>
        /// 绑定数据库
        /// </summary>
        private void GetDatabaseList()
        {
            drpDatabase.Items.Clear();
            drpDatabase.Items.Add(new ListItem("请选择试题数据库", ""));
            string[] databaseName = Directory.GetFiles(EasyConfig.PathAppData, "*.mdb");

            foreach (string db in databaseName)
            {
                drpDatabase.Items.Add(new ListItem(Path.GetFileName(db), db));
            }
        }
        private void AddExamInfo(int parentId, TreeNode parentNode)
        {
            List<ExamInfo> examList = examlist(parentId);

            foreach (ExamInfo drv in examList)
            {
                TreeNode myNode = new TreeNode();
                myNode.Text = drv.Name.Trim();
                myNode.Value = drv.ID.ToString();

                parentNode.ChildNodes.Add(myNode);
                AddExamInfo(drv.ID, myNode);
            }
        }
        /// <summary>
        /// iframe操作
        /// </summary>
        protected void treeFileView_SelectedNodeChanged(object sender, EventArgs e)
        {
            frame.Attributes.Add("src", "FormInside.aspx?ExamInfoID=" + treeFileView.SelectedValue);
        }

        protected void btnAddPaper_Click(object sender, EventArgs e)
        {

            if (txtPaperName.Text == string.Empty)
                return;

            ExamInfo ei = new ExamInfo();
            ei.Name = txtPaperName.Text;
            ei.PID = int.Parse(treeFileView.SelectedValue);
            ei.CanRandom = true;
            ei.IsMaterial = true;
            examsys.Add(ei);
            InitlializeMaterials();
            treeFileView.Nodes[0].Expand();
        }

        protected void btnSelectDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(drpDatabase.SelectedValue))
                return;

            EasyConfig.SetConfiguration("DBName", drpDatabase.SelectedItem.Text);
            EasyConfig.SetConnectionString("EFD", drpDatabase.SelectedItem.Text);

            Response.Redirect(Request.Url.ToString());

            //EasyConfig.SetAppConfig("DbName", drpDatabase.SelectedItem.Text);
        }

        protected void btnNewDB_Click(object sender, EventArgs e)
        {
            string newdb = Request.Form["txtNewDB"] + ".mdb";

            if (newdb == ".mdb")
                return;


            if (File.Exists(EasyConfig.PathAppData + newdb))
            {
                litInfo.Text = newdb + "已经存在，请重新命名。";
                return;
            }

            File.Copy(EasyConfig.PathDB, EasyConfig.PathAppData + newdb, false);
            GetDatabaseList();
        }
    }
}