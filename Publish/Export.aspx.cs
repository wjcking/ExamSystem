using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Text;
using Model;
using Cts;

namespace Publish
{

    public partial class Export : System.Web.UI.Page
    {
        protected VerifyCidInfo vc = new VerifyCidInfo();

        //备份试题图片路径 后面要加上 /
        public static readonly string ImageBackupPath = ConfigurationManager.AppSettings["ImageBackupPath"];
        //试题图片路径到debug 后面要加上/
        public static readonly string ImageDebugPath = ConfigurationManager.AppSettings["ImageDebugPath"];
        //试题图片路径到 Release 后面要加上/
        public static readonly string ImageReleasePath = ConfigurationManager.AppSettings["ImageReleasePath"];
        //试题图片路径到EFD 后面要加上/
        public static readonly string ImageEFDPath = ConfigurationManager.AppSettings["ImageEFDPath"];

        //数据库复制到 debug 项目 扩展名为.efd 后面要加上/
        public static readonly string DataBaseDebugPath = ConfigurationManager.AppSettings["DataBaseDebugPath"];
        //数据库复制到 EFD 宇宙版项目中 扩展名为.efd 后面要加上
        public static readonly string DataBaseEFDPath = ConfigurationManager.AppSettings["DataBaseEFDPath"];


        //生成Cid文件到debug 
        public static readonly string CidDebugPath = ConfigurationManager.AppSettings["CidDebugPath"];
        //生成Cid文件到Release 
        public static readonly string CidReleasePath = ConfigurationManager.AppSettings["CidReleasePath"];
        //生成Cid文件到EFD 
        public static readonly string CidEFDPath = ConfigurationManager.AppSettings["CidEFDPath"];
        //备份Cid文件路径
        public static readonly string CidBackupPath = ConfigurationManager.AppSettings["CidBackupPath"];
        public static readonly string UrlGetCategory = ConfigurationManager.AppSettings["UrlGetCategory"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEfdTitle.Text = EasyConfig.DBName.Replace(".mdb", "试题图库");
                btnCid.Attributes.Add("onclick", "return validCid();");
                //GetDatabaseList();
            }

            vc.ProductID = Request.Form["txtProductID"];
            vc.Title = Request.Form["txtProductTitle"];
            vc.Cid = Request.Form["txtCid"];
            vc.Category = Request.Form["txtCategory"];

            DataBind();
        }
        /// <summary>
        /// 备份文件(一份新的，一份测试用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEfdTitle.Text))
                return;

            if (!Directory.Exists(EasyConfig.ImageRenamedLibraryPath))
                return;

            string[] imageFiles = Directory.GetFiles(EasyConfig.ImageRenamedLibraryPath);

            //要备份的图片路径
            string backupDirectory = ImageBackupPath + txtEfdTitle.Text + "\\";
            //测试的图片路径 

            if (!Directory.Exists(backupDirectory))
                Directory.CreateDirectory(backupDirectory);

            if (!Directory.Exists(ImageDebugPath))
                Directory.CreateDirectory(ImageDebugPath);

            if (!Directory.Exists(ImageEFDPath))
                Directory.CreateDirectory(ImageEFDPath);

            //清空debug和EFD下的imagelib

            string[] debugImages = Directory.GetFiles(ImageDebugPath);
            string[] efdImages = Directory.GetFiles(ImageDebugPath);
            string[] releaseImages = Directory.GetFiles(ImageReleasePath);

            clearImageFile(debugImages);
            clearImageFile(efdImages);
            clearImageFile(releaseImages);

