using System.Windows.Forms;
using Cts;
using System;
using System.Drawing;

namespace ExamSys
{
    public partial class EFDPrint : Form
    {
        private int linesPrinted;
        private string[] lines;
        private string examPaper = "";
     //   private int printPageCount = 1;
        public EFDPrint(Model.TemplateInfo temp)
        {
            InitializeComponent();
            examPaper = EPReader.Read(temp);
            Text = "[打印]" + temp.Title;
            //textBox1.Text = currentExam;

            printDocument.DocumentName = temp.Title;
            numericUpDown1.Maximum = printPreviewControl.Rows;
        }

        private void btnHandle_Click(object sender, System.EventArgs e)
        { 
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left - 45;
            int y = e.MarginBounds.Top - 45;

            System.Drawing.Brush brush = new System.Drawing.SolidBrush(Color.Black);
            Font font = new System.Drawing.Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++], font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };

            //if (printDocument.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.Selection)
            //    lines = examPaper.Split(param);
            //else
            lines = examPaper.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
        {
           
           // printPreviewControl.StartPage = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
