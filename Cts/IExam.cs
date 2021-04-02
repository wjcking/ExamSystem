using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using System.Xml;

namespace Cts
{
    public interface IExam
    {

        string Delete();
        string Delete(int index);
        int Count { get; }
    }
}