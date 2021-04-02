using System;
using System.Drawing;
using System.Windows.Forms;
using Cts;
using Model;
using ExamSys.Delegation;

namespace ExamSys
{
    public partial class CheckOut : Form
    {
        public event LocateItemEventHandler LocateItemClick;
        public event RefreshEventHandler RefreshClick;
        private TemplateInfo templateInfo = null;

        public TemplateInfo TemplateInfo
        {
            get { return templateInfo; }
            set { templateInfo = value; }
        }

        public   void OnLocateItemClick(LocateItemEventArgs e)
        {
            if (LocateItemClick != null)
            {
                LocateItemClick(this, e);
            }
        }
         public   void OnRefreshClick(EventArgs e)
        {
            if (RefreshClick != null)
            {
                RefreshClick(this, e);
            }
        }

        public CheckOut(TemplateInfo temp)
        {
            templateInfo = temp;
            InitializeComponent();
            CheckingOut();


        }
        public void CheckingOut()
        {

            string itemLocationStyle = SysConfig.SettingsHelper.GetValue(Settings.ExamItemLocationStyle);

            if (!string.IsNullOrEmpty(itemLocationStyle))
                chkLocationStyle.Checked = itemLocationStyle.ToLower() == "true" ? true : false;

            dgExamItem.AutoGenerateColumns = false;
            dgExamItem.DataSource = EPBuilder.CurrentExamItemList;

            cMainSubject.DataPropertyName = "MainSubjectTitle";
            cSubject.DataPropertyName = "Subject";
            cMark.DataPropertyName = "Mark";
            cKey.DataPropertyName = "key";
            cUserAnswer.DataPropertyName = "UserAnswer";
            dgExamItem.Refresh();
        
        }
        private void dgExamItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            ExamItemInfo ei = EPBuilder.CurrentExamItemList[e.RowIndex];
            LocateItemEventArgs locateEvent = new LocateItemEventArgs();
            locateEvent.SelectedItem = ei;

            OnLocateItemClick(locateEvent);

            if (chkLocationStyle.Checked)
            {
                DialogResult = DialogResult.Ignore;
                Close();
            }
        }

        private void chkLocationStyle_CheckedChanged(object sender, EventArgs e)
        {
            SysConfig.SettingsHelper.SetValue(Settings.ExamItemLocationStyle, chkLocationStyle.Checked.ToString());
        }

        private void btnHandIn_Click(object sender, EventArgs e)
        {
            HandIn handin = new HandIn();
            handin.TemplateInfo = templateInfo;
            DialogResult = handin.ShowDialog();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Ignore;
            Close();
        }

        /// <summary>
        /// 提交后，显示那些有问题
        /// </summary>
        private void CheckOut_Load(object sender, EventArgs e)
        {
            int subjectIndex = 1;
            int index = 0;

            foreach (DataGridViewRow row in dgExamItem.Rows)
            {
                row.Cells["cIndex"].Value = subjectIndex++;

                if (SysConfig.IsHandedIn)
                {
                    //出错的
                    if (!EPBuilder.CurrentExamItemList[index].IsCorrect)
                        dgExamItem.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;

                    //没做的
                    if (String.IsNullOrEmpty(EPBuilder.CurrentExamItemList[index].UserAnswer))
                        dgExamItem.Rows[index].Cells["cUserAnswer"].Style.BackColor= Color.Yellow;
                    index++;
                }
            }

            //显示答案
            if (SysConfig.IsHandedIn)
            {
                cKey.Visible = true;
                cUserAnswer.Visible = true;
            }
        }


        private void CheckOut_Activated(object sender, EventArgs e)
        {
            OnRefreshClick(e);
            CheckingOut();
        }
    }
}
