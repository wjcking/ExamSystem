using System;
using System.Windows.Forms;
using Model;
using ExamSys.Util;

namespace ExamSys
{
    public partial class SearchTask : Form
    {
        private int pagesize = 10;
        private int recordCount = 0;
        private int pageCount = 0;
        private int historyCount = 0;

        private string searchQueryString = "";
        private string recordCountString = "";
        private string checkedSubjectType = "全部试题";
        private ExamInfo selectedExamInfo = new ExamInfo();
        private MainSubjectInfo msi = new MainSubjectInfo();
        private string searchedKeyword = "";


        public SearchTask()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = false;

            SysConfig.Decorater.DrawDataGridRowNumber(dgvData);
            SysConfig.Decorater.FormCloseByKeyUp(this);
            drpExamInfo.BindExamInfo(true);

            btnQuit.Click += delegate { Close(); };
            drpTopic.DataSource = SysData.MainSubjectList;
            drpTopic.DisplayMember = "Subject";
            drpExamInfo.SelectedIndexChanged += delegate { lbStatus.Text = drpExamInfo.Text; };

            if (drpPage.Items.Count == 0)
                btnEnter.Enabled = false;

            //注册限制
            if (!Valid.IsRegistered)
            {
                drpPage.Enabled = false;
                numPageSize.Enabled = false;
                historyCount = Convert.ToInt32(SysData.AccessHelper.ExecuteScalar("SELECT count(*) FROM History"));

             

            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            pagesize = Convert.ToInt32(numPageSize.Value);
            GetExamListByPaging(1);
            GetPageNumber(pageCount);

            btnEnter.Enabled = (drpPage.Items.Count == 0) ? false : true;
            lbStatus.Text = "查询试题总数为：" + recordCount.ToString() + "    共[" + pageCount.ToString() + "]页";
        }


        //下拉页面 
        private void GetPageNumber(int max)
        {
            drpPage.Items.Clear();

            if (max == 0)
                return;

            for (int i = 1; i <= max; i++)
                drpPage.Items.Add(i);

        }

