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

namespace Publish
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Exception exp = new Exception();

            
        //    GridView1.DataSource = new Cts.Selection(@"F:\ExamSys\Publish\通用自测系统题库\人力资源管理与开发\History.xml").GetList();
         //   GridView1.DataBind();

        }
    }
}
