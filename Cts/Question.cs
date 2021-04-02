using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Cts
{
    public class Question : XmlHelper, IExam
    {
        public Question(string fileName)
            : base(fileName)
        {
            singleNodeInfo = ConstInfo.ELEMENT_EXAMSYS + "/" + ConstInfo.ELEMENT_QUESTION;

        }

        /// <summary>
        /// Add a new 
        /// </summary>
        public string Add(QuestionInfo qi)
        {
            base.NewNode(ConstInfo.ELEMENT_QUESTION, Template.Question(qi));

            return ConstInfo.CTS_HANDLE_DONE;
        }

        /// <summary>
        /// 
        /// </summary>
        public string  Update(QuestionInfo qi)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return ConstInfo.CTS_HANDLE_FAILED;

            if (!string.IsNullOrEmpty(qi.Subject))
                childNodes[qi.Index][ConstInfo.SUBELE_QUESTION_SUBJECT].InnerText = qi.Subject;

            if (!string.IsNullOrEmpty(qi.Key))
                childNodes[qi.Index][ConstInfo.SUBELE_QUESTION_KEY].InnerText = qi.Key;

            if (!string.IsNullOrEmpty(qi.MainSubject))
                childNodes[qi.Index][ConstInfo.SUBELE_QUESTION_MAINSUBJECT].InnerText = qi.MainSubject;

            if (!string.IsNullOrEmpty(qi.Answer))
                childNodes[qi.Index][ConstInfo.SUBELE_QUESTION_ANSWER].InnerText = qi.Answer;

            xmlDoc.Save(fileName);
            return ConstInfo.CTS_HANDLE_DONE;
        }

        /// <summary>
        /// Get main subject list.
        /// </summary>
        public List<QuestionInfo> GetList()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            List<QuestionInfo> qiList = new List<QuestionInfo>();

            if (childNodes.Count < 0)
                return null;

            for (int i = 0; i < childNodes.Count; i++)
            {
                QuestionInfo qi = new QuestionInfo();

                qi.Index = i;
                qi.MainSubject = childNodes[i][ConstInfo.SUBELE_QUESTION_MAINSUBJECT].InnerText;
                qi.Key = childNodes[i][ConstInfo.SUBELE_QUESTION_KEY].InnerText;
                qi.Subject = childNodes[i][ConstInfo.SUBELE_QUESTION_SUBJECT].InnerText;
                qi.Answer = childNodes[i][ConstInfo.SUBELE_QUESTION_ANSWER].InnerText;
                qi.CurrentMainSubject = new MainSubject(fileName).GetInfo(qi.MainSubject);
                qiList.Add(qi);
            }

            return qiList;
        }

        public QuestionInfo GetInfo(int index)
        {
            List<QuestionInfo> qiList = GetList();

            QuestionInfo qi = new QuestionInfo();

            for (int i = 0; i < qiList.Count; i++)
            {
                if (qiList[i].Index == index)
                {
              
                }
            }

            return qi; 
        }
        #region IExam 成员


        /// <summary>
        /// delete all of elements in main subject
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
             //xmlDoc.SelectNodes(singleNodeInfo)[0].RemoveAll();
             //xmlDoc.Save(fileName);
            //if (childNodes == null)
            //    return ConstInfo.CTS_HANDLE_FAILED;
             return ConstInfo.CTS_HANDLE_DONE;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Delete(int index)
        {
            if (index < 0)
                return ConstInfo.CTS_HANDLE_FAILED;
            
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return ConstInfo.CTS_HANDLE_FAILED;

            //judge wthether this node is null or not
            if (childNodes[index] == null)
                return ConstInfo.CTS_HANDLE_FAILED;

            xmlDoc.SelectNodes(singleNodeInfo)[0].RemoveChild(childNodes[index]);
            xmlDoc.Save(fileName);

            return ConstInfo.CTS_HANDLE_DONE;
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