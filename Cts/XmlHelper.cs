using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Cts
{
    public class XmlHelper
    {
        protected XmlDocument xmlDoc = new XmlDocument();
        protected XmlNodeList childNodes;
        protected string singleNodeInfo = "ExamSys";
        protected string fileName;

        public string SingleNodeInfo
        {
            get { return singleNodeInfo; }
            set { singleNodeInfo = value; }
        }

        /// <summary>
        /// load xml file
        /// </summary>
        /// <param name="fileName"></param>
        public XmlHelper(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("文件名不能为空");;

            if (!System.IO.File.Exists(fileName))
                throw new Exception("文件不存在");
             

            this.fileName = fileName;
            xmlDoc.Load(fileName);
            
        }


        public void NewNode(string elementInfo, string nodeDetails)
        {
            XmlNode rootNode = xmlDoc.SelectSingleNode(singleNodeInfo);

            rootNode.InnerXml = rootNode.InnerXml + nodeDetails;
            xmlDoc.Save(fileName);
        }
        
        public int NodeCount
        {
            get
            {
                int nodeCount = xmlDoc.ChildNodes.Count;
                return nodeCount;
            }
        }

        public void RemoveNode(string element, int id)
        {
            //XmlNode node = xmlDoc.SelectNodes(singleNodeInfo);
            //XmlElement xmlEle = (XmlElement)xmlDoc.GetElementsByTagName(element)[id];
           // xmlDoc.DocumentElement.RemoveChild(node);
            
          //  xmlDoc.Save(fileName);
        }

        /// <summary>
        /// Read settings' file values
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValue(string name)
        {
            childNodes = xmlDoc.DocumentElement.ChildNodes;
            return childNodes.Item(0)[name] == null ? string.Empty : childNodes.Item(0)[name].InnerText;
        }
        /// <summary>
        /// Write settings' file values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue(string name, string value)
        {
            childNodes = xmlDoc.DocumentElement.ChildNodes;
            childNodes.Item(0)[name].InnerText = value;
            xmlDoc.Save(fileName);
        } 
    }
}