using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using ExamSys.Util;

namespace ExamSys
{
    public partial class History : Form
    {

        public History()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = false;

            SysConfig.Decorater.DrawDataGridRowNumber(dgvData);
            SysConfig.Decorater.FormCloseByKeyUp(this);

            Reload();

            btnQuit.Click += delegate { Close(); }; 


            drpDisplayStyle.Items.Add(ConstInfo.DisplayStyle.列表);
            drpDisplayStyle.Items.Add(ConstInfo.DisplayStyle.逐个);
            drpDisplayStyle.SelectedIndex = 0;

            drpTestWay.Items.Add(ConstInfo.TestWay.试题学习);
            drpTestWay.Items.Add(ConstInfo.TestWay.正式考试);
            drpTestWay.SelectedIndex = 0;

            //注册限制
            if (!Valid.IsRegistered)
            {
                drpTestWay.Enabled = false;
            }

            listMessage.Items.Add("请选择表格中的检索记录进行组卷、考试或删除操作");

            //注册提示
            if (Valid.IsRegistered)
                listMessage.Items.Add("您选择的试题检索记录将限制在" + SysData.MainSubjectList.Count.ToString() + "个大题类型之内进行组卷");
            else
                listMessage.Items.Add("在试用版中，您选择的试题检索记录将限制在2个大题类型进行组卷");

            string mainSubjectString = "";

            foreach (MainSubjectInfo msi in SysData.MainSubjectList)
            {
                mainSubjectString += msi.Subject + ",";
            }

