using System;
using System.Diagnostics;
using System.Linq;
using SikuliModule;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Environment.CurrentDirectory + @"\img\pattern.png";
            string pattern1 = Environment.CurrentDirectory + @"\img\pattern1.png";
            string demo = Environment.CurrentDirectory + @"\img\demo.png";

            StartMSPaint(demo);

            if (!SikuliAction.Exists(pattern).IsEmpty)
            {
                Console.WriteLine("Yep! It's there...");
            }
            else
            {
                Console.WriteLine("Nope! It's gone...");
            }

            SikuliAction.Click(pattern);

            SikuliAction.DoubleClick(pattern1);

            SikuliAction.RightClick(pattern);

            SikuliAction.Hover(pattern1);

            SikuliAction.DragAndDrop(pattern1, pattern);

            KillMSPaint();

            Console.ReadLine();
        }

        static void KillMSPaint()
        {
            foreach (Process proc in Process.GetProcessesByName("mspaint"))
            {
                proc.Kill();
            }
        }

        static void StartMSPaint(string image)
        {
            System.Diagnostics.Process.Start("mspaint.exe", image);
        }
    }
}
