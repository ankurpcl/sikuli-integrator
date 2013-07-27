using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace SikuliModule
{
    public class Commander
    {
        private static void AddSikuliLibs()
        {
            var zipStream = typeof(Commander).Assembly.GetManifestResourceStream(typeof(Commander).Assembly.GetName().Name + "." + "sikulilibs.zip");

            using (ZipFile zip = ZipFile.Read(zipStream))
            {
                // This call to ExtractAll() assumes:
                //   - none of the entries are password-protected.
                //   - want to extract all entries to current working directory
                //   - none of the files in the zip already exist in the directory;
                //     if they do, the method will throw.

                string tempPath = System.IO.Path.GetTempPath();
                zip.ExtractAll(tempPath, ExtractExistingFileAction.OverwriteSilently);

                string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Process);

                path += ";" + tempPath + @"\tmplib";

                Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.Process);
            }
        }

        public static Point Execute(Command command, string mainPattern, string extraPattern, float similarity, int timeout)
        {
            ProcessStartInfo psi = null;
            string output = "";
            string error = "";

            AddSikuliLibs();

            if (String.IsNullOrEmpty(extraPattern))
            {
                psi = new ProcessStartInfo("java.exe", "-jar \"" + Path.GetDirectoryName(typeof(Commander).Assembly.Location) + @"\" + Settings.JarFile + "\" " + mainPattern + " \"" + command.ToString() + "\" " + similarity + " " + timeout);
            }
            else
            {
                psi = new ProcessStartInfo("java.exe", "-jar \"" + Path.GetDirectoryName(typeof(Commander).Assembly.Location) + @"\" + Settings.JarFile + "\" " + mainPattern + " \"" + command.ToString() + "\" " + similarity + " " + timeout + " \"" + extraPattern + "\"");
            }

            System.IO.File.WriteAllText(@"C:\SikuliOutputLog.txt", psi.Arguments);

            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            System.Diagnostics.Process reg;

            reg = System.Diagnostics.Process.Start(psi);
            reg.WaitForExit();
            using (System.IO.StreamReader myOutput = reg.StandardOutput)
            {
                output = myOutput.ReadToEnd();
            }
            using (System.IO.StreamReader myError = reg.StandardError)
            {
                error = myError.ReadToEnd();
            }

            ConsumeResult(output, error);

            if (command == Command.EXISTS)
            {
                return PrepareCoordinates(output);
            }
            else
            {
                return Point.Empty;
            }
        }

        private static void ConsumeResult(string output, string error)
        {
            if (!String.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            if (output.Contains(Settings.ErrorMessage))
            {
                throw new Exception(output);
            }
        }

        private static Point PrepareCoordinates(String rawCoordinates)
        {
            Point point = new Point();

            string separator = "###";

            rawCoordinates = rawCoordinates.Substring(0,rawCoordinates.IndexOf(Environment.NewLine));

            rawCoordinates = rawCoordinates.Substring(rawCoordinates.IndexOf(separator) + separator.Length);

            rawCoordinates = rawCoordinates.Trim().Replace("(", "").Replace(")", "");

            string[] coordinates = rawCoordinates.Split(';');

            if (coordinates.Length == 2)
            {
                point = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }
            else
            {
                throw new Exception("Controls coordinates can not be determined: " + rawCoordinates);
            }

            return point;
        }
    }
}