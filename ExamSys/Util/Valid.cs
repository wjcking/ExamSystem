using System.IO;
using Cts;
using Model;

namespace ExamSys.Util
{
    public class Valid
    {    
       
        //机器号
        public readonly static string MachineID = Hardware.MachineID;

        public readonly static string SelectionCount = SysData.AccessHelper.ExecuteScalar("SELECT COUNT(*) FROM Selection").ToString();
        public readonly static string JudgementCount = SysData.AccessHelper.ExecuteScalar("SELECT COUNT(*) FROM Judgement").ToString();
        public readonly static string FillCount = SysData.AccessHelper.ExecuteScalar("SELECT COUNT(*) FROM Fill").ToString();
        public readonly static string QuestionCount = SysData.AccessHelper.ExecuteScalar("SELECT COUNT(*) FROM Question").ToString();
        public readonly static string ExamPaperCount = SysData.AccessHelper.ExecuteScalar("SELECT COUNT(*) FROM MainSubject").ToString();

        public readonly static VerifyInfo AccessRegisterInfo = Encrypt.DecryptVerifyXml(SysData.ExamSysUtil.RegisterInfo.ValidXml);
        //是否注册成功
        public readonly static bool IsRegistered = VeryifedCode == 0 ? true : false;


     
        /// <summary>
        /// 第一次注册
        /// </summary>
        /// <param name="encryptedXml"></param>
        /// <returns></returns>    

        public static int Register(string validCode)
        {
            VerifyInfo vi = new VerifyInfo();
            vi.MachineID = AccessRegisterInfo.MachineID;
            vi.CategoryID = AccessRegisterInfo.CategoryID;
                    
            if (Valid.MachineID == "")
                return 10000;

            vi.MachineID = Valid.MachineID;

            string encryptedXml = Encrypt.EncryptVerifyXml(vi, true);
            string code = Encrypt.GetValidCode(vi);

            if (validCode != code)
                return 10001;     

            vi.SelectionCount = SelectionCount;
            vi.JudgementCount = JudgementCount;
            vi.QuestionCount = QuestionCount;
            vi.FillCount = FillCount;
            vi.ExamPaperCount = ExamPaperCount;

            string xml = Encrypt.EncryptVerifyXml(vi, true);
            SysData.ExamSysUtil.UpdateRegisterInfo(xml);
            return 0;
           
        }
        public static int VeryifedCode
        {
            get
            {
                string md5CategoryID = Cts.Encrypt.StringToMD5Hash(AccessRegisterInfo.CategoryID);
                   //调试注册
                if (SysConfig.DebugMode.Equals(md5CategoryID))
                    return 0;

                if (AccessRegisterInfo.MachineID != Valid.MachineID)
                    return 20000;

                if (AccessRegisterInfo.SelectionCount != Valid.SelectionCount)
                    return 20001;

                if (AccessRegisterInfo.JudgementCount != Valid.JudgementCount)
                    return 20002;

                if (AccessRegisterInfo.FillCount != Valid.FillCount)
                    return 20003;

                if (AccessRegisterInfo.QuestionCount != Valid.QuestionCount)
                    return 20004;

                if (AccessRegisterInfo.ExamPaperCount != Valid.ExamPaperCount)
                    return 20005;

                return 0;

            }
        }

        public static string GetErrorText(int code)
        {
            switch (code)
            {
                case 10000:
                    return "机器码获取失败";
                case 10001:
                case 10002:
                    return "注册码验证失败";
                    //return "很抱歉，产品分类错误，您的注册信息不属于该系统。";

                    
                case 20001:
                    return string.Format("数据验证失败 SC = [{0}#{1}]", AccessRegisterInfo.SelectionCount, Valid.SelectionCount);                   
                case 20002:
                    return string.Format("数据验证失败 JC = [{0}#{1}]", AccessRegisterInfo.JudgementCount, Valid.JudgementCount);                   
                case 20003:
                    return string.Format("数据验证失败 FC = [{0}#{1}]", AccessRegisterInfo.FillCount, Valid.FillCount);                   
                case 20004:
                    return string.Format("数据验证失败 QC =[{0}#{1}]", AccessRegisterInfo.QuestionCount, Valid.QuestionCount);                   
                case 20005:
                    return string.Format("数据验证失败 MC = [{0}#{1}]", AccessRegisterInfo.ExamPaperCount, Valid.ExamPaperCount);                   
                case 20000:
                     return string.Format("MachineID[{0}#{1}]", AccessRegisterInfo.MachineID ,  Valid.MachineID);
                   
                case 30000:
                     return "错误： 请输入正确注册码"; 
                   
                case 30001:
                     return "错误： 请输入正确注册码(nullException)";
            }

            return "";
        }
    }
}
