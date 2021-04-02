using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using Cts;
using System.Text;
using DataUtility;
using Model;
using System.Collections.Generic;

namespace Publish
{
    public partial class Web : MasterPage
    {
        protected string sonPageName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            sonPageName = body.Page.GetType().Name.Substring(0, body.Page.GetType().Name.IndexOf("_")).ToLower();
            MajorSubject ms = new MajorSubject(EasyConfig.ConnectionKey);
            ExamSys es = new ExamSys(EasyConfig.ConnectionKey);


            int mid = (Request["Mid"] == null) ? 0 : Convert.ToInt32(Request["Mid"]);
            int examInfoID = (Request["ExamInfoID"] == null) ? 0 : Convert.ToInt32(Request["ExamInfoID"]);

            MainSubjectInfo msi = null;
            ExamInfo examInfo = null;

            if (mid != 0)
                msi = ms.GetModel(mid);

            if (examInfoID != 0)
                examInfo = es.GetModel(examInfoID);

            if (sonPageName == "default")
            {
                divTitle.InnerText = "EasyFound ExamPaper Management System ";
                return;
            }


            string msInfo = (msi == null) ? String.Empty : msi.Subject;
            string esInfo = (examInfo == null) ? string.Empty : examInfo.Name;

            if (!string.IsNullOrEmpty(msInfo))
            {

                divTitle.InnerText += esInfo + " -> " + msInfo;
                header.Title = divTitle.InnerText;
            }
            else
            {
                divTitle.InnerHtml = this.header.Title;
            }


        }

        protected string GetGuideList()
        {
            StringBuilder incGuide = new StringBuilder();

            if (String.IsNullOrEmpty(Request.QueryString["ExamInfoID"]))
                return string.Empty;

            List<MainSubjectInfo> msiList = new MajorSubject(EasyConfig.ConnectionKey).GetListArray(" 100 = 100 ORDER BY [Sort] ASC");

            //写入导航下拉单
            incGuide.Append("<select id='drpGuide' style='background-color:  #990000;  font-family:Arial;  font-size:12px; color:white;' onchange='guide();'>");
            incGuide.Append("<option value=\"\">请选择导航信息</option>\r\n");
            incGuide.Append("<option value=\"\">-------------------------</option>\r\n");
            incGuide.Append("<option value=\"0\">试题管理中心</option>\r\n");
            incGuide.Append("<option value=\"1\">试卷大题管理</option>\r\n");
            incGuide.Append("<option value=\"2\">导出图库，数据库</option>\r\n");

            for (int i = 0; i < msiList.Count; i++)
            {
                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msiList[i].Type;

                //下拉单
                string optionValue = "";
                string optionParam = "Mid=" + msiList[i].ID;

                incGuide.Append("<option value=\"\">-------------------------</option>\r\n");

                if (qt == ConstInfo.QuestionType.Selection)
                {
                    optionValue = string.Format("<option value=\"/EditSelection.aspx?{0}\">添加 {1}</option>\r\n", optionParam, msiList[i].Subject);
                    optionValue += string.Format("<option value=\"/EditChoices.aspx?{0}\">修改 {1}</option>\r\n ", optionParam, msiList[i].Subject);
                }
                else if (qt == ConstInfo.QuestionType.Judgement)
                    optionValue = string.Format("<option value=\"/EditJudgement.aspx?{0}\">{1}</option>\r\n ", optionParam, msiList[i].Subject);
                else if (qt == ConstInfo.QuestionType.Fill)
                    optionValue = string.Format("<option value=\"/EditFill.aspx?{0}\">{1}</option>\r\n ", optionParam, msiList[i].Subject);
                else if (qt == ConstInfo.QuestionType.Question)
                    optionValue = string.Format("<option value=\"/EditQuestion.aspx?{0}\">{1}</option>\r\n ", optionParam, msiList[i].Subject);
                else
                    optionValue = "";

                incGuide.Append(optionValue);
            }
            incGuide.Append("</select>");

            return incGuide.ToString();
        }
    }
}