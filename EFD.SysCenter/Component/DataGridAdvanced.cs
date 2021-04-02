using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Model;
using System.Drawing;

namespace EFD.SysCenter
{
    public partial class DataGridAdvanced : DataGridView
    {
        private SubjectDetailWnd subjectDetailWindow;
        private int rowIndex = 0;

        public DataGridAdvanced()
        {
            InitializeComponent();
            // EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            //  MultiSelect = false;

        }
        //题目详细设置网格
        private void subjectDetailWindow_OnSubjectDetailSelected(object sender, SubjectDetailEventArgs e)
        {
            if (e.IsReset)
            {
                Rows[rowIndex].Cells["cbtnSubjectDetail"].Value = String.Empty;
                return;
            }

            if (!e.IsFirst)
                Rows[rowIndex].Cells["cbtnSubjectDetail"].Value = e.SubjectDetailInfo.ID;
            else
                Rows[rowIndex].Cells["cbtnSubjectDetail"].Value = ConstInfo.SUBJECT_DETAIL_FIRST;
        }

        /// <summary>
        /// 根据题型邦定列
        /// </summary>
        public void BindCheckBox()
        {
            DataGridViewCheckBoxColumn cChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            cChk.Name = "cChk";
            cChk.HeaderText = "选择";
            cChk.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            Columns.Insert(0, cChk);
        }

        public ExamQuery ExamQuery
        {
            get;
            set;
        }

