using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Core
{
    [TestClass]
    public class BaseTestCase
    {
        readonly protected string pattern = Environment.CurrentDirectory + @"\pattern.png";
        readonly protected string extraPattern = Environment.CurrentDirectory + @"\pattern1.png";
        readonly protected string findAllPattern = Environment.CurrentDirectory + @"\pattern2.png";
        readonly protected string demo = Environment.CurrentDirectory + @"\demo.png";

        public TestContext TestContext { set; get; }

        [TestInitialize]
        public void BeforeEach()
        {
            //Stop Debug Trace
            Debug.Close();

            //Get current test case
            var testCaseMetaData = this.GetType().GetMethod(TestContext.TestName);
            if (testCaseMetaData == null)
            {
                throw new ArgumentNullException("testCaseMetaData");
            }

            //Try to get AppNotStartAttribute attribute
            var appNotStartAttribute = testCaseMetaData.GetCustomAttribute<AppNotStartAttribute>(true);

            //Start App if AppNotStartAttribute does not exists
            if (appNotStartAttribute == null)
            {
                StartMSPaint();
            }
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

        protected void StartMSPaint(int delayInSeconds = 0)
        {
            if (delayInSeconds == 0)
            {
                //Start MSPaint now in main thread
                System.Diagnostics.Process.Start("mspaint.exe", "\"" + demo + "\"");
            }
            else
            {
                this.delayTimeInSeconds = delayInSeconds;
                //Start MSPaint after specified delay time in worker thread
                Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
                thread.Start();
            }
        }

        private int delayTimeInSeconds;

        private void WorkThreadFunction()
        {
            try
            {
                Thread.Sleep(this.delayTimeInSeconds*1000);
                System.Diagnostics.Process.Start("mspaint.exe", "\"" + demo + "\"");
            }
            catch (Exception ex)
            {
                Report.Error("Application can not be started");
            }
        }


    }
}