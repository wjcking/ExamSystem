using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MediaFileInfo
    {
        private string fullFileName = string.Empty;

        public const string IMG_JPG = "jpg";
        public const string IMG_GIF = "gif";
        public const string IMG_PNG = "png";

        public string FullFileName
        {
            get { return fullFileName; }
            set { fullFileName = value; }
        }
        private string fileName = string.Empty;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string serverFileName;

        public string ServerFileName
        {
            get { return serverFileName; }
            set { serverFileName = value; }
        }

        private string fileExten = string.Empty;

        public string FileExten
        {
            get { return fileExten; }
            set { fileExten = value; }
        }

        private string fileNameWithoutExten = string.Empty;

        public string FileNameWithoutExten
        {
            get { return fileNameWithoutExten; }
            set { fileNameWithoutExten = value; }
        }

        private string sImagePostion = MediaFileInfo.IMG_JPG;

        public string SImagePostion
        {
            get { return sImagePostion; }
            set { sImagePostion = value; }
        }
        private string aImagePostion = MediaFileInfo.IMG_JPG;

        public string AImagePostion
        {
            get { return aImagePostion; }
            set { aImagePostion = value; }
        }



        private string htmlTag = string.Empty;

        public string HtmlTag
        {
            get { return htmlTag; }
            set { htmlTag = value; }
        }
    }
}