        public void BindExamData()
        {


            //绑定题目详细对话框事件
            subjectDetailWindow = new SubjectDetailWnd();
            subjectDetailWindow.OnSubjectDetailSelected += new SubjectDetailEventHandler(subjectDetailWindow_OnSubjectDetailSelected);

            AutoGenerateColumns = false;
            Columns.Clear();

            DataGridViewCheckBoxColumn cChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            cChk.Name = "cChk";
            cChk.HeaderText = "选择";
            cChk.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn ctxtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ctxtID.Visible = false;
            ctxtID.Name = "ctxtID";
            ctxtID.HeaderText = "编号";
            ctxtID.DataPropertyName = "ID";
            ctxtID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            DataGridViewTextBoxColumn ctxtSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ctxtSubject.Name = "ctxtSubject";
            ctxtSubject.HeaderText = "题目";
            ctxtSubject.DataPropertyName = "Subject";
            ctxtSubject.Width = 130;


            DataGridViewTextBoxColumn ctxtChoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ctxtChoice.Name = "ctxtChoice";
            ctxtChoice.HeaderText = "选项";
            ctxtChoice.DataPropertyName = "Choice";
            ctxtChoice.Width = 130;

            DataGridViewCheckBoxColumn cChkMultiple = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            cChkMultiple.Name = "cChkMultiple";
            cChkMultiple.HeaderText = "单/多";
            cChkMultiple.DataPropertyName = "Multiple";
            cChkMultiple.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn ctxtKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ctxtKey.Name = "ctxtKey";
            ctxtKey.HeaderText = "答案";
            ctxtKey.DataPropertyName = "Key";
            if (ExamQuery.QuestionType == ConstInfo.QuestionType.Selection)
                ctxtKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            else
                ctxtKey.Width = 200;

            //DataGridViewComboBoxColumn cDrpBreakType = new DataGridViewComboBoxColumn();

            ////List<MainSubjectInfo> mainSubjectList = Exam.GetMainSubjectListByQuestionType(ExamQuery.QuestionType);

            ////foreach (MainSubjectInfo msi in mainSubjectList)
            ////    cDrpMainSubject.Items.Add(msi);
            //cDrpBreakType.Items.Add(0);
            //cDrpBreakType.Items.Add(1);
            //cDrpBreakType.Items.Add(2);
            //cDrpBreakType.HeaderText = "换行";
            //cDrpBreakType.Name = "cDrpBreakType";
            //cDrpBreakType.DataPropertyName = "BreakType";
            // cDrpBreakType.DisplayMember = "BreakType";
            // cDrpBreakType.ValueMember = "BreakType";
            // cDrpBreakType.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn ctxtBreakType = new DataGridViewTextBoxColumn();
            ctxtBreakType.HeaderText = "换行";
            ctxtBreakType.Name = "ctxtBreakType";
            ctxtBreakType.DataPropertyName = "BreakType";
            ctxtBreakType.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewButtonColumn cbtnSubjectDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            cbtnSubjectDetail.Name = "cbtnSubjectDetail";
            cbtnSubjectDetail.HeaderText = "题目详细";
            cbtnSubjectDetail.DataPropertyName = "SubjectDetail";
            cbtnSubjectDetail.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //cbtnSubjectDetail.UseColumnTextForButtonValue = true

            DataGridViewTextBoxColumn ctxtAnalysis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ctxtAnalysis.Name = "ctxtAnalysis";
            ctxtAnalysis.HeaderText = "分析";
            ctxtAnalysis.DataPropertyName = "Analysis";
            ctxtAnalysis.Width = 100;


            DataGridViewComboBoxColumn cDrpMainSubject = new DataGridViewComboBoxColumn();

            List<MainSubjectInfo> mainSubjectList = Exam.GetMainSubjectListByQuestionType(ExamQuery.QuestionType);

            foreach (MainSubjectInfo msi in mainSubjectList)
                cDrpMainSubject.Items.Add(msi);

            cDrpMainSubject.HeaderText = "大题目";
            cDrpMainSubject.Name = "cDrpMainSubject";
            cDrpMainSubject.DisplayMember = "Subject";
            cDrpMainSubject.ValueMember = "ID";
            cDrpMainSubject.DataPropertyName = "MainSubjectID";

            Columns.Add(cChk);
            Columns.Add(ctxtID);
            Columns.Add(ctxtSubject);

            if (ExamQuery.QuestionType == ConstInfo.QuestionType.Selection)
            {
                Columns.Add(ctxtChoice);
                Columns.Add(cChkMultiple);
                Columns.Add(ctxtBreakType);
            }

            //if (ExamQuery.QuestionType == ConstInfo.QuestionType.Judgement)
            //    Columns.Add(cChkJudgementKey);
            //else
            Columns.Add(ctxtKey);

            Columns.Add(cbtnSubjectDetail);

            if (ExamQuery.QuestionType != ConstInfo.QuestionType.Question)
                Columns.Add(ctxtAnalysis);

            Columns.Add(cDrpMainSubject);

            switch (ExamQuery.QuestionType)
            {

                case ConstInfo.QuestionType.Selection:
                    DataSource = Exam.Choice.GetListArray(ExamQuery.Query);
                    return;
                case ConstInfo.QuestionType.Fill:
                    DataSource = Exam.Fill.GetListArray(ExamQuery.Query);
                    return;
                case ConstInfo.QuestionType.Judgement:
                    DataSource = Exam.Judgement.GetListArray(ExamQuery.Query);
                    return;
                case ConstInfo.QuestionType.Question:
                    DataSource = Exam.Question.GetListArray(ExamQuery.Query);
                    return;
            }
        }


        /// <summary>
        /// 更新试题详解
        /// </summary>
        /// <param name="analysis"></param>
        /// <returns>错了就返回行数</returns>
        public int BindAnalysis(string[] analysis)
        {
            if (analysis.Length == 0)
                return -1;

            if (Rows.Count != analysis.Length)
                return -2;

            for (int i = 0; i < analysis.Length; i++)
                Rows[i].Cells["ctxtAnalysis"].Value = analysis[i];

            for (int i = 0; i < Rows.Count; i++)
            {
                int id = Convert.ToInt32(Rows[i].Cells["ctxtID"].Value);
                string a = Rows[i].Cells["ctxtAnalysis"].Value.ToString();

                Exam.ExamSys.UpdateAnalysis(ExamQuery.QuestionType, id, a);
            }

            return 0;
        }


