using System;
using System.IO;
using System.Linq;

namespace SikuliInvoker
{
    class Logger
    {
        public static void Info(string text)
        {
            BuildDirectoryPath(@"C:\SikuliInvoker");
            System.IO.File.WriteAllText(@"C:\SikuliInvoker\SikuliInvokerLog.txt", text);
        }

        public static void Error(string text)
        {
            BuildDirectoryPath(@"C:\SikuliInvoker");
            System.IO.File.WriteAllText(@"C:\SikuliInvoker\SikuliInvokerErrorLog.txt", text);
        }

        private static void BuildDirectoryPath(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
            }
        }
    }
}
