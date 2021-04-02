using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Cts
{
    public class Judgement : XmlHelper, IExam
    {
        public Judgement(string fileName) : base(fileName)
        {
            singleNodeInfo = ConstInfo.ELEMENT_EXAMSYS + "/" + ConstInfo.ELEMENT_JUDGEMENT;

        }

        /// <summary>
        /// Add a new main subjec telement
        /// </summary>
        public string Add(JudgementInfo ji)
        {
            base.NewNode(ConstInfo.ELEMENT_JUDGEMENT, Template.Judgement(ji));

            return ConstInfo.CTS_HANDLE_DONE;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Update(JudgementInfo ji)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return ConstInfo.CTS_HANDLE_FAILED;

            if (!string.IsNullOrEmpty(ji.Subject))
                childNodes[ji.Index][ConstInfo.SUBELE_JUDGE_SUBJECT].InnerText = ji.Subject;

            if (!string.IsNullOrEmpty(ji.Key))
                childNodes[ji.Index][ConstInfo.SUBELE_JUDGE_KEY].InnerText = ji.Key;

            if (!string.IsNullOrEmpty(ji.MainSubject))
                childNodes[ji.Index][ConstInfo.SUBELE_JUDGE_MAINSUBJECT].InnerText = ji.MainSubject;

            if (!string.IsNullOrEmpty(ji.Answer))
                childNodes[ji.Index][ConstInfo.SUBELE_JUDGE_ANSWER].InnerText = ji.Answer;
            if (!string.IsNullOrEmpty(ji.Note))
                childNodes[ji.Index][ConstInfo.Note].InnerText = ji.Note;
            xmlDoc.Save(fileName);
            return ConstInfo.CTS_HANDLE_DONE;
        }
        /// <summary>
        /// Get main subject list randomly.
        /// </summary>
        public List<JudgementInfo> GetListByRandom()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            List<JudgementInfo> jiList = new List<JudgementInfo>();

            if (childNodes.Count < 0)
                return null;

             int[] rand = StrTool.RandNum(childNodes.Count);

            for (int r = 0; r < rand.Length; r++)
            {
                JudgementInfo ji = new JudgementInfo();
                int i = rand[r];

                ji.Index = i;
                ji.MainSubject = childNodes[i][ConstInfo.SUBELE_JUDGE_MAINSUBJECT].InnerText;
                ji.Key = childNodes[i][ConstInfo.SUBELE_JUDGE_KEY].InnerText;
                ji.Subject = childNodes[i][ConstInfo.SUBELE_JUDGE_SUBJECT].InnerText;
                ji.Answer = childNodes[i][ConstInfo.SUBELE_JUDGE_ANSWER].InnerText;
                ji.CurrentMainSubject = new MainSubject(fileName).GetInfo(ji.MainSubject);
                jiList.Add(ji);
            }

            return jiList;
        }
        /// <summary>
        /// Get main subject list.
        /// </summary>
        public List<JudgementInfo> GetList()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            List<JudgementInfo> jiList = new List<JudgementInfo>();

            if (childNodes.Count < 0)
                return null;

            for (int i = 0; i < childNodes.Count; i++)
            {
                JudgementInfo ji = new JudgementInfo();

                ji.Index = i;
                ji.MainSubject = childNodes[i][ConstInfo.SUBELE_JUDGE_MAINSUBJECT].InnerText;
                ji.Key = childNodes[i][ConstInfo.SUBELE_JUDGE_KEY].InnerText;
                ji.Subject = childNodes[i][ConstInfo.SUBELE_JUDGE_SUBJECT].InnerText;
                ji.Answer = childNodes[i][ConstInfo.SUBELE_JUDGE_ANSWER].InnerText;
                ji.CurrentMainSubject = new MainSubject(fileName).GetInfo(ji.MainSubject);
                jiList.Add(ji);
            }

            return jiList;
        }

        public JudgementInfo GetInfo(int i)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            JudgementInfo ji = new JudgementInfo();

            ji.Index = i;
            ji.MainSubject = childNodes[i][ConstInfo.SUBELE_JUDGE_MAINSUBJECT].InnerText;
            ji.Key = childNodes[i][ConstInfo.SUBELE_JUDGE_KEY].InnerText;
            ji.Subject = childNodes[i][ConstInfo.SUBELE_JUDGE_SUBJECT].InnerText;
            ji.Answer = childNodes[i][ConstInfo.SUBELE_JUDGE_ANSWER].InnerText;
            ji.Note = childNodes[i][ConstInfo.Note].InnerText;
            ji.CurrentMainSubject = new MainSubject(fileName).GetInfo(ji.MainSubject);

            return ji;

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