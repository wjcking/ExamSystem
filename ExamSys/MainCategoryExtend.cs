using System;
using System.Collections.Generic;
using System.Drawing;
using Model;
using ExamSys.Util;
using System.Windows.Forms;
using Cts;

namespace ExamSys
{
    public partial class MainCategory
    {

        private static readonly char[] CHAR_RETURN = "\r\n".ToCharArray();

        private TemplateInfo templateInfo;

        /// <summary>
        /// 执行examinfo.htm发送过来的参数
        /// </summary>
        /// <param name="para"></param>
        public void ActiveScriptMethod(string para)
        {

            switch (para)
            {


                case "refreshanswer":
                    SysData.ExamSysUtil.RefreshUserAnswersByExamInfoID(treeFileView.SelectedNode.Name);
                    break;
                case "refreshincorrect":
                    SysData.ExamSysUtil.RefreshInCorrectNoByExamInfoID(treeFileView.SelectedNode.Name);
                    break;
                case "refreshfav":
                    SysData.ExamSysUtil.RefreshFavByExamInfoID(treeFileView.SelectedNode.Name);
                    break;
                case "examresult":
                    selectedExamFunction = 2;
                    if (treeFileView.SelectedNode.Name == "-1")
                    {
                        MessageBox.Show("请选择左侧试题列表中的题目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }


                    break;
                case "examinfo":
                    selectedExamFunction = 1;
                    break;
                case "clearhistory":
                    if (MessageBox.Show("您确定要删除考试历史记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SysData.AccessHelper.ExecuteNonQuery("DELETE * FROM ExamResult Where ExamInfoID = " + treeFileView.SelectedNode.Name);
                        EFDDocument.GetExamResultHtml(treeFileView.SelectedNode.Name, webPanel);

                    }
                    break;
                case "help":
                    if (System.IO.File.Exists("help.chm"))
                        System.Diagnostics.Process.Start("help.chm");
                    break;


                default:
                    break;
            }
        }



        public void Run(string jsonTemplateInfo)
        {
            Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonTemplateInfo);

            templateInfo = new TemplateInfo();

            templateInfo.Title = values["Title"].ToString();
            templateInfo.FileName = values["ExamInfoID"].ToString();
            templateInfo.TemplatPath = SysConfig.TemplatePath();
            templateInfo.ExamInfoID = Convert.ToInt32(values["ExamInfoID"]);
            templateInfo.IsShowSelection = Convert.ToBoolean(values["IsShowSelection"]);
            templateInfo.IsShowJudgement = Convert.ToBoolean(values["IsShowJudgement"]);
            templateInfo.IsShowFill = Convert.ToBoolean(values["IsShowFill"]);
            templateInfo.IsShowQuestion = Convert.ToBoolean(values["IsShowQuestion"]);

            //bool isLimitedTime = Convert.ToBoolean(chkIsLimtedTime.GetAttribute("checked"));

            //if (isLimitedTime)
            //    templateInfo.LimitedTime = Convert.ToInt32(txtTime.GetAttribute("value"));
            //else
            templateInfo.LimitedTime = 0;

            int displayStyleSelectedValue = Convert.ToInt32(values["DisplayStyle"]);
            int testway = Convert.ToInt32(values["TestWay"]);

            templateInfo.DisplayStyle = (ConstInfo.DisplayStyle)displayStyleSelectedValue;
            templateInfo.TestWay = (ConstInfo.TestWay)testway;
            templateInfo.PlatformStyle = values["PlatformStyle"].ToString();
            templateInfo.WindowSize = this.WindowState.ToString();

            Cursor = Cursors.WaitCursor;

            Platform.Activate(templateInfo);
            Cursor = Cursors.Default;


        }

    }
}
