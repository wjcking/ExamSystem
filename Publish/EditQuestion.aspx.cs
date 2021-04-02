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
using System.IO;


namespace Publish
{
    public partial class EditQuestion : PageBase
    {
        protected Quest question;
        private ExamSys sys;

        protected void Page_Load(object sender, EventArgs e)
        {
            question = new Quest(EasyConfig.ConnectionKey);
            sys = new ExamSys(EasyConfig.ConnectionKey);

            if (!IsPostBack)
            {
                GetMainSubject(drpMainSubject, ConstInfo.QuestionType.Question);
                Bind();
            }
        } 
        private void GetDirectories(string path, string searchText)
        {
            if (!Directory.Exists(path))
                return;

            string[] directories = Directory.GetDirectories(path);

            foreach (string dir in directories)
            {
                drpFolders.Items.Add(new ListItem(dir, dir.Replace(EasyConfig.PathRoot, string.Empty)));
                GetDirectories(dir, searchText);
            }
        }
        void Bind()
        {
            string lib = EasyConfig.ImageLibraryPath;
            drpFolders.Items.Clear();
            drpFolders.Items.Add(new ListItem(lib, "Library"));
            GetDirectories(lib, String.Empty);
            List<QuestionInfo> fiList = question.GetListArray(ExamInfoQuery);

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
            QuestionInfo qi = new QuestionInfo();

            qi.ExamInfoID = ExamInfoID;
            qi.MainSubjectID = Mid;// int.Parse(drpMainSubject.SelectedValue); ;

            qi.Key = txtKey.Text;
            qi.Subject = StrTool.GetSubjectWithoutDot(txtSubject.Text);

            question.Add(qi);
            Bind();
            Reset();
        }

        protected void dgList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[e.RowIndex].FindControl("hidIndex");
            question.Delete(int.Parse(hidIndex.Value));
            Bind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                if (dgList.Rows[i] == null)
                    continue;


                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                TextBox txtKey = (TextBox)dgList.Rows[i].FindControl("txtKey");
                TextBox txtSubject = (TextBox)dgList.Rows[i].FindControl("txtSubject");

                QuestionInfo qi = new QuestionInfo();

                qi.ID = int.Parse(hidIndex.Value);
                qi.ExamInfoID = ExamInfoID;
                qi.MainSubjectID = Mid;
                qi.Subject = txtSubject.Text;
                qi.Key = txtKey.Text;


                //subject image
                string subjectImageServerFileName = Request.Form["hidSubjectServerFileName" + hidIndex.Value];
                string subjectDest = Request.Form["hidSubjectDest" + hidIndex.Value];
                string subjectExten = Request.Form["hidSubjectExten" + hidIndex.Value];

                if (!string.IsNullOrEmpty(subjectImageServerFileName))
                {
                    if (!Directory.Exists(EasyConfig.ImageRenamedLibraryPath))
                        Directory.CreateDirectory(EasyConfig.ImageRenamedLibraryPath);

                    File.Copy(EasyConfig.PathRoot + subjectImageServerFileName, EasyConfig.ImageRenamedLibraryPath + subjectDest, true);

                }
                qi.SImage = subjectExten;
                //answer image
                string answerImageServerFileName = Request.Form["hidAnswerServerFileName" + hidIndex.Value];
                string answerDest = Request.Form["hidAnswerDest" + hidIndex.Value];
                string answerExten = Request.Form["hidAnswerExten" + hidIndex.Value];

                if (!string.IsNullOrEmpty(answerImageServerFileName))
                {
                    if (!Directory.Exists(EasyConfig.ImageRenamedLibraryPath))
                        Directory.CreateDirectory(EasyConfig.ImageRenamedLibraryPath);

                    File.Copy(EasyConfig.PathRoot + answerImageServerFileName, EasyConfig.ImageRenamedLibraryPath + answerDest, true);

                }
                qi.AImage = answerExten;
                question.Update(qi);
                //int.Parse(drpMainSubject.SelectedValue)
                //int line = sys.UpdateKey(ConstInfo.QuestionType.Question, int.Parse(hidIndex.Value), txtKey.Text.TrimEnd());
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

                QuestionInfo qi = new QuestionInfo();

                qi.ExamInfoID = ExamInfoID;
                qi.MainSubjectID = Mid;// int.Parse(drpMainSubject.SelectedValue); ;

                qi.Key = txtKey.Text;
                qi.Subject = StrTool.GetSubjectWithoutDot(subjects[i].ToString());

                question.Add(qi);

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
                CheckBox chk = (CheckBox)dgList.Rows[i].FindControl("chk");

                if (!chk.Checked)
                    continue;

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                //
                string simage = EasyConfig.ImageRenamedLibraryPath + PrefixSubjectImage + hidIndex.Value + ".jpg";
                string aimage = EasyConfig.ImageRenamedLibraryPath + PrefixAnswerImage + hidIndex.Value + ".jpg";

                if (File.Exists(simage))
                    File.Delete(EasyConfig.ImageRenamedLibraryPath + PrefixSubjectImage + hidIndex.Value + ".jpg");

                if (File.Exists(aimage))
                    File.Delete(EasyConfig.ImageRenamedLibraryPath + PrefixAnswerImage + hidIndex.Value + ".jpg");

                 question.Delete(int.Parse(hidIndex.Value));
            }
            Bind();
        }

        protected void btnBatchAddKey_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
                return;

            ListDictionary key = GetBatches(txtBatchKey.Text, ConstInfo.QuestionType.Question);

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
                int line = sys.UpdateKey(ConstInfo.QuestionType.Question, int.Parse(hidIndex.Value), key[i].ToString().Trim());
            }
            MsgBox("批量更新完毕");
            Bind();
        }

    }
}