            listMessage.Items.Add(mainSubjectString);
            listMessage.Items.Add("");

        }


        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            int rowID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[cID.Name].Value);
            int rowExamInfoID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[cExamInfoID.Name].Value);
            string rowKeyword = dgvData.Rows[e.RowIndex].Cells[cKeyword.Name].Value.ToString();
            string rowExamInfoName = dgvData.Rows[e.RowIndex].Cells[cExamInfoName.Name].Value.ToString();
            string rowSearchType = dgvData.Rows[e.RowIndex].Cells[cSearchType.Name].Value.ToString();
            string rowMainSubject = dgvData.Rows[e.RowIndex].Cells[cMainSubject.Name].Value.ToString();
            int rowMainSubjectID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[cMainSubjectID.Name].Value);
            int rowRecordCount = string.IsNullOrEmpty(dgvData.Rows[e.RowIndex].Cells[cRecordCount.Name].Value.ToString()) ? 0 : Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[cRecordCount.Name].Value);
            string rowSqlRecordCount = dgvData.Rows[e.RowIndex].Cells[cSqlRecordCount.Name].Value.ToString();
            string rowSqlSearch = dgvData.Rows[e.RowIndex].Cells[cSqlSearch.Name].Value.ToString();

            HistoryInfo hi = new HistoryInfo();
            hi.ID = rowID;
            hi.ExamInfoID = rowExamInfoID;
            hi.ExamInfoName = rowExamInfoName;
            hi.MainSubject = rowMainSubject;
            hi.MainSubjectID = rowMainSubjectID;
            hi.SearchType = rowSearchType;
            hi.Keyword = rowKeyword;
            hi.RecordCount = rowRecordCount.ToString();
            hi.SqlRecordCount = rowSqlRecordCount;
            hi.SqlSearch = rowSqlSearch;

            StringBuilder titleString = new StringBuilder();
            titleString.Append(rowExamInfoName);
            titleString.Append(SysConfig.RIGHT_ARROW);
            titleString.Append(rowSearchType);
            titleString.Append(SysConfig.RIGHT_ARROW + rowMainSubject);

            if (!String.IsNullOrEmpty(rowKeyword))
            {
                titleString.Append(SysConfig.RIGHT_ARROW);
                titleString.AppendFormat("关键字: '{0}'", rowKeyword);
            }


            if (dgvData.Columns[e.ColumnIndex] == cBtnDelete)
            {
                if (MessageBox.Show("确定要删除当前记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SysData.AccessHelper.ExecuteScalar("DELETE * FROM History WHERE ID = " + rowID);
                    Reload();
                }
            }
            else if (dgvData.Columns[e.ColumnIndex] == cBtnEnter)
            {
                //注册限制
                if (!Valid.IsRegistered)
                {
                    if (e.RowIndex % 2 == 0)
                    {
                        listMessage.AddMessage("[未注册]您不能进入该项，请选择下一项");
                        return;
                    }
                }

                if (Platform.IsActivated)
                {
                    listMessage.AddMessage(SysConfig.Platform_Actived_Reminder);
                    return;
                }

                TemplateInfo temp = new TemplateInfo();
                temp.DisplayStyle = drpDisplayStyle.SelectedIndex == 0 ? ConstInfo.DisplayStyle.列表 : ConstInfo.DisplayStyle.逐个;
                temp.ExamInfoID = 0;
                temp.TestWay = drpTestWay.SelectedIndex == 0 ? ConstInfo.TestWay.试题学习 : ConstInfo.TestWay.正式考试;
                temp.PlatformStyle = "customs";
                temp.Title = titleString.ToString();
                temp.MainSubjectQuery = rowSqlRecordCount;
                temp.PagingQuery = rowSqlSearch;
                temp.RecordCount = rowRecordCount;
                temp.TemplatPath = SysConfig.TemplatePath();
                temp.LimitedTime = 0;
                temp.ExamQueryStyle =   TemplateInfo.QueryStyle_Search;
                temp.ExamHistoryList.Clear();
                temp.ExamHistoryList.Add(hi);


                Platform.Activate(temp);
                listMessage.AddMessage("进入试卷：" + titleString.ToString());

            }
            else if (dgvData.Columns[e.ColumnIndex] == cMainSubject)
            {
                AddHistoryItem(hi);
                listMessage.AddMessage("选择组卷：" + titleString.ToString());

            }

        }
        /// <summary>
        /// 从新载入数据
        /// </summary>
        private void Reload()
        {
            dgvData.DataSource = SysData.ExamHistoryUtil.GetListArray(" 100 = 100 ORDER BY PubDate DESC");
        }

 


        /// <summary>
        /// 添加用户选择的检索记录到listbox，剔除相同大题编号的检索记录，并把指向最后一条列表项。
        /// </summary>
        /// <param name="historyInfo"></param>
        private void AddHistoryItem(HistoryInfo historyInfo)
        {
            //去除相同大题编号的记录
            if (listHistory.Items.Count > -1)
            {
                for (int i = 0; i < listHistory.Items.Count; i++)
                {
                    HistoryInfo hi = listHistory.Items[i] as HistoryInfo;

                    if (hi.MainSubjectID == historyInfo.MainSubjectID)
                    {
                        listHistory.Items.RemoveAt(i);
                    }
                }
            }
            //注册限制
            if (!Valid.IsRegistered)
            {
                if (listHistory.Items.Count == 2)
                {
                    listMessage.AddMessage("尊敬的用户，试用版本组卷项最多只能为2项，请您注册正式版享受全部功能");
                    return;
                }
            }

            listHistory.Items.Add(historyInfo);
            listHistory.DisplayMember = "MainSubject";
            listHistory.ValueMember = "MainSubjectID";
            listHistory.SelectedIndex = listHistory.Items.Count - 1;
        }



        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除所有记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SysData.AccessHelper.ExecuteScalar("DELETE * FROM History ");
                dgvData.DataSource = null;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dgvData.DataSource = SysData.ExamHistoryUtil.GetListArray(string.Format(" 100 = 100 AND PubDate = #{0}# ORDER BY PubDate DESC", dateTimePicker.Value.Date.ToString("yyyy/M/d")));
        }

        /// <summary>
        /// 删除组卷记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listHistory_KeyUp(object sender, KeyEventArgs e)
        {
            if (listHistory.SelectedIndex == -1)
                return;

            HistoryInfo hi = listHistory.SelectedItem as HistoryInfo;

            if (hi == null)
                return;

            if (e.KeyData == Keys.Delete)
            {
                listHistory.Items.RemoveAt(listHistory.SelectedIndex);
                listMessage.AddMessage("删除已选组卷记录：" + hi.ExamInfoName + "->" + hi.MainSubject);
            }
        }


        /// <summary>
        /// 组卷后进入考试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {

            if (Platform.IsActivated)
            {
                listMessage.AddMessage(SysConfig.Platform_Actived_Reminder);
                return;
            }

            TemplateInfo temp = new TemplateInfo();
            temp.ExamHistoryList.Clear();

            if (listHistory.Items.Count < 2)
            {
                listMessage.AddMessage("组卷题目类型必须是2条以上。");
                return;
            }

            int questionCount = 0;

            for (int i = 0; i < listHistory.Items.Count; i++)
            {
                HistoryInfo hi = listHistory.Items[i] as HistoryInfo;
                questionCount += hi.QuestionCount;
                temp.ExamHistoryList.Add(hi);
            }

            listMessage.AddMessage("试题总数为：[" + questionCount.ToString() + "] 正在组卷请稍候..........");


            temp.DisplayStyle = drpDisplayStyle.SelectedIndex == 0 ? ConstInfo.DisplayStyle.列表 : ConstInfo.DisplayStyle.逐个;
            temp.ExamInfoID = 0;
            temp.TestWay = drpTestWay.SelectedIndex == 0 ? ConstInfo.TestWay.试题学习 : ConstInfo.TestWay.正式考试;
            temp.PlatformStyle = "customs";
            temp.Title = Valid.AccessRegisterInfo.ProductName + "组卷考试";
            temp.MainSubjectQuery = "";
            temp.PagingQuery = "";
            temp.RecordCount = 0;
            temp.TemplatPath = SysConfig.TemplatePath();
            temp.LimitedTime = 0;
            temp.ExamQueryStyle = TemplateInfo.QueryStyle_Search;

            Platform.Activate(temp);
            listMessage.AddMessage("已经成功进入试卷");


        }


        private void menuListHistory_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listHistory.Items.Count == -1)
            {
                listMessage.AddMessage("请先点击组卷列中的选择按钮");
                return;
            }

            if (listHistory.SelectedIndex < 0)
            {
                listMessage.AddMessage("请先选择您要操作的项");
                return;
            }

            string tsmName = e.ClickedItem.Name;
            HistoryInfo hi = listHistory.SelectedItem as HistoryInfo;

            switch (tsmName)
            {
                case "tsmDelete":
                    listHistory.Items.RemoveAt(listHistory.SelectedIndex);
                    listMessage.AddMessage("删除已选组卷记录" + hi.ExamInfoName + "->" + hi.MainSubject);
                    return; ;
                case "tsmViewDetail":
                    return;
                case "tsmRemoveAll":
                    listHistory.Items.Clear();
                    return;
                default:
                    return;
            }
        }

        private void History_Activated(object sender, EventArgs e)
        {
            Reload();
            dgvData.Refresh();
        }
    }
}
