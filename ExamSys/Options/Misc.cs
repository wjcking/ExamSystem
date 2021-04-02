using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ExamSys.Delegation;

namespace ExamSys.Options
{
    public partial class Misc : UserControl
    {
        public event SkinChangedHandler SkinSelected;
        public const string IsShowSplash = "IsShowSplash";
        public const string Skin = "Skin";
        public static readonly string Skin_Current = Environment.CurrentDirectory + "\\skin\\" + SysConfig.SettingsHelper.GetValue(Skin);
        private string skinFile = "";

        public void OnSkinSelected(SkinSelectedArgs e)
        {
            if (SkinSelected != null)
            {
                SkinSelected(this, e);
            }
        }

        public Misc()
        {
            InitializeComponent();

            if (SysConfig.DEBUGE_CODE != SysConfig.DebugMode)
                chkSplash.Visible = false;

            chkSplash.Checked = (SysConfig.SettingsHelper.GetValue(IsShowSplash).ToLower() == "true") ? true : false;

            string skin = SysConfig.SettingsHelper.GetValue(Skin).ToLower();

            if (skin == "default.ssk")
                rbDefault.Checked = true;
            else if (skin == "apple.ssk")
                rbApple.Checked = true;
            else
                rbClassic.Checked = true;

            numLimitedTime.Value = Convert.ToInt32(SysConfig.SettingsHelper.GetValue(SysConfig.Option_LimitedTime));
            cbSound.Checked =  SysConfig.EnabledSound;
        }

        public void Save()
        {
            SysConfig.SettingsHelper.SetValue(Skin, skinFile);
            SysConfig.SettingsHelper.SetValue(SysConfig.Option_LimitedTime, numLimitedTime.Value.ToString());
            SysConfig.EnabledSound = cbSound.Checked;
        }

        private void rbDefault_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            switch (rb.Name)
            {
                case "rbDefault":
                    skinFile = "default.ssk";
                    break;
                case "rbClassic":
                    skinFile = "";
                    break;
                case "rbApple":
                    skinFile = "apple.ssk";
                    break;
            }

            SkinSelectedArgs skin = new SkinSelectedArgs();

            skin.SkinFile = Environment.CurrentDirectory + "\\skin\\" + skinFile;
            skin.SkinName = skinFile;
            OnSkinSelected(skin);
        }

    }
}
