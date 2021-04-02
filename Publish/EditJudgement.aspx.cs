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
using Cts;
using Model;
using System.Collections.Generic;
using System.Collections.Specialized;
using DataUtility;

namespace Publish
{
    public partial class EditJudgement : PageBase
    {
        private Judge judge;
        private ExamSys sys;

        protected void Page_Load(object sender, EventArgs e)
        {
            judge = new Judge(EasyConfig.ConnectionKey);
            sys = new ExamSys(EasyConfig.ConnectionKey);

            if (!IsPostBack)
            {
                GetMainSubject(drpMainSubject, ConstInfo.QuestionType.Judgement);
                Bind();
            }
        }


        void Bind()
        {
            List<JudgementInfo> jiList = judge.GetListArray(ExamInfoQuery);
            dgList.DataSource = jiList;
            dgList.DataBind();

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                if (dgList.Rows[i] == null)
                    continue;

                CheckBox chkKey = (CheckBox)dgList.Rows[i].FindControl("myKey");


                if (jiList[i].Key.ToLower() == "true")
                    chkKey.Checked = true;
                //  DropDownList drpType = (DropDownList)dgList.Rows[i].FindControl("drpType");
                //if (drpType.Items.FindByValue(msiList[i].Type.ToString()) == null)
                //    return;

                //drpType.SelectedValue = msiList[i].Type.ToString();
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            JudgementInfo ji = new JudgementInfo();

            ji.ExamInfoID = ExamInfoID;
            ji.MainSubjectID = Mid;// drpMainSubject.SelectedValue;
            ji.Key = chkKey.Checked.ToString();
            ji.Subject = StrTool.GetSubjectWithoutDot(txtSubject.Text);

            judge.Add(ji);
            Bind();
            Reset();
        }

        protected void dgList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[e.RowIndex].FindControl("hidIndex");
            judge.Delete(int.Parse(hidIndex.Value));
            Bind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                if (dgList.Rows[i] == null)
                    continue;

                JudgementInfo ji = new JudgementInfo();
                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                TextBox txtSubject = (TextBox)dgList.Rows[i].FindControl("txtSubject");
                CheckBox chkKey = (CheckBox)dgList.Rows[i].FindControl("myKey");
                CheckBox chk = (CheckBox)dgList.Rows[i].FindControl("chk");

                ji.ExamInfoID = ExamInfoID;
                ji.MainSubjectID = Mid;
                ji.Subject = txtSubject.Text;
                ji.Key = chkKey.Checked.ToString();
                ji.Index = ji.ID = int.Parse(hidIndex.Value);

                //if (chk.Checked)
                //    ji.MainSubject = drpMainSubject.SelectedValue;

                judge.Update(ji);
            }

            Bind();
        }

        protected void btnBatchAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBatchSubject.Text))
                return;

            ListDictionary subjects = GetBatchSubjects(txtBatchSubject.Text);

            for (int i = 0; i < subjects.Count; i++)
            {
                if (string.IsNullOrEmpty(subjects[i].ToString().Trim()))
                    continue;

                JudgementInfo ji = new JudgementInfo();

                ji.ExamInfoID = ExamInfoID;
                ji.MainSubjectID = Mid;
                ji.Key = chkKey.Checked.ToString();
                ji.Subject = StrTool.GetSubjectWithoutDot(subjects[i].ToString());

                judge.Add(ji);

            }
            Bind();
            Reset();
        }

        void Reset()
        {
            txtSubject.Text = string.Empty;
            txtBatchSubject.Text = string.Empty;
        }

        protected void btnDeleteByCategory_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
                return;

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dgList.Rows[i].FindControl("chk");

                if (!chk.Checked)
                    continue;

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                judge.Delete(int.Parse(hidIndex.Value));
            }
            Bind();
          
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dgList.Rows[i].FindControl("chk");

                if (!chk.Checked)
                    continue;

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                sys.UpdateMainSubjectID(ConstInfo.QuestionType.Judgement, int.Parse(hidIndex.Value), int.Parse(drpMainSubject.SelectedValue));
            }
            Bind();
        }
    }
}