using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SubjectDetailInfo
    {
        public SubjectDetailInfo()
        { }
      
        private string _content = "";
        private int _examinfoid = 0;
        private int  _id = 0;
        private string _image = "";
        private int _mainsubjectid = 0;
        private string _media = "";
        private int _subjectid = 0;
        private string _title = "";
        public string MediaName {
            get 
            {
                StringBuilder mediaInfo = new StringBuilder();

                mediaInfo.Append(ExamInfoID);
                mediaInfo.Append("-");
                mediaInfo.Append(SubjectID);
                mediaInfo.Append("-");
                mediaInfo.Append(MainSubjectID);
                mediaInfo.Append("-");
                mediaInfo.Append("SDM");
                mediaInfo.Append("-");
                mediaInfo.Append(ID);
                mediaInfo.Append(Media);

                return mediaInfo.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get 
            { 

                return _content; 
            }
        }
        public string CombinedContent
        {
            get
            {
                
                StringBuilder ep = new StringBuilder();

                if (!string.IsNullOrEmpty(Title))
                    ep.Append(Title);

                if (!string.IsNullOrEmpty(Media))
                {
                    ep.AppendFormat("<img  class=\"playMedia\" alt=\"播放音频\" onclick=\"playMedia('{0}')\"  src=\"[#TempImagePath#]playMedia.png\"/>", MediaName);
                    ep.Append("<img  class=\"pauseMedia\" alt=\"停止音频\"  src=\"[#TempImagePath#]pauseMedia.png\"/>");
             
                }
                ep.Append("<br/>");
                Content = Content.Replace("\r\n", "<br/>");
                Content = Content.Replace(" ", "&nbsp;");
                ep.Append(Content);
 
                return ep.ToString();
            }
        }
 

        /// <summary>
        /// 
        /// </summary>
        public int ExamInfoID
        {
            set { _examinfoid = value; }
            get { return _examinfoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MainSubjectID
        {
            set { _mainsubjectid = value; }
            get { return _mainsubjectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Media
        {
            set { _media = value; }
            get { return _media; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SubjectID
        {
            set { _subjectid = value; }
            get { return _subjectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        } 
    }
}
