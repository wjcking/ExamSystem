using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

namespace Cts
{
    public class Encrypt
    {
        public static string Decrypt_Key = "wjcking";
        /// <summary>
        /// 获得 加密代码
        /// </summary>
        /// <param name="product">VerifyCidInfo</param>
        /// <param name="encoding"></param> 
        /// <returns></returns>
        public static string EncryptVerifyXml(VerifyInfo product, bool isEncrypt)
        {
            StringBuilder encryptXmlInfo = new StringBuilder();

            encryptXmlInfo.Append("<?xml version=\"1.0\" encoding=\"GB2312\" ?>").Append("\r\n");
            encryptXmlInfo.Append("<EasyFound>").Append("\r\n");
            encryptXmlInfo.Append("<ExamSys>").Append("\r\n");
            encryptXmlInfo.AppendFormat("<CategoryID>{0}</CategoryID>", product.CategoryID).Append("\r\n");
            encryptXmlInfo.AppendFormat("<MachineID>{0}</MachineID>", product.MachineID).Append("\r\n");
            //题目个数
            encryptXmlInfo.AppendFormat("<SelectionCount>{0}</SelectionCount>", product.SelectionCount).Append("\r\n");
            encryptXmlInfo.AppendFormat("<JudgementCount>{0}</JudgementCount>", product.JudgementCount).Append("\r\n");
            encryptXmlInfo.AppendFormat("<FillCount>{0}</FillCount>", product.FillCount).Append("\r\n");
            encryptXmlInfo.AppendFormat("<QuestionCount>{0}</QuestionCount>", product.QuestionCount).Append("\r\n");
            encryptXmlInfo.AppendFormat("<ExamPaperCount>{0}</ExamPaperCount>", product.ExamPaperCount).Append("\r\n");

            encryptXmlInfo.Append("  </ExamSys> ").Append("\r\n");
            encryptXmlInfo.Append("</EasyFound> ").Append("\r\n");

            if (isEncrypt)
            {

                Rijndael rijndael = new Rijndael(Decrypt_Key);
                return rijndael.Encrypt(encryptXmlInfo.ToString());
            }

            return encryptXmlInfo.ToString();
        }

        /// <summary>
        /// 获得 注册码
        /// </summary>
        /// <param name="product">VerifyCidInfo</param>
        /// <param name="encoding"></param> 
        /// <returns></returns>
        public static string GetValidCode(VerifyInfo product)
        {
            string encryptedString = EncryptVerifyXml(product, true);
            encryptedString = encryptedString.Replace("/", "");
            encryptedString = encryptedString.Replace("_", "");
            encryptedString = encryptedString.Replace("+", "");
            encryptedString = encryptedString.Replace("=", "");
            encryptedString = encryptedString.ToUpper();

            StringBuilder validCode = new StringBuilder();
            validCode.Append("EFD"  ); 
            validCode.Append("-");
            validCode.Append(product.CategoryID); 
            validCode.Append("-");
       
             validCode.Append(encryptedString.Substring(encryptedString.Length-10,10));
            validCode.Append("-");
            validCode.Append(encryptedString.Substring(encryptedString.Length - 20, 10));
            validCode.Append("-");
            validCode.Append(encryptedString.Substring(encryptedString.Length - 30, 10));         
            
            return validCode.ToString();



        }


        /// <summary>
        /// 解码注册文件 (解码xml）
        /// </summary>
        /// <param name="machinIDForKey">机器号</param>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static VerifyInfo DecryptVerifyXml(string encryptString)
        {
            VerifyInfo vc = new VerifyInfo();
            try
            {

                Rijndael rijndael = new Rijndael(Decrypt_Key);
                string decryptXml = rijndael.Decrypt(encryptString);

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(decryptXml);
                XmlNode node = xmldoc.SelectSingleNode("EasyFound/ExamSys");
                vc.CategoryID = node["CategoryID"].InnerText;
                vc.MachineID = node["MachineID"].InnerText;
                vc.SelectionCount = node["SelectionCount"].InnerText;
                vc.JudgementCount = node["JudgementCount"].InnerText;
                vc.FillCount = node["FillCount"].InnerText;
                vc.QuestionCount = node["QuestionCount"].InnerText;
                vc.ExamPaperCount = node["ExamPaperCount"].InnerText;
            }
            catch (Exception e)
            {
                vc.ProductName = e.Message;
            }
            return vc;
        }


        /// <summary>
        /// FileStream读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static char[] FileStreamReadFile(string filePath)
        {
            byte[] data = new byte[16];
            char[] charData = new char[16];
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                //文件指针指向0位置
                file.Seek(0, SeekOrigin.Begin);
                //读入两百个字节
                file.Read(data, 0, 16);
                //提取字节数组
                Decoder dec = Encoding.UTF8.GetDecoder();
                dec.GetChars(data, 0, data.Length, charData, 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                file.Close();
            }
            return charData;
        }

        ///<summary>
        /// 用FileStream写文件
        ///</summary>
        ///<param name="str"></param>
        ///<returns></returns>
        public static int EncryptAccess(string path, bool isEncrypt)
        {
            const short Byte_Length = 16;

            byte[] byteReadAccesHead = new byte[Byte_Length];

            byte[] byteAccessHead = new byte[Byte_Length] { 0x00, 0x01, 0x00, 0x00, 0x53, 0x74, 0x61, 0x6E, 0x64, 0x61, 0x72, 0x64, 0x20, 0x4A, 0x65, 0x74 };
            byte[] byteEncryptCode = new byte[Byte_Length] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            FileStream file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            try
            {

                //file.Seek(0, SeekOrigin.Begin);
                //file.Read(byteReadAccesHead, 0, Byte_Length);

                string stringReadAccessHead = Encoding.Default.GetString(byteReadAccesHead);
                string stringAccessHead = Encoding.Default.GetString(byteAccessHead);

                long p = file.Position;

                if (isEncrypt)
                    file.Write(byteEncryptCode, 0, Byte_Length);
                else
                    file.Write(byteAccessHead, 0, Byte_Length);

                if (stringReadAccessHead == stringAccessHead)
                    return -1;

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                file.Close();
            }
        }

        /// <summary>
        /// 加密MD5        
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string StringToMD5Hash(string inputString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }
    }
}
