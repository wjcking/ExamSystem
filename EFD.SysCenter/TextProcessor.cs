using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

namespace EFD.SysCenter
{

    public partial class TextProcessor : Form
    {
        List<TextInfo> textList = new List<TextInfo>();
       private const string KeyRegex = "KeyRegex";
       private const string AnalysisRegex = "AnalysisRegex";
       private const string ClearQuestionRegex = "ClearQuestionRegex";

        private void GetContentByRegex(string buttonID)
        {
            try
            {
                string content = txtOutput.Text;
                string keyExpression = txtKeyExpression.Text;
                string analysisExpression = txtAnalysisExpression.Text;
                string clearExpression = cbxClear.Text;
                string expression = "";
                txtOutput.Clear();

                switch (buttonID)
                {
                    case "btnGetKey":
                        expression = keyExpression;

                        Static.Settings.SetValue(KeyRegex, expression);
                        break;
                    case "btnGetAnalysis":
                        expression = analysisExpression;
                        Static.Settings.SetValue(AnalysisRegex, expression);
                        break;
                    case "btnClearQuestion":
                        expression = clearExpression;
                        Static.Settings.SetValue(ClearQuestionRegex, expression);
                        break;
                }

                MatchCollection Matches = Regex.Matches(content, expression);
                string[] ops = new string[Matches.Count];

                switch (buttonID)
                {
                    case "btnGetKey":
                        for (int i = 0; i < Matches.Count; i++)
                        {
                            int id = i + 1;
                            ops[i] = Matches[i].Value;
                            //   ops[i] = Matches[i].Groups[0].Value;
                            txtOutput.AppendText(id.ToString() + "." + ops[i] + "\r\n");

                        }
                        break;
                    case "btnGetAnalysis":
                        for (int i = 0; i < Matches.Count; i++)
                        {
                            int id = i + 1;
                            ops[i] = Matches[i].Value;
                            txtOutput.AppendText(id.ToString() + "." + ops[i] + "\r\n");
                        }
                        break;
                    case "btnClearQuestion":
                        txtOutput.Text = Regex.Replace(content, expression, "");
                        cbxClear.Items.Add(cbxClear.Text);
                        break;
                }

            }
            catch (Exception e)
            {
                txtOutput.Text = e.Message;
            }

        }
        public TextProcessor()
        {
            InitializeComponent();

        txtKeyExpression.Text =    Static.Settings.GetValue(KeyRegex);
        txtAnalysisExpression.Text = Static.Settings.GetValue(AnalysisRegex);
        cbxClear.Text = Static.Settings.GetValue(ClearQuestionRegex);
        }
        private void Btn_Click(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;

            GetContentByRegex(btn.Name);
        }
        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    listFiles.BindFiles(ofd.SelectedPath);
                }
            }
        }

        private void listItems_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listItems.Items.Count != 0)
                txtOutput.Text = textList[listItems.SelectedIndex].Text;
        }

        private void listFiles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listFiles.Items.Count == 0)
                return;

            if (listFiles.Content == null)
                return;

            MatchCollection mc = Regex.Matches(listFiles.Content, @"\[q=([^\]]+)\]([\w\W]*?)(\[/q\])", RegexOptions.IgnoreCase);
            int index = 1;

            if (mc.Count == 0)
            {
                txtOutput.Text = listFiles.Content;
                return;
            }

            textList.Clear();
            listItems.Items.Clear();
            foreach (Match m in mc)
            {
                TextInfo textInfo = new TextInfo();
                textInfo.Name = m.Groups[1].Value;
                textInfo.Text = m.Groups[2].Value;
                textInfo.Index = index++;
                textList.Add(textInfo);
                listItems.Items.Add(textInfo);
            }


            listItems.DisplayMember = "Name";
        }
    }
}
