using System;
using System.Windows.Forms;
using ExamSys.Util;

namespace ExamSys
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            Init();
        }

        public Register(string message)
        {
            InitializeComponent();
            Init();
            listMessage.AddMessage(message);
        }

        private void Init()
        {
            // picEasyLogo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "images\\alert.png");
            button1.DialogResult = DialogResult.Cancel;
            Text = string.Format("注册(易方得{0})", SysData.ExamSysUtil.RegisterInfo.ProductName);
            listMessage.AddMessage("[" + Valid.VeryifedCode.ToString() + "]" + Valid.GetErrorText(Valid.VeryifedCode));

        }

        /// <summary>
        /// 实例化注册窗口, 
        /// </summary>
        /// <param name="message">添加消息到列表中</param>
        /// <returns></returns>
        public static DialogResult GetNewRegister(string message)
        {
            if (Valid.IsRegistered)
                return DialogResult.Yes;

            return new Register(message).ShowDialog();
        }
        /// <summary>
        /// 新注册窗口
        /// </summary>
        /// <returns></returns>
        public static DialogResult GetNewRegister()
        {
            if (Valid.IsRegistered)
                return DialogResult.Yes;

            return new Register().ShowDialog();
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);

            if (btn == btnMachineID)
            {
                Clipboard.SetText(Valid.MachineID);
                listMessage.AddMessage(String.Format("您的机器号：{0} 复制完毕", Valid.MachineID));
            }

            else if (btn == btnRegister)
            {
                if (string.IsNullOrEmpty(txtValidCode.Text))
                {
                    listMessage.AddMessage("请输入注册码");
                    txtValidCode.Focus();
                    return;
                }
                int result = Valid.Register(txtValidCode.Text);

                if (result > 0)
                {
                    listMessage.AddMessage("[" + result.ToString() + "]" + Valid.GetErrorText(result));
                    return;
                }

                MessageBox.Show("注册成功, 重新启动系统......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SysConfig.SettingsHelper.SetValue(SysConfig.Json_Initialized, "false");
                Application.Restart();


            }
        }

    }
}


