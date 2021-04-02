using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Xml;

namespace Cts
{
    public class MainSubject : XmlHelper, IExam
    {
        private const string xpathMainSubject = "/ExamSys/{0}/Item[MainSubject={1}]";

        public MainSubject(string fileName)
            : base(fileName)
        {
            singleNodeInfo = ConstInfo.ELEMENT_EXAMSYS + "/" + ConstInfo.ELEMENT_MAINSUBJECT;

        }

        /// <summary>
        /// Add a new main subject element
        /// </summary>
        public string Add(MainSubjectInfo msi)
        {
            base.NewNode(ConstInfo.ELEMENT_MAINSUBJECT, Template.MainSubject(msi));

            return ConstInfo.CTS_HANDLE_DONE;
        }

        /// <summary>
        /// add multiple main subjects by TXT files.
        /// </summary>
        /// <param name="templatePath">XmlModel</param>
        /// <returns></returns>
        public string Add(string templateName)
        {
            base.NewNode(ConstInfo.ELEMENT_MAINSUBJECT, Template.MainSubject(templateName));

            return ConstInfo.CTS_HANDLE_DONE;
        }

        public void Move(int rawid, int id)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes[rawid] == null)
                return;

            string xml = childNodes[rawid].InnerXml;

            childNodes[rawid].InnerXml = childNodes[id].InnerXml;
            childNodes[id].InnerXml = xml;

