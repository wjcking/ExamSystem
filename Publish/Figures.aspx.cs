using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DataUtility;

namespace Publish
{
    public partial class Figures : System.Web.UI.Page
    {
        protected readonly int selectionCount = Convert.ToInt32(EasyConfig.DataSys.ExecuteScalar("SELECT COUNT(*) FROM Selection"));
        protected readonly int judgementCount = Convert.ToInt32(EasyConfig.DataSys.ExecuteScalar("SELECT COUNT(*) FROM Judgement"));
        protected readonly int fillCount = Convert.ToInt32(EasyConfig.DataSys.ExecuteScalar("SELECT COUNT(*) FROM Fill"));
        protected readonly int questionCount = Convert.ToInt32(EasyConfig.DataSys.ExecuteScalar("SELECT COUNT(*) FROM Question"));
        protected readonly int outlineCount = Convert.ToInt32(EasyConfig.DataSys.ExecuteScalar("SELECT COUNT(*) FROM Outline WHERE Type=0 "));
        protected readonly int examInfoCount = Convert.ToInt32(EasyConfig.DataSys.ExecuteScalar("SELECT COUNT(*) FROM ExamInfo WHERE IsMaterial = true "));
        protected readonly string UrlAddProductRedirect = System.Configuration.ConfigurationManager.AppSettings["UrlAddProductRedirect"];
        protected int[] msiArray;
        protected int sumup = 0;
        protected string mainSubjects = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            sumup = selectionCount + judgementCount + fillCount + questionCount;

            List<MainSubjectInfo> msiList = new MajorSubject(EasyConfig.ConnectionKey).GetListArray( " 100 = 100 ORDER BY [Sort] ASC");

            msiArray = new int[msiList.Count];

            for (int i=0;i<msiList.Count;i++)
            {
               ConstInfo.QuestionType qt = (ConstInfo.QuestionType)msiList[i].Type;
                msiArray[i] = Convert.ToInt32(EasyConfig.DataSys.ExecuteScalar(string.Format("SELECT COUNT(*) FROM {0} WHERE MainSubjectID = {1}", qt, msiList[i].CurrentID)));
                mainSubjects += "\r\n" +  msiList[i].Subject + "试题总数：" + msiArray[i].ToString()+ "个";
            }
        }
    }
}