using System.IO;
using DataUtility;
using Model;
using EFD.SysCenter.Util;
using System.Collections.Generic;

namespace EFD.SysCenter
{
    public class Exam
    {
        private static ExamCategoryInfo[] databaseList = null;
        private static string selectedFilePath = Static.Settings.GetValue(Constant.RecentFiles);

        public static string DatabaseFolder = Static.Settings.GetValue(Constant.DatabasePath);
        public static ExamSys ExamSys = null;
        public static Outline Outline = null;
        public static Select Choice = null;
        public static Judge Judgement = null;
        public static Quest Question = null;
        public static FillBlank Fill = null;
        public static MajorSubject MainSubject = null;
        public static AccessHelper Access = null;
        public static SubjectDetail SubjectDetail = null;
        public static List<MainSubjectInfo> MainSubjectList = null;
        /// <summary>
        /// 选中的题库文件地址
        /// </summary>
        public static string SelectedFilePath
        {
            get { return selectedFilePath; }
            set
            {
                Access = new AccessHelper(value);
                ExamSys = new ExamSys(value);
                Outline = new Outline(value);
                Choice = new Select(value);
                Question = new Quest(value);
                Fill = new FillBlank(value);
                Judgement = new Judge(value);
                MainSubject = new MajorSubject(value);
                SubjectDetail = new SubjectDetail(value);
                MainSubjectList = MainSubject.GetListArray(string.Empty);
                selectedFilePath = value;
            }
        }

        public static string SelectedFileName
        {
            get
            {
                if (string.IsNullOrEmpty(SelectedFilePath))
                    return "";

                return Path.GetFileNameWithoutExtension(SelectedFilePath);
            }
        }

        /// <summary>
        /// [缓存]
        /// </summary>
        /// <param name="qt"></param>
        /// <returns></returns>
        public static List<MainSubjectInfo> GetMainSubjectListByQuestionType(ConstInfo.QuestionType qt)
        {
            //if (MainSubjectList == null || MainSubjectList.Count ==0)
            //{
                int topicTypeID = (int)qt;
                MainSubjectList = MainSubject.GetListArray(" TopicTypeID = " + topicTypeID.ToString());
            //    return MainSubjectList;
            //}

            List<MainSubjectInfo> list = new List<MainSubjectInfo>();
            foreach (MainSubjectInfo msi in MainSubjectList)
            {
                if (msi.Type == (int)qt)
                    list.Add(msi);
            }

            return list;
        }

        /// <summary>
        /// [缓存]获得所有题库
        /// </summary>
        public static ExamCategoryInfo[] DatabaseList
        {
            get
            {
                if (databaseList == null)
                {

                    databaseList = GetDatabaseList();

                    return databaseList;
                }

                return databaseList;
            }
        }

        public static FileInfo[] GetSkinList()
        {
            string skinPath = Static.Settings.GetValue(Constant.SkinPath);

            if (!Directory.Exists(skinPath))
                return null;
            string[] skinList = Directory.GetFiles(skinPath, "*.ssk");
            FileInfo[] fileList = new FileInfo[skinList.Length];

            for (int i = 0; i < skinList.Length; i++)
            {
                fileList[i] = new FileInfo(skinList[i]);

            }

            return fileList;
        }

        /// <summary>
        /// 获得所有题库
        /// </summary>
        /// <returns></returns>
        public static ExamCategoryInfo[] GetDatabaseList()
        {
            string[] databaseList = Directory.GetFiles(DatabaseFolder, "*.mdb");

            ExamCategoryInfo[] fileList = new ExamCategoryInfo[databaseList.Length];

            for (int i = 0; i < fileList.Length; i++)
            {

                FileInfo fi = new FileInfo(databaseList[i]);
                fileList[i] = new ExamCategoryInfo();
                fileList[i].Name = fi.Name;
                fileList[i].LastAccessTime = fi.LastAccessTime.ToString();
                fileList[i].LastWriteTime = fi.LastWriteTime.ToString();
                fileList[i].CreationTime = fi.CreationTime.ToString();
                fileList[i].FullName = fi.FullName;
            }

            return fileList;
        }
    }
}
