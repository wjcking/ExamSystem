using System;
using System.Windows.Forms;
using Model;
using ExamSys.Util;

namespace ExamSys
{
    public partial class Keyword : Form
    {
        private KeywordInfo keywordInfo = new KeywordInfo();
        private static string cacheKeyword = "";
 
        private const string HIGHLIGHT_STYLE_BACKGROUND = "Background";

        public Keyword(KeywordInfo keyInfo)
        {
            InitializeComponent();
            Init();

            if (keyInfo.Section == KeywordInfo.KeywordSection.ExamInfo)
            {
                if (keyInfo.SectionID == 0)
                {
                    txtKeyword.Text = cacheKeyword;
                }
                else
                {
                    ExamInfo ei = SysData.ExamSysUtil.GetModel(keyInfo.SectionID);
                    txtKeyword.Text = ei.Keyword;
                }
            }
            else
            {
                OutlineInfo oi = SysData.OutlineUtil.GetModel(keyInfo.SectionID);
                txtKeyword.Text = oi.Keyword;
            }
            keywordInfo = keyInfo;
        }

        private void Init()
        {
            SysConfig.Decorater.FormCloseByKeyUp(this);
            button1.DialogResult = DialogResult.Cancel;
            btnRemark.DialogResult = DialogResult.OK;
        }

        public KeywordInfo KeywordInfo
        {
            get { return keywordInfo; }
            set { keywordInfo = value; }
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            keywordInfo.Keyword = Cts.StrTool.ClearSpecialChar(txtKeyword.Text).Replace("\r\n","");

            if (keywordInfo.SectionID != 0)
                SysData.AccessHelper.ExecuteNonQuery(String.Format("UPDATE {0} SET [Keyword] = '{1}' WHERE ID = {2}", keywordInfo.Section, keywordInfo.Keyword, keywordInfo.SectionID));
            else
                cacheKeyword = txtKeyword.Text;
            SysData.GenerateJson();
            Close();
        }

        private void txtKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnRemark_Click(sender, null);
        }


    }
}


