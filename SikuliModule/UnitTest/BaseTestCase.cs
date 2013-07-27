using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class BaseTestCase
    {
        readonly protected string pattern = Environment.CurrentDirectory + @"\pattern.png";
        readonly protected string extraPattern = Environment.CurrentDirectory + @"\pattern1.png";
        readonly protected string demo = Environment.CurrentDirectory + @"\demo.png";

        [TestInitialize]
        public void BeforeEach()
        {
            //Stop Debug Trace
            Debug.Close();

            StartMSPaint(demo);
        }

        [TestCleanup]
        public void AfterEach()
        {
            KillMSPaint();
        }

        private void KillMSPaint()
        {
            foreach (Process proc in Process.GetProcessesByName("mspaint"))
            {
                proc.Kill();
            }
        }

        private void StartMSPaint(string image)
        {
            System.Diagnostics.Process.Start("mspaint.exe", "\""+image+"\"");
        }
    }
}