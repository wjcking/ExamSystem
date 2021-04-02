using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using System;
using Model;
using System.Text.RegularExpressions;
using Cts;
using System.Text;

namespace EFD.SysCenter
{
    public partial class TextboxAdvanced : TextBox
    {
        public TextboxAdvanced()
        {
            InitializeComponent();
        }

        public TextboxAdvanced(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 根据 编号.的规则生成string[]
        /// </summary>
        public string[] TextArray
        {
            get
            {
                try
                {

                    string content = Text;
                    content = content.Replace("、", ".");
                    content = content.Replace("．", ".");

                    Regex reg = new Regex(@"(?s)(\d{1,3}\..*?)(?=(\d{1,3}\.)|$)");
                    MatchCollection mc = reg.Matches(content);
                    string[] array = new string[mc.Count];

                    for (int i = 0; i < mc.Count; i++)
                        array[i] = StrTool.GetSubjectWithoutDot(mc[i].Groups[1].Value);

                    return array;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        /// <summary>
        /// 选择题生成
        /// </summary>
        public SelectionInfo[] GetTextChoices(bool isMultiple, int breakType)
        {

            try
            {
                const string gbLetters = "Ａ,Ｂ,Ｃ,Ｄ,Ｅ,Ｆ,Ｇ,Ｈ,Ｉ,Ｊ,Ｋ,Ｌ,Ｍ,Ｎ,Ｏ,Ｐ,Ｑ,Ｒ,Ｓ,Ｔ,Ｕ,Ｖ,Ｗ,Ｘ,Ｙ,Ｚ";
                const string letters = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                string content = Text;

                content = content.Replace("．", ".");

                //change dots
                string[] lets = letters.Split(",".ToCharArray());
                string[] gblets = gbLetters.Split(",".ToCharArray());

                for (int i = 0; i < lets.Length; i++)
                {
                    content = content.Replace(gblets[i], lets[i]);
                }
                //half
                //小括号
                // reg = new Regex(@"(?s)(\d{1,3}\..*?)(A\).*?)(?=(\d{1,3}\.)|$)");
                //中括号
                //   reg = new Regex(@"(?s)(\d{1,3}\..*?)(\[A\].*?)(?=(\d{1,3}\.)|$)");
                //全角 ．
                // reg = new Regex(@"(?s)(\d{1,3}．.*?)(A．.*?)(?=(\d{1,3}．)|$)"); 
                //顿号 、
                // reg = new Regex(@"(?s)(\d{1,3}、.*?)(A．.*?)(?=(\d{1,3}、)|$)"); 

                Regex reg;
                reg = new Regex(@"(?s)(\d{1,3}\..*?)(A.*?)(?=(\d{1,3}\.)|$)");
                MatchCollection mc = reg.Matches(content);
                
                SelectionInfo[] array = new SelectionInfo[mc.Count];

                for (int i = 0; i < mc.Count; i++)
                {
                    array[i] = new SelectionInfo();
                    array[i].Subject = StrTool.GetSubjectWithoutDot(mc[i].Groups[1].Value);
                    array[i].Choice = mc[i].Groups[2].Value;
                    array[i].Multiple = isMultiple;
                    array[i].BreakType = breakType;
                    array[i].ChoiceHtml = StrTool.GenerateChoices(array[i]);
                }

                return array;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void OrganizeChoice()
        {
            Text = Text.Replace("、", ".");
            Text = Text.Replace("．", ".");
            Text = Cts.StrTool.OrganizeChoice(Text);
        
        }
        public string GetTextChoicesHtml(bool isMultiple, int breakType, ref int count)
        {

            SelectionInfo[] textChoices = GetTextChoices(isMultiple, breakType);
            int index = 1;
            StringBuilder choiceHtml = new StringBuilder();

            foreach (SelectionInfo si in textChoices)
            {
                choiceHtml.Append(index + ".");
                choiceHtml.Append(si.Subject);
                choiceHtml.Append("<br />");
                choiceHtml.Append(si.ChoiceHtml);
                choiceHtml.Append("<br />");
                choiceHtml.Append("<br />");
                index++;
            }
            count = textChoices.Length;
            return choiceHtml.ToString();
        }

        private void TextboxAdvanced_DragOver(object sender, DragEventArgs e)
        {
            e.Effect  = DragDropEffects.Move;
           
        }

        private void TextboxAdvanced_DragDrop(object sender, DragEventArgs e)
        {
            Text =   e.Data.GetData(DataFormats.Text).ToString();
        }
    }
}
