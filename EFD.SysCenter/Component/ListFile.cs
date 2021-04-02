using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace EFD.SysCenter
{
    public partial class ListFile : ListBox
    {
        public ListFile()
        {
            InitializeComponent();
        }

        public string[] BindFiles(string folder)
        {

            string[] files = Directory.GetFiles(folder);

            if (files.Length == 0)
                return files;

            Items.Clear();
            foreach (string file in files)
            {
                FileInfo f = new FileInfo(file);
                Items.Add(f);
            }
            DisplayMember = "Name";
            ValueMember = "FullName";
            return files;

        }
        public ListFile(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public FileInfo FileInfo { get; set; }
        public string Content { get; set; }

        public string ReadWord(string docFileName)
        {
            //实例化COM
            Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            object fileobj = docFileName;
            object nullobj = System.Reflection.Missing.Value;
            //打开指定文件（不同版本的COM参数个数有差异，一般而言除第一个外都用nullobj就行了）
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref fileobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj
                );
            //取得doc文件中的文本
            string outText = doc.Content.Text;
            //关闭文件
            doc.Close(ref nullobj, ref nullobj, ref nullobj);
             
            //关闭COM
            wordApp.Quit(ref nullobj, ref nullobj, ref nullobj);
            //返回
            return outText;
        }
        private void ListFile_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Items.Count == 0)
                return;

            FileInfo = SelectedItem as FileInfo;

            switch (FileInfo.Extension.ToLower())
            {
                case ".txt":
                    Content = File.ReadAllText(FileInfo.FullName, Encoding.Default);
                    return;
                case ".doc":
                case ".docx":
                    Content = ReadWord(FileInfo.FullName).Replace("\r","\r\n");
                    return;
                case ".rtf":
                    return;
                default:
                    return;
            }
        }
    }
}
