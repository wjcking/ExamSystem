using System;
using System.Text;
using System.Windows.Forms;
using Cts;
using Model;
using ExamSys.Util;

namespace ExamSys
{
    public partial class HandIn : Form
    {
        private TemplateInfo templateInfo = null;

        public TemplateInfo TemplateInfo
        {
            get { return templateInfo; }
            set { templateInfo = value; }
        }

        public HandIn()
        {
            InitializeComponent();
            //提交
            SysConfig.IsHandedIn = true;


            Load += delegate { lbTitle.Text = templateInfo.Title; };
            chkRecordResult.Checked = Convert.ToBoolean(SysConfig.SettingsHelper.GetValue(Settings.RecordResult));
            chkRecordUserAnswer.Checked = Convert.ToBoolean(SysConfig.SettingsHelper.GetValue(Settings.RecordUserAnswer));
            chkRecordIncorrect.Checked = Convert.ToBoolean(SysConfig.SettingsHelper.GetValue(Settings.RecordIncorrect));

            chkRecordResult.CheckedChanged += delegate { SysConfig.SettingsHelper.SetValue(Settings.RecordResult, chkRecordResult.Checked.ToString().ToLower()); };
            chkRecordUserAnswer.CheckedChanged += delegate { SysConfig.SettingsHelper.SetValue(Settings.RecordUserAnswer, chkRecordUserAnswer.Checked.ToString().ToLower()); };
            chkRecordIncorrect.CheckedChanged += delegate { SysConfig.SettingsHelper.SetValue(Settings.RecordIncorrect, chkRecordIncorrect.Checked.ToString().ToLower()); };

            lbHandinTime.Text = "提交时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
         
            int totalCorrectNumber = 0;
            int totalIncorrecNumber = 0;
            int totalSubjectSum = 0;
            float totalCorrectScore = 0;
            float totalScore = 0;

            ListViewItem lviSubject = null;
            ListViewItem.ListViewSubItem lviSubjectSum = null;
            ListViewItem.ListViewSubItem lviCorrectNumber = null;
            ListViewItem.ListViewSubItem lviIncorrectNumber = null;
            ListViewItem.ListViewSubItem lviEachPoint = null;
            ListViewItem.ListViewSubItem lviTotalScore = null;
            ListViewItem.ListViewSubItem lviCorrectScore = null;
            ListViewItem.ListViewSubItem lviPercent = null;

            foreach (MainSubjectInfo msi in EPBuilder.CurrentMsiList)
            {
                lviSubject = new ListViewItem(msi.Subject);

                lviSubjectSum = new ListViewItem.ListViewSubItem();
                lviCorrectNumber = new ListViewItem.ListViewSubItem();
                lviIncorrectNumber = new ListViewItem.ListViewSubItem();
                lviEachPoint = new ListViewItem.ListViewSubItem();
                lviTotalScore = new ListViewItem.ListViewSubItem();
                lviCorrectScore = new ListViewItem.ListViewSubItem();
                lviPercent = new ListViewItem.ListViewSubItem();

                lviCorrectNumber.Name = "lviCorrectNumber";
                lviCorrectScore.Name = "lviCorrectScore";
                lviTotalScore.Name = "lviTotalScore";
                lviSubjectSum.Name = "lviSubjectSum";
                lviSubjectSum.Text = msi.SubjectSum.ToString();
                lviPercent.Name = "lviPercent";
                lviIncorrectNumber.Name = "lviIncorrectNumber";

                int correctNumber = 0;
                foreach (ExamItemInfo ei in EPBuilder.CurrentExamItemList)
                {
                    if (msi.CurrentID != ei.MainSubject)
                        continue;

                    if (String.IsNullOrEmpty(ei.UserAnswer))
                        continue;

                    ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msi.Type;

                    switch (qt)
                    {
                        case ConstInfo.QuestionType.Selection:
                            if (ei.UserAnswer == ei.Key.ToUpper().Trim())
                                correctNumber++;
                            else
                                ei.IsCorrect = false;
                            break;

                        case ConstInfo.QuestionType.Fill:

                            if (ei.Key.Trim().IndexOf(ei.UserAnswer.Trim()) > -1)
                                correctNumber++;
                            else
                                ei.IsCorrect = false;
                            break;

                        case ConstInfo.QuestionType.Judgement:

                            bool judgeAnswer = ei.UserAnswer.Trim() == "√" ? true : false;

                            if (judgeAnswer.ToString().ToLower().Trim() == ei.Key.ToLower().Trim())
                                correctNumber++;
                            else
                                ei.IsCorrect = false;
                            break;

                        case ConstInfo.QuestionType.Question:

                            if (ei.Key.IndexOf(ei.UserAnswer) > -1 && ei.UserAnswer.Length > ei.Key.Length / 2)
                                correctNumber++;
                            else
                                ei.IsCorrect = false;
                            break;
                    }
                }

                totalCorrectNumber += correctNumber;
                totalSubjectSum += msi.SubjectSum;
                totalScore += msi.SubjectSum * msi.EachPoint;
                totalCorrectScore += correctNumber * msi.EachPoint;
                totalIncorrecNumber += msi.SubjectSum - correctNumber;

                lviCorrectNumber.Text = correctNumber.ToString();
                lviEachPoint.Text = msi.EachPoint.ToString();
                lviTotalScore.Text = Convert.ToString(msi.SubjectSum * msi.EachPoint);
                lviCorrectScore.Text = Convert.ToString(correctNumber * msi.EachPoint);
                lviIncorrectNumber.Text = Convert.ToString(msi.SubjectSum - correctNumber);
                //正确率
                //   double dividedVal = Math.Round(Convert.ToDouble(correctNumber) / Convert.ToDouble(msi.SubjectSum), 2);

                double dividedVal = Math.Round(Convert.ToDouble(correctNumber * msi.EachPoint) / Convert.ToDouble(msi.SubjectSum * msi.EachPoint), 2);
                lviPercent.Text = Convert.ToString(dividedVal * 100) + "%";
                lviCorrectNumber.BackColor = SysConfig.CategoryColor;
                lviCorrectScore.BackColor = SysConfig.CategoryColor;

                lviSubject.SubItems.Add(lviSubjectSum);
                lviSubject.SubItems.Add(lviEachPoint);
                lviSubject.SubItems.Add(lviCorrectNumber);
                lviSubject.SubItems.Add(lviIncorrectNumber);
                lviSubject.SubItems.Add(lviTotalScore);
                lviSubject.SubItems.Add(lviCorrectScore);
                lviSubject.SubItems.Add(lviPercent);

                lvResult.Items.Add(lviSubject);
            }

            //汇总
            lviSubject = new ListViewItem(SysConfig.Subject_TotalName);
            lviSubjectSum = new ListViewItem.ListViewSubItem();
            lviEachPoint = new ListViewItem.ListViewSubItem();
            lviCorrectNumber = new ListViewItem.ListViewSubItem();
            lviIncorrectNumber = new ListViewItem.ListViewSubItem();
            lviTotalScore = new ListViewItem.ListViewSubItem();
            lviCorrectScore = new ListViewItem.ListViewSubItem();
            lviPercent = new ListViewItem.ListViewSubItem();

            lviCorrectNumber.Name = "lviCorrectNumber";
            lviCorrectScore.Name = "lviCorrectScore";
            lviTotalScore.Name = "lviTotalScore";
            lviSubjectSum.Name = "lviSubjectSum";
            lviPercent.Name = "lviPercent";
            lviIncorrectNumber.Name = "lviIncorrectNumber";

            //double dividedTotalVal = Math.Round(Convert.ToDouble(totalCorrectNumber) / Convert.ToDouble(totalSubjectSum), 2);
            double dividedTotalVal = Math.Round(Convert.ToDouble(totalCorrectScore) / Convert.ToDouble(totalScore), 2);

            //记录
            if (SysData.SubmitInfo != null) {
            SysData.SubmitInfo.EndTime = DateTime.Now;
            SysData.SubmitInfo.TotalNumber = totalSubjectSum;
            SysData.SubmitInfo.CorrectNumber = totalCorrectNumber;
        }
            lviSubjectSum.Text = totalSubjectSum.ToString();
            lviEachPoint.Text = "0";
            lviCorrectNumber.Text = totalCorrectNumber.ToString();
            lviIncorrectNumber.Text = totalIncorrecNumber.ToString();
            lviTotalScore.Text = totalScore.ToString();
            lviCorrectScore.Text = totalCorrectScore.ToString();
            lviPercent.Text = Convert.ToString(dividedTotalVal * 100) + "%";

            lviSubject.SubItems.Add(lviSubjectSum);
            lviSubject.SubItems.Add(lviEachPoint);
            lviSubject.SubItems.Add(lviCorrectNumber);
            lviSubject.SubItems.Add(lviIncorrectNumber);
            lviSubject.SubItems.Add(lviTotalScore);
            lviSubject.SubItems.Add(lviCorrectScore);
            lviSubject.SubItems.Add(lviPercent);

            lvResult.Items.Add(lviSubject);

        }

