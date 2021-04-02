using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EFD.SysCenter
{
    public partial class AddExam : Form
    {
        public AddExam()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtCategory.Text == String.Empty || txtName.Text == string.Empty)
                return;

            StringBuilder newDatabase = new StringBuilder();

            newDatabase.Append(Static.Settings.GetValue(Constant.DatabasePath));
            newDatabase.Append("\\");
            newDatabase.Append(txtCategory.Text.ToUpper());
            newDatabase.Append("-");
            newDatabase.Append(txtSubCategory.Text.ToUpper());
            newDatabase.Append("-");
            newDatabase.Append(txtNumber.Text.ToUpper());
            newDatabase.Append("-");
            newDatabase.Append(txtName.Text);
            newDatabase.Append(".mdb");

            System.IO.File.Copy(Environment.CurrentDirectory + "\\App_Data\\db.mdb", newDatabase.ToString(), true);
            Static.Settings.SetValue(Constant.RecentFiles, newDatabase.ToString());
            Exam.SelectedFilePath = newDatabase.ToString();
            Close();
        }
    }
}