        /// <summary>
        /// 更新答案
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public int BindKeys(string[] keys)
        {
            if (keys.Length == 0)
                return -1;

            if (Rows.Count != keys.Length)
                return -2;

            for (int i = 0; i < keys.Length; i++)
                Rows[i].Cells["ctxtKey"].Value = keys[i];

            for (int i = 0; i < Rows.Count; i++)
            {
                int id = Convert.ToInt32(Rows[i].Cells["ctxtID"].Value);


                string key = Rows[i].Cells["ctxtKey"].Value.ToString();


                if (ExamQuery.QuestionType == ConstInfo.QuestionType.Selection)
                    key = key.ToUpper();
                else if (ExamQuery.QuestionType == ConstInfo.QuestionType.Judgement)
                    key = Cts.StrTool.ChangeJudgementKey(key);
                else if (ExamQuery.QuestionType == ConstInfo.QuestionType.Question)
                {
                    string subject = Rows[i].Cells["ctxtSubject"].Value.ToString().Replace("\r\n","");
                    key = key.Replace(subject, "");
                }
                Exam.ExamSys.UpdateKey(ExamQuery.QuestionType, id, key);
            }

            return 0;
        }

        public int AddSubjects(string[] subjects)
        {
            if (subjects.Length == 0)
                return -1;

            int rows = 0;
            foreach (string subject in subjects)
            {
                switch (ExamQuery.QuestionType)
                {
                    case ConstInfo.QuestionType.Fill:
                        FillInfo fillInfo = new FillInfo();
                        fillInfo.ExamInfoID = ExamQuery.ExamInfoID;
                        fillInfo.MainSubjectID = ExamQuery.MainSubjectID;
                        fillInfo.Subject = subject;

                        rows += Exam.Fill.Add(fillInfo);
                        break;

                    case ConstInfo.QuestionType.Judgement:
                        JudgementInfo judgementInfo = new JudgementInfo();
                        judgementInfo.ExamInfoID = ExamQuery.ExamInfoID;
                        judgementInfo.MainSubjectID = ExamQuery.MainSubjectID;
                        judgementInfo.Subject = subject;

                        rows += Exam.Judgement.Add(judgementInfo);
                        break;
                    case ConstInfo.QuestionType.Question:
                        QuestionInfo questionInfo = new QuestionInfo();
                        questionInfo.ExamInfoID = ExamQuery.ExamInfoID;
                        questionInfo.MainSubjectID = ExamQuery.MainSubjectID;
                        questionInfo.Subject = subject;

                        rows += Exam.Question.Add(questionInfo);
                        break;
                }
            }

            switch (ExamQuery.QuestionType)
            {
                case ConstInfo.QuestionType.Fill:
                    DataSource = Exam.Fill.GetListArray(ExamQuery.Query);
                    break;
                case ConstInfo.QuestionType.Judgement:
                    DataSource = Exam.Judgement.GetListArray(ExamQuery.Query);
                    break;
                case ConstInfo.QuestionType.Question:
                    DataSource = Exam.Question.GetListArray(ExamQuery.Query);
                    break;
            }
            return rows;
        }
        public int DeleteExamData()
        {
            if (MessageBox.Show("确定吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return -1;

            int result = 0;

            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Cells["cChk"].Value == null)
                    continue;

                if (Rows[i].Cells["cChk"].Value.ToString().ToLower() == "true")
                {
                    //根据题目类型，在表中删除
                    result += Exam.Access.ExecuteNonQuery(string.Format("DELETE * FROM {0} WHERE ID={1}", ExamQuery.QuestionType, Rows[i].Cells["ctxtID"].Value));

                }
            }
            BindExamData();

            return result;
        }

        public int OrganizeChoiceText()
        {
            if (MessageBox.Show("确定吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return -1;

            int result = 0;

            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Cells["cChk"].Value == null)
                    continue;

                if (Rows[i].Cells["cChk"].Value.ToString().ToLower() == "true")
                {
                    int id = Convert.ToInt32(Rows[i].Cells["ctxtID"].Value);
                    string choice = Cts.StrTool.OrganizeChoice(Rows[i].Cells["ctxtChoice"].Value.ToString());

                    result += Exam.Choice.UpdateChoice(id, choice);

                }
            }
            BindExamData();

            return result;
        }
        public DataGridAdvanced(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void DataGridAdvanced_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                            e.RowBounds.Location.Y,
                                            RowHeadersWidth - 4,

                                              e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                 RowHeadersDefaultCellStyle.Font,
                                  rectangle,
                                 RowHeadersDefaultCellStyle.ForeColor,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void DataGridAdvanced_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            rowIndex = e.RowIndex;

            if (Columns[e.ColumnIndex].Name == "cbtnSubjectDetail")
            {
                subjectDetailWindow.ExamQuery = new ExamQuery();
                subjectDetailWindow.ExamQuery.ExamInfoID = ExamQuery.ExamInfoID;
                subjectDetailWindow.ExamQuery.QuestionType = ExamQuery.QuestionType;
                subjectDetailWindow.ExamQuery.SubjectID = Convert.ToInt32(Rows[e.RowIndex].Cells["ctxtID"].Value);
                subjectDetailWindow.ExamQuery.MainSubjectID = Convert.ToInt32(Rows[e.RowIndex].Cells["cDrpMainSubject"].Value);
                subjectDetailWindow.ExamQuery.SubjectName = Rows[e.RowIndex].Cells["ctxtSubject"].Value.ToString();
                //DataGridViewComboBoxCell combo = Rows[e.RowIndex].Cells["cDrpMainSubject"] as DataGridViewComboBoxCell;
                //subjectDetailWindow.ExamQuery.MainSubjectName = 
                subjectDetailWindow.Initialize();
                Decorator.ShowDialog(subjectDetailWindow);
            }
        }

        private void DataGridAdvanced_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            if (Columns[e.ColumnIndex].Name == "cChk")
            {
                for (int i = 0; i < Rows.Count; i++)
                {

                    MessageBox.Show(Rows[i].Cells["cChk"].Value.ToString());
                }
            }
        }

        public void UpdateExamData()
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                string subject = Rows[i].Cells["ctxtSubject"].Value.ToString();
                string analysis = ExamQuery.QuestionType == ConstInfo.QuestionType.Question ? "" : Rows[i].Cells["ctxtAnalysis"].Value.ToString();
                string key = Rows[i].Cells["ctxtKey"].Value.ToString();
                int id = Convert.ToInt32(Rows[i].Cells["ctxtID"].Value);
                int mainSubjectID = Convert.ToInt32(Rows[i].Cells["cDrpMainSubject"].Value);
                switch (ExamQuery.QuestionType)
                {

                    case ConstInfo.QuestionType.Selection:
                        SelectionInfo si = new SelectionInfo();
                        si.Subject = subject;
                        si.Choice = Rows[i].Cells["ctxtChoice"].Value.ToString();
                        si.Multiple = Convert.ToBoolean(Rows[i].Cells["cChkMultiple"].FormattedValue);

                        si.BreakType = Convert.ToInt32(Rows[i].Cells["ctxtBreakType"].FormattedValue);
                        si.Analysis = analysis;
                        si.Key = key.ToUpper();
                        si.ID = id;
                        si.MainSubjectID = mainSubjectID;
                        Exam.Choice.Update(si);
                        break;

                    case ConstInfo.QuestionType.Fill:
                        FillInfo fi = new FillInfo();
                        fi.ID = id;
                        fi.Subject = subject;
                        fi.Key = key;
                        fi.Analysis = analysis;
                        fi.MainSubjectID = mainSubjectID;
                        Exam.Fill.Update(fi);
                        break;
                    case ConstInfo.QuestionType.Judgement:
                        JudgementInfo ji = new JudgementInfo();
                        ji.ID = id;
                        ji.Subject = subject;
                        ji.Key = Cts.StrTool.ChangeJudgementKey(key);
                        ji.Analysis = analysis;
                        ji.MainSubjectID = mainSubjectID;
                        Exam.Judgement.Update(ji);
                        break;
                    case ConstInfo.QuestionType.Question:
                        QuestionInfo qi = new QuestionInfo();
                        qi.ID = id;
                        qi.Subject = subject;
                        qi.Key = key;
                        qi.MainSubjectID = mainSubjectID;
                        Exam.Question.Update(qi);
                        break;
                }

            }
        }

        private void DataGridAdvanced_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
                return;

            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex < 0)
                return;

            DataGridViewCell cell = Rows[e.RowIndex].Cells[e.ColumnIndex];
            DetailWnd detailWnd = new DetailWnd(cell.Value.ToString());
            if (detailWnd.ShowDialog() == DialogResult.OK)
                cell.Value = detailWnd.Detail;
        }
    }
}
