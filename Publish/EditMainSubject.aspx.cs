using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Model;
using Cts;
using System.Collections.Generic;
using DataUtility;
using System.Text;
using System.IO; 

namespace Publish
{
    public partial class EditMainSubject : PageBase
    {
        private MajorSubject ms; 
        protected int subjectSum = 0;
        protected float scoreSum = 0;

        protected void Page_Load(object sender, EventArgs e)
        { 
            ms = new MajorSubject(EasyConfig.ConnectionKey);

            if (!IsPostBack)
            {
              Bind();             
            }
        }

        void Bind()
        {

            List<MainSubjectInfo> msiList = new MajorSubject(EasyConfig.ConnectionKey).GetListArray(" 100 = 100 ORDER BY [Sort] ASC");


            dgList.DataSource = msiList;
            dgList.DataBind();

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                if (dgList.Rows[i] == null)
                    continue;

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                Literal txtType = (Literal)dgList.Rows[i].FindControl("txtType");
                HtmlGenericControl spanCount = (HtmlGenericControl)dgList.Rows[i].FindControl("spanCount");
                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msiList[i].Type;

                string editUrl = "";
                string requestParam = "ExamInfoID=" + ExamInfoID + "&Mid=" + hidIndex.Value;

                TemplateInfo templateInfo = new TemplateInfo();
                templateInfo.ExamInfoID = ExamInfoID;

                spanCount.InnerText = ms.GetSubjectNumber(qt, msiList[i].ID, templateInfo).ToString();

                if (qt == ConstInfo.QuestionType.Selection)
                    editUrl = string.Format("<a  href=\"/EditSelection.aspx?{0}\">添加</a>/ <a  href=\"/EditChoices.aspx?{0}\">修改 选择题</a> ", requestParam);
                else if (qt == ConstInfo.QuestionType.Judgement)
                    editUrl = string.Format("<a  href=\"/EditJudgement.aspx?{0}\">判断题</a> ", requestParam);
                else if (qt == ConstInfo.QuestionType.Fill)
                    editUrl = string.Format("<a  href=\"/EditFill.aspx?{0}\">填空题</a> ", requestParam);
                else if (qt == ConstInfo.QuestionType.Question)
                    editUrl = string.Format("<a  href=\"/EditQuestion.aspx?{0}\">简答或论述题</a> ", requestParam);
                else
                    editUrl = "";


                txtType.Text = editUrl;

            }

        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            MainSubjectInfo msi = new MainSubjectInfo();

            msi.Subject = txtSubject.Text;
           msi.TopicTypeID = short.Parse(drpType.SelectedValue);
          
           
            msi.Note = txtNote.Text;
            msi.Analysis = txtAnalysis.Text;
            msi.Content = txtContent.Text;
            msi.EachPoint = float.Parse(txtEachPoint.Text);

            ms.Add(msi);
            Bind();
            Reset();
        }

        protected void dgList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[e.RowIndex].FindControl("hidIndex");

            int id = int.Parse(hidIndex.Value);
            ms.Delete(id);
            Bind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                if (dgList.Rows[i] == null)
                    continue;

                MainSubjectInfo msi = new MainSubjectInfo();
                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                HtmlInputHidden hidType = (HtmlInputHidden)dgList.Rows[i].FindControl("hidType");
                //       DropDownList drpType = (DropDownList)dgList.Rows[i].FindControl("drpType");
                TextBox txtSubject = (TextBox)dgList.Rows[i].FindControl("txtSubject");
                TextBox txtNote = (TextBox)dgList.Rows[i].FindControl("txtNote");
                TextBox txtContent = (TextBox)dgList.Rows[i].FindControl("txtContent");
                TextBox txtAnalysis = (TextBox)dgList.Rows[i].FindControl("txtAnalysis");
                TextBox txtSort = (TextBox)dgList.Rows[i].FindControl("txtSort");
                Literal txtType = (Literal)dgList.Rows[i].FindControl("txtType");
                TextBox txtEachPoint = (TextBox)dgList.Rows[i].FindControl("txtEachPoint");

                msi.Index = msi.ID = int.Parse(hidIndex.Value);
                msi.Subject = txtSubject.Text;
                //msi.Score = Convert.ToInt32(txtScore.Text);
                msi.EachPoint = float.Parse(txtEachPoint.Text);
                msi.Type = int.Parse(hidType.Value);
                  msi.Sort= Convert.ToInt32(txtSort.Text);

                msi.Note = txtNote.Text;
                msi.Content = txtContent.Text;
                msi.Analysis = txtAnalysis.Text;

                ms.Update(msi);
            }

            Bind();
        }

        void Reset()
        {
            txtSubject.Text = string.Empty;
            txtContent.Text = string.Empty;
            txtAnalysis.Text = string.Empty;
            txtNote.Text = string.Empty;
        }
        protected void btnDel_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in dgList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                HtmlInputHidden hidIndex = (HtmlInputHidden)row.FindControl("hidIndex");

                if (chk.Checked)
                    ms.Delete(int.Parse(hidIndex.Value));
            }

            Bind();
        }
        
  

        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {          
            Bind();
        }

    
    }                             

}