using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Model;
using DataUtility;
using ExamSys.Util;

namespace ExamSys
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class Material : Form
    {

        private Outline outline = new Outline();
        private static List<OutlineInfo> userOutlinelist;
        private static readonly string editOutlineType = SysConfig.SettingsHelper.GetSettingsElement(Settings.EditOutlineType).Trim();
        private static readonly string editOutlineRuler = System.Configuration.ConfigurationManager.AppSettings["EditOutlineRuler"];
        public static bool isInitialized = false;
        public static Material formMaterial = new Material();

        public Material()
        {
            InitializeComponent();
            init();
        }
        public static void InitMaterial()
        {
            InitMaterial(string.Empty);
        }


        public static void InitMaterial(string keyword)
        {
            if (!isInitialized)
            {
                formMaterial.Show();
                isInitialized = true;
            }
            else
            {

                formMaterial.Activate();
            }

            if (!string.IsNullOrEmpty(keyword))
                formMaterial.GetSearchedKeywords(keyword);
            else
            {
                formMaterial.tabControl1.SelectedTab = formMaterial.tabEdit;
            }

        }
        public void GetSearchedKeywords(string keyword)
        {
            tabControl1.SelectedTab = tabWeb;
            string id = SysConfig.SettingsHelper.GetSettingsElement(Settings.OutlineIndex);
            string material = Browser.ReadOutline(id, keyword);
            webBrowser.DocumentText = material;
        }

        private void init()
        {
            panelTop.BackColor = SysConfig.CategoryColor;

            if (editOutlineType == "")
                userOutlinelist = SysConfig.DataOutlineUtility.GetListArray(string.Empty);
            else
                userOutlinelist = SysConfig.DataOutlineUtility.GetListArray("[type] = " + editOutlineType);

            GetOutlineList();
            webBrowser.ObjectForScripting = this;
            string[] encoding = System.Configuration.ConfigurationManager.AppSettings["Encoding"].Split(',');

            cbxEncoding.Items.Add("默认编码");

            foreach (string en in encoding)
                cbxEncoding.Items.Add(en);

            cbxEncoding.SelectedIndex = 0;

            treeView.ExpandAll();
            btnOk.DialogResult = DialogResult.OK;
            btnQuit.DialogResult = DialogResult.Cancel;
            openFile.Filter = "文本文档|*.txt|htm文档|*.htm|html文档|*.html|所有文件|*.*";

            if (editOutlineRuler != SysConfig.WJCKING)
                chkOutlineType.Visible = false;
            //     txtMaterial.Font = new Font(Settings.helper.GetSettingsElement(Settings.OutlineFontFamily), Settings.helper.GetSettingsElement(Settings.OutlineFontSize));
        }

        
        List<OutlineInfo> OutlineList(int currentpid)
        {
            List<OutlineInfo> temp = new List<OutlineInfo>();

            foreach (OutlineInfo oi in userOutlinelist)
                if (oi.PID == currentpid)
                    temp.Add(oi);

            return temp;
        }

        private void AddOutlineInfo(int parentId, TreeNode parentNode)
        {
            List<OutlineInfo> outlineList = OutlineList(parentId);

            foreach (OutlineInfo oi in outlineList)
            {
                TreeNode myNode = new TreeNode(oi.ID.ToString());
                //myNode.Expanded = false;
                myNode.Name = oi.ID.ToString();
                myNode.Text = oi.Title;
                //if (oi.ID > 2)
                //    myNode.ContextMenuStrip = contextMenu;
                if (oi.Type == 0)
                    myNode.ForeColor = SysConfig.CategoryColor;

                parentNode.Nodes.Add(myNode);
                AddOutlineInfo(oi.ID, myNode);
            }
        }

        public void GetOutlineList()
        {
            treeView.Nodes.Clear();

            TreeNode rootNode = new TreeNode("编辑我的文档库");
            rootNode.Name = "-1";
            AddOutlineInfo(0, rootNode);
            treeView.Nodes.Add(rootNode);

            if (treeView.Nodes[0] != null)
                treeView.Nodes[0].Expand();

        } 

        private int OutlineID
        {
            get { return (treeView.SelectedNode == null) ? 0 : Convert.ToInt32(treeView.SelectedNode.Name); }
        }

        private int OutlineType
        {
            get
            {
                return chkOutlineType.Checked ? 0 : 1;
            }
            set
            {
                chkOutlineType.Checked = (value == 0) ? true : false;
            }
        }
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetMaterial();
        }

        private void GetMaterial()
        {
            if (OutlineID == 0)
                return;

            //注册限制（单数编号的资料才能访问）
            if (!Valid.IsRegistered)
            {
                if ((OutlineID % 2) == 0)
                {
                    new Register().ShowDialog();
                    return;
                }
            }

            lbTitle.Text = treeView.SelectedNode.Text;

            OutlineInfo oi = outline.GetModel(OutlineID);
            OutlineType = oi.Type;
            txtMaterial.Text = oi.Content;

            //系统资料则不可编辑除了wjcking
            if (editOutlineRuler  != SysConfig.WJCKING)
                txtMaterial.ReadOnly = (oi.Type == 0) ? true : false;

            webBrowser.DocumentText = Browser.ReadOutline(oi.ID.ToString());
        }

        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            
            AddMaterial();
        }

        /// <summary>
        /// 添加资料
        /// </summary>
        private void AddMaterial()
        {
            //注册限制（只能在分类下创建一个资料）
            if (!Valid.IsRegistered)
            {
                if (treeView.SelectedNode.Nodes.Count > 0)
                {
                    new Register().ShowDialog();
                    return;
                }
            }

            if (treeView.SelectedNode == null)
                return;

            if (treeView.SelectedNode.Name == "-1")
                return;
            //如果是系统文档不可编辑或删除
            if (treeView.SelectedNode.Parent.Name.Equals("1"))
                return;
           
            OutlineInfo oi;

            if (editOutlineRuler != SysConfig.WJCKING)
            {
                oi = outline.GetModel(OutlineID);
                if (oi.Type == 0)
                {
                 //   MessageBox.Show("您无权修改系统资料", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            oi = new OutlineInfo();
            TreeNode tr = new TreeNode();

            tr.Text = String.Format("新文档({0})", DateTime.Now.ToString("y-M-d HH:mm:ss"));

            oi.PID = OutlineID;
            oi.Title = tr.Text;
            oi.Type = 1;
            oi.Content = "";
            oi.ContentType = 1;
            outline.Add(oi);

            tr.Name = SysConfig.DataSys.ExecuteScalar("SELECT TOP 1 ID FROM Outline ORDER BY ID DESC").ToString();
            treeView.SelectedNode.Nodes.Add(tr);
            treeView.SelectedNode.Expand();
           // tr.BeginEdit(); 
        }
        private void treeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (treeView.SelectedNode.Name == "-1" || treeView.SelectedNode.Name == "1" || treeView.SelectedNode.Name == "2")
                return;
             
            if (e.KeyData == Keys.Delete)
            {
                
                if (MessageBox.Show("该分类下的子项将一同删除，确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (treeView.SelectedNode.Parent.Name.Equals("1"))
                        return;

                    if (OutlineID > 2)
                        SysConfig.DataSys.ExecuteNonQuery("DELETE * FROM Outline WHERE ID = " + treeView.SelectedNode.Name);

                    SysConfig.DataSys.ExecuteNonQuery("DELETE * FROM Outline WHERE PID = " + treeView.SelectedNode.Name);

                    if (OutlineID > 2)
                        treeView.SelectedNode.Remove();

                }
            }
            else if (e.KeyData == Keys.Enter)
                treeView.SelectedNode.EndEdit(false);
            else if (e.KeyData == Keys.F2)
                treeView.SelectedNode.BeginEdit();
            //else if (e.KeyData == Keys.Escape)
            //    treeView.SelectedNode.Remove();
        }

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

            if (e.Node.Text == String.Empty)
                return;

            if (OutlineID < 2)
                return;

            if (string.IsNullOrEmpty(e.Label))
                return;

            if (chkOutlineType.Checked)
                e.Node.ForeColor = SysConfig.CategoryColor;

            SysConfig.DataSys.ExecuteNonQuery(String.Format("UPDATE Outline SET Title = '{0}' , Type={1} WHERE  ID = {2}", e.Label, OutlineType, e.Node.Name));
            lbTitle.Text = e.Label;
        }

        private void txtMaterial_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void txtMaterial_DragDrop(object sender, DragEventArgs e)
        {
            object o = e.Data.GetData(typeof(string));

            if (o != null)
                txtMaterial.Text = o.ToString();
        }

        private void UpdateMaterial(int contentType)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("请选择左侧资料项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            OutlineInfo oi;

            if (editOutlineRuler != SysConfig.WJCKING)
            {
                oi = outline.GetModel(OutlineID);
                if (oi.Type == 0)
                {
                    MessageBox.Show("您无权修改系统资料", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            oi = new OutlineInfo();
            oi.Content = txtMaterial.Text;
            oi.ID = Convert.ToInt32(treeView.SelectedNode.Name);
            oi.Type = OutlineType;

            if (oi.Type == 0)
                treeView.SelectedNode.ForeColor = SysConfig.CategoryColor;

            oi.ContentType = contentType;
            outline.Update(oi);
        }

        private void UpdateMaterial()
        {
            UpdateMaterial(0);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == btnQuit)
            {
                Close();
                return;
            }
            else if (button == btnSave)
                UpdateMaterial();
            else if (button == btnOk)
            {
                UpdateMaterial();
                Close();
            }
        }

        /// <summary>
        /// 标注关键字
        /// </summary>
        public void HighlightTextByScript()
        {
            KeywordInfo ki = new KeywordInfo();
            ki.SectionID = OutlineID;
            ki.Section = KeywordInfo.KeywordSection.Outline;

            Keyword keyword = new Keyword(ki);
            keyword.ShowDialog();
            if (keyword.DialogResult == DialogResult.OK)
                webBrowser.Document.InvokeScript("highword", new object[] { keyword.KeywordInfo.Keyword.Replace("\r\n", ""), keyword.KeywordInfo.HighlightStyle });                   
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("请选择左侧资料项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (cbxEncoding.SelectedIndex == 0)
                    txtMaterial.Text = System.IO.File.ReadAllText(openFile.FileName, Encoding.Default);
                else
                    txtMaterial.Text = System.IO.File.ReadAllText(openFile.FileName, Encoding.GetEncoding(cbxEncoding.Text));

                string exten = System.IO.Path.GetExtension(openFile.FileName).ToLower();

                if (exten == ".htm" || exten == ".html")
                    UpdateMaterial(1);
                else
                    UpdateMaterial(0);

                webBrowser.DocumentText = Browser.ReadOutline(treeView.SelectedNode.Name);
            }
        }

        public void Material_FormClosing(object sender, FormClosingEventArgs e)
        {
            isInitialized = false;
            formMaterial.Dispose();
            formMaterial = new Material();

            if (treeView.SelectedNode != null)
                SysConfig.SettingsHelper.SetSettingsElement(Settings.OutlineIndex, treeView.SelectedNode.Name);
        }

        private void menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item == menuRename)
                treeView.SelectedNode.BeginEdit();
            else if (item == menuAddMaterial)
                AddMaterial();
            else if (item == menuDelMaterial)
                treeView_KeyUp(this.treeView, new KeyEventArgs(Keys.Delete));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMaterial();
        }

        private void txtMaterial_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.S | Keys.Control))
                UpdateMaterial();
        }

    }
}
