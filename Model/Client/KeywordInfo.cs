using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class KeywordInfo
    {
        private string keyword = "";
        private int sectionID = 0;
        private KeywordSection section = KeywordSection.ExamInfo;
        private string highlightStyle = "Underline";

       
        public int SectionID
        {
            get { return sectionID; }
            set { sectionID = value; }
        }
        /// <summary>
        /// 试题，大纲 分类
        /// </summary>
        public KeywordSection Section
        {
            get { return section; }
            set { section = value; }
        }
       public string  HighlightStyle
        {
            get { return highlightStyle; }
            set { highlightStyle = value; }
        }
        public KeywordInfo()
        {

        }

        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }


   

        public enum KeywordSection
        {
            ExamInfo = 1,
            Outline = 2
        }
    }
}
