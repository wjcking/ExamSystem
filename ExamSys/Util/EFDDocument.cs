using System;
using System.IO;

namespace ExamSys.Util
{
    public static class EFDDocument
    {

        private readonly static string[] myFileDirect = SysConfig.SettingsHelper.GetValue("MyFileDirect").Split(',');
        private readonly static string[] myFileText = SysConfig.SettingsHelper.GetValue("MyFileText").Split(',');
        private readonly static string[] myFileMedia = SysConfig.SettingsHelper.GetValue("MyFileMedia").Split(',');

        public enum DocumentType
        {
            Direct = 0,
            Text,
            Media = 2
        }

        public static string Redirect(string path, out DocumentType docType)
        {
            if (Path.GetExtension(path) == string.Empty)
            {
                docType = DocumentType.Direct;
                return Environment.CurrentDirectory + @"\template\MyFile_Default.htm";
            }
            if (VerifyMyFile(path) < 0)
            {
                docType = DocumentType.Direct;
                return string.Empty;
            }

            string extenName = Path.GetExtension(path).ToLower().Replace(".", "");
            string fileName = Path.GetFileName(path);

            //直接打开
            foreach (string ext in myFileDirect)
            {
                if (ext == extenName)
                {
                    docType = DocumentType.Direct;
                    return path; 
                }
            }
            //文本类型
            //foreach (string ext in myFileText)
            //{
            //    if (ext == extenName)
            //    {
            //        return Environment.CurrentDirectory + @"\template\MyFile_Text.htm";
            //    }
            //}
            ////多媒体类型
            foreach (string ext in myFileMedia)
            {
                if (ext == extenName)
                {
                    docType = DocumentType.Media;
                    return Environment.CurrentDirectory + @"\template\MyFile_Media.htm";
                }
            }
            docType = DocumentType.Direct;
            //其他类型
            return Environment.CurrentDirectory + @"\template\MyFile.htm";
        }

        private static int VerifyMyFile(string path)
        {
            try
            {

                bool isSystemPath = path.ToLower().Contains(AppDomain.CurrentDomain.BaseDirectory.ToLower());

                if (isSystemPath)
                {
                    return -1;
                }

                //禁止浏览的文件
                string fileName = Path.GetFileName(path).ToLower();
                string fileExten = Path.GetExtension(path).ToLower();

                if (fileExten == ".config")
                {
                    return -2;
                }

                return 0;
            }
            catch
            {
                return -101;
            }
        }



    }
}
