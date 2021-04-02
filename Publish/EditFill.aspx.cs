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
    public partial class EditFill : PageBase
    {
        protected FillBlank fill;
        private ExamSys sys;

        protected void Page_Load(object sender, EventArgs e)
        {
            fill = new FillBlank(EasyConfig.ConnectionKey);
            sys = new ExamSys(EasyConfig.ConnectionKey);

            if (!IsPostBack)
            {
                GetMainSubject(drpMainSubject, ConstInfo.QuestionType.Fill);
                Bind();
            }
        }

        void Bind()
        {
            
            List<FillInfo> fiList = fill.GetListArray(ExamInfoQuery);

            dgList.DataSource = fiList;
            dgList.DataBind();

            //for (int i = 0; i < dgList.Rows.Count; i++)
            //{
            //    if (dgList.Rows[i] == null)
            //        continue;

            //    CheckBox chkKey = (CheckBox)dgList.Rows[i].FindControl("chkKey");

            //    if (fiList[i].Key.ToLower() == "true")
            //        chkKey.Checked = true;
            //}
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            FillInfo fi = new FillInfo();

            fi.ExamInfoID = ExamInfoID;
            fi.MainSubjectID = int.Parse(drpMainSubject.SelectedValue); ;
        
            fi.Key = txtKey.Text;
            fi.Subject = StrTool.GetSubjectWithoutDot(txtSubject.Text);

            fill.Add(fi);
            Bind();
            Reset();
        }

        protected void dgList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[e.RowIndex].FindControl("hidIndex");
            fill.Delete(int.Parse(hidIndex.Value));
            Bind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                if (dgList.Rows[i] == null)
                    continue;

                FillInfo fi = new FillInfo();

                TextBox txtSubject = (TextBox)dgList.Rows[i].FindControl("txtSubject");
                TextBox txtKey = (TextBox)dgList.Rows[i].FindControl("txtKey");
                CheckBox chk = (CheckBox)dgList.Rows[i].FindControl("chk");
                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
              

                fi.ExamInfoID = ExamInfoID;
                fi.MainSubjectID = Mid;
                fi.Subject = txtSubject.Text;
                fi.Key = txtKey.Text;
                fi.Index = fi.ID = Convert.ToInt32(hidIndex.Value);

                fill.Update(fi);
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

                FillInfo fi = new FillInfo();

                fi.ExamInfoID = ExamInfoID;
                fi.MainSubjectID = Mid;// int.Parse(drpMainSubject.SelectedValue);  
                fi.Key = txtKey.Text;
                fi.Subject = StrTool.GetSubjectWithoutDot(subjects[i].ToString());

                fill.Add(fi);

            }

            Bind();
            Reset();
        }

        void Reset()
        {
            txtSubject.Text = string.Empty;
            txtBatchSubject.Text = string.Empty;
            txtKey.Text = string.Empty;
        }

        protected void btnDeleteByCategory_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
                return;

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                CheckBox chk = (CheckBox)dgList.Rows[i].FindControl("chk");

                if (!chk.Checked)
                    continue;

                fill.Delete(int.Parse(hidIndex.Value));
            }
            Bind();
        }

        protected void btnBatchAddKey_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
                return;

            ListDictionary key = GetBatches(txtBatchKey.Text, ConstInfo.QuestionType.Fill);

            if (dgList.Rows.Count == 0)
                return;

            if (key == null)
            {
                MsgBox("答案添加有误或者题目数有相同");
                return;
            }

            if (key.Count != dgList.Rows.Count)
            {
                MsgBox("整体数量与当前试题数量不相等，不能批量添加，请检查答案数量是否准确");
                return;
            }

            for (int i = 0; i < key.Count; i++)
            {
                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                sys.UpdateKey(ConstInfo.QuestionType.Fill, int.Parse(hidIndex.Value), key[i].ToString().Trim());

            }
            MsgBox("批量更新完毕");
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