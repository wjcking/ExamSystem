using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EFD.SysCenter
{
    public partial class DetailWnd : Form
    {
        public DetailWnd(string detail)
        {
            InitializeComponent();
            
            Detail = detail;
            txtDetail.Text = Detail;
        }
        public string Detail { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Detail = txtDetail.Text;
        }

        private void DetailWnd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
