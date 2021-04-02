using System;
using System.Windows.Forms;
using ExamSys.Util;

namespace ExamSys
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            //是否有实例在运行
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "ExamSys");
            bool flag = mutex.WaitOne(0, false);

            if (!flag)
            {
                MessageBox.Show("程序已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);         
            
           
            //第一步 解密数据库
            Cts.Encrypt.EncryptAccess("EasyFound.dll", false);

            //一次性初始化
            SysData.InitializeJson();
            //初始化json cache
            SysData.GenerateJson();
           
            //if (SysConfig.DebugMode != SysConfig.DEBUGE_CODE)
            //{
            //    //SplashFadeAppContext splashContext = new SplashFadeAppContext(new MainCategory(), new Splash());
            //    //splashContext.DoFadeOpen = true;
            //    //splashContext.DoFadeClose = true;
            //    //splashContext.SecondsSplashShown = 1;
            //    //Application.Run(splashContext);
            //    Application.Run(new MainCategory());
            //}
            //else
            //{
                Application.Run(new MainCategory());
            //}
        }
    }
}