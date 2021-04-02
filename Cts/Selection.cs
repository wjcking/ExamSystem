using System;
using System.Text;
using System.Collections.Generic;
using Model;

namespace Cts
{
    public class Selection : XmlHelper, IExam
    {
        // private List<SelectionInfo> itemList;

        public Selection(string fileName)
            : base(fileName)
        {
            singleNodeInfo = ConstInfo.ELEMENT_EXAMSYS + "/" + ConstInfo.ELEMENT_SELECTION;
        }

        public string Add(List<SelectionInfo> si)
        {
            string selectionList = Template.Selection(si);

            base.NewNode(ConstInfo.ELEMENT_SELECTION, selectionList);

            return ConstInfo.CTS_HANDLE_DONE;
        }
        /// <summary>
        /// update choice items
        /// </summary>
        public string Update(SelectionInfo si)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return ConstInfo.CTS_HANDLE_FAILED;

            if (!string.IsNullOrEmpty(si.Subject))
                childNodes[si.Index][ConstInfo.SUBELE_SELECT_SUBJECT].InnerText = si.Subject;

            if (!string.IsNullOrEmpty(si.Key))
                childNodes[si.Index][ConstInfo.SUBELE_SELECT_KEY].InnerText = si.Key;

            if (si.BreakType != -1)
                childNodes[si.Index][ConstInfo.SUBELE_SELECT_BREAKTYPE].InnerText = si.BreakType.ToString();

            if (!string.IsNullOrEmpty(si.Answer))
                childNodes[si.Index][ConstInfo.SUBELE_SELECT_ANSWER].InnerText = si.Answer;

            if (!string.IsNullOrEmpty(si.MainSubject))
                childNodes[si.Index][ConstInfo.SUBELE_QUESTION_MAINSUBJECT].InnerText = si.MainSubject;

            if (!string.IsNullOrEmpty(si.Note))
                childNodes[si.Index][ConstInfo.Note].InnerText = si.Note;

            xmlDoc.Save(fileName);

            return ConstInfo.CTS_HANDLE_DONE;
        }
        public List<SelectionInfo> GetListByRandom()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            List<SelectionInfo> slist = new List<SelectionInfo>();

            if (childNodes.Count < 0)
                return null;
            
            int[] rand = StrTool.RandNum(childNodes.Count);

            for (int r = 0; r < rand.Length; r++)
            {
                SelectionInfo si = new SelectionInfo();

                int i = rand[r];

                si.Index = i;
                // si.Index = rand[r];

                si.MainSubject = childNodes[i][ConstInfo.SUBELE_SELECT_MAINSUBJECT].InnerText;
                si.Key = childNodes[i][ConstInfo.SUBELE_SELECT_KEY].InnerText;
                si.Subject = childNodes[i][ConstInfo.SUBELE_SELECT_SUBJECT].InnerText;
                si.Answer = childNodes[i][ConstInfo.SUBELE_SELECT_ANSWER].InnerText;
                si.Choice = childNodes[i][ConstInfo.SUBELE_SELECT_CHOICE].InnerText;

                if (!string.IsNullOrEmpty(childNodes[i][ConstInfo.SUBELE_SELECT_BREAKTYPE].InnerText))
                    si.BreakType = Convert.ToInt32(childNodes[i][ConstInfo.SUBELE_SELECT_BREAKTYPE].InnerText);

                if (!string.IsNullOrEmpty(childNodes[i][ConstInfo.SUBELE_SELECT_MULTIPLE].InnerText))
                    si.Multiple = Convert.ToBoolean(childNodes[i][ConstInfo.SUBELE_SELECT_MULTIPLE].InnerText);

                // 
                si.CurrentMainSubject = new MainSubject(fileName).GetInfo(si.MainSubject);

              //  si.ChoiceHtml = GenerateChoices(si);
                slist.Add(si);
 
            }
            return slist;
        }
        /// <summary>
        /// Get main subject list.
        /// </summary>

        public List<SelectionInfo> GetList()
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            List<SelectionInfo> slist = new List<SelectionInfo>();

            if (childNodes.Count < 0)
                return null;


            for (int i = 0; i < childNodes.Count; i++)
            {
                SelectionInfo si = new SelectionInfo();




                si.Index = i;
                si.MainSubject = childNodes[i][ConstInfo.SUBELE_SELECT_MAINSUBJECT].InnerText;
                si.Key = childNodes[i][ConstInfo.SUBELE_SELECT_KEY].InnerText;
                si.Subject = childNodes[i][ConstInfo.SUBELE_SELECT_SUBJECT].InnerText;
                si.Answer = childNodes[i][ConstInfo.SUBELE_SELECT_ANSWER].InnerText;
                si.Choice = childNodes[i][ConstInfo.SUBELE_SELECT_CHOICE].InnerText;

                if (!string.IsNullOrEmpty(childNodes[i][ConstInfo.SUBELE_SELECT_BREAKTYPE].InnerText))
                    si.BreakType = Convert.ToInt32(childNodes[i][ConstInfo.SUBELE_SELECT_BREAKTYPE].InnerText);

                if (!string.IsNullOrEmpty(childNodes[i][ConstInfo.SUBELE_SELECT_MULTIPLE].InnerText))
                    si.Multiple = Convert.ToBoolean(childNodes[i][ConstInfo.SUBELE_SELECT_MULTIPLE].InnerText);

                // 
                si.CurrentMainSubject = new MainSubject(fileName).GetInfo(si.MainSubject);

                si.ChoiceHtml = GenerateChoices(si);
                slist.Add(si);

            }

            return slist;
        }

        public string Delete()
        {
            return ConstInfo.CTS_HANDLE_DONE;
        }

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

        public SelectionInfo GetInfo(int i)
        {
            childNodes = xmlDoc.SelectNodes(singleNodeInfo)[0].ChildNodes;

            if (childNodes == null)
                return null;

            SelectionInfo si = new SelectionInfo();

            si.MainSubject = childNodes[i][ConstInfo.SUBELE_SELECT_MAINSUBJECT].InnerText;
            si.Key = childNodes[i][ConstInfo.SUBELE_SELECT_KEY].InnerText;
            si.Subject = childNodes[i][ConstInfo.SUBELE_SELECT_SUBJECT].InnerText;
            si.Answer = childNodes[i][ConstInfo.SUBELE_SELECT_ANSWER].InnerText;
            si.Choice = childNodes[i][ConstInfo.SUBELE_SELECT_CHOICE].InnerText;
            si.Note = childNodes[i][ConstInfo.Note].InnerText;

            if (!string.IsNullOrEmpty(childNodes[i][ConstInfo.SUBELE_SELECT_BREAKTYPE].InnerText))
                si.BreakType = Convert.ToInt32(childNodes[i][ConstInfo.SUBELE_SELECT_BREAKTYPE].InnerText);

            if (!string.IsNullOrEmpty(childNodes[i][ConstInfo.SUBELE_SELECT_MULTIPLE].InnerText))
                si.Multiple = Convert.ToBoolean(childNodes[i][ConstInfo.SUBELE_SELECT_MULTIPLE].InnerText);

            // 
            si.CurrentMainSubject = new MainSubject(fileName).GetInfo(si.MainSubject);

            return si;
        }

        public int Count
        {
            get { return base.NodeCount; }
        }

        
       

    }
}