using System;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace ExamSys.Util
{

    public class Print
    {
        //��ӡ�ĵ�
        private PrintDocument printDocument = new PrintDocument();


        private static readonly char[] CHAR_RETURN = "\r\n".ToCharArray();
        //����
       // private int lineIndex;
        //��ӡ�ַ�����
        private string[] lines;

        //��ӡ��Ԥ������
        private static string printPreviewDialogError = "";
        //��ӡ����
        private static string printDialogError = "";



        //��ӡ����
        public string PrintContent { get; set; }
        //��ӡ����
        public string PrintName { get; set; }

        /// <summary>
        /// ��ӡԤ��
        /// </summary>
        public void PrintPreview()
        {
            if (printPreviewDialogError != "")
            {
                MessageBox.Show(printPreviewDialogError, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                //  examPaper = Cts.EPReader.Read(templateInfo);

                // d.BeginPrint
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_PrintPage);
                printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(printDocument_BeginPrint);

                //printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
                //printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
                printPreviewDialog.ClientSize = new System.Drawing.Size(600, 400);
                printPreviewDialog.DataBindings.Add(new System.Windows.Forms.Binding("StartPosition", global::ExamSys.Properties.Settings.Default, "CenterScreen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                printPreviewDialog.Icon = null;
                printPreviewDialog.Name = "printPreviewDialog";
                printPreviewDialog.ShowIcon = false;
                printPreviewDialog.StartPosition = global::ExamSys.Properties.Settings.Default.CenterScreen;
                printDocument.DocumentName = PrintName;

                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception exp)
            {
                printPreviewDialogError = "[PrintPreview]��ӡ����������\n" + exp.Message;
                MessageBox.Show(printPreviewDialogError, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        System.IO.StringReader lineReader = null;

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            lineReader = new System.IO.StringReader(PrintContent);
       

            //const int MB_DIFFER = 50;
            //int x = e.MarginBounds.Left - MB_DIFFER;
            //int y = e.MarginBounds.Top - MB_DIFFER;

            //string fontFaimly = SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontFamily);
            //float fontSize = Convert.ToSingle(SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformFontSize));
            //   int dividedHeight = 20;


            //Brush brush = new SolidBrush(Color.Black);
            //Font font = new Font(fontFaimly, fontSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134))); 
            //RectangleF rect = new RectangleF(x, y, e.MarginBounds.Width + MB_DIFFER, e.MarginBounds.Height);
            //e.Graphics.DrawString(PrintContent, font, brush, rect, new StringFormat()); 

            //RectangleF rect2 = new RectangleF(x, y + e.MarginBounds.Height+50, e.MarginBounds.Width + MB_DIFFER, e.MarginBounds.Height);
            //e.Graphics.DrawString(PrintContent, font, brush, rect2, new StringFormat());

            //if (y <= e.MarginBounds.Bottom)
            //{
            //    e.HasMorePages = false;
            //    return;
            //}
            //while (lineIndex < lines.Length)
            //{
            //    string line = lines[lineIndex++];
            //    RectangleF rect = new RectangleF(x, y, e.MarginBounds.Width + MB_DIFFER, e.MarginBounds.Height);
            //    e.Graphics.DrawString(line, font, brush, rect , new StringFormat());
            //    y += Convert.ToInt32(font.GetHeight()/2)  ;


            //    if (y >= e.MarginBounds.Bottom)
            //    {
            //        e.HasMorePages = true;
            //        return;
            //    }
            //}

            lineIndex = 0;
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lines = PrintContent.Split(CHAR_RETURN);
        }

        public void PrintExamInfo()
        {

            //���û�д�ӡ���򲻴�ӡ
            if (printDialogError != "")
            {
                MessageBox.Show(printDialogError, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                PrintDialog pd = new PrintDialog();
                pd.Document = printDocument;

                if (pd.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = pd.PrinterSettings;
                    printDocument.Print();
                }
            }
            catch (Exception e)
            {
                printDialogError = e.Message;
                printDialogError = "[PrintDialog]��ӡ����������\n" + e.Message;
                MessageBox.Show(printPreviewDialogError, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
