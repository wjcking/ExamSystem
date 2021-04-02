using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataUtility;
using Model;

namespace Publish
{
    public partial class FormInside : PageBase
    {
        private ExamSys examSys;

        protected void Page_Load(object sender, EventArgs e)
        {
            examSys = new ExamSys(EasyConfig.ConnectionKey);

            if (!IsPostBack)
            { 
                if (ExamInfoID == 0)                 
                    return;
             
                try
                {
                    Bind();
                }
                catch (Exception exp)
                {
                    txtContent.Text = exp.Message;
                    return;
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ExamInfo ei = new ExamInfo();

            ei.Name = txtMaterialName.Text;
            ei.CanRandom = chkCanRandom.Checked;
            ei.Content = txtContent.Text;
            ei.Time = Convert.ToInt32(txtTime.Text);
            ei.ID = ExamInfoID;
            ei.IsMaterial = chkIsMaterial.Checked;

            examSys.Update(ei);
           // if (ExamInfoID == 0)
              //  EasyConfig.DataSys.ExecuteNonQuery(string.Format("UPDATE Easy SET Title='{0}'", txtEfdTitle.Text));

        }

        void Bind()
        {          
            ExamInfo ei = examSys.GetModel(ExamInfoID);

            txtMaterialName.Text = ei.Name;
            txtContent.Text = ei.Content;
            txtTime.Text = ei.Time.ToString();
            chkIsMaterial.Checked = ei.IsMaterial;
            MajorSubject ms = new MajorSubject(EasyConfig.ConnectionKey);
            List<MainSubjectInfo> msiList = ms.GetListArray(" 1000 = 1000 ORDER BY [Sort]");

            rptList.DataSource = msiList;
            rptList.DataBind();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlGenericControl spanCount = (HtmlGenericControl)rptList.Items[i].FindControl("spanCount");
                HtmlInputHidden hidIndex = (HtmlInputHidden)rptList.Items[i].FindControl("hidIndex");
                Literal txtType = (Literal)rptList.Items[i].FindControl("txtType");

                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msiList[i].Type;

                string editUrl = "";
                string requestParam = "ExamInfoID=" + ExamInfoID + "&Mid=" + hidIndex.Value;

                TemplateInfo templateInfo = new TemplateInfo();
                templateInfo.ExamInfoID = ExamInfoID;

                spanCount.InnerText = ms.GetSubjectNumber(qt, msiList[i].ID, templateInfo).ToString();

                if (qt == ConstInfo.QuestionType.Selection)
                    editUrl = string.Format("<a target=\"_blank\"  href=\"/EditSelection.aspx?{0}\">添加</a>/ <a  target=\"_blank\" href=\"/EditChoices.aspx?{0}\">修改 选择题</a> ", requestParam);
                else if (qt == ConstInfo.QuestionType.Judgement)
                    editUrl = string.Format("<a target=\"_blank\"  href=\"/EditJudgement.aspx?{0}\">判断题</a> ", requestParam);
                else if (qt == ConstInfo.QuestionType.Fill)
                    editUrl = string.Format("<a target=\"_blank\"  href=\"/EditFill.aspx?{0}\">填空题</a> ", requestParam);
                else if (qt == ConstInfo.QuestionType.Question)
                    editUrl = string.Format("<a target=\"_blank\"  href=\"/EditQuestion.aspx?{0}\">简答或论述题</a> ", requestParam);
                else
                    editUrl = "";

                txtType.Text = editUrl;
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            EasyConfig.DataSys.ExecuteNonQuery("DELETE * FROM ExamInfo WHERE ID=" + ExamInfoID.ToString());
            EasyConfig.DataSys.ExecuteNonQuery("DELETE * FROM Selection WHERE ExamInfoID=" + ExamInfoID.ToString());
            EasyConfig.DataSys.ExecuteNonQuery("DELETE * FROM Judgement WHERE ExamInfoID=" + ExamInfoID.ToString());
            EasyConfig.DataSys.ExecuteNonQuery("DELETE * FROM Fill WHERE ExamInfoID=" + ExamInfoID.ToString());
            EasyConfig.DataSys.ExecuteNonQuery("DELETE * FROM Question WHERE ExamInfoID=" + ExamInfoID.ToString());
            EasyConfig.DataSys.ExecuteNonQuery("DELETE * FROM ExamResult WHERE ExamInfoID=" + ExamInfoID.ToString());

            ClientScript.RegisterStartupScript(this.GetType(), "del", "<script type=\"text/javascript\">parent.location='default.aspx?state=del';</script>");
        }

    }
}
