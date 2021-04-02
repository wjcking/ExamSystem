using System;
using System.Collections.Generic;
using System.Text;

namespace EFD.SysCenter
{
    public class ExamCategoryInfo
    {
        public string NameWithoutExtension { get { return System.IO.Path.GetFileNameWithoutExtension(Name); } }
       public string  LastAccessTime { get; set; }
       public string  CreationTime  { get; set; }
       public string LastWriteTime { get; set; }
       private string name = "";
       public string Name
       {

           get
           {
               return name;
           }
           set
           {
               name = value;
               if (value.IndexOf('-') < 0 || string.IsNullOrEmpty(value))
                   return;

               ValidCodeCategory = value.Substring(0, value.LastIndexOf('-'));
               string[] cates = value.Split('-');

               if (cates.Length == 1)
               {
                   CategoryID = cates[0];
               }
               else if (cates.Length == 2)
               {
                   CategoryID = cates[0];
                   SubCategoryID = "";
                   ExamName = System.IO.Path.GetFileNameWithoutExtension(cates[1]);
               }
               else if (cates.Length == 3)
               {
                   CategoryID = cates[0];
                   SubCategoryID = cates[1];
                   Number = "";
                   ExamName = System.IO.Path.GetFileNameWithoutExtension(cates[2]);
               }
               else if (cates.Length == 4)
               {
                   CategoryID = cates[0];
                   SubCategoryID = cates[1];
                   Number = cates[2];
                   ExamName = System.IO.Path.GetFileNameWithoutExtension(cates[3]);
               }
           }
       }
        public string FullName {get;set;}
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string Number { get; set; }
        public string ExamName { get; set; }
        public string ValidCodeCategory { get; set; }
    }

}
