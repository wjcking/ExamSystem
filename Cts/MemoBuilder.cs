using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataUtility;

namespace Cts
{
    public  class MemoBuilder
    {

        public static string ScriptVariants = "";

    
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
            else
            {
                majorSubjectInfoList = Constant.DataMajorSubject.GetListArray(temp);
                examInfo = Constant.DataExamSys.GetModel(temp.ExamInfoID);
            }

            if (examInfo == null)
                return string.Empty;


            if (majorSubjectInfoList.Count == 0)
                return string.Empty;

            string template = temp.TemplateContent;

            StringBuilder ep = new StringBuilder();

            //脚本下标
            int svi = 0;
            //试题图片位置
            string imageLib = temp.TemplatPath + "ImageLib\\";

            string[] elementIDs = new string[majorSubjectInfoList.Count];

            int currentSubjectNo = 1;

            //initialize static variants for javascript.
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
                if (qt == ConstInfo.QuestionType.Question)
                {

                    Quest quest = new Quest();

                    List<QuestionInfo> qiList = null;

                    if (temp.ExamQueryStyle == TemplateInfo.QueryStyle_Search)
                    {
                        strWhere = EPBuilder.GenerateQuery(temp, mi.ID);
                        qiList = quest.GetListArray(strWhere);
                    }
                    else
                    {
                        HistoryInfo hi = temp.GetHistoryInfoByMainSubjectID(mi.ID);
                        qiList = quest.GetListArrayByPaging(hi.SqlSearch);
                    }

                    int index;

                    ep.AppendFormat("\r\n<div id=\"divPanel{0}\" style=\"display:none\">", mi.CurrentID);
                    ep.AppendFormat("\r\n<div>{0}</div>", mi.Subject);
                    ep.AppendFormat("\r\n<p style='color:gray; font-weight:normal'>{0}</p>", StrTool.StrToHtm(mi.Content));

                    foreach (QuestionInfo qi in qiList)
                    {

                        if (qi.MainSubject != mi.CurrentID)
                            continue;
                        //检查试题列表项
                        qi.CurrentMainSubject = mi;
                        qi.MainSubjectTitle = mi.Subject;

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
                        ep.AppendFormat("<div id=\"{0}\" style=\"display:{1}\" >", divSubjectPanelID, (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个) ? "none" : "normal");

                        //Anchors
                        ep.AppendFormat("\r\n<a name=\"an{0}{1}\" id=\"an{0}{1}\"  style='display:none'>{2}</a>", mi.CurrentID, index, index);
              


                        //subjectdetail
                        if (!string.IsNullOrEmpty(qi.SubjectDetail))
                        {
                            SubjectDetailInfo detailInfo = null;

                            if (qi.SubjectDetail == ConstInfo.SUBJECT_DETAIL_FIRST)
                            {
                                ep.Append(currentSubjectNo);
                                ep.Append(". ");
                                detailInfo = Constant.SubjectDetail.GetModel(qi.ID, qi.ExamInfoID, qi.MainSubjectID);
                                ep.AppendFormat("<span style=\"margin:0 10px 5px 10px;\">{0}<br/></span>", Cts.StrTool.StrToHtm(detailInfo.Content));
                            }
                            else
                            {

                                int detailID = Convert.ToInt32(qi.SubjectDetail);
                                detailInfo = Constant.SubjectDetail.GetModel(detailID);
                                ep.Append(currentSubjectNo);
                                ep.Append(". ");

                                if (temp.DisplayStyle == ConstInfo.DisplayStyle.逐个)
                                {
                                    ep.AppendFormat("<span style=\"margin:0 10px 5px 10px;\">{0}<br/></span>", Cts.StrTool.StrToHtm(detailInfo.Content));
                                }
                                else if (temp.ExamQueryStyle != TemplateInfo.QueryStyle_Normal || temp.TestWay == ConstInfo.TestWay.错题重做 || temp.TestWay == ConstInfo.TestWay.我的收藏 || temp.TestWay == ConstInfo.TestWay.随机抽题)
                                {
                                    ep.AppendFormat("<span style=\"margin:0 10px 5px 10px;\" style=\"display:none;\" id=\"spanDetail{0}\">{1}<br/></span>", seed, Cts.StrTool.StrToHtm(detailInfo.Content));
                                   // ep.AppendFormat("<input type=\"button\" onclick=\"this.style.display='none';$('spanDetail{0}').style.display='';\" class=\"buttonRectangle\" value=\"明细\">", seed);
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
                        //if (!qi.Fav)
                        //    ep.AppendFormat("  <img title='添加收藏' onclick=\"window.external.UpdateFav({0}, 'true', '{1}');this.style.display='none';\" src='[#TempImagePath#]fav.png' style='border:0px;'/>{2}", (int)qt, index, "");

                        if (temp.TestWay == ConstInfo.TestWay.试题学习)
                        {
                            //search
                            //ep.AppendFormat(" <img title='标题关键字检索' src='[#TempImagePath#]search.gif' style='border:0px;' onclick=\"window.external.GotoLibrary($('{0}').innerText)\"/>", subjectId);
                            //user answers
                            ep.AppendFormat("<div style='display:none' id=\"{0}\">{1}</div>", lastAnswer, qi.Answer);
                            // the last answers
                            if (!String.IsNullOrEmpty(qi.Answer))
                                ep.AppendFormat("<img src='[#TempImagePath#]ua.gif' onclick=\"$('{0}').value = $('{1}').innerHTML;\" alt=\"显示上次作答\" />", userAnswerID, lastAnswer);
                            //display key by letters
                            //ep.AppendFormat("<a href='###' onclick=\"Javascript:setQuestionKey(document.getElementById('{0}').innerText, document.getElementById('{1}').innerText, {2})\"><img title='答案' src='[#TempImagePath#]key.gif' style='border:0px;width:15px;height:16px'/></a>", subjectId, divKey, 100);
                            //show key
                            //ep.AppendFormat(" <a href='###' onclick=\"getKey('{0}');\"><img title='答案' src='[#TempImagePath#]key.gif' style='border:0px;width:15px;height:16px'/></a>", seed);
                        }


                        //SImage
                        if (!string.IsNullOrEmpty(qi.SImage))
                        {
                            ep.AppendFormat("<br/>");
                            string prefixSubjectImage = EPBuilder.GetImagePrefixName(qi.ExamInfoID, mi.CurrentID, Cts.Constant.ImageOwner.Subject);
                            string subjectImage = prefixSubjectImage + qi.ID.ToString() + qi.SImage;

                            ep.AppendFormat("<img src=\"{0}\"   style=\"margin:5px 0 0 20px;\" alt=\"{1}\" />", imageLib + subjectImage, "");
                        }

                        ep.Append("\r\n<br/>\r\n");
                        //qi.Key.Length
                        //ep.AppendFormat("\r\n　 <textarea  id=\"userAnswerID{0}{1}\" style='width:70%;height:80px' ></textarea>\r\n", qi.MainSubject, index);
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
                            string prefixAnswerImage = EPBuilder.GetImagePrefixName(qi.ExamInfoID, mi.CurrentID, Constant.ImageOwner.Answer);
                            string answerImage = prefixAnswerImage + qi.ID.ToString() + qi.AImage;

                            image += string.Format("<img src=\"{0}\"   style=\"margin:5px 0 0 20px;\" alt=\"{1}\" /> <br/>", imageLib + answerImage, "");
                        }
                        //key
                        ep.AppendFormat("\r\n<div id=\"divKey{0}{1}\" style=\" padding:2px 2px 2px 2px\" class=\"classKey\">{2}</div>\r\n", qi.MainSubject, index, image + StrTool.StrToHtm(qi.Key));
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

                svi++;

            }

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

            template = template.Replace("[#temp.Name#]", temp.Title);
            template = template.Replace("[#temp.Time#]", examInfo.Time.ToString());
            template = template.Replace("[#temp.Score#]", examInfo.Score.ToString());
            template = template.Replace("[#temp.Content#]", StrTool.StrToHtm(examInfo.Content));
            template = template.Replace("[#temp.ExamArea#]", examArea);

            template = template.Replace("<%= epVariants %>",EPBuilder.GetScript(majorSubjectInfoList));


            return template;
        }
    }
}
