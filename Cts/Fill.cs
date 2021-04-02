using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Xml;

namespace Cts
{
    public class Fill : XmlHelper, IExam
    {
        public Fill(string fileName) : base(fileName)
        {
            singleNodeInfo = ConstInfo.ELEMENT_EXAMSYS + "/" + ConstInfo.ELEMENT_FILL;
        }

        /// <summary>
        /// Add a new 
        /// </summary>
        public string Add(FillInfo fi)
        {
            //if (fi.Index == -1)
            //{
               base.NewNode(ConstInfo.ELEMENT_FILL, Template.Fill(fi)); 
            xmlDoc.Save(fileName);
               return ConstInfo.CTS_HANDLE_DONE;
            //}

           // XmlNode node;// = xmlDoc

           // node.InnerXml = Template.Fill(fi);
        //    childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;
            //childNodes[0].AppendChild(node);

            //XmlNode refNode;
            //childNodes[0].InsertBefore(node, null);
            //XmlNode node = xmlDoc.SelectSingleNode(singleNodeInfo).;
            //node.InnerText
            //childNodes[0].AppendChild(
            //node.InnerXml = Template.Fill(fi);
            //node[ConstInfo.SUBELE_FILL_SUBJECT].InnerText = fi.Subject;
            //node[ConstInfo.SUBELE_FILL_KEY].InnerText = fi.Key;
            //node[ConstInfo.SUBELE_FILL_MAINSUBJECT].InnerText = fi.MainSubject;
            //node[ConstInfo.SUBELE_FILL_ANSWER].InnerText = fi.Answer;
   }

        /// <summary>
        /// 
        /// </summary>
        public string Update(FillInfo fi)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return ConstInfo.CTS_HANDLE_FAILED;

            if (!string.IsNullOrEmpty(fi.Subject))
                childNodes[fi.Index][ConstInfo.SUBELE_FILL_SUBJECT].InnerText = fi.Subject;

            if (!string.IsNullOrEmpty(fi.Key))
                childNodes[fi.Index][ConstInfo.SUBELE_FILL_KEY].InnerText = fi.Key;

            if (!string.IsNullOrEmpty(fi.MainSubject))
                childNodes[fi.Index][ConstInfo.SUBELE_FILL_MAINSUBJECT].InnerText = fi.MainSubject;

            if (!string.IsNullOrEmpty(fi.Answer))
                childNodes[fi.Index][ConstInfo.SUBELE_FILL_ANSWER].InnerText = fi.Answer;

            xmlDoc.Save(fileName);
            return ConstInfo.CTS_HANDLE_DONE;
        }

        /// <summary>
        /// Get main subject list.
        /// </summary>
        public List<FillInfo> GetList()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            List<FillInfo> fiiList = new List<FillInfo>();

            if (childNodes.Count < 0)
                return null;

            for (int i = 0; i < childNodes.Count; i++)
            {
                FillInfo fi = new FillInfo();

                fi.Index = i;
           
                fi.MainSubject = childNodes[i][ConstInfo.SUBELE_FILL_MAINSUBJECT].InnerText;
                fi.Key = childNodes[i][ConstInfo.SUBELE_FILL_KEY].InnerText;
                fi.Subject = childNodes[i][ConstInfo.SUBELE_FILL_SUBJECT].InnerText;
                fi.Answer = childNodes[i][ConstInfo.SUBELE_FILL_ANSWER].InnerText;
                fi.CurrentMainSubject = new MainSubject(fileName).GetInfo(fi.MainSubject);

                fiiList.Add(fi);
            }
            return fiiList;
        }

        public FillInfo GetInfo(int index)
        {
            List<FillInfo> fiiList = GetList();

            FillInfo fi = new FillInfo();

            for (int i = 0; i < fiiList.Count; i++)
            {
                if (fiiList[i].Index == index)
                {
              
                }
            }

            return fi; 
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