using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ExamItemInfo : ExamSysInfo
    {
        private string mainSubject = string.Empty;

        private MainSubjectInfo currentMainSubject = null;
        private string _image = string.Empty;

        private DateTime _pubdate;
        private bool _fav = false;
        private int _incorrectno = 0;
        private string _correctiontype = "正确";
        private int _id;
        private int _examinfoid = 0;
        private string examInfoName = "";


        private int _mainsubjectid = 0;
        private string _subject = string.Empty;
        private string userAnswer = "";
        private bool mark = false;
        private string sImage = "";

        private string aImage = "";
        private string sMedia = "";
        private string aMedia = "";
        private string mainSubjectTitle = "";
        private bool isCorrect = true;
        private string subjectDetail = "";

        public string SubjectDetail
        {
            get { return subjectDetail; }
            set { subjectDetail = value; }
        }
  
        public string ExamInfoName
        {
            get { return examInfoName; }
            set { examInfoName = value; }
        }
        public bool IsCorrect
        {
            get { return isCorrect; }
            set { isCorrect = value; }
        }

        public string MainSubjectTitle
        {
            get { return mainSubjectTitle; }
            set { mainSubjectTitle = value; }
        }

        public MainSubjectInfo CurrentMainSubject
        {
            get { return currentMainSubject; }
            set { currentMainSubject = value; }
        }
        public bool Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public string UserAnswer
        {
            get { return userAnswer; }
            set { userAnswer = value; }
        }
        private string note = string.Empty;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public string MainSubject
        {
            get { return mainSubject; }
            set { mainSubject = value; }
        }
        private string answer = string.Empty;

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        private string key = string.Empty;

        public virtual string Key
        {
            get { return key; }
            set { key = value; }
        }
        //************************
        //added
        //*******

        /// <summary>
        /// 
        /// </summary>
        public DateTime PubDate
        {
            set { _pubdate = value; }
            get { return _pubdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Fav
        {
            set { _fav = value; }
            get { return _fav; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IncorrectNo
        {
            set { _incorrectno = value; }
            get { return _incorrectno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorrectionType
        {
            set { _correctiontype = value; }
            get { return _correctiontype; }
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
        public int ExamInfoID
        {
            set { _examinfoid = value; }
            get { return _examinfoid; }
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
        public  virtual string Subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }


        public string SImage
        {
            get { return sImage; }
            set { sImage = value; }
        }

        public string AImage
        {
            get { return aImage; }
            set { aImage = value; }
        }

        public string SMedia
        {
            get { return sMedia; }
            set { sMedia = value; }
        }

        public string AMedia
        {
            get { return aMedia; }
            set { aMedia = value; }
        }

        public string SImageName
        {
            get
            {
                if (SImage == "")
                    return String.Empty;

                StringBuilder imageInfo = new StringBuilder();

                imageInfo.Append(ExamInfoID);
                imageInfo.Append("-");
                imageInfo.Append(MainSubjectID);
                imageInfo.Append("-");
                imageInfo.Append("SI-");
                imageInfo.Append(ID);
                imageInfo.Append(SImage);

                return imageInfo.ToString();
            }
        }
        public string AImageName
        {
            get
            {
                if (AImage == "")
                    return String.Empty;

                StringBuilder imageInfo = new StringBuilder();

                imageInfo.Append(ExamInfoID);
                imageInfo.Append("-");
                imageInfo.Append(MainSubjectID);
                imageInfo.Append("-");
                imageInfo.Append("AI-");
                imageInfo.Append(ID);
                imageInfo.Append(AImage);

                return imageInfo.ToString();
            }
        }


        public string SMediaName
        {
            get
            {
                if (SMedia == "")
                    return String.Empty;

                StringBuilder mediaInfo = new StringBuilder();

                mediaInfo.Append(ExamInfoID);
                mediaInfo.Append("-");
                mediaInfo.Append(MainSubjectID);
                mediaInfo.Append("-");
                mediaInfo.Append("SM-");
                mediaInfo.Append(ID);
                mediaInfo.Append(SMedia);

                return mediaInfo.ToString();
            }
        }
        public string AMediaName
        {
            get
            {
                if (AMedia == "")
                    return String.Empty;

                StringBuilder mediaInfo = new StringBuilder();

                mediaInfo.Append(ExamInfoID);
                mediaInfo.Append("-");
                mediaInfo.Append(MainSubjectID);
                mediaInfo.Append("-");
                mediaInfo.Append("AM-");
                mediaInfo.Append(ID);
                mediaInfo.Append(AMedia);

                return mediaInfo.ToString();
            }
        }

        public ExamItemInfo()
        {

        }
    }
}
