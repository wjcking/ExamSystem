using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataUtility;

namespace Cts
{
    public static class EPBuilder
    {
        public static string ScriptVariants = "";
        public static List<MainSubjectInfo> CurrentMsiList;
        public static List<ExamItemInfo> CurrentExamItemList = new List<ExamItemInfo>();
        
        public static string GetScript(List<MainSubjectInfo> msiList)
        {
            StringBuilder ep = new StringBuilder();
            int index = 0;

            foreach (MainSubjectInfo mi in msiList)
            {
                ep.AppendFormat("\r\n // {0}", mi.Subject);
                ep.AppendFormat("\r\n mainSubject[{0}] = \"{1}\";", index, mi.Subject);
                ep.AppendFormat("\r\n mainSubjectID[{0}] = \"{1}\";", index, mi.CurrentID);
                ep.AppendFormat("\r\n typeID[{0}] = \"{1}\";", index, mi.Type);
                ep.AppendFormat("\r\n mainSubjectCount[{0}] = \"{1}\";", index, mi.Count);
                ep.AppendFormat("\r\n eachPoint[{0}] = \"{1}\";", index, mi.EachPoint);
                ep.AppendFormat("\r\n resultsArray[{0}] ={1};", index, 0);                                      
                ep.AppendFormat("\r\n subjectIDArray[{0}] = {1};", index, "null");

                index++;
            }

            return ep.ToString();
        }