            foreach (string file in imageFiles)
            {
                string name = Path.GetFileName(file);

                //备份图库
                File.Copy(file, backupDirectory + name, true);

                File.Copy(file, ImageReleasePath + name, true);
                File.Copy(file, ImageDebugPath + name, true);
                File.Copy(file, ImageEFDPath + name, true);
            }

        }

        /// <summary>
        /// 清空指定路径中的图片文件
        /// </summary>
        /// <param name="imgFileNames"></param>
        private void clearImageFile(string[] imgFileNames)
        {
            foreach (string img in imgFileNames)
            {
                string exten = Path.GetExtension(img).ToLower();

                if (exten == ".jpg" || exten == ".gif")
                    File.Delete(img);
            }
        }

        protected void btnExportDatabase_Click(object sender, EventArgs e)
        {
            File.Copy(EasyConfig.PathCurrentDatabase, DataBaseDebugPath + "EasyFound.dll", true);
            File.Copy(EasyConfig.PathCurrentDatabase, DataBaseEFDPath + "EasyFound.dll", true);
        }




        /// <summary>
        /// 获得Cid加密代码
        /// </summary>
        /// <param name="product">VerifyCidInfo</param>
        /// <param name="encoding"></param>
        /// <param name="isEncrypt"></param>
        /// <returns></returns>
        public string GetCategoryCodeFile(VerifyCidInfo product, string encoding, bool isEncrypt)
        {
            StringBuilder cidInfo = new StringBuilder();

            cidInfo.AppendFormat("<?xml version=\"1.0\" encoding=\"{0}\" ?>", encoding).Append("\r\n");
            cidInfo.Append("<EasyFound>").Append("\r\n");
            cidInfo.Append("<ExamSys>").Append("\r\n");
            cidInfo.AppendFormat("<Title>{0}</Title>", product.Title).Append("\r\n");
            cidInfo.AppendFormat("<ProductID>{0}</ProductID>", product.ProductID).Append("\r\n");
            cidInfo.AppendFormat("<ProductName>{0}</ProductName>", product.Title).Append("\r\n");
            cidInfo.AppendFormat("<Cid>{0}</Cid>", product.Cid).Append("\r\n");
            cidInfo.AppendFormat("<CategoryCode>{0}</CategoryCode>", product.Cid + "#" + product.ProductID.ToString()).Append("\r\n");
            //新增备用
            cidInfo.AppendFormat("<ParentCid>{0}</ParentCid>", product.ParentCid).Append("\r\n");
            cidInfo.AppendFormat("<ParentCategory>{0}</ParentCategory>", product.ParentCategory).Append("\r\n");
            cidInfo.AppendFormat("<Category>{0}</Category>", product.Category).Append("\r\n");
            cidInfo.AppendFormat("<Version>{0}</Version>", product.Version).Append("\r\n");
            cidInfo.AppendFormat("<VoiceInfo>{0}</VoiceInfo>", product.VoiceInfo).Append("\r\n");
            cidInfo.AppendFormat("<PubTime>{0}</PubTime>", product.PubTime).Append("\r\n");
            cidInfo.AppendFormat("<Content>{0}</Content>", product.Content).Append("\r\n");
            cidInfo.AppendFormat("<MachineID>{0}</MachineID>", product.MachineID).Append("\r\n");
            
            cidInfo.Append("  </ExamSys> ").Append("\r\n");
            cidInfo.Append("</EasyFound> ").Append("\r\n");

            if (isEncrypt)
            {
                Rijndael rijndael = new Rijndael(product.MachineID);
                return rijndael.Encrypt(cidInfo.ToString());
            }

            return cidInfo.ToString();
        }
        /// <summary>
        /// 生成cid到指定路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCid_Click(object sender, EventArgs e)
        {
            vc.ProductID = Request.Form["txtProductID"];
          
            vc.Title = Request.Form["txtProductTitle"];
            vc.Cid = Request.Form["txtCid"];
            vc.Category = Request.Form["txtCategory"];
            vc.MachineID = Request.Form["txtMachineCode"];
            string encryptedCidString = GetCategoryCodeFile(vc, "utf-8", true);

            File.WriteAllText(CidDebugPath, encryptedCidString, System.Text.Encoding.Default);
            File.WriteAllText(CidReleasePath, encryptedCidString, System.Text.Encoding.Default);
            File.WriteAllText(CidEFDPath, encryptedCidString, System.Text.Encoding.Default);
            //备份

            if (!Directory.Exists(CidBackupPath))
                Directory.CreateDirectory(CidBackupPath);
            
            string cidFileName = CidBackupPath + EasyConfig.DBNameWithoutExtension + ".cab";      
        
            File.WriteAllText(cidFileName, encryptedCidString, System.Text.Encoding.Default);
        }
    }
}