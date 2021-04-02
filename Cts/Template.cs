using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.IO;

namespace Cts
{
    public static class Template
    {
        public static string ExamInfo(ExamInfo ei)
        {
            StringBuilder temp = new StringBuilder();

            //     temp.Append("\r\n<ExamInfo>\r\n");
            //     temp.Append("\r\n<Item>\r\n");
            temp.AppendFormat("\r\n<Name>{0}</Name>\r\n", ei.Name);
            temp.AppendFormat("\r\n<Time>{0}</Time>\r\n", ei.Time);
            temp.AppendFormat("\r\n<Score>{0}</Score>\r\n", ei.Score);
            temp.AppendFormat("\r\n<Content><![CDATA[{0}]]></Content>\r\n", ei.Content);
            temp.AppendFormat("\r\n<PublishDate>{0}</PublishDate>\r\n", ei.PublishDate);
            temp.AppendFormat("\r\n<LastTestTime>{0}</LastTestTime>\r\n", ei.LastTestTime);
            temp.AppendFormat("\r\n<LastTestScore>{0}</LastTestScore>\r\n", ei.LastTestScore);


            temp.AppendFormat("\r\n<Fun_Import>{0}</Fun_Import>\r\n", "False");
            temp.AppendFormat("\r\n<ValidID>{0}</ValidID>\r\n", "MachineID");
            //   temp.Append("\r\n</Item>\r\n");
            //     temp.Append("\r\n</ExamInfo>\r\n");

            return temp.ToString();
        }

        public static string MainSubject(string templatePath)
        {
            return MainSubject(templatePath,  string.Empty);
        }

        public static string MainSubject(string templatePath, string encode)
        {
            if (File.Exists(templatePath))
            {
                return File.ReadAllText(templatePath, (encode==string.Empty) ? System.Text.Encoding.Default : System.Text.Encoding.GetEncoding(encode));
            }

            return string.Empty;
        }

        public static string MainSubject(MainSubjectInfo msi)
        {
            StringBuilder temp = new StringBuilder();
            
            temp.Append("\r\n<Item>\r\n");
            temp.AppendFormat("\r\n<ID>{0}</ID>\r\n", msi.CurrentID);
            temp.AppendFormat("\r\n<Subject>{0}</Subject>\r\n", msi.Subject);
            temp.AppendFormat("\r\n<Type>{0}</Type>\r\n", msi.Type);
            temp.AppendFormat("\r\n<LastTestScore>{0}</LastTestScore>", msi.LastTestScore);
            temp.AppendFormat("\r\n<LimitTime>{0}</LimitTime>\r\n", msi.LimitedTime);
            temp.AppendFormat("\r\n<Score>{0}</Score>\r\n", msi.Score);
            temp.AppendFormat("\r\n<EachPoint>{0}</EachPoint>\r\n", msi.EachPoint);
            temp.AppendFormat("\r\n<Count>{0}</Count>\r\n", msi.Count);
            temp.AppendFormat("\r\n<Content><![CDATA[{0}]]></Content>\r\n", msi.Content);
            temp.AppendFormat("\r\n<Note><![CDATA[{0}]]></Note>\r\n", msi.Note);
            temp.AppendFormat("\r\n<Analysis><![CDATA[{0}]]></Analysis>\r\n", msi.Analysis);

            temp.Append("\r\n</Item>\r\n");

            return temp.ToString();

        }

        public static string Selection(List<SelectionInfo> si)
        {
            StringBuilder temp = new StringBuilder();

            for (int i = 0; i < si.Count; i++)
            {
                si[i].Index = i;
                
                temp.Append("\r\n<Item>\r\n");
                //mainsubject is id
                temp.AppendFormat("\r\n<MainSubject>{0}</MainSubject>\r\n", si[i].MainSubject);
                temp.AppendFormat("\r\n<Subject><![CDATA[{0}]]></Subject>\r\n", si[i].Subject);
                temp.AppendFormat("\r\n<Choice><![CDATA[{0}]]></Choice>\r\n", si[i].Choice);
                temp.AppendFormat("\r\n<Multiple>{0}</Multiple>\r\n", si[i].Multiple);
                temp.AppendFormat("\r\n<BreakType>{0}</BreakType>\r\n", si[i].BreakType);
                temp.AppendFormat("\r\n<Answer>{0}</Answer>\r\n", si[i].Answer);
                temp.AppendFormat("\r\n<Note><![CDATA[{0}]]></Note>\r\n", si[i].Note);
                temp.AppendFormat("\r\n<Key>{0}</Key>\r\n", si[i].Key);
                temp.Append("\r\n</Item>\r\n");
            }

            return temp.ToString();
        }




