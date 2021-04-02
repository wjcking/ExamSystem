using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ExamSys.Util;
using Model;

namespace ExamSys.Options
{
    public partial class ResetExam : UserControl
    {

        public ResetExam()
        {
            InitializeComponent();
            drpExamInfo.BindExamInfo(true);
        }

        public void Save()
        {

            ListItemExamInfo li = drpExamInfo.SelectedItem as ListItemExamInfo;


            if (li == null)
            {
                if (chkResetResult.Checked)
                    SysData.AccessHelper.ExecuteNonQuery("DELETE * FROM ExamResult");

                if (chkResetFav.Checked)
                {
                    SysData.AccessHelper.ExecuteNonQuery(string.Format("DELETE * FROM history WHERE SearchType = '{0}'", ConstInfo.TestWay.我的收藏));
                    SysData.ExamSysUtil.RefreshFav();
                }
                if (chkResetIncorrect.Checked)
                {
                    SysData.AccessHelper.ExecuteNonQuery(string.Format("DELETE * FROM history WHERE SearchType = '{0}'", ConstInfo.TestWay.错题重做));
                    SysData.ExamSysUtil.RefreshInCorrect();
                }
                if (chkResetUserAnswer.Checked)
                { 
                    SysData.ExamSysUtil.RefreshUserAnswers();
                }
                if (chkResetTestTime.Checked)
                    SysData.AccessHelper.ExecuteNonQuery("UPDATE ExamInfo SET TestTimes = 0");

                if (chkResetExamInfoKeyword.Checked)
                    SysData.AccessHelper.ExecuteNonQuery("UPDATE ExamInfo SET [Keyword]='' ");

                if (chkResetOutlineKeyword.Checked)
                    SysData.AccessHelper.ExecuteNonQuery("UPDATE Outline SET [Keyword]='' ");


            }
            else
            {
                if (chkResetResult.Checked)
                    SysData.AccessHelper.ExecuteNonQuery("DELETE * FROM ExamResult WHERE ExamInfoID="+ li.ID.ToString());

                if (chkResetFav.Checked)
                {
                    SysData.AccessHelper.ExecuteNonQuery(string.Format("DELETE * FROM history WHERE ExamInfoID = {0} AND SearchType = '{1}'", li.ExamInfo.ID, ConstInfo.TestWay.我的收藏));
                    SysData.ExamSysUtil.RefreshFavByExamInfoID(li.ID.ToString());
                }
                if (chkResetIncorrect.Checked)
                {
                    SysData.AccessHelper.ExecuteNonQuery(string.Format("DELETE * FROM history WHERE ExamInfoID = {0} AND  SearchType = '{1}'", li.ExamInfo.ID, ConstInfo.TestWay.错题重做));
                    SysData.ExamSysUtil.RefreshInCorrectNoByExamInfoID(li.ID.ToString());
                }
                if (chkResetUserAnswer.Checked)
                    SysData.ExamSysUtil.RefreshUserAnswersByExamInfoID(li.ID.ToString());

                if (chkResetTestTime.Checked)
                    SysData.AccessHelper.ExecuteNonQuery("UPDATE ExamInfo SET TestTimes = 0 WHERE ID=" + li.ID.ToString());

                if (chkResetExamInfoKeyword.Checked)
                    SysData.AccessHelper.ExecuteNonQuery("UPDATE ExamInfo SET [Keyword]='' WHERE ID=" + li.ID.ToString());
                 
            }
            //   SysConfig.SettingsHelper.SetValue(IsShowSplash, chkSplash.Checked.ToString().ToLower());
            //写入json缓存
            SysData.GenerateJson();
        }

          

    }
}
