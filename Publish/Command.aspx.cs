using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Publish
{
    public partial class Command : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetContentByRegex(string buttonID)
        {
            try
            {
                litResult.Text = string.Empty;
                string content = Request.Form["txtContent"];                    
                string keyExpression = Request.Form["txtKeyExpression"];
                string analysisExpression = Request.Form["txtAnalysisExpression"];
                string clearExpression = Request.Form["txtClearExpression"];
                string expression = "";

                switch (buttonID)
                {
                    case "btnGetkey":
                        expression = keyExpression;
                        break;
                    case "btnGetAnalysis":
                        expression = analysisExpression;
                        break;
                    case "btnClearQuestion":
                        expression = clearExpression;
                        break;
                }

                MatchCollection Matches = Regex.Matches(content, expression);
                string[] ops = new string[Matches.Count];

                switch (buttonID)
                {
                    case "btnGetkey":
                        for (int i = 0; i < Matches.Count; i++)
                        {
                            int id = i + 1;
                           ops[i] = Matches[i].Value;
                          //   ops[i] = Matches[i].Groups[0].Value;
                            litResult.Text += id.ToString() + "." + ops[i] + "<br/>";
                            
                        }
                        break;
                    case "btnGetAnalysis":
                        for (int i = 0; i < Matches.Count; i++)
                        {
                            int id = i + 1;
                            ops[i] = Matches[i].Value;
                            litResult.Text += id.ToString() + "." + ops[i] + "<br/>";
                        }
                        break;
                    case "btnClearQuestion":
                       litResult.Text = Cts.StrTool.StrToHtm(Regex.Replace(content, expression, ""));
                        break;
                }
            
            }
            catch (Exception e)
            {
                litResult.Text = e.Message;
            }

        }
        protected void btnGetkey_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            GetContentByRegex(b.ID);
        }

        protected void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = Request.Form["txtQuery"];
                int line = EasyConfig.DataSys.ExecuteNonQuery(sql);
                litResult.Text = "执行行数为：" + line.ToString();
            }
            catch (Exception exp)
            {
                litResult.Text = exp.Message;
            }
        }



    }
}