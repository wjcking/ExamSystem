using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Collections.Generic;
using Model;

namespace Publish
{
    public partial class MediaList : System.Web.UI.Page
    {
        private List<MediaFileInfo> fileNameList = new List<MediaFileInfo>();
        private string lib = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lib = EasyConfig.ImageLibraryPath;

                //drpFolders.Items.Clear();
                //drpFolders.Items.Add(new ListItem(lib, lib));
                //GetDirectories(lib, String.Empty);
                GetFiles(lib, string.Empty);

                dlMediaList.DataSource = fileNameList;
                dlMediaList.DataBind();
            }
        }

        /// <summary>
        /// 获得图片，或媒体文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        private List<MediaFileInfo> GetFiles(string path, string searchText)
        {
            string[] fileNames = Directory.GetFiles(path);

            foreach (string file in fileNames)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                string fileName = Path.GetFileName(file);
                MediaFileInfo mfi = new MediaFileInfo();

                mfi.FileName = fileName;
                mfi.FullFileName = file;
                mfi.ServerFileName = file.Replace(Server.MapPath("") + "\\", string.Empty);
                mfi.FileNameWithoutExten = fileNameWithoutExtension;
                mfi.FileExten = Path.GetExtension(file).ToLower();

                switch (mfi.FileExten)
                {
                    case ".jpg":
                        mfi.HtmlTag = String.Format("<img src=\"{0}\" alt=\"{1}\"  style=\"width: 120px;  height: 100px;\" />", mfi.ServerFileName, mfi.FileName);
                        break;

                    case ".gif":
                        mfi.SImagePostion = MediaFileInfo.IMG_GIF;
                        mfi.AImagePostion = MediaFileInfo.IMG_GIF;
                        mfi.HtmlTag = String.Format("<img src=\"{0}\" alt=\"{1}\"  style=\"width: 120px;  height: 100px;\" />", mfi.ServerFileName, mfi.FileName);
                        break;

                    case ".png":
                        mfi.SImagePostion = MediaFileInfo.IMG_PNG;
                        mfi.AImagePostion = MediaFileInfo.IMG_PNG;
                        mfi.HtmlTag = String.Format("<img src=\"{0}\" alt=\"{1}\"  style=\"width: 120px;  height: 100px;\" />", mfi.ServerFileName, mfi.FileName);
                        break;

                    default:
                        mfi.HtmlTag = mfi.FileName;
                        break;
                }

                if (string.IsNullOrEmpty(searchText))
                {
                    fileNameList.Add(mfi);
                    continue;
                }

                if (fileName.ToLower().IndexOf(searchText.ToLower()) > -1)
                {

                }
            }

            return fileNameList;
        }

    }
}
