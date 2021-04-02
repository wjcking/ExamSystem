using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataUtility;

namespace Cts
{
    public static class EPReader
    {

        public static List<MainSubjectInfo> CurrentMsiList;
        public static List<ExamItemInfo> CurrentExamItemList = new List<ExamItemInfo>();


        public static string Read(TemplateInfo temp)
        {
            List<MainSubjectInfo> majorSubjectInfoList = null;
            ExamInfo examInfo = null;

            //判断是否是查询后的试题结果
            if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Search)
            {
                examInfo = new ExamInfo();
                majorSubjectInfoList = new List<MainSubjectInfo>();

                foreach (HistoryInfo hi in temp.ExamHistoryList)
                {
                    MainSubjectInfo msi = Constant.DataMajorSubject.GetModel(hi.SqlRecordCount);
                    msi.SubjectSum = int.Parse(hi.RecordCount);
                    majorSubjectInfoList.Add(msi);
                }

                examInfo.Name = temp.Title;
            }
            else
            {
                majorSubjectInfoList = Constant.DataMajorSubject.GetListArray(temp);
                examInfo = Constant.DataExamSys.GetModel(temp.ExamInfoID);
            }

            if (examInfo == null)
                return string.Empty;


            CurrentMsiList = majorSubjectInfoList;

            if (majorSubjectInfoList.Count == 0)
                return string.Empty;

            string template = temp.TemplateContent;

            StringBuilder ep = new StringBuilder();

            //试题图片位置
            string imageLib = temp.TemplatPath + "ImageLib\\";
            //清空
            CurrentExamItemList.Clear();

            int currentSubjectNo = 1;
    
            foreach (MainSubjectInfo mi in majorSubjectInfoList)
            {
                if (mi.Type == 0)
                    continue;

                string strWhere = "";
                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)mi.Type;

                //==============================================CHOICE==========================================       
                if (qt == ConstInfo.QuestionType.Selection)
                {
                    Select select = new Select();
                    List<SelectionInfo> slist = null;

                    if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Normal)
                    {
                        strWhere = GenerateQuery(temp, mi.ID);
                        slist = select.GetListArray(strWhere);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        slist = select.GetListArrayByPaging(hi.SqlSearch);
                    }

                    int index;
                    //打印选择题大题
                    ep.Append("\r\n");
                    ep.Append(mi.Subject);
                    ep.AppendFormat("\r\n");
                    ep.AppendFormat("\r\n");

                    foreach (SelectionInfo si in slist)
                    {

                        if (si.MainSubject != mi.CurrentID)
                        {
                            continue;
                        }
                        CurrentExamItemList.Add(si as ExamItemInfo);
                        //检查试题列表项
                        si.CurrentMainSubject = mi;
                        si.MainSubjectTitle = mi.Subject;
                        index = si.Index;

                        //subject number 
                        if (!string.IsNullOrEmpty(si.SubjectDetail))
                        {
                            SubjectDetailInfo detailInfo = null;

                            if (si.SubjectDetail == ConstInfo.SUBJECT_DETAIL_FIRST)
                            {

                                detailInfo = Constant.SubjectDetail.GetModel(si.ID, si.ExamInfoID, si.MainSubjectID);
                                ep.Append(detailInfo.Content);
                            }
                            else
                            {

                                int detailID = Convert.ToInt32(si.SubjectDetail);
                                detailInfo = Constant.SubjectDetail.GetModel(detailID);

                                if (temp.ExamQueryStyle != TemplateInfo.QueryStyle_Normal || temp.TestWay == ConstInfo.TestWay.错题重做 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题)
                                {
                                    ep.Append(detailInfo.Content);
                                }
                            }
                        }


                        //题号
                        ep.Append(currentSubjectNo).Append(".");
                        ep.Append(si.Subject);
                        ep.Append("\r\n");
                        //答案 
                        ep.Append(si.Key);
                        ep.Append("\r\n");

                        //用户作答
                        //if (temp.TestWay == ConstInfo.TestWay.试题学习)
                        //{
                        //    if (!String.IsNullOrEmpty(si.Answer))
                        //        ep.Append(si.Answer);
                        //}


                        //SImage
                        //if (!string.IsNullOrEmpty(si.SImage))
                        //{
                        //    ep.AppendFormat("\r\n");

                        //    string prefixSubjectImage = GetImagePrefixName(si.ExamInfoID, mi.CurrentID, Constant.ImageOwner.Subject);

                        //    string subjectImage = prefixSubjectImage + si.ID.ToString() + si.SImage;

                        //    ep.AppendFormat(" {0} {1} ", imageLib + subjectImage, "");
                        //}

                        //if (si.Subject.Trim().Length > 4 && si.BreakType == 0)
                        //    ep.Append("\r\n  "); 
                        //choice 
                        ep.Append(si.ChoiceText);
                        ep.Append("\r\n");

                        //Analysis
                        //ep.AppendFormat(" {0}", si.Analysis.TrimStart());
                        ep.Append("\r\n");

                        currentSubjectNo++;
                    }
                    ep.Append("\r\n");
                }
                //==============================================JUDGEMENT==========================================     
                else if (qt == ConstInfo.QuestionType.Judgement)
                {
                    Judge judge = new Judge();
                    List<JudgementInfo> jiList = null;

                    if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Normal)
                    {
                        strWhere = GenerateQuery(temp, mi.ID);
                        jiList = judge.GetListArray(strWhere);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        jiList = judge.GetListArrayByPaging(hi.SqlSearch);
                    }

