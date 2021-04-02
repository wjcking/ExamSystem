using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EFD.SysCenter
{

    public partial class Config : Form
    {
        private static readonly PropertyGrid pathProperty = new PropertyGrid();
       // private static readonly DataGridView exportGrid = new DataGridView(); 

        public Config()
        {
            InitializeComponent();
            listOption.SelectedIndex = 0;
        }

        private void listOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCenter.Controls.Clear();
            lbTitle.Text = listOption.Text;

            switch (listOption.SelectedIndex)
            {
                case 0:
                    pathProperty.SelectedObject = new ExportPathInfo();
                    pathProperty.Dock = DockStyle.Fill;
                    panelCenter.Controls.Add(pathProperty);
                    return;
                //case 1:
                //    exportGrid.Dock = DockStyle.Fill;
                //    exportGrid.DataSource = Exam.DatabaseList;
                //    panelCenter.Controls.Add(exportGrid);
                //    return;
                //case 2:
                //    return;
            }
        }



    }
}
