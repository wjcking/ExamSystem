using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;

namespace Cts
{
    public  class Category
    {
        private List<CategoryInfo> ci;
        private int parentIndex = 0;
        private int childIndex = 0;
        private string baseDirectory;

        public Category()
        {
                ci = new List<CategoryInfo>();
        }




        public  List<CategoryInfo> GetCategoryList(string rootFolder, string searchPattern)
        {
            if (!Directory.Exists(rootFolder))
                return null;

            DirectoryInfo di = new DirectoryInfo(rootFolder);
            DirectoryInfo[] diA = di.GetDirectories();

            if (diA.Length == 0)
                return null;

            for (int i = 0; i < diA.Length; i++)
            {
                CategoryInfo temp = new CategoryInfo();

                temp.Name = diA[i].Name;
                temp.Path = diA[i].FullName;


                //get all of files.
                FileInfo[] fi = diA[i].GetFiles(searchPattern);

                for (int m = 0; m < fi.Length; m++)
                {
                    if (!fi[m].Exists)
                        continue;

                    MaterialInfo mi = new MaterialInfo();

                    mi.Name = fi[m].Name;
                    mi.Path = fi[m].FullName;

                    temp.MaterialListInfo.Add(mi);
                }

                //The root directiory
                if (parentIndex == 0 && childIndex == 0)
                {

                    temp.ChildIndex = childIndex++;
                    baseDirectory = rootFolder;
                }
                else
                {
                    //0-1
                    //1-2
                    //2-3
                    //2-4
                    //3-5
                    if (diA[i] != null)
                    {
                        if (diA[i].Parent.Name == baseDirectory)
                        {
                            int middle = childIndex;
                            childIndex = parentIndex++;
                            parentIndex = middle++;
                        }
                        else
                        {
                            temp.ParentIndex = parentIndex;
                            temp.ChildIndex = childIndex++;

                        }
                    }
                    ci.Add(temp);
                }

                GetCategoryList(diA[i].FullName, searchPattern);
            }
            return ci;
        }
        public List<CategoryInfo> GetCategoryList(string rootFolder)
        {
            return GetCategoryList(rootFolder, "*.*");
        }
    }
}
