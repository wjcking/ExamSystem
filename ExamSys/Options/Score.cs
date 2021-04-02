using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ExamSys.Util;
using Model;

namespace ExamSys.Options
{
    public partial class Score : UserControl
    {

        public Score()
        {
            InitializeComponent();
            dataGridView.DataError += new DataGridViewDataErrorEventHandler(dataGridView_DataError);
            BindData();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }


        private void BindData()
        {

            dataGridView.DataSource = SysData.MajorSubjectUtil.GetListArray("100 = 100 ORDER BY [sort] ASC"); 

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                if (col.HeaderText == "ID")
                {
                    col.Name = "cID";
                    col.Visible = false;
                    continue;
                }
                if (col.Name == "Subject")
                {
                    col.ReadOnly = true;
                    col.Width = 200;
                    col.HeaderText =  "题目";
                    col.Name = "cSubject";
                    continue;
                }
                if (col.Name == "EachPoint")
                {
                    col.Width = 180;
                    col.HeaderText  = "试题每分";
                    col.Name = "cEachPoint";
                    continue;
                }
                col.Visible = false;
            }

        }
        

        public void Save()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                SysData.AccessHelper.ExecuteNonQuery(String.Format("UPDATE MainSubject SET EachPoint = {0} WHERE ID = {1}", row.Cells["cEachPoint"].Value, row.Cells["cID"].Value));
            }

            SysData.GenerateJson();
        }
    }
}
