using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cts;
using DataUtility;
using Model;
namespace Publish
{
    public partial class EditSelection : PageBase
    {
        private List<SelectionInfo> li;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMainSubject(drpMainSubject, ConstInfo.QuestionType.Selection);
            }
        }

       private List<SelectionInfo> GenerateChoice(string content, bool isMultiple)
        {
            const string letterPoint = "A.,B.,C.,D.,E.,F.,G.,H.,I.,J.,K.,L.,M.,N.,O.,P.,Q.,R.,S.,T.,U.,V.,W.,X.,Y.,Z.";
            const string gbLetters = "Ａ,Ｂ,Ｃ,Ｄ,Ｅ,Ｆ,Ｇ,Ｈ,Ｉ,Ｊ,Ｋ,Ｌ,Ｍ,Ｎ,Ｏ,Ｐ,Ｑ,Ｒ,Ｓ,Ｔ,Ｕ,Ｖ,Ｗ,Ｘ,Ｙ,Ｚ";
            const string letters = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

            List<SelectionInfo> li = new List<SelectionInfo>();
            int index = 1;
            //half
            //小括号
            //Regex reg = new Regex(@"(?s)(\d{1,3}\..*?)(A\).*?)(?=(\d{1,3}\.)|$)");
            //中括号
            //  Regex reg = new Regex(@"(?s)(\d{1,3}\..*?)(\[A\].*?)(?=(\d{1,3}\.)|$)");
            //full 
            //Regex reg = new Regex(@"(?s)(\d{1,3}．.*?)(A．.*?)(?=(\d{1,3}．)|$)"); 
            //Regex reg = new Regex(@"(?s)(\d{1,3}(\.|．).*?) (A．.*?) (?=(\d{1,3}(\.|．))|$)");
            Regex reg = new Regex(@"(?s)(\d{1,3}\..*?)(A\..*?)(?=(\d{1,3}\.)|$)");

           

            //change dots
            string[] lets = letters.Split(",".ToCharArray());
            string[] gblets = gbLetters.Split(",".ToCharArray());

            for (int i = 0; i < lets.Length; i++)
                content = content.Replace(gblets[i], lets[i]);

            content = content.Replace("．", ".");

            foreach (Match m in reg.Matches(content))
            {
                SelectionInfo item = new SelectionInfo();

                item.ExamInfoID = ExamInfoID;
                item.Multiple = isMultiple;
             //   item.MainSubjectID = int.Parse(drpMainSubject.SelectedValue);
                //选择题大题分类
                item.MainSubjectID = Mid;
                item.Subject = m.Groups[1].Value;
                item.Choice = m.Groups[2].Value;

                foreach (string option in letterPoint.Split(",".ToCharArray()))
                    item.Choice = item.Choice.Replace(option, "\r\n" + option);

                item.Index = index;

                item.BreakType = Convert.ToInt32(radBreakType.SelectedValue);
                item.ChoiceHtml = StrTool.GenerateChoices(item);

                li.Add(item);

                index++;
            }

            return li;
        }


        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            li = GenerateChoice(Server.HtmlEncode(txtSelection.Text), chkChoiceType.Checked);
            Cache["ItemInfo_li"] = li;

            dgChoiceList.DataSource = li;
            dgChoiceList.DataBind();
        }

        protected void btnKeyUpdate_Click(object sender, EventArgs e)
        {
            if (Cache["ItemInfo_li"] != null)
            {
                Select selection = new Select(EasyConfig.ConnectionKey);

                li = Cache["ItemInfo_li"] as List<SelectionInfo>;

                if (dgChoiceList.Rows.Count < 0)
                    return;

                foreach (SelectionInfo item in li)
                {
                    item.Key = Request.Form["hidChoice" + item.MainSubject + item.Index];
                    item.Subject = StrTool.GetSubjectWithoutDot(item.Subject);

                    selection.Add(item);
                }

                dgChoiceList.DataSource = li;
                dgChoiceList.DataBind();

                MsgBox("添加成功");
                txtSelection.Text = string.Empty;
            }

        }
    }
}