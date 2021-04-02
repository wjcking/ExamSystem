using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EFD.SysCenter
{
    public class Decorator
    {
        public static DialogResult ShowDialog(Form form)
        {            
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
          //  form.KeyUp += new KeyEventHandler(form_KeyUp);
            return    form.ShowDialog();            
        }     
    }
}
