using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Model;
using Cts;
using System.Collections.Specialized;
using DataUtility;
using System.IO;

namespace Publish
{
    public partial class EditChoices : PageBase
    {
        private Select selection = new Select(EasyConfig.ConnectionKey);

        private ExamSys sys = new ExamSys(EasyConfig.ConnectionKey);


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Bind();
                GetMainSubject(drpMainSubject, ConstInfo.QuestionType.Selection);
            }
        }
        private void GetDirectories(string path, string searchText)
        {
            if (!Directory.Exists(path))
                return;

            string[] directories = Directory.GetDirectories(path);

            foreach (string dir in directories)
            {
                drpFolders.Items.Add(new ListItem(dir, dir.Replace(Server.MapPath(""), string.Empty)));
                GetDirectories(dir, searchText);
            }
        }
        void Bind()
        {
            string lib = EasyConfig.ImageLibraryPath;
            drpFolders.Items.Clear();
            drpFolders.Items.Add(new ListItem(lib, "Library"));
            GetDirectories(lib, String.Empty);

            List<SelectionInfo> slist = selection.GetListArray(ExamInfoQuery);

            foreach (SelectionInfo si in slist)
                si.ChoiceHtml = StrTool.GenerateChoices(si);

            dgChoiceList.DataSource = slist;
            dgChoiceList.DataBind();

            for (int i = 0; i < dgChoiceList.Rows.Count; i++)
            {
                DropDownList drpBreak = (DropDownList)dgChoiceList.Rows[i].FindControl("drpBreak");
                drpBreak.SelectedValue = slist[i].BreakType.ToString();
            }
        }

        protected void btnKeyUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgChoiceList.Rows.Count; i++)
            {
                if (dgChoiceList.Rows[i] == null)
                    continue;

                SelectionInfo si = new SelectionInfo();

                TextBox txtSubject = (TextBox)dgChoiceList.Rows[i].FindControl("txtSubject");
                CheckBox chk = (CheckBox)dgChoiceList.Rows[i].FindControl("chk");
                CheckBox chkMultiple = (CheckBox)dgChoiceList.Rows[i].FindControl("cbMultiple");
                DropDownList drpBreak = (DropDownList)dgChoiceList.Rows[i].FindControl("drpBreak");
                HtmlInputHidden hidCurrentID = (HtmlInputHidden)dgChoiceList.Rows[i].FindControl("hidCurrentID");
                HtmlInputHidden hidIndex = (HtmlInputHidden)dgChoiceList.Rows[i].FindControl("hidIndex");

                si.ID = int.Parse(hidIndex.Value);
                si.ExamInfoID = ExamInfoID;
                si.MainSubjectID = Mid;
                si.BreakType = Convert.ToInt32(drpBreak.SelectedValue);
                si.Subject = txtSubject.Text;
                si.Multiple = chkMultiple.Checked;
                si.Key = Request.Form["hidChoice" + hidCurrentID.Value + hidIndex.Value];
                si.Analysis = Request.Form["txtAnalysis" + hidIndex.Value];
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
                si.SImage = subjectExten;
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
                si.AImage = answerExten;
                selection.Update(si);
            }
            Bind();
        }

        protected void dgChoiceList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HtmlInputHidden hidIndex = (HtmlInputHidden)dgChoiceList.Rows[e.RowIndex].FindControl("hidIndex");
            selection.Delete(int.Parse(hidIndex.Value));
            Bind();
        }

        protected void btnBatchKeyUpdate_Click(object sender, EventArgs e)
        {
            if (dgChoiceList.Rows.Count == 0)
                return;

            ListDictionary key = GetBatches(txtChoiceKey.Text);

            if (key == null)
            {
                MsgBox("答案添加有误或者题目数有相同");
                return;
            }

            if (key.Count != dgChoiceList.Rows.Count)
            {
                MsgBox("整体数量与当前试题数量不相等，不能批量添加，请检查答案数量是否准确");
                return;
            }

            for (int i = 0; i < key.Count; i++)
            {

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgChoiceList.Rows[i].FindControl("hidIndex");
                int line = sys.UpdateKey(ConstInfo.QuestionType.Selection, int.Parse(hidIndex.Value), key[i].ToString().Trim());

                sys.UpdateKey(ConstInfo.QuestionType.Selection, int.Parse(hidIndex.Value), key[i].ToString());
            }
            MsgBox("批量更新完毕");
            Bind();
        }

        protected void btnDeleteByCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgChoiceList.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dgChoiceList.Rows[i].FindControl("chk");

                if (!chk.Checked)
                    continue;

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgChoiceList.Rows[i].FindControl("hidIndex");
                selection.Delete(int.Parse(hidIndex.Value));

                string simage = EasyConfig.ImageRenamedLibraryPath + PrefixSubjectImage + hidIndex.Value + ".jpg";
                string aimage = EasyConfig.ImageRenamedLibraryPath + PrefixAnswerImage + hidIndex.Value + ".jpg";

                if (File.Exists(simage))
                    File.Delete(simage);

                if (File.Exists(aimage))
                    File.Delete(aimage);
            }
            MsgBox("删除完毕");
            Bind();
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgChoiceList.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dgChoiceList.Rows[i].FindControl("chk");

                if (!chk.Checked)
                    continue;

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgChoiceList.Rows[i].FindControl("hidIndex");

                sys.UpdateMainSubjectID(ConstInfo.QuestionType.Selection, int.Parse(hidIndex.Value), int.Parse(drpMainSubject.SelectedValue));
            }

            Response.Redirect(Request.Url.ToString());
        }
    }
}