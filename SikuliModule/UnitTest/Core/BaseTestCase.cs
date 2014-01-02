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

        protected void KillMSPaint(int delayInSeconds = 0)
        {
            this.delayTimeInSeconds = delayInSeconds;
            //Kill MSPaint after specified delay time from worker thread
            Thread thread = new Thread(new ThreadStart(DelayedKillMSPaint));
            thread.Start();
        }

        protected void KillNotepad(int delayInSeconds = 0)
        {
            this.delayTimeInSeconds = delayInSeconds;
            //Kill MSPaint after specified delay time from worker thread
            Thread thread = new Thread(new ThreadStart(DelayedKillNotepad));
            thread.Start();
        }

        protected void StartMSPaint(int delayInSeconds = 0)
        {
            if (delayInSeconds == 0)
            {
                //Start MSPaint now in main thread
                ProcessStartInfo startInfo = new ProcessStartInfo("mspaint.exe", "\"" + demo + "\"");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
            }
            else
            {
                this.delayTimeInSeconds = delayInSeconds;
                //Start MSPaint after specified delay time in worker thread
                Thread thread = new Thread(new ThreadStart(DelayedStartMSPaint));
                thread.Start();
            }
        }

        protected void StartNotepad(int delayInSeconds, int waitSeconds)
        {
            if (delayInSeconds == 0)
            {
                //Start MSPaint now in main thread
                ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
            }
            else
            {
                this.delayTimeInSeconds = delayInSeconds;
                Thread thread = new Thread(new ThreadStart(DelayedStartNotepad));
                thread.Start();
            }
        }

        private int delayTimeInSeconds;

        private void DelayedStartMSPaint()
        {
            DelayedStart("mspaint.exe");
        }

        private void DelayedStartNotepad()
        {
            DelayedStart("notepad.exe");
        }

        private void DelayedKillMSPaint()
        {
            DelayedKill("mspaint");
        }

        private void DelayedKillNotepad()
        {
            DelayedKill("notepad");
        }

        private void DelayedStart(string appName)
        {
            try
            {
                Thread.Sleep(this.delayTimeInSeconds * 1000);
                ProcessStartInfo startInfo = new ProcessStartInfo(appName, "\"" + demo + "\"");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Report.Error("Application can not be started " + ex.Message);
            }
        }

        private void DelayedKill(string appName)
        {
            try
            {
                Thread.Sleep(this.delayTimeInSeconds * 1000);
                foreach (Process proc in Process.GetProcessesByName(appName))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                Report.Error("Application can not be killed " + ex.Message);
            }
        }


    }
}