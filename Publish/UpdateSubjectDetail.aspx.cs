using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataUtility;
using Model;

namespace Publish
{
    public partial class UpdateSubjectDetail : PageBase
    {
       // private SubjectDetail sd = new SubjectDetail(EasyConfig.ConnectionKey);
        protected SubjectDetailInfo sdi = new SubjectDetailInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {         
                SubjectDetail sd = new SubjectDetail(EasyConfig.ConnectionKey);
     
                int subjectid = Convert.ToInt32(Request.QueryString["ID"]);
                sdi = sd.GetModel(subjectid, ExamInfoID, Mid);

                if (sdi == null)
                    return;

                DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SubjectDetail sd = new SubjectDetail(EasyConfig.ConnectionKey);
           sdi = new SubjectDetailInfo();

            sdi.SubjectID = Convert.ToInt32(Request.QueryString["ID"]);
            sdi.ExamInfoID = ExamInfoID;
            sdi.MainSubjectID = Mid;
            sdi.Title = Request.Form["txtTitle"];
            sdi.Image = "";
            sdi.Media = "";
            sdi.Content = Request.Form["txtSubjectDetail"];

            int qt = Convert.ToInt32(Request.QueryString["qt"]);
            ConstInfo.QuestionType questType = (ConstInfo.QuestionType)qt;

            sd.Update(sdi);
            EasyConfig.DataSys.ExecuteNonQuery(String.Format("UPDATE {0} SET SubjectDetail = '{1}' WHERE ID={1}", questType, sdi.SubjectID));
            ClientScript.RegisterStartupScript(this.GetType(), "set", "<script type=\"text/javascript\">self.close();</script>", false);

        }
    }
}