            xmlDoc.Save(fileName);
        }

        public string Update(MainSubjectInfo msi)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return ConstInfo.CTS_HANDLE_FAILED;
          
            if (!string.IsNullOrEmpty(msi.Subject))
                childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_SUBJECT].InnerText = msi.Subject;

            if (msi.LastTestScore != 0)
                childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_LASTTESTSCORE].InnerText = msi.LastTestScore.ToString();

            if (msi.LimitedTime != 0)
                childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_LIMITEDTIME].InnerText = msi.LimitedTime.ToString();
            if (msi.EachPoint != 0)
                childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_EACHPOINT].InnerText = msi.EachPoint.ToString();

            if (msi.Count != 0)
                childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_COUNT].InnerText = (Convert.ToInt32(childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_COUNT].InnerText) + msi.Count).ToString();

            childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_CONTENT].InnerText = msi.Content;

            childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_ANALYSIS].InnerText = msi.Analysis;

            if (msi.Score != 0)
                childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_SCORE].InnerText = msi.Score.ToString();

            if (msi.Type > 0)
            childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_TYPE].InnerText = msi.Type.ToString();
            childNodes[msi.Index][ConstInfo.SUBELE_MAINSUBJECT_NOTE].InnerText = msi.Note;

            xmlDoc.Save(fileName);

            return ConstInfo.CTS_HANDLE_DONE;
        }

        /// <summary>
        /// Get main subject list.
        /// </summary>
        public List<MainSubjectInfo> GetList()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            List<MainSubjectInfo> listMsi = new List<MainSubjectInfo>();

            if (childNodes.Count < 0)
                return null;

            float scoreSum = 0.0f;
            int subjectSum = 0;

            for (int i = 0; i < childNodes.Count; i++)
            {
                if (string.IsNullOrEmpty(childNodes[i].InnerXml))
                    continue;

                MainSubjectInfo msi = new MainSubjectInfo();

                msi.Index = i;
                msi.CurrentID = childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_ID].InnerText;
                msi.Subject = childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_SUBJECT].InnerText;
                msi.LastTestScore = float.Parse(childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_LASTTESTSCORE].InnerText);
                msi.LimitedTime = int.Parse(childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_LIMITEDTIME].InnerText);
                msi.EachPoint = float.Parse(childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_EACHPOINT].InnerText);

                msi.Content = childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_CONTENT].InnerText;
                msi.Analysis = childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_ANALYSIS].InnerText;

           

                msi.Type = int.Parse(childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_TYPE].InnerText);
                msi.Note = childNodes[i][ConstInfo.SUBELE_MAINSUBJECT_NOTE].InnerText;

                msi.Count = GetCountOfEachMainSubject((ConstInfo.QuestionType)msi.Type, msi.CurrentID);

                scoreSum  = msi.EachPoint * msi.Count; 
                subjectSum += msi.Count;

                listMsi.Add(msi);
            }

            for (int i = 0; i < listMsi.Count; i++)
            {
                listMsi[i].SubjectSum = subjectSum;
                listMsi[i].Score = scoreSum;
            }

          
           
            return listMsi;
        }

        public MainSubjectInfo GetInfo(string currentid)
        {
            XmlNodeList nodeList;

            string xpathCurrent = string.Format("/ExamSys/MainSubject/Item[ID={0}]", currentid);

            nodeList = xmlDoc.SelectNodes(xpathCurrent);

            if (nodeList.Count == 0)
                return null;

            MainSubjectInfo msi = new MainSubjectInfo();

            msi.CurrentID = currentid;
            msi.Subject = nodeList[0]["Subject"].InnerText;
            msi.LastTestScore = Convert.ToInt32(nodeList[0]["LastTestScore"].InnerText);
            msi.LimitedTime = Convert.ToInt32(nodeList[0]["LimitTime"].InnerText);
            msi.EachPoint = Convert.ToSingle(nodeList[0]["EachPoint"].InnerText);
            msi.Score = Convert.ToInt32(nodeList[0]["Score"].InnerText);
            msi.Content = nodeList[0]["Content"].InnerText;
            msi.Analysis = nodeList[0]["Analysis"].InnerText;

            msi.Type = Convert.ToInt32(nodeList[0]["Type"].InnerText);
            msi.Note = nodeList[0]["Note"].InnerText;
            msi.TypeName = ((ConstInfo.QuestionType)msi.Type).ToString();
            msi.Count = GetCountOfEachMainSubject((ConstInfo.QuestionType)msi.Type, currentid);
            return msi;
        }

        public MainSubjectInfo GetInfo(int index)
        {
            List<MainSubjectInfo> msiList = GetList();

            MainSubjectInfo msi = new MainSubjectInfo();

            for (int i = 0; i < msiList.Count; i++)
            {
                if (msiList[i].Index == index)
                {
                    msi.Subject = msiList[i].Subject;
                    msi.LastTestScore = msiList[i].LastTestScore;
                    msi.LimitedTime = msiList[i].LimitedTime;
                    msi.EachPoint = msiList[i].EachPoint;
                    msi.Count = msiList[i].Count;
                    msi.Content = msiList[i].Content;
                    msi.Analysis = msiList[i].Analysis;
                    msi.Score = msiList[i].Score;
                    msi.Type = msiList[i].Type;
                    msi.Note = msiList[i].Note;

                    return msi;      
                }
            }
            return null;
                             
        }

        public int GetCountOfEachMainSubject(ConstInfo.QuestionType qt, string currentid)
        {
            XmlNodeList nodeList;

            if (qt == ConstInfo.QuestionType.MainSubject)
                return 0;

            nodeList = xmlDoc.SelectNodes(GetXPathByMainSubject(qt, currentid));

            return (nodeList == null) ? 0 : nodeList.Count;
        }

        private string GetXPathByMainSubject(ConstInfo.QuestionType qt, string currentid)
        {
            switch (qt)
            {
                case ConstInfo.QuestionType.Selection:
                    return string.Format(xpathMainSubject, ConstInfo.ELEMENT_SELECTION, currentid);
                case ConstInfo.QuestionType.Fill:
            
                    return string.Format(xpathMainSubject, ConstInfo.ELEMENT_FILL, currentid);    
                case ConstInfo.QuestionType.Judgement: 
                    return string.Format(xpathMainSubject, ConstInfo.ELEMENT_JUDGEMENT, currentid);
            
                case ConstInfo.QuestionType.Question:
                    return string.Format(xpathMainSubject, ConstInfo.ELEMENT_QUESTION, currentid);
                default:
                    return string.Empty;
            }
        }




        #region IExam 成员

        /// <summary>
        /// delete all of elements in main subject
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

             while (childNodes.Count > 0)
            {
                Delete(childNodes.Count-1);
             }

            return ConstInfo.CTS_HANDLE_DONE;
        }

        public void Delete(List<int> indexes)
        {
        //    childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

        //    xmlDoc.Save(fileName);

            //int i = indexes.Count - 1;
            
            //while (childNodes.Count > 0)
            //{
            //    if (indexes.Count == childNodes.Count)
            //        Delete(indexes[i]);
            //    else if (indexes[i] == 0)
            //        Delete(indexes[i]);
            //    else
            //        Delete(indexes[i] + 1);
            //    i--;
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        public string Delete(int index)
        {
            //if (index < 0)
            //    return ConstInfo.CTS_HANDLE_FAILED;
            
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return ConstInfo.CTS_HANDLE_FAILED;

            //judge wthether this node is null or not
            if (childNodes[index] == null)
                return ConstInfo.CTS_HANDLE_FAILED;

           // remove all of item related to main subjects.
            if (childNodes[index][ConstInfo.SUBELE_MAINSUBJECT_TYPE] != null)
            {
                ConstInfo.QuestionType qt = (ConstInfo.QuestionType)(int.Parse(childNodes[index][ConstInfo.SUBELE_MAINSUBJECT_TYPE].InnerText));
                DeleteRelatedItem(qt, childNodes[index][ConstInfo.SUBELE_MAINSUBJECT_ID].InnerText);
            }

            xmlDoc.SelectNodes(singleNodeInfo)[0].RemoveChild(childNodes[index]);
            xmlDoc.Save(fileName);

            return ConstInfo.CTS_HANDLE_DONE;
        }

        public int DeleteRelatedItem(ConstInfo.QuestionType qt, string currentid)
        {
            XmlNodeList nodeList;

            nodeList = xmlDoc.SelectNodes(GetXPathByMainSubject(qt, currentid));

            if (nodeList.Count == 0)
                return 0;

            for (int i = 0; i < nodeList.Count; i++)
                nodeList[i].ParentNode.RemoveChild(nodeList[i]);

            xmlDoc.Save(fileName);

            return nodeList.Count;
        }
        
        public int Count
        {
            get
            {
                childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

                if (childNodes == null)
                    return -1;

                return childNodes.Count;
           }
        }

        #endregion
    }
}