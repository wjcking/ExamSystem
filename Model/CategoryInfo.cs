using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CategoryInfo
    {
        private string name;
        private string path;
        private int parentIndex;
        private int childIndex;
        private List<MaterialInfo> materialListInfo;

        public CategoryInfo()
        {
            MaterialListInfo = new List<MaterialInfo>();
         }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public int ParentIndex
        {
            get { return parentIndex; }
            set { parentIndex = value; }
        }
 

        public List<MaterialInfo> MaterialListInfo
        {
            get { return materialListInfo; }
            set { materialListInfo = value; }
        }

        public int ChildIndex
        {
            get { return childIndex; }
            set { childIndex = value; }
        }
    }
}