        private void AddExamResult()
        {
            //如果是查询就记录，就更新查询记录中的分数
            if (templateInfo.ExamQueryStyle == TemplateInfo.QueryStyle_Search)
            {
                for (int i = 0; i < lvResult.Items.Count -1; i++ )
                {
                    StringBuilder reorganizedQuery = new StringBuilder();
                    reorganizedQuery.AppendFormat(" UPDATE History SET Score = '{0}/{1}' ", lvResult.Items[i].SubItems["lviCorrectScore"].Text, lvResult.Items[i].SubItems["lviTotalScore"].Text);
                    reorganizedQuery.Append("  , TestTimes = TestTimes + 1 ");
                    reorganizedQuery.AppendFormat("  , [Percent] ='{0}' ", lvResult.Items[i].SubItems["lviPercent"].Text);
                    reorganizedQuery.Append(" WHERE ID = ").Append(templateInfo.ExamHistoryList[i].ID);
                    SysData.AccessHelper.ExecuteNonQuery(reorganizedQuery.ToString());
                }
            }


            if (chkRecordResult.Checked && templateInfo.ExamQueryStyle ==  TemplateInfo.QueryStyle_Normal)
            {
            

                DataUtility.ExamResult examResult = new DataUtility.ExamResult();
                ExamResultInfo er = new ExamResultInfo();
                er.ExamInfoID = templateInfo.ExamInfoID;
                er.DisplayStyle = Convert.ToInt16(templateInfo.DisplayStyle);
                er.IsLimitedTime = (templateInfo.LimitedTime <= 0) ? false : true;
                er.Name = templateInfo.Title;
                er.TestWay = templateInfo.TestWay.ToString();

                StringBuilder mainSubjects = new StringBuilder();
                StringBuilder correctNum = new StringBuilder();
                StringBuilder scores = new StringBuilder();

                foreach (ListViewItem lvi in lvResult.Items)
                {
                    mainSubjects.Append(lvi.Text + ",");
                    correctNum.Append(lvi.SubItems["lviCorrectNumber"].Text + ",");
                    scores.Append(lvi.SubItems["lviCorrectScore"].Text + ",");
                }

                er.CorrectNum = correctNum.ToString();
                er.TestedScore = scores.ToString();
                er.TestedSubject = mainSubjects.ToString();
                // null
                er.Content = "";
                examResult.Add(er);
            }

            progressBar.Visible = true;
            //清空错误个数
            SysData.ExamSysUtil.RefreshUserAnswersByExamInfoID(TemplateInfo.ExamInfoID.ToString());
            //清空错误个数
            SysData.ExamSysUtil.RefreshInCorrectNoByExamInfoID(TemplateInfo.ExamInfoID.ToString());
            if (chkRecordUserAnswer.Checked)
            {
                progressBar.Value = 0;
                progressBar.Maximum = EPBuilder.CurrentExamItemList.Count;
                progressBar.Tag = Text = "正在记录用户作答...";

                foreach (ExamItemInfo ei in EPBuilder.CurrentExamItemList)
                {
                    progressBar.Increment(1);
                    if (String.IsNullOrEmpty(ei.UserAnswer))
                        continue;

                    SysData.ExamSysUtil.UpdateUserAnswers(((ConstInfo.QuestionType)ei.CurrentMainSubject.Type), ei.UserAnswer, ei.ID.ToString());
                }
            }
           
            if (chkRecordIncorrect.Checked)
            {
                progressBar.Value = 0;
                progressBar.Maximum = EPBuilder.CurrentExamItemList.Count;
                progressBar.Tag = Text = "正在记录错误次数...";
                foreach (ExamItemInfo ei in EPBuilder.CurrentExamItemList)
                {
                    progressBar.Increment(1);

                    if (!ei.IsCorrect)
                         SysData.ExamSysUtil.UpdateInCorrectNo(((ConstInfo.QuestionType)ei.CurrentMainSubject.Type), 1, ei.ID.ToString());
                }
            }

            //如果是正常考试，就更新当前试卷测试次数
            if (templateInfo.ExamQueryStyle == TemplateInfo.QueryStyle_Normal)
            {
                int favCount = SysData.StatisticUtil.GetFavCountByExamInfoID(templateInfo.ExamInfoID);
                int emptyCount = SysData.StatisticUtil.GetEmptyCountByExamInfoID(templateInfo.ExamInfoID);
                int IncorrectCount = SysData.StatisticUtil.GetIncorrectCountByExamInfoID(templateInfo.ExamInfoID);
                //如果没有执行填充试卷总数则更新当前试卷总数
                ExamInfo totalExamInfo = SysData.GetExamListByID(templateInfo.ExamInfoID);

                if (totalExamInfo.TotalCount <= 0)
                {
                   int totalCount=  SysData.StatisticUtil.GetTotalCountByExamInfoID(templateInfo.ExamInfoID);
                    SysData.AccessHelper.ExecuteNonQuery(String.Format("UPDATE ExamInfo  SET TotalCount={0} WHERE ID ={1}", totalCount,templateInfo.ExamInfoID));
                }
                SysConfig.SettingsHelper.SetValue(Settings.LastExamSubject, templateInfo.Title);
                StringBuilder updatedResult = new StringBuilder();
                updatedResult.Append(" UPDATE ExamInfo  SET ");
                updatedResult.Append("   TestTimes = TestTimes + 1 , ");
                updatedResult.Append("  LastTestTime=Date()+Time() , ");
                updatedResult.AppendFormat(" IncorrectCount = {0}, ",IncorrectCount);
                updatedResult.AppendFormat(" EmptyCount = {0}, ", emptyCount);
                updatedResult.AppendFormat(" FavCount = {0} ",favCount);
                updatedResult.AppendFormat(" WHERE ID = {0} ",templateInfo.ExamInfoID);
                SysData.AccessHelper.ExecuteNonQuery(updatedResult.ToString());
            }
      
            //写入json缓存
            SysData.GenerateJson();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            AddExamResult();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnToPlatform_Click(object sender, EventArgs e)
        {
            AddExamResult();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("重新考试将清除您当前的作答，确定吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.Retry;
                Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (SysData.SubmitInfo != null)
                SysConfig.Decorater.Activate(typeof(Submit));
            else
                MessageBox.Show("当前没有考试结果，请重新考试");
        }

    }
}
