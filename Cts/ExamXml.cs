using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using System.Xml;

namespace Cts
{
    public class ExamXml
    { 
        protected XmlDocument document = new XmlDocument(); 
        protected XmlNodeList childNodes;

        protected string fileName;

        public ExamXml(string fileName)
        {
            this.fileName = fileName;
            childNodes = document.DocumentElement.ChildNodes;
        }

        public  string GetXmlElement(string name)
        {
            document.Load(fileName);
            return childNodes.Item(0)[name] == null ? string.Empty : childNodes.Item(0)[name].InnerText;
       
        }

        public void SetXmlElement(string name, string value)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            childNodes.Item(0)[name].InnerText = value;
            document.Save(fileName);
        }
    }
}