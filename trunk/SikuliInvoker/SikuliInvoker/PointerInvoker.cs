using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SikuliInvoker
{
    public class PointerInvoker
    {
        private String controlPattern;
        private String similarity;
        private String timeout;
        private String command;

        public PointerInvoker(String controlPattern,String command, float similarity, long timeout)
        {
            this.controlPattern = Path.Combine(Settings.patternsFolder, controlPattern);
            this.similarity = similarity.ToString();
            this.timeout = timeout.ToString();
            this.command = command;
        }

        public Point TryGetPoint()
        {
            Point point = new Point();

            string output = "";
            string error = "";

            ProcessStartInfo psi = new ProcessStartInfo("java.exe", "-jar \"" + Settings.jarFile + "\" \"" + this.controlPattern + "\" " + this.command + " " + this.similarity + " " + this.timeout);
            Logger.Info("-jar \"" + Settings.jarFile + "\" \"" + this.controlPattern + "\" " + this.similarity + " " + this.timeout);

            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            System.Diagnostics.Process reg;
            try
            {
                reg = System.Diagnostics.Process.Start(psi);
                reg.WaitForExit();
                using (System.IO.StreamReader myOutput = reg.StandardOutput)
                {
                    output = myOutput.ReadToEnd();
                    if (!String.IsNullOrEmpty(output))
                    {
                        Logger.Info(output);
                    }
                }
                using (System.IO.StreamReader myError = reg.StandardError)
                {
                    error = myError.ReadToEnd();
                    if (!String.IsNullOrEmpty(error))
                    {
                        Logger.Error(error);
                    }
                }
            }
            catch
            {
                throw new Exception("Control is NOT found");
            }

            if (output.Contains("(") && output.Contains(")"))
            {
                point = PrepareCoordinates(output);
            }

            return point;
        }

        private Point PrepareCoordinates(String rawCoordinates)
        {
            Point point = new Point();

            string separator = "###";

            rawCoordinates = rawCoordinates.Substring(rawCoordinates.IndexOf(separator) + separator.Length);

            rawCoordinates = rawCoordinates.Trim().Replace("(", "").Replace(")", "");

            string[] coordinates = rawCoordinates.Split(';');

            if (coordinates.Length == 2)
            {
                point = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }
            else
            {
                Console.WriteLine("Controls coordinates can not be determined: " + rawCoordinates);
            }

            return point;
        }
    }
}