                    int index;
                    ep.Append("\r\n");
                    ep.Append(mi.Subject);
                    ep.AppendFormat("\r\n");
                    ep.AppendFormat("\r\n");
                    foreach (JudgementInfo ji in jiList)
                    {

                        if (ji.MainSubject != mi.CurrentID)
                            continue;
                        //检查试题列表项
                        ji.CurrentMainSubject = mi;
                        ji.MainSubjectTitle = mi.Subject;
                        CurrentExamItemList.Add(ji as ExamItemInfo);

                        index = ji.Index;

                        ep.Append(currentSubjectNo).Append(".");
                        ep.Append(ji.Subject);
                        ep.Append("\r\n");
                        ep.Append(ji.Key);
                        ep.Append("\r\n");
                        //SImage
                        //if (!string.IsNullOrEmpty(ji.SImage))
                        //{
                        //    ep.AppendFormat("<br/>");
                        //    string prefixSubjectImage = GetImagePrefixName(ji.ExamInfoID, mi.CurrentID, Constant.ImageOwner.Subject);
                        //    string subjectImage = prefixSubjectImage + ji.ID.ToString() + ji.SImage;

                        //    ep.AppendFormat("<img src=\"{0}\"   style=\"margin:5px 0 0 20px;\" alt=\"{1}\" />", imageLib + subjectImage, "");
                        //}


                        currentSubjectNo++;
                    }
                }
                //==============================================FILL==========================================     
                else if (qt == ConstInfo.QuestionType.Fill)
                {

                    List<FillInfo> fiList = null;

                    if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Normal)
                    {
                        strWhere = GenerateQuery(temp, mi.ID);
                        fiList = Constant.DataFillBlank.GetListArray(strWhere);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        fiList = Constant.DataFillBlank.GetListArrayByPaging(hi.SqlSearch);
                    }
                    ep.Append("\r\n");
                    ep.Append(mi.Subject);
                    ep.AppendFormat("\r\n");
                    ep.AppendFormat("\r\n");

                    foreach (FillInfo fi in fiList)
                    {
                        if (fi.MainSubject != mi.CurrentID)
                            continue;
                        //检查试题列表项
                        fi.CurrentMainSubject = mi;
                        fi.MainSubjectTitle = mi.Subject;
                        CurrentExamItemList.Add(fi as ExamItemInfo);


                        ep.Append(currentSubjectNo);
                        ep.Append(".");
                        ep.Append(fi.Subject);
                        ep.Append("\r\n");
                        ep.Append(fi.Key);
                        ep.Append("\r\n");

                        currentSubjectNo++;

                    }
                }
                //==============================================QUESTION==========================================     
                else if (qt == ConstInfo.QuestionType.Question)
                {

                    Quest quest = new Quest();

                    List<QuestionInfo> qiList = null;

                    if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Normal)
                    {
                        strWhere = GenerateQuery(temp, mi.ID);
                        qiList = quest.GetListArray(strWhere);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        qiList = quest.GetListArrayByPaging(hi.SqlSearch);
                    }

                    int index;
                    ep.Append("\r\n");
                    ep.Append(mi.Subject);
                    ep.AppendFormat("\r\n");
                    ep.AppendFormat("\r\n");

                    foreach (QuestionInfo qi in qiList)
                    {
                        if (qi.MainSubject != mi.CurrentID)
                            continue;
                        //检查试题列表项
                        qi.CurrentMainSubject = mi;
                        qi.MainSubjectTitle = mi.Subject;
                        CurrentExamItemList.Add(qi as ExamItemInfo);
                        index = qi.Index;

                        //subjectdetail
                        if (!string.IsNullOrEmpty(qi.SubjectDetail))
                        {
                            SubjectDetailInfo detailInfo = null;

                            if (qi.SubjectDetail == ConstInfo.SUBJECT_DETAIL_FIRST)
                            {
                                ep.Append(currentSubjectNo);
                                ep.Append(". ");
                                detailInfo = Constant.SubjectDetail.GetModel(qi.ID, qi.ExamInfoID, qi.MainSubjectID);
                                ep.Append(detailInfo.Content);
                            }
                            else
                            {

                                int detailID = Convert.ToInt32(qi.SubjectDetail);
                                detailInfo = Constant.SubjectDetail.GetModel(detailID);
                                ep.Append(currentSubjectNo);
                                ep.Append(". ");

                                if (temp.ExamQueryStyle != TemplateInfo.QueryStyle_Normal || temp.TestWay == ConstInfo.TestWay.错题重做 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题)
                                {
                                    ep.Append(detailInfo.Content);

                                }
                            }
                        }
                        else
                        {
                            ep.Append(currentSubjectNo);
                            ep.Append(". ");
                        }

                        //subject

                        ep.Append(qi.Subject);
                        ep.Append("\r\n");
                        ep.Append("\r\n");
                        ep.Append(qi.Key);
                        ep.Append("\r\n");
                       // ep.Append("\r\n");
                        //SImage
                        //if (!string.IsNullOrEmpty(qi.SImage))
                        //{
                        //    ep.AppendFormat("<br/>");
                        //    string prefixSubjectImage = GetImagePrefixName(qi.ExamInfoID, mi.CurrentID, Constant.ImageOwner.Subject);
                        //    string subjectImage = prefixSubjectImage + qi.ID.ToString() + qi.SImage;

                        //    ep.AppendFormat("<img src=\"{0}\"   style=\"margin:5px 0 0 20px;\" alt=\"{1}\" />", imageLib + subjectImage, "");
                        //}

                        //image
                        //string image = "";

                        //if (!string.IsNullOrEmpty(qi.AImage))
                        //{
                        //    image = "<br/>";
                        //    string prefixAnswerImage = GetImagePrefixName(qi.ExamInfoID, mi.CurrentID, Constant.ImageOwner.Answer);
                        //    string answerImage = prefixAnswerImage + qi.ID.ToString() + qi.AImage;

                        //    image += string.Format("<img src=\"{0}\"   style=\"margin:5px 0 0 20px;\" alt=\"{1}\" /> <br/>", imageLib + answerImage, "");
                        //}

                        currentSubjectNo++;
                    }
                    ep.Append("\r\n");

                }

            }

            return ep.ToString();
        }
        /// <summary>
        /// 前缀
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="mid"></param>
        /// <param name="io"></param>
        /// <returns></returns>
        public static string GetImagePrefixName(int eid, string mid, Constant.ImageOwner io)
        {
            StringBuilder prefixInfo = new StringBuilder();

            prefixInfo.Append(eid);
            prefixInfo.Append("-");
            prefixInfo.Append(mid);
            prefixInfo.Append("-");

            if (io == Constant.ImageOwner.Answer)
                prefixInfo.Append("A-");
            else
                prefixInfo.Append("S-");

            return prefixInfo.ToString();
        }


        /// <summary>
        /// 正常考试
        /// </summary>
        /// 
        public static string GenerateQuery(TemplateInfo temp, int msid)
        {

            if (temp.ExamQueryStyle !=  TemplateInfo.QueryStyle_Search)
                return string.Empty;

            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("ExamInfoID = {0} AND MainSubjectID ={1} ", temp.ExamInfoID, msid);

            if (temp.TestWay == ConstInfo.TestWay.正式考试 || temp.TestWay == ConstInfo.TestWay.试题学习)
                return sql.ToString();

            else if (temp.TestWay == ConstInfo.TestWay.随机抽题)
            {
                Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
                int intRandomNumber = rnd.Next();

                sql.Append("Order By Rnd(" + (-1 * intRandomNumber) + "*id)");
                return sql.ToString();
            }

            else if (temp.TestWay == ConstInfo.TestWay.我的收藏)
            {
                sql.AppendFormat("AND Fav = true ORDER BY ID ASC");
                return sql.ToString();
            }

            else if (temp.TestWay == ConstInfo.TestWay.错题重做)
            {
                sql.AppendFormat("AND InCorrectNo > 0 ORDER BY InCorrectNo DESC");
                return sql.ToString();
            }

            return sql.ToString();
        }


        /// <summary>
        /// 打印答案
        /// </summary>
        /// <returns></returns>
        public static string GetKeyCollection()
        {
            if (CurrentExamItemList.Count == 0)
                return String.Empty;


            StringBuilder collection = new StringBuilder();

            int id = 0;
            for (int i = 0; i < CurrentExamItemList.Count; i++)
            {

                id = i + 1;
                collection.AppendFormat("[{0}]", id);
                if (CurrentExamItemList[i] is JudgementInfo)
                    collection.Append((CurrentExamItemList[i] as JudgementInfo).KeyText);
                else
                    collection.Append(CurrentExamItemList[i].Key);

                collection.Append(" ");
                switch (CurrentExamItemList[i].GetType().Name)
                {
                    case "SelectionInfo":
                        if (id % 5 == 0)
                            collection.Append("\r\n");
                        continue;
                    case "JudgementInfo":
                    case "FillInfo":
                        if (id % 10 == 0)
                            collection.Append("\r\n");
                        continue;
                }
                collection.Append("\r\n");
            }
            return collection.ToString();
        }
    }
}
