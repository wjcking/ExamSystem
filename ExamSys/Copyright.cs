using System;
using System.Drawing;
using System.Windows.Forms;
using ExamSys.Util;

namespace ExamSys
{
    public partial class Copyright : Form
    {
        public Copyright()
        {
            InitializeComponent();

            SysConfig.Decorater.FormCloseByKeyUp(this);

            picEasyLogo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "images\\logo_home.gif");
 
            button1.DialogResult = DialogResult.Cancel;
            lbHomePage.Text += SysConfig.SettingsHelper.GetValue(Settings.HomePage);

        //    lbxRegisterInfo.Items.Add("系统名：" + Valid.EfdCid.SystemTitle);
          //  lbxRegisterInfo.Items.Add("题库版本：" + Valid.AccessRegisterInfo.Version);

            if (Valid.IsRegistered)
            {
             //   lbxRegisterInfo.Items.Add("注册号：" + Valid.EfdInfo.RegCode);
            }

            lbxRegisterInfo.Items.Add("注意：注册码对应一台计算机，注册后则不能在使用其他系统或计算机上。");
            lbxRegisterInfo.Items.Add("版权所有：易方得科技");

            if (SysConfig.IsShowSystemCreator)
            {
                lbxRegisterInfo.Items.Add("易方得考试系统创建者：吴金春(wjcking)");
            }
                lbxRegisterInfo.Items.Add("产品编号：" + Valid.AccessRegisterInfo.CategoryID);
            lbxRegisterInfo.Items.Add("机器号：" + Valid.MachineID);

            lbxRegisterInfo.SelectedIndex = 0;
            lbSystemName.Text = "计算机名：" + SystemInformation.ComputerName;

            //注册限制
            if (Valid.IsRegistered)
            {
                btnRegister.Enabled = false;
                btnRegister.Text = "已注册";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            switch (btn.Name)
            {
                case "btnMachineID":
                    Clipboard.SetText(Valid.MachineID);
                    MessageBox.Show(String.Format("您的机器号：{0} 复制完毕", Valid.MachineID), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                case "btnRegister":
                    Register.GetNewRegister();
                    return;
                case "btnJoin":
                    System.Diagnostics.Process.Start(SysConfig.SettingsHelper.GetValue(Settings.RegisterUrl));
                    return;
                case "btnHelp":
                    System.Diagnostics.Process.Start("help.chm");
                    return;
            }
        }


    }
}


