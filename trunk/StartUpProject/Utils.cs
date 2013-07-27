using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace StartUpProject
{
    public class Utils
    {
        readonly protected string pattern = Environment.CurrentDirectory + @"\img\pattern.png";
        readonly protected string extraPattern = Environment.CurrentDirectory + @"\img\pattern1.png";
        readonly protected string findAllPattern = Environment.CurrentDirectory + @"\img\pattern2.png";
        readonly protected string demo = Environment.CurrentDirectory + @"\img\demo.png";

        protected void KillMSPaint(int delayInSeconds = 0)
        {
            this.delayTimeInSeconds = delayInSeconds;
            //Kill MSPaint after specified delay time from worker thread
            Thread thread = new Thread(new ThreadStart(DelayedKillMSPaint));
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
                //System.Diagnostics.Process.Start("mspaint.exe", "\"" + demo + "\"");
            }
            else
            {
                this.delayTimeInSeconds = delayInSeconds;
                //Start MSPaint after specified delay time in worker thread
                Thread thread = new Thread(new ThreadStart(DelayedStartMSPaint));
                thread.Start();
            }
        }

        private int delayTimeInSeconds;

        private void DelayedStartMSPaint()
        {
            try
            {
                Thread.Sleep(this.delayTimeInSeconds * 1000);
                ProcessStartInfo startInfo = new ProcessStartInfo("mspaint.exe", "\"" + demo + "\"");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Application can not be started");
            }
        }

        private void DelayedKillMSPaint()
        {
            try
            {
                Thread.Sleep(this.delayTimeInSeconds * 1000);
                foreach (Process proc in Process.GetProcessesByName("mspaint"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Application can not be killed");
            }
        }
    }
}
