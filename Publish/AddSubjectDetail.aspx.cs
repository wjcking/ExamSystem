using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataUtility;
using Model;

namespace Publish
{
    public partial class AddSubjectDetail : PageBase
    {

        SubjectDetail sd = new SubjectDetail(EasyConfig.ConnectionKey);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string handle = GetFormString("hidHandle");
            string detailid = GetFormString("hidID");
            string subjectId = Request.QueryString["ID"];
            int qt = Convert.ToInt32(Request.QueryString["qt"]);

            ConstInfo.QuestionType questType = (ConstInfo.QuestionType)qt;
            litQuestType.Text = questType.ToString();

            switch (handle.ToUpper())
            {
                case "DEL":
                    EasyConfig.DataSys.ExecuteNonQuery(String.Format("DELETE FROM SubjectDetail WHERE ID = {0}", detailid));
                    EasyConfig.DataSys.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '' WHERE ID={1}", questType, subjectId));
                    EasyConfig.DataSys.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '' WHERE SubjectDetail='{1}'", questType, detailid));
                    break;

                case "FIRST":
                    EasyConfig.DataSys.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = 'FIRST' WHERE ID={1}", questType, subjectId));
                    ClientScript.RegisterStartupScript(this.GetType(), "set", "<script type=\"text/javascript\">set('FIRST');</script>", false);
                    break;

                case "SUBJECT":
                    EasyConfig.DataSys.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '{1}' WHERE ID={2}", questType, detailid, subjectId));
                    ClientScript.RegisterStartupScript(this.GetType(), "set", string.Format("<script type=\"text/javascript\">set({0});</script>",detailid), false);
                    break;

                default:
                    break;
            }

            Bind();
        }

        private void Bind()
        {
            rptList.DataSource = sd.GetListByArray(ExamInfoID);
            rptList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            SubjectDetailInfo sdi;
            sdi = new SubjectDetailInfo();
            sdi.SubjectID = Convert.ToInt32(Request.QueryString["ID"]);
            sdi.ExamInfoID = ExamInfoID;
            sdi.MainSubjectID = Mid;

            sdi.Image = "";
            sdi.Media = "";
            sdi.Content = Request.Form["txtSubjectDetail"];
            sdi.Title = Request.Form["txtTitle"];

            sdi.Title = string.IsNullOrEmpty(sdi.Title) ? sdi.Content.Substring(0, 22) : sdi.Title;
            int qt = Convert.ToInt32(Request.QueryString["qt"]);
            ConstInfo.QuestionType questType = (ConstInfo.QuestionType)qt;

            sd.Add(sdi);

            //first
            EasyConfig.DataSys.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '{1}' WHERE ID={1}", questType, sdi.SubjectID));
            hidResult.Value = sdi.SubjectID.ToString();

            Bind();
        }
    }
}