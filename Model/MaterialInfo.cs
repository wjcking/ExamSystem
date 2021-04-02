using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MaterialInfo
    {
        private string name;
        private string path;
        private int parentIndex;
        private int index;

        public MaterialInfo()
        {
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

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