        private void GetExamListByPaging(int currentPageIndex)
        {

            if (drpExamInfo.SelectedIndex == 0)
            {
                if (Valid.IsRegistered)
                {
                    selectedExamInfo.ID = 0;
                    selectedExamInfo.Name = "所有题库";
                }
                else
                {
                    selectedExamInfo = (drpExamInfo.SelectedItem as ListItemExamInfo).ExamInfo;
                }
            }
            else
            {
                selectedExamInfo = (drpExamInfo.SelectedItem as ListItemExamInfo).ExamInfo;
            }


            msi = drpTopic.SelectedValue as MainSubjectInfo;

            ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msi.Type;

            string query = "";
            string choiceKeywordQuery = "";

            //if (qt == ConstInfo.QuestionType.Selection)
            //    choiceKeywordQuery = string.IsNullOrEmpty(txtKey.Text)? string.Empty : String.Format(" OR [Choice] like \"%{0}%\"", txtKey.Text);

            string keyword = (string.IsNullOrEmpty(txtKey.Text)) ? string.Empty : string.Format("AND [Subject] like \"%{0}%\" {1} ", txtKey.Text, choiceKeywordQuery);
            string sqlExamInfoID = (selectedExamInfo.ID == 0) ? String.Empty : string.Format(" AND ExamInfoID = {0}", selectedExamInfo.ID);
            searchedKeyword = txtKey.Text;

            if (rdoAll.Checked)
            {
                checkedSubjectType = rdoAll.Text;
                query = string.Format("MainSubjectID = {0} {1} {2} ", msi.ID, sqlExamInfoID, keyword);
            }
            else if (rdoFav.Checked)
            {
                checkedSubjectType = rdoFav.Text;
                query = string.Format("MainSubjectID = {0} AND Fav = true {1} {2}", msi.ID, keyword, sqlExamInfoID);
            }
            else if (rdoIncorrect.Checked)
            {
                checkedSubjectType = rdoIncorrect.Text;
                query = string.Format("MainSubjectID = {0} AND InCorrectNo > 0  {1} {2}  ", msi.ID, sqlExamInfoID, keyword);
            }
            else if (rdoCorrection.Checked)
            {
                checkedSubjectType = rdoCorrection.Text;
                query = string.Format("MainSubjectID = {0} AND CorrectionType <> '正确'  {1} {2}  ", msi.ID, sqlExamInfoID, keyword);
            }
            //ORDER BY InCorrectNo ASC
            recordCountString = string.Format("SELECT COUNT(*) FROM [{0}] WHERE  {1} ", qt, query);
            recordCount =  Convert.ToInt32(SysData.AccessHelper.ExecuteScalar(recordCountString));
            pageCount = Pagination.GetPageCount(recordCount, pagesize);

            if (recordCount == 0)
            {
                dgvData.DataSource = null;
                return;
            }

            if (pageCount == 0)
            {
                dgvData.DataSource = null;
                return;
            }

            string pagingSql = Pagination.Paging(pagesize, currentPageIndex, recordCount, qt.ToString(), "*", "ID", true, query);

            switch (qt)
            {
                case ConstInfo.QuestionType.Selection:
                    dgvData.DataSource = new DataUtility.Select().GetListArrayByPaging(pagingSql);
                    break;
                case ConstInfo.QuestionType.Judgement:
                    dgvData.DataSource = new DataUtility.Judge().GetListArrayByPaging(pagingSql);
                    break;
                case ConstInfo.QuestionType.Fill:
                    dgvData.DataSource = new DataUtility.FillBlank().GetListArrayByPaging(pagingSql);
                    break;
                case ConstInfo.QuestionType.Question:
                    dgvData.DataSource = new DataUtility.Quest().GetListArrayByPaging(pagingSql);
                    break;
            }
          //  dgvData.Columns[""].SortMode = DataGridViewColumnSortMode.Programmatic;
            searchQueryString = pagingSql;
            lbStatus.Text = "查询试题总数为：" + recordCount.ToString();
        }



        private void drpPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = Convert.ToInt32(drpPage.Text);
            GetExamListByPaging(currentIndex);
            lbStatus.Text = string.Format("第[{0}]页 记录个数为：{1}", currentIndex, dgvData.Rows.Count);
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            //将答案显示到状态栏
            string key = dgvData.Rows[e.RowIndex].Cells[cKey.Name].Value.ToString().Trim();

            if (msi.Type == 4)
                lbStatus.Text = "简答或论述类型题答案，请参考校正对话框 答案长度为：" + key.Length.ToString();

            else
                lbStatus.Text = "答案：" + key;

            if (dgvData.Columns[e.ColumnIndex] != cCorrectionType)
                return;

            int sid = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[id.Name].Value);
            ExamItemInfo ei = new ExamItemInfo();
            ei.Subject = dgvData.Rows[e.RowIndex].Cells[cSubject.Name].Value.ToString();
            ei.ID = sid;
            ei.Key = key;