        public static string Judgement(JudgementInfo ji)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append("\r\n<Item>\r\n");
            temp.AppendFormat("\r\n<MainSubject>{0}</MainSubject>\r\n", ji.MainSubject);
            temp.AppendFormat("\r\n<Subject><![CDATA[{0}]]></Subject>\r\n", ji.Subject);
            temp.AppendFormat("\r\n<Answer>{0}</Answer>\r\n", ji.Answer);
            temp.AppendFormat("\r\n<Note><![CDATA[{0}]]></Note>\r\n", ji.Note);
            temp.AppendFormat("\r\n<key>{0}</key>\r\n", ji.Key);
            temp.Append("\r\n</Item>\r\n");

            return temp.ToString();
        }


        public static string Fill(FillInfo fi)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append("\r\n<Item>\r\n");
            temp.AppendFormat("\r\n<MainSubject>{0}</MainSubject>\r\n", fi.MainSubject);
            temp.AppendFormat("\r\n<Subject>{0}</Subject>\r\n", fi.Subject);
            temp.AppendFormat("\r\n<Answer>{0}</Answer>\r\n", fi.Answer);
            temp.AppendFormat("\r\n<Note><![CDATA[{0}]]></Note>\r\n", fi.Note);
            temp.AppendFormat("\r\n<key>{0}</key>\r\n", fi.Key);
            temp.Append("\r\n</Item>\r\n");

            return temp.ToString();
        }


        public static string Question(QuestionInfo qi)
        {
            StringBuilder temp = new StringBuilder();

            temp.Append("\r\n<Item>\r\n");
            temp.AppendFormat("\r\n<MainSubject>{0}</MainSubject>\r\n", qi.MainSubject);
            temp.AppendFormat("\r\n<Subject><![CDATA[ {0} ]]></Subject>\r\n", qi.Subject);
            temp.AppendFormat("\r\n<Answer>{0}</Answer>\r\n", qi.Answer);
            temp.AppendFormat("\r\n<key> <![CDATA[ {0} ]]> </key>\r\n", qi.Key);
            temp.Append("\r\n</Item>\r\n");

            return temp.ToString();
        }


        public static string ExamSys(string encoding)
        {
            StringBuilder temp = new StringBuilder();

            temp.AppendFormat("<?xml version=\"1.0\" encoding=\"{0}\" ?>\r\n", encoding);
            temp.Append("\r\n<ExamSys>\r\n");

            temp.Append("\r\n<ExamInfo>\r\n");
            ExamInfo ei = new ExamInfo();

            temp.Append(Template.ExamInfo(ei));

            temp.Append("\r\n</ExamInfo>\r\n");

            temp.Append("\r\n<MainSubject>\r\n");
            temp.Append("\r\n</MainSubject>\r\n");

            temp.Append("\r\n<Selection>\r\n");
            temp.Append("\r\n</Selection>\r\n");

            temp.Append("\r\n<Judgement>\r\n");
            temp.Append("\r\n</Judgement>\r\n");

            temp.Append("\r\n<Fill>\r\n");
            temp.Append("\r\n</Fill>\r\n");

            temp.Append("\r\n<Question>\r\n");
            temp.Append("\r\n</Question >\r\n");
            temp.Append(" \r\n");


            temp.Append("\r\n</ExamSys>\r\n");

            return temp.ToString();
        }

        public static string ExamSys()
        {
            return ExamSys("utf-8");
        }

        //private static string CreateNewElement(string elementName, string elements)
        //{
        //    if (String.IsNullOrEmpty(elementName))
        //        return elements;

        //    StringBuilder temp = new StringBuilder();

        //    temp.AppendFormat("\r\n<{0}>\r\n", elementName);

        //    temp.Append(" \r\n");
        //    temp.Append(elements);
        //    temp.Append(" \r\n");

        //    temp.AppendFormat("\r\n</{0}>\r\n", elementName);

        //    return temp.ToString();
        //}
    }
}