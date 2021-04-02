using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace Cts
{
    public class ExamSys : XmlHelper
    {

        public ExamSys(string fileName)
            : base(fileName)
        {
            singleNodeInfo = ConstInfo.ELEMENT_EXAMSYS + "/" + ConstInfo.ELEMENT_EXAMINFO;
        }


        public void Update(ExamInfo ei)
        {
            childNodes = xmlDoc.DocumentElement.ChildNodes;

            // name
            if (!string.IsNullOrEmpty(ei.Name))
                childNodes[0][ConstInfo.SUBELE_EXAMINFO_NAME].InnerText = ei.Name;
            //lasttesttime
            if (!string.IsNullOrEmpty(ei.LastTestTime))
                childNodes[0][ConstInfo.SUBELE_EXAMINFO_LASTTESTTIME].InnerText = ei.LastTestTime;
            //lasttestscore
            if (ei.LastTestScore != 0)
                childNodes[0][ConstInfo.SUBELE_EXAMINFO_LASTTESTSCORE].InnerText = ei.LastTestScore.ToString();
            //examinfo
            if (!string.IsNullOrEmpty(ei.Content))
                childNodes[0][ConstInfo.SUBELE_EXAMINFO_CONTENT].InnerXml = String.Format("<![CDATA[ {0} ]]>", ei.Content);
            //time
            if (ei.Time != 0)
                childNodes[0][ConstInfo.SUBELE_EXAMINFO_TIME].InnerText = ei.Time.ToString();
            //socre
            if (ei.Score != 0)
                childNodes[0][ConstInfo.SUBELE_EXAMINFO_SCORE].InnerText = ei.Score.ToString();

            xmlDoc.Save(fileName);
        }


        public ExamInfo GetExamInfo()
        {
            childNodes = xmlDoc.DocumentElement.ChildNodes;
            ExamInfo ei = new ExamInfo();
            //name
            ei.Name = childNodes[0][ConstInfo.SUBELE_EXAMINFO_NAME].InnerText;
            //lasttesttime
            if (!string.IsNullOrEmpty(childNodes[0][ConstInfo.SUBELE_EXAMINFO_LASTTESTTIME].InnerText))
                ei.LastTestTime = childNodes[0][ConstInfo.SUBELE_EXAMINFO_LASTTESTTIME].InnerText;
            //lasttestscore
            if (!string.IsNullOrEmpty(childNodes[0][ConstInfo.SUBELE_EXAMINFO_LASTTESTSCORE].InnerText))
                ei.LastTestScore = int.Parse(childNodes[0][ConstInfo.SUBELE_EXAMINFO_LASTTESTSCORE].InnerText);
            //content
            ei.Content = childNodes[0][ConstInfo.SUBELE_EXAMINFO_CONTENT].InnerText;
            //time
            if (!string.IsNullOrEmpty(childNodes[0][ConstInfo.SUBELE_EXAMINFO_TIME].InnerText))
                ei.Time = int.Parse(childNodes[0][ConstInfo.SUBELE_EXAMINFO_TIME].InnerText);
             //socre
            if (!string.IsNullOrEmpty(childNodes[0][ConstInfo.SUBELE_EXAMINFO_SCORE].InnerText))
                ei.Score = int.Parse(childNodes[0][ConstInfo.SUBELE_EXAMINFO_SCORE].InnerText);

            return ei;
        }
    }
}
