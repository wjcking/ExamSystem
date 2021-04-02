using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SelectionInfo : ExamItemInfo
    {

        private string choice;

        public string Choice
        {
            get { return choice; }
            set { choice = value; }
        }

        /// <summary>
        /// 打印使用
        /// </summary>
        public string ChoiceText
        {
            get
            {

                string[] choiceArray = choice.Split("\r\n".ToCharArray());
                StringBuilder choiceString = new StringBuilder();
                for (int i = 0; i < choiceArray.Length; i++)
                {
                    if (string.IsNullOrEmpty(choiceArray[i].Trim()))
                        continue;

             

                    if (BreakType != 0)
                        if (i % BreakType == 0 && i != 0 && i != 1)
                            choiceString.Append("\r\n");
                    choiceString.Append(choiceArray[i]);
                }

                return choiceString.ToString();
            }
        }
        private bool multiple = false;

        public bool Multiple
        {
            get { return multiple; }
            set { multiple = value; }
        }
        private int breakType = -1;

        public int BreakType
        {
            get { return breakType; }
            set { breakType = value; }
        }

        public SelectionInfo()
        {

        }
        private string analysis = string.Empty;

        public string Analysis
        {
            get { return analysis; }
            set { analysis = value; }
        }
        private string choiceHtml = string.Empty;
        public string ChoiceHtml
        {
            get { return choiceHtml; }
            set { choiceHtml = value; }
        }

        public override string Key
        {
            get
            {
                return base.Key.Trim();
            }
        }

        public override string Subject
        {
            get
            {
                return base.Subject.Trim();
            }
        }
    }
}
