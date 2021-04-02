using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Model;

namespace Cts
{
    public class StrTool
    {
       public const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string GetSubjectWithoutDot(string subject)
        {
            if (string.IsNullOrEmpty(subject))
                return String.Empty;

            if (subject.IndexOf(".") < 0)
                return subject;

            int dot = subject.IndexOf(".") + 1;

            return subject.Substring(dot, subject.Length - dot);
        }

        public static string ChangeJudgementKey(string key)
        {
            switch (key)
            {
                case "false":
                case "False":
                case "":
                    return "False";
              
                case "true":
                case "True":
                case "对":
                case "Y":
                case "y":
                case "T":
                case "t":
                case "√":
                    return "True";
                 
                default:
                    return "False";
                
            } 
        }
        public static string GenerateChoices(SelectionInfo singleItem)
        {
            StringBuilder item = new StringBuilder();
            if (singleItem.Multiple == false)
            {
                string[] choices = singleItem.Choice.Split("\r\n".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

                int i = 1;
                char letter;
                string hid = "";

                foreach (string choice in choices)
                {
                    if (choice.Trim() == string.Empty)
                        continue;

                    letter = GetChoiceLetter(i);
                    // 0=不换行 1=每个一换 2=每两个
                    if (singleItem.BreakType != 0)
                        if (i % singleItem.BreakType == 0 && i != 0 && i != 1)
                            item.Append("  <br />\r\n");

                    string radioId = String.Format("Choice_{0}_{1}_{2}", singleItem.MainSubject, singleItem.Index, letter);
                    string radioName = String.Format("Choice_{0}_{1}", singleItem.MainSubject, singleItem.Index);
                    string clickEvent = String.Format("GetSelectedKey('{0}', '{1}', 'False')", radioName, singleItem.MainSubject + singleItem.Index);

                    string labelID = "Label_" + radioId;

                    hid = string.Format("Choice_Key_{0}_{1}", singleItem.MainSubject, singleItem.Index);

                    item.AppendFormat("  <input type=\"radio\" id=\"{0}\" name=\"{1}\" value=\"{2}\"  onclick=\"{3}\" />", radioId, radioName, letter, clickEvent);
                    item.AppendFormat(" <label for=\"{0}\" id=\"{1}\" >{2}</label>\r\n", radioId, labelID, choice);

                    i++;
                }

                item.AppendFormat("  <input type=\"hidden\" value=\"{0}\" id=\"{1}\" />\r\n", singleItem.Key, hid);


            }

            else
            {

                string[] choices = singleItem.Choice.Split("\r\n".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

                int i = 1;
                char letter;
                string hid = "";
                foreach (string choice in choices)
                {
                    if (choice.Trim() == string.Empty)
                        continue;

                    letter = GetChoiceLetter(i);

                    if (singleItem.BreakType != 0)
                        if (i % singleItem.BreakType == 0 && i != 0 && i != 1)
                            item.Append("  <br />\r\n");

                    string checkId = String.Format("Multi_{0}_{1}_{2}", singleItem.MainSubject, singleItem.Index, letter);
                    string checkName = String.Format("Multi_{0}_{1}", singleItem.MainSubject, singleItem.Index);
                    string clickEvent = String.Format("GetSelectedKey('{0}', '{1}', 'True')", checkName, singleItem.MainSubject + singleItem.Index);

                    string labelID = "Label_" + checkId;


                    hid = string.Format("Choice_Key_{0}_{1}", singleItem.MainSubject, singleItem.Index);
                    //debug

                    item.AppendFormat("  <input type=\"checkbox\" class=\"multiChoice\" id=\"{0}\" name=\"{1}\" value=\"{2}\" onclick=\"{3}\"/>", checkId, checkName, letter, clickEvent);
                    item.AppendFormat(" <label for=\"{0}\" id=\"{1}\" >{2}</label>\r\n", checkId, labelID, choice);
                    i++;

                }

                item.AppendFormat("  <input type=\"hidden\" value=\"{0}\" id=\"{1}\" />\r\n", singleItem.Key, hid);
            }

            return item.ToString();
        }
        public static string OrganizeChoice(string choices)
        {
            foreach (char c in Cts.StrTool.Letters)
            {
                if (c == 65)
                    continue;
                choices = choices.Replace(c.ToString() + ".", "\r\n" + c.ToString() + ".");
            }
            return choices;
        }
        private static char GetChoiceLetter(int id)
        {
            

            int i = 1;
            foreach (char c in Letters)
            {
                if (i == id)
                    return c;
                i++;
            }

            return 'z';
        }

        public static bool IsLetter(string str)
        {
            foreach (char c in str)
            {
                if (Char.IsLetter(c))
                    continue;

                return false;
            }

            return true;
        }


        /// <summary>
        /// 截取字符串并在结尾补上指定字符
        /// </summary>
        /// <param name="inputString">传入参数</param>
        /// <param name="len">指定偶数长度</param>
        /// <param name="Extra">附加字符</param>
        /// <returns></returns>
        public static string CutString(string inputString, int len, string Extra)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return "";
            }
            inputString = System.Text.RegularExpressions.Regex.Replace(inputString, "<.+?>", "");

            System.Text.ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] >= 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
                tempString += Extra + Extra + Extra;
            return tempString;
        }


        /// <summary>
        /// 截取字符串并补上"..."
        /// </summary>
        /// <param name="inputString">传入字符串</param>
        /// <param name="len">指定偶数长度</param>
        /// <returns></returns>
        public static string CutString(string inputString, int len)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return "";
            }
            inputString = System.Text.RegularExpressions.Regex.Replace(inputString, "<.+?>", "");

            System.Text.ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] >= 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len + 2)
                tempString += "...";
            return tempString;
        }


        /// <summary>
        /// 清除特殊字符
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string ClearSpecialChar(string Str)
        {
            Str = Str.Replace(";", "；");
            Str = Str.Replace("--", "");
            Str = Str.Replace("select", "");
            Str = Str.Replace("<", "");
            Str = Str.Replace(">", "");
            Str = Str.Replace("chr(10)", "");
            Str = Str.Replace("chr(13)", "");
            Str = Str.Replace("\\", "");
            Str = Str.Replace("}", "");
            Str = Str.Replace("{", "");
            Str = Str.Replace("~", "");
            Str = Str.Replace("&", "");
            Str = Str.Replace("!", "");

            return Str;
        }

        public static string StrToHtm(string Str)
        {
            if (string.IsNullOrEmpty(Str))
                return string.Empty;

            Str = TransferChar(Str);
            Str = Str.Replace("\r", "<br/>");
            Str = Str.Replace("\n", "<br/>");
            Str = Str.Replace("\r\n", "<br/>");
            Str = Str.Replace(" ", "&nbsp;");

            return Str;
        }


        public static string HtmToStr(string Str)
        {
            Str = Str.Replace("<br/>", "\r\n");
            Str = Str.Replace("&nbsp;", " ");

            return Str;
        }

        public static string TransferChar(string Str)
        {
            Str = Str.Replace("<", "&lt;");
            Str = Str.Replace(">", "&gt;");

            return Str;
        }


    }


}