        public static string Build(TemplateInfo temp)
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
            else if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Regroup)
            {
                examInfo = new ExamInfo();
                majorSubjectInfoList = new List<MainSubjectInfo>();
                
                foreach (RegroupQuery rq in temp.RegroupQueryList)
                {
                    majorSubjectInfoList.Add(rq.MainSubjectInfo);
                    
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

            //脚本下标
            int svi = 0;
            //试题图片位置
            string imageLib = temp.TemplatPath + "ImageLib\\";
            string imageFav = temp.TemplatPath + "Images\\fav.gif";
            string imageKey = temp.TemplatPath + "Images\\key.gif";
            string imageLastAnswer = temp.TemplatPath + "Images\\lastAnswer.gif";
            //清空
            CurrentExamItemList.Clear();
            string[] elementIDs = new string[majorSubjectInfoList.Count];

            int currentSubjectNo = 1;

            ScriptVariants = "";
            
            foreach (MainSubjectInfo mi in majorSubjectInfoList)
            {
                ep.Append("\r\n<div style=\"font-weight:bold;font-size:14px; \">\r\n");
                ep.Append("\r\n</div>\r\n");

                if (mi.Type == 0)
                    continue;

                string strWhere = "";
                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)mi.Type;

                //==============================================CHOICE==========================================       
                if (qt == ConstInfo.QuestionType.Selection)
                {
                    Select select = new Select();
                    List<SelectionInfo> slist = null;
                    //正常考试
                    if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Normal)
                    {
                        strWhere = GenerateQuery(temp, mi.ID);
                        slist = select.GetListArray(strWhere);


                    }
                    else if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Regroup)
                    {
                        RegroupQuery rq = temp.GetRegroupQueryByMainSubjectID(mi.ID);
                        slist = select.GetListArrayByPaging(rq.SqlQuery);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        slist = select.GetListArrayByPaging(hi.SqlSearch);
                    }
                    int index;

                    ep.AppendFormat("\r\n<div id=\"divPanel{0}\" style=\"display:none\">", mi.CurrentID);
                    ep.AppendFormat("\r\n<div>{0}</div>", mi.Subject);                    
                    ep.AppendFormat("\r\n<p style='font-weight:normal'>{0}</p>", StrTool.StrToHtm(mi.Content));

                    foreach (SelectionInfo si in slist)
                    {

                        if (si.MainSubject != mi.CurrentID)
                        {
                            continue;
                        }
                        //检查试题列表项
                        si.CurrentMainSubject = mi;
                        si.MainSubjectTitle = mi.Subject;
                        CurrentExamItemList.Add(si as ExamItemInfo);

                        index = si.Index;
                        //initialize javascript variants
                        elementIDs[svi] += mi.CurrentID + index.ToString() + ",";


                        //class
                        string classSubjectPanel = String.Format("ClassSubjectPanel{0}", mi.CurrentID);

                        //id
                        string seed = mi.CurrentID + index.ToString();
                        string divAnalysis = string.Format("divAnalysis{0}{1}", mi.CurrentID, index);
                        string classKey = "clsChoiceKey";
                        string subjectId = String.Format("subject{0}{1}", mi.CurrentID, index);
                        string divKey = string.Format("divKey{0}{1}", mi.CurrentID, index);
                        string userAnswerID = String.Format("userAnswerID{0}{1}", mi.CurrentID, index);
                        string divSubjectPanelID = string.Format("subjectPanel{0}{1}", mi.CurrentID, index); 
                        string anchorID = "an" + mi.CurrentID + index.ToString();
                        ep.AppendFormat("<div id=\"{0}\" style=\"display:{1}\" class='{2}'>", divSubjectPanelID, (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个) ? "none" : "block", classSubjectPanel);
                        //Anchors
                        ep.AppendFormat("\r\n<a href='' name=\"an{0}{1}\" id=\"an{0}{1}\" class='{2}' style='display:none'>{3}</a>", mi.CurrentID, index, "classAnchor", index);
                     
                        //subject number
                        //subjectdetail
                        if (!string.IsNullOrEmpty(si.SubjectDetail))
                        {
                            SubjectDetailInfo detailInfo = null;

                            if (si.SubjectDetail == ConstInfo.SUBJECT_DETAIL_FIRST)
                            {
                                //ep.Append(currentSubjectNo);
                                //ep.Append(". ");
                                detailInfo = Constant.GetSubjectDetailInfo(si.ID, si.ExamInfoID, si.MainSubjectID);
                                ep.AppendFormat("<span class=\"subjectDetail\">{0}<br/></span>", detailInfo.CombinedContent);
                            }
                            else
                            {

                                int detailID = Convert.ToInt32(si.SubjectDetail);
                                detailInfo = Constant.GetSubjectDetailInfo(detailID);
                                //ep.Append(currentSubjectNo);
                                //ep.Append(". ");

                                if (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个)
                                {
                                    ep.AppendFormat("<span class=\"subjectDetail\">{0}<br/></span>", detailInfo.CombinedContent);
                                }
                                else if (temp.ExamQueryStyle  != TemplateInfo.QueryStyle_Normal || temp.TestWay == ConstInfo.TestWay.错题重做 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题)
                                {
                                    ep.AppendFormat("<span class=\"subjectDetail\" id=\"spanDetail{0}\">{1}<br/></span>", seed, detailInfo.CombinedContent);
                                  //  ep.AppendFormat("<input type=\"button\" onclick=\"this.style.display='none';document.getElementById('spanDetail{0}').style.display='';\" class=\"buttonRectangle\" value=\"明细\">", seed);
                                }
                            }

                        }
                    

                        //标记此题
                        ep.AppendFormat("<input type='checkbox' title='标记此题'  id='Mark{0}{1}' class='{2}'/>", mi.CurrentID, index, "classMark");
                        //题号
                        ep.Append(currentSubjectNo);
                        ep.Append(". ");
                        //题目
                        ep.AppendFormat("<span id=\"{0}\" class='{1}'>{2}</span>\r\n", subjectId, "classSubject", si.Subject);

                  

                        //Fav
                        if (!si.Fav)
                            ep.AppendFormat("<img class=\"addFav\" alt=\"添加收藏\" onclick=\"window.external.UpdateFav({0}, 'true', '{1}');this.style.display='none';\"   style='border:0px;' src=\"{2}\"/>", (int)qt, index, imageFav);

                        if (temp.TestWay == ConstInfo.TestWay.试题学习 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题 || temp.TestWay == ConstInfo.TestWay.错题重做)
                        {
                        
                          //getchoiceley function (javascript)
                            string jsGetChoiceKey = String.Format("window.external.GetChoiceKey({0}, '{1}', '{2}', '{3}');", si.Multiple.ToString().ToLower(), mi.CurrentID, index.ToString(), si.Key.ToUpper().Trim());
                            string jsGetKey = String.Format("getKey('{0}');", seed);
                            //show key
                            ep.AppendFormat("<img class=\"showKey\"   style='border:0px;' onclick=\"{0}\" src=\"{1}\"/>", jsGetChoiceKey + jsGetKey, imageKey);
                            //user answers
                            if (!String.IsNullOrEmpty(si.Answer))
                                ep.AppendFormat("<img  onclick=\"document.getElementById('{0}').innerText ='{1}';\" class=\"lastAnswer\" alt=\"上次作答\"  src=\"{2}\"/>", userAnswerID, si.Answer, imageLastAnswer);
                     
                        }


                        //SImage
                        if (!string.IsNullOrEmpty(si.SImage))
                        {
                            ep.AppendFormat("<br/>");

                          
                            ep.AppendFormat("<img src=\"{0}\"  class=\"examImageLib\" alt=\"{1}\" />", imageLib+ si.SImageName, "");
                        }

                        if (si.Subject.Trim().Length > 4 && si.BreakType == 0)
                            ep.Append("\r\n<br/>\r\n");

                        //choice
                        ep.Append("<div style=\"margin:0px 0 20px 2px\">");
                        ep.Append(Cts.StrTool.GenerateChoices(si));    
                        //用户作答
                        ep.AppendFormat("<br /> ");
                     //   ep.AppendFormat(" <img  class=\"imgMyAnswer\" alt=\"我的作答\"/> ");
                        ep.AppendFormat("<span id='{0}'  class='classAnswer'></span> \r\n", userAnswerID);
                        ep.Append("</div>\r\n");

                        //SI.INDEX
                        string hidID = String.Format("hidChoice_{0}_{1}", mi.CurrentID, index);
                        string hidName = hidID;

                        ep.AppendFormat("\r\n<input type=\"hidden\" name=\"{0}\" id=\"{0}\" />\r\n", hidName, hidID);
                        //divtip
                        if (string.IsNullOrEmpty(si.Analysis))

                            ep.AppendFormat("<span id=\"divTip{0}\" style=\"margin:10px 6px 10px 6px; \">", seed);
                        else
                            ep.AppendFormat("<div id=\"divTip{0}\" style=\"margin:10px 6px 10px 6px; \">", seed);

                    
                        //keytip
                        ep.AppendFormat("\r\n<span id=\"spanKeyTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, classKey, "答案：");
                        
                        string image = "";

                        if (!string.IsNullOrEmpty(si.AImage))
                        {
                            image =  string.Format("<img src=\"{0}\"  class=\"examImageLib\" alt=\"{1}\" /> <br />", imageLib + si.AImageName, "");
                          
                        }
                       
                        //key
                        ep.AppendFormat("\r\n<span id=\"{0}\" style=\"display:none;\" class='{1}'>{2}</span>\r\n", divKey, classKey, si.Key.Trim());

                        //AnalysisTip
                        ep.AppendFormat("\r\n<span id=\"spanAnalysisTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, classKey, "分析：");
                        //Analysis
                        ep.AppendFormat("\r\n<span id=\"{0}\" style=\"display:none;\" class='{1}'>{2}</span>\r\n", divAnalysis, classKey, si.Analysis+image);
   

                        //close subjectPanelID div
                        if (string.IsNullOrEmpty(si.Analysis))
                            ep.Append("\r\n</span>\r\n");
                        else
                            ep.Append("\r\n</div>\r\n");
                  

                        ep.Append("\r\n</div>\r\n");
                        currentSubjectNo++;
                    }
                    ep.Append("\r\n</div>\r\n");
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
                    else if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Regroup)
                    {
                        RegroupQuery rq = temp.GetRegroupQueryByMainSubjectID(mi.ID);
                        jiList = judge.GetListArrayByPaging(rq.SqlQuery);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        jiList = judge.GetListArrayByPaging(hi.SqlSearch);
                    }

                    int index;
                    ep.AppendFormat("\r\n<div id=\"divPanel{0}\" style=\"display:none\">", mi.CurrentID);


                    ep.AppendFormat("\r\n<div>{0}</div>", mi.Subject);
                    ep.AppendFormat("\r\n<p style='font-weight:normal'>{0}</p>", StrTool.StrToHtm(mi.Content));

                    foreach (JudgementInfo ji in jiList)
                    {

                        if (ji.MainSubject != mi.CurrentID)
                            continue;
                        //检查试题列表项
                        ji.CurrentMainSubject = mi;
                        ji.MainSubjectTitle = mi.Subject;
                        CurrentExamItemList.Add(ji as ExamItemInfo);

                        index = ji.Index;
                        elementIDs[svi] += mi.CurrentID + index.ToString() + ",";
                        //class
                        string classSubjectPanel = String.Format("ClassSubjectPanel{0}", mi.CurrentID);

                        //id    
                        string seed = mi.CurrentID + index.ToString();
                        string divAnalysis = string.Format("divAnalysis{0}{1}", mi.CurrentID, index);
                        string classKey = "clsJudgeKey";
                        string divSubjectPanelID = string.Format("subjectPanel{0}{1}", mi.CurrentID, index);
                        string subjectId = String.Format("subject{0}{1}", mi.CurrentID, index);
                        string divKey = string.Format("divKey{0}{1}", mi.CurrentID, index);
                        string anchorID = "an" + mi.CurrentID + index.ToString();
                        //panels for each choice subject
                        ep.AppendFormat("<div id=\"{0}\" style=\"display:{1}\" class='{2}'>", divSubjectPanelID, (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个) ? "none" : "inline", classSubjectPanel);

                        //Anchors
                        ep.AppendFormat("\r\n<a name=\"an{0}{1}\" id=\"an{0}{1}\" class='{2}' style='display:none'>{3}</a>", mi.CurrentID, index, "classAnchor", index);


                        string rdoName = string.Format("chkJudge_{0}_{1}", ji.MainSubject, index);
                        string keyJudge = string.Format("keyJudge_{0}_{1}", ji.MainSubject, index);
                        string userAnswerID = "userAnswerID" + mi.CurrentID + index;

                        // to save users' answers into a hidden span.
                        string scriptGetUserJudgeAnswer = string.Format("GetUserJudgeAnswer('{0}','{1}')", rdoName, userAnswerID);

                        //for each subject in   divs
                        //marks
                        ep.AppendFormat("<input type='checkbox' title='标记此题' id='Mark{0}{1}' class='{2}'/>", mi.CurrentID, index, "classMark");
                        //subject number
                        ep.Append(currentSubjectNo);
                        ep.Append(". ");
                        //subjects
                        ep.AppendFormat("<span id=\"{0}\" class='{1}'>{2}</span>", subjectId, "classSubject", ji.Subject);
                        //the users' anwsers
                        ep.Append("(");
                        ep.AppendFormat("<span id=\"userAnswerID{0}{1}\" style='' class='{2}'></span>", ji.MainSubject, index, "classAnswer");
                        ep.Append(")");
                        //Fav
                        if (!ji.Fav)
                            ep.AppendFormat("  <img class=\"addFav\" alt=\"添加收藏\" onclick=\"window.external.UpdateFav({0}, 'true', '{1}');this.style.display='none';\"   style='border:0px;' src=\"{2}\"/>", (int)qt, index, imageFav);

                        if (temp.TestWay == ConstInfo.TestWay.试题学习 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题 || temp.TestWay == ConstInfo.TestWay.错题重做)
                        {
                            ep.AppendFormat("<img class=\"showKey\" onclick=\"getKey('{0}');\" style='border:0px' src=\"{1}\"/>", seed, imageKey);

                            if (!String.IsNullOrEmpty(ji.Answer))
                                ep.AppendFormat("<img  onclick=\"document.getElementById('{0}').innerText ='{1}';\" class=\"lastAnswer\" alt=\"上次作答\"  src=\"{2}\"/>", userAnswerID, ji.Answer, imageLastAnswer);

                        }

                        //SImage
                        if (!string.IsNullOrEmpty(ji.SImage))
                        {
                            ep.AppendFormat("<br/>");

                       
                            ep.AppendFormat("<img src=\"{0}\"    class=\"examImageLib\" alt=\"{1}\" />", imageLib + ji.SImageName, "");
                        }
               
                        ep.Append("<div style=\"margin:0 0 0 20px;\">");
                        ep.AppendFormat("\r\n<input type=\"radio\" name=\"{0}\" value=\"√\"  onclick=\"{1}\"/>\r\n", rdoName, scriptGetUserJudgeAnswer);
                        ep.Append("√");
                        ep.AppendFormat("\r\n<input type=\"radio\" name=\"{0}\" value=\"×\"  onclick=\"{1}\"/>\r\n", rdoName, scriptGetUserJudgeAnswer);
                        ep.Append("×");
                        ep.Append("</div>");
                        //divtip
                        ep.AppendFormat("<span id=\"divTip{0}\" class=\"judgeTip\">", seed);
                        //keytip
                        ep.AppendFormat("\r\n<span id=\"spanKeyTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, classKey, "答案：");

                        //image
                        //string image = "";

                        //if (!string.IsNullOrEmpty(ji.AImage))
                        //{
                        //    image = "<br/>";
                        //    image += string.Format("<img src=\"{0}\"  class=\"examImageLib\" alt=\"{1}\" /> <br />", imageLib + ji.AImageName, "");
                        //}
                        //key
                        ep.AppendFormat("\r\n<span id=\"{0}\" style=\"display:none;\" class='{1}'>{2}</span>\r\n", divKey, "classKey", ji.KeyText);
                        //AnalysisTip
                        ep.AppendFormat("\r\n<span id=\"spanAnalysisTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, classKey, "分析：");
                        //Analysis
                        ep.AppendFormat("\r\n<span id=\"{0}\" style=\"display:none;\" class='{1}'>{2}</span>\r\n", divAnalysis, classKey, ji.Analysis);
                        //END div tip
                        ep.Append("</span>");
                        //keys
                        ep.AppendFormat("\r\n<input type=\"hidden\" id=\"hidJudge_{0}_{1}\" name=\"hidJudge_{0}_{1}\" value=\"{2}\"/>\r\n", ji.MainSubject, index, ji.Key);
                        ep.Append("\r\n<br />\r\n");
                        ep.Append("\r\n</div>");



                        currentSubjectNo++;
                    }
                    ep.Append("\r\n</div>");
                }
                //==============================================FILL==========================================     
                else if (qt == ConstInfo.QuestionType.Fill)
                {
                    List<FillInfo> fiList = null;

                    if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Normal)
                    {
                        strWhere = GenerateQuery(temp, mi.ID);
                        fiList =  Constant.DataFillBlank.GetListArray(strWhere);
                    }
                    else if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Regroup)
                    {
                        RegroupQuery rq = temp.GetRegroupQueryByMainSubjectID(mi.ID);
                        fiList = Constant.DataFillBlank.GetListArrayByPaging(rq.SqlQuery);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        fiList = Constant.DataFillBlank.GetListArrayByPaging(hi.SqlSearch);
                    }

                    int index;

                    ep.AppendFormat("\r\n<div id=\"divPanel{0}\" style=\"display:none\">", mi.CurrentID);
                    ep.AppendFormat("\r\n<div>{0}</div>", mi.Subject);
                    ep.AppendFormat("\r\n<p style='font-weight:normal'>{0}</p>", StrTool.StrToHtm(mi.Content));

                    foreach (FillInfo fi in fiList)
                    {
                        if (fi.MainSubject != mi.CurrentID)
                            continue;
                        //检查试题列表项
                        fi.CurrentMainSubject = mi;
                        fi.MainSubjectTitle = mi.Subject;
                        CurrentExamItemList.Add(fi as ExamItemInfo);

                        index = fi.Index;
                        elementIDs[svi] += mi.CurrentID + index.ToString() + ",";

                        string seed = mi.CurrentID + index.ToString();
                        string divAnalysis = string.Format("divAnalysis{0}{1}", mi.CurrentID, index);
                        string subjectId = String.Format("subject{0}{1}", mi.CurrentID, index);
                        string divKey = string.Format("divKey{0}{1}", mi.CurrentID, index);
                        string userAnswerID = "userAnswerID" + mi.CurrentID + index.ToString();
                        string anchorID = "an" + mi.CurrentID + index.ToString();
                        string lastAnswer = "lastAnswer" + mi.CurrentID + index.ToString();
                        //id
                        string divSubjectPanelID = string.Format("subjectPanel{0}{1}", mi.CurrentID, index);

                        //panels for each choice subject
                        ep.AppendFormat("<div id=\"{0}\" style=\"display:{1}\" >", divSubjectPanelID, (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个) ? "none" : "normal");

                        //Anchors
                        ep.AppendFormat("\r\n<a name=\"an{0}{1}\" id=\"an{0}{1}\"  style='display:none'>{2}</a>", mi.CurrentID, index, index);

                        //marks
                        ep.AppendFormat("<input type='checkbox' title='标记此题' id='Mark{0}{1}'/>", mi.CurrentID, index);
                        //subject number
                        ep.Append(currentSubjectNo);
                        ep.Append(". ");
                        //subject
                        ep.AppendFormat("<span id=\"{0}\">{1}</span>", subjectId, fi.Subject.Replace(" ", "_"));
                        //Fav
                        if (!fi.Fav)
                            ep.AppendFormat("  <img class=\"addFav\" alt=\"添加收藏\" onclick=\"window.external.UpdateFav({0}, 'true', '{1}');this.style.display='none';\"   style='border:0px;' src=\"{2}\"/>", (int)qt, index, imageFav);

                        if (temp.TestWay == ConstInfo.TestWay.试题学习 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题 || temp.TestWay == ConstInfo.TestWay.错题重做)
                        {
                          //key
                            ep.AppendFormat("<img class=\"showKey\"  onclick=\"getKey('{0}')\"   style='border:0px;' src=\"{1}\"/>", seed, imageKey);
                    
                            //user answers
                            ep.AppendFormat("<div style='display:none' id=\"{0}\">{1}</div>", lastAnswer, fi.Answer);

                            if (!String.IsNullOrEmpty(fi.Answer))
                                //ep.AppendFormat("<img  onclick=\"document.getElementById('{0}').innerText ='{1}';\" class=\"lastAnswer\" alt=\"上次作答\"  src=\"{2}\"/>", userAnswerID, fi.Answer, imageLastAnswer);
                                ep.AppendFormat("<img  onclick=\"document.getElementById('{0}').innerText =document.getElementById('{1}').innerText;\" class=\"lastAnswer\" alt=\"上次作答\"  src=\"{2}\"/>", userAnswerID, lastAnswer, imageLastAnswer);
           
                       }

                        //SImage
                        if (!string.IsNullOrEmpty(fi.SImage))
                        {
                            ep.AppendFormat("<br/>");

                            ep.AppendFormat("<img src=\"{0}\"  class=\"examImageLib\" alt=\"{1}\" />", imageLib + fi.SImageName, "");
                        }

                        ep.Append("\r\n<br/>\r\n");
                        ep.AppendFormat("\r\n<input type=\"text\" id=\"{0}\"  size=\"{1}\" style=\"margin:0 0 0 25px;\"  />\r\n", userAnswerID, fi.Key.Length * 2);
                        ep.Append("\r\n<br/>\r\n");

                        //divtip
                        ep.AppendFormat("<span id=\"divTip{0}\" class=\"fillTip\">", seed);
                        //keytip
                        ep.AppendFormat("\r\n<span id=\"spanKeyTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, "", "答案：");

                        //image
                        string image = "";

                        if (!string.IsNullOrEmpty(fi.AImage))
                        {
                            image = string.Format("<img src=\"{0}\"  class=\"examImageLib\" alt=\"{1}\" /> <br />", imageLib + fi.AImageName, "");
                        }
                        //key
                        ep.AppendFormat("\r\n<span id=\"{0}\" class='{1}'>{2}</span>\r\n", divKey, "clsFillKey", fi.Key);
                        //AnalysisTip
                        ep.AppendFormat("\r\n<span id=\"spanAnalysisTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, "", "分析：");
                        //Analysis
                        ep.AppendFormat("\r\n<span id=\"{0}\" style=\"display:none;\" class='{1}'>{2}</span>\r\n", divAnalysis, "", fi.Analysis + image);
                        //END div tip
                        ep.Append("</span>");
                        ep.Append("\r\n</div>");


                        currentSubjectNo++;
                    }
                    ep.Append("\r\n</div>");

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
                    else if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Regroup)
                    {
                        RegroupQuery rq = temp.GetRegroupQueryByMainSubjectID(mi.ID);
                        qiList = quest.GetListArrayByPaging(rq.SqlQuery);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        qiList = quest.GetListArrayByPaging(hi.SqlSearch);
                    }

                    int index;

                    ep.AppendFormat("\r\n<div id=\"divPanel{0}\" style=\"display:none\">", mi.CurrentID);
                    ep.AppendFormat("\r\n<div>{0}</div>", mi.Subject);
                    
                    ep.AppendFormat("\r\n<p style='font-weight:normal'>{0}</p>", StrTool.StrToHtm(mi.Content));

                    foreach (QuestionInfo qi in qiList)
                    {

                        if (qi.MainSubject != mi.CurrentID)
                            continue;
                        //检查试题列表项
                        qi.CurrentMainSubject = mi;
                        qi.MainSubjectTitle = mi.Subject;
                        CurrentExamItemList.Add(qi as ExamItemInfo);

                        index = qi.Index;
                        elementIDs[svi] += mi.CurrentID + index.ToString() + ",";
                        string seed = mi.CurrentID + index.ToString();
                        string divAnalysis = string.Format("divAnalysis{0}{1}", mi.CurrentID, index);
                        string subjectId = String.Format("subject{0}{1}", mi.CurrentID, index);
                        string divKey = string.Format("divKey{0}{1}", mi.CurrentID, index);
                        string userAnswerID = "userAnswerID" + mi.CurrentID + index.ToString();
                        string anchorID = "an" + mi.CurrentID + index.ToString();
                        string lastAnswer = "lastAnswer" + mi.CurrentID + index.ToString();
                        //id
                        string divSubjectPanelID = string.Format("subjectPanel{0}{1}", mi.CurrentID, index);

                        //panels for each choice subject
                        ep.AppendFormat("<div id=\"{0}\" style=\"display:{1}\" >", divSubjectPanelID, (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个) ? "none" : "block");

                        //Anchors
                        ep.AppendFormat("\r\n<a name=\"an{0}{1}\" id=\"an{0}{1}\"  style='display:none'>{2}</a>", mi.CurrentID, index, index);
                        //marks
                        ep.AppendFormat("<input type='checkbox' title='标记此题' id='Mark{0}{1}'/>", mi.CurrentID, index);
             
                        //subjectdetail
                        if (!string.IsNullOrEmpty(qi.SubjectDetail))
                        {
                            SubjectDetailInfo detailInfo = null;

                            if (qi.SubjectDetail == ConstInfo.SUBJECT_DETAIL_FIRST)
                            {
                                ep.Append(currentSubjectNo);
                                ep.Append(". ");
                                detailInfo = Constant.GetSubjectDetailInfo(qi.ID, qi.ExamInfoID, qi.MainSubjectID);

                                ep.AppendFormat("<span class=\"subjectDetail\">");
                                ep.Append(detailInfo.CombinedContent);
                               ep.Append("</span>");
                            }
                            else
                            {

                                int detailID = Convert.ToInt32(qi.SubjectDetail);
                                detailInfo = Constant.GetSubjectDetailInfo(detailID);
                                ep.Append(currentSubjectNo);
                                ep.Append(". ");

                                if (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个)
                                {
                                    ep.AppendFormat("<span class=\"subjectDetail\">{0}<br/></span>", detailInfo.CombinedContent);
                                }
                                else if (temp.ExamQueryStyle != TemplateInfo.QueryStyle_Normal || temp.TestWay == ConstInfo.TestWay.错题重做 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题)
                                {
                                    ep.AppendFormat("<span class=\"subjectDetail\"  id=\"spanDetail{0}\">{1}<br/></span>", seed, detailInfo.CombinedContent);
                                 // ep.AppendFormat("<input type=\"button\" onclick=\"this.style.display='none';document.getElementById('spanDetail{0}').style.display='';\" class=\"buttonRectangle\" value=\"明细\">", seed);
                                }
                            }
                        }
                        else
                        {
                            ep.Append(currentSubjectNo);
                            ep.Append(". ");
                        }
                        
                        //subject
                        ep.AppendFormat("<span id=\"{0}\">{1}</span>", subjectId, qi.Subject);
                        //Fav
                        if (!qi.Fav) 
                            ep.AppendFormat("  <img class=\"addFav\" alt=\"添加收藏\" onclick=\"window.external.UpdateFav({0}, 'true', '{1}');this.style.display='none';\"   style='border:0px;' src=\"{2}\"/>", (int)qt, index, imageFav);

                        if (temp.TestWay == ConstInfo.TestWay.试题学习 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题 || temp.TestWay == ConstInfo.TestWay.错题重做)
                        {       
                            //show key
                            ep.AppendFormat("<img class=\"showKey\" alt=\"显示答案\"  onclick=\"getKey('{0}');\" style='border:0px;' src=\"{1}\"/>", seed,imageKey);
                     
                           //user answers
                            ep.AppendFormat("<div style='display:none' id=\"{0}\">{1}</div>", lastAnswer, qi.Answer);
                            // the last answers
                             if (!String.IsNullOrEmpty(qi.Answer))
                                 ep.AppendFormat("<img  onclick=\"document.getElementById('{0}').innerText =document.getElementById('{1}').innerText;\" class=\"lastAnswer\" alt=\"上次作答\"  src=\"{2}\"/>", userAnswerID, lastAnswer, imageLastAnswer);
                      }


                        //SImage
                        if (!string.IsNullOrEmpty(qi.SImage))
                        {
                            ep.AppendFormat("<br/>");
                        
                            ep.AppendFormat("<img src=\"{0}\" class=\"examImageLib\" alt=\"{1}\" />", imageLib + qi.SImageName, "");
                        }
            
                        ep.Append("\r\n<br/>\r\n");
                        //高度
                        int textareaHeight = qi.Key.Length <=30 ? 25 : qi.Key.Length - Convert.ToInt32(qi.Key.Length*0.5); 

                        //qi.Key.Length
                        ep.AppendFormat("\r\n　 <textarea  id=\"userAnswerID{0}{1}\" style='width:70%;height:{2}px' ></textarea>\r\n", qi.MainSubject, index, textareaHeight);
                        ep.Append("\r\n<br/>\r\n");

                        //divtip
                        ep.AppendFormat("<div id=\"divTip{0}\" style=\"margin:10px 6px 10px 6px; \">", seed);
                        //keytip
                        ep.AppendFormat("\r\n<span id=\"spanKeyTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, "", "");

                        //image
                        string image = "";

                        if (!string.IsNullOrEmpty(qi.AImage))
                        {
                            image = "<br/>";
                            image += string.Format("<img src=\"{0}\"  class=\"examImageLib\" alt=\"{1}\" /> <br />", imageLib + qi.AImageName, "");
                        }
                        //key
                        ep.AppendFormat("\r\n<div id=\"divKey{0}{1}\" class=\"clsQuestionKey\">{2}</div>\r\n", qi.MainSubject, index, image + StrTool.StrToHtm(qi.Key)); 
                        //AnalysisTip
                        ep.AppendFormat("\r\n<span id=\"spanAnalysisTip{0}\" style=\"display:none; \" class='{1}'>{2}</span>\r\n", seed, "", "分析：");
                        //Analysis
                        ep.AppendFormat("\r\n<span id=\"{0}\" style=\"display:none;\" class='{1}'>{2}</span>\r\n", divAnalysis, "", "");

                        ep.Append("</div>");
                        ep.Append("\r\n<br/>\r\n");
                        ep.Append("\r\n</div>");

                        currentSubjectNo++;
                    }
                    ep.Append("\r\n</div>");

                }
                //iterative script variants
                svi++;

            }

            //subscript for javascript
            for (int i = 0; i < elementIDs.Length; i++)
            {
                if (elementIDs[i] == null)
                {
                    elementIDs[i] = "";
                    ScriptVariants += string.Format("subjectIDArray[{0}] =\"\"; \r\n", i);
                    continue;
                }

                ScriptVariants += string.Format("subjectIDArray[{0}] =\"{1}\"; \r\n", i, elementIDs[i].Substring(0, elementIDs[i].LastIndexOf(",")));
                ScriptVariants += "\r\n//------------------------\r\n";
            }

            string examArea = ep.ToString();

            temp.Title = examInfo.Name;
            template = template.Replace("[#temp.Name#]", examInfo.Name);
            template = template.Replace("[#temp.Time#]", examInfo.Time.ToString());
            template = template.Replace("[#temp.Score#]", examInfo.Score.ToString());
            template = template.Replace("[#temp.Content#]", StrTool.StrToHtm(examInfo.Content));
            template = template.Replace("[#temp.ExamArea#]", examArea);

            template = template.Replace("<%= epVariants %>", GetScript(majorSubjectInfoList));
       
      
            return template;
        }




        public static string GenerateQuery(TemplateInfo temp, int msid)
        {

            if (temp.ExamQueryStyle !=   TemplateInfo.QueryStyle_Normal)
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

    }
}
