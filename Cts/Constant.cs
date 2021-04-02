using System;
using System.Collections.Generic;
using System.Text;
using DataUtility;
using Model;

namespace Cts
{
    public static class Constant
    {
        public static readonly SubjectDetail SubjectDetail = new SubjectDetail();
        public static readonly MajorSubject DataMajorSubject = new MajorSubject();
        public static readonly ExamSys DataExamSys = new DataUtility.ExamSys();

        public static readonly DataUtility.FillBlank DataFillBlank = new DataUtility.FillBlank();

        public static readonly List<SubjectDetailInfo> SubjectDetailList = SubjectDetail.GetListByArray("SELECT * FROM SubjectDetail ORDER BY ID DESC");

        public static SubjectDetailInfo GetSubjectDetailInfo(int id)
        {
            foreach (SubjectDetailInfo sdi in SubjectDetailList)
            {
                if (sdi.ID == id)
                    return sdi;
            }

            return new SubjectDetailInfo();
        }

        public static SubjectDetailInfo GetSubjectDetailInfo(int subjectID, int examInfoID, int mainSubjectID)
        {
            foreach (SubjectDetailInfo sdi in SubjectDetailList)
            {
                if (sdi.SubjectID == subjectID && sdi.ExamInfoID == examInfoID && sdi.MainSubjectID == mainSubjectID)
                    return sdi;
            }

            return new SubjectDetailInfo();
        }
    }
}