            ei.CurrentMainSubject = msi;
            ei.CorrectionType = dgvData.Rows[e.RowIndex].Cells[cCorrectionType.Name].Value.ToString();
            ei.ExamInfoID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[cExamInfoID.Name].Value);

            CorrectSubject cs = new CorrectSubject(ei);
            cs.ShowDialog();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //注册限制
            if (!Valid.IsRegistered)
                Register.GetNewRegister();

            if (Platform.IsActivated)
            {
                lbStatus.Text = SysConfig.Platform_Actived_Reminder;
                return;
            }
            if (dgvData.Rows.Count == 0)
                return;

            TemplateInfo temp = new TemplateInfo();

            temp.DisplayStyle = ConstInfo.DisplayStyle.列表;
            temp.ExamInfoID = selectedExamInfo.ID;
            temp.TestWay = ConstInfo.TestWay.试题学习;
            temp.PlatformStyle = "customs";
            temp.Title = selectedExamInfo.Name + SysConfig.RIGHT_ARROW + msi.Subject + SysConfig.RIGHT_ARROW + checkedSubjectType + (searchedKeyword == "" ? "" : SysConfig.RIGHT_ARROW + "关键字：" + searchedKeyword);
            temp.MainSubjectQuery = "SELECT TOP 1 * FROM MainSubject WHERE ID = " + msi.ID.ToString();
            temp.PagingQuery = searchQueryString;
            temp.RecordCount = dgvData.Rows.Count;
            temp.TemplatPath = SysConfig.TemplatePath();
            temp.LimitedTime = 0;
            temp.ExamQueryStyle =  TemplateInfo.QueryStyle_Search;

            HistoryInfo hi = new HistoryInfo();

            hi.ID =  Convert.ToInt32(SysData.AccessHelper.ExecuteScalar("SELECT TOP 1 ID FROM History ORDER BY ID DESC"));
            hi.MainSubject = msi.Subject; ;
            hi.ExamInfoName = selectedExamInfo.Name;
            hi.Testway = temp.TestWay.ToString();
            hi.PageNumber = string.IsNullOrEmpty(drpPage.Text) ? "1" : drpPage.Text;
            hi.RecordCount = temp.RecordCount.ToString();
            hi.Score = "";
            //存放检索mainsubject的SQL语句。
            hi.SqlRecordCount = temp.MainSubjectQuery;
            //存放当前检索
            hi.SqlSearch = searchQueryString;
            hi.SearchType = checkedSubjectType;
            hi.Keyword = searchedKeyword;
            hi.MainSubjectID = msi.ID;
            hi.ExamInfoID = selectedExamInfo.ID;
            hi.TestTimes = 1;
            //如果该记录存在则不记录，直接进入考试
            bool isHistoryExsits = SysData.ExamHistoryUtil.Exists(hi);

            if (!isHistoryExsits)
                SysData.ExamHistoryUtil.Add(hi);

            temp.ExamHistoryList.Clear();
            temp.ExamHistoryList.Add(hi);

            Platform.Activate(temp);

            if (isHistoryExsits)
                lbStatus.Text = "已进入当前检索的试卷（检索记录已存在）";
            else
                lbStatus.Text = "已进入当前检索的试卷（检索记录保存成功）";
        }


        private void btnCheckHistory_Click(object sender, EventArgs e)
        {
            SysConfig.Decorater.Activate(typeof(History));
        }

        private void btnAddHistory_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                lbStatus.Text = "检索无结果，请先选择检索条件，执行检索程序";
                return;
            }

            HistoryInfo hi = new HistoryInfo();
            hi.SqlRecordCount = "SELECT TOP 1 * FROM MainSubject WHERE ID = " + msi.ID.ToString();
            hi.MainSubject = msi.Subject;
            hi.ExamInfoName = selectedExamInfo.Name;
            hi.MainSubjectID = msi.ID;
            hi.ExamInfoID = selectedExamInfo.ID;
            hi.PageNumber = string.IsNullOrEmpty(drpPage.Text) ? "1" : drpPage.Text;
            hi.RecordCount = dgvData.Rows.Count.ToString();
            hi.SearchType = checkedSubjectType;
            hi.SqlSearch = searchQueryString;
            hi.Keyword = searchedKeyword;
            
            hi.Score = "";

            bool isHistoryExsits = SysData.ExamHistoryUtil.Exists(hi);
            lbStatus.Text = isHistoryExsits.ToString();
            //如果该搜索记录不存在则添加到搜索历史
            if (!isHistoryExsits)
            {
                SysData.ExamHistoryUtil.Add(hi);
                lbStatus.Text = "检索记录添加完毕。";
            }
            else
                lbStatus.Text = "该试题检索记录已经存在，请重新选择检索条件。";
        }



    }
}
