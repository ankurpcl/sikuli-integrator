using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Ionic.Zip;
using System.Threading;

namespace SikuliModule
{
    public class Commander
    {
        private static void AddSikuliLibs()
        {
            //Access to %APPDATA% path
            string tempPath = System.IO.Path.GetTempPath();

            //check if sikulilibs are installed
            string installationPath = Path.Combine(tempPath, "sikulilibs");
            if (Directory.Exists(installationPath))
            {
                return;
            }

            //Extract ZIP
            var zipStream = typeof(Commander).Assembly.GetManifestResourceStream(typeof(Commander).Assembly.GetName().Name + "." + "sikulilibs.zip");

            using (ZipFile zip = ZipFile.Read(zipStream))
            {
                // This call to ExtractAll() assumes:
                //   - none of the entries are password-protected.
                //   - want to extract all entries to current working directory
                //   - none of the files in the zip already exist in the directory;
                //     if they do, the method will throw.
                zip.ExtractAll(tempPath, ExtractExistingFileAction.OverwriteSilently);

                string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Process);

                path += ";" + tempPath + @"\tmplib";

                Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.Process);
            }
        }

        private static string AddQuotes(string value)
        {
            return " \"" + value + "\"";
        }

        public static List<Point> Execute(Command command, string mainPattern, string extraPattern, float similarity, int timeout)
        {
            ProcessStartInfo psi = null;
            string output = "";
            string error = "";

            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                AddSikuliLibs();

                if (String.IsNullOrEmpty(extraPattern))
                {
                    psi = new ProcessStartInfo("java.exe", "-jar" + AddQuotes(Path.GetDirectoryName(typeof(Commander).Assembly.Location) + @"\" + Settings.JarFile) + AddQuotes(mainPattern) + AddQuotes(command.ToString()) + " " + similarity + " " + timeout);
                }
                else
                {
                    psi = new ProcessStartInfo("java.exe", "-jar" + AddQuotes(Path.GetDirectoryName(typeof(Commander).Assembly.Location) + @"\" + Settings.JarFile) + AddQuotes(mainPattern) + AddQuotes(command.ToString()) + " " + similarity + " " + timeout + AddQuotes(extraPattern));
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

                switch (command)
                {
                    case Command.FIND_ALL:
                    case Command.EXISTS:
                        {
                            return PrepareCoordinates(output);
                        }
                    default:
                        {
                            return null;
                        }
                }
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"C:\SikuliExceptionLog.txt", ex.Message);
            }
            return null;
        }

        private static void ConsumeResult(string output, string error)
        {
            if (!String.IsNullOrEmpty(error))
            {
                #if DEBUG
                throw new Exception(error);
                #else
                throw new Exception("Internal Error");
                #endif
            }

            if (output.Contains(Settings.ErrorMessage))
            {
                throw new Exception(output);
            }
        }

        private static List<Point> PrepareCoordinates(String rawCoordinates)
        {
            List<Point> points = new List<Point>();

            string[] pointCoordinates = Regex.Split(rawCoordinates, Environment.NewLine);

            foreach (string point in pointCoordinates)
            {
                if (!String.IsNullOrEmpty(point) && !String.IsNullOrWhiteSpace(point))
                {
                    string rawCoord = point.Substring(rawCoordinates.IndexOf(Settings.Separator) + Settings.Separator.Length);

                    rawCoord = rawCoord.Trim().Replace("(", "").Replace(")", "");

                    //Check point format
                    string regex = @"[0-9];[0-9]";
                    var match = Regex.Match(rawCoord, regex, RegexOptions.IgnoreCase);

                    if (!match.Success)
                    {
                        continue;
                    }

                    string[] coordinates = rawCoord.Split(';');

                    //Check whether the coordinates are extracted corectly
                    if (coordinates.Length == 2)
                    {
                        points.Add(new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1])));
                    }
                    else
                    {
                        throw new Exception("Controls coordinates can not be determined: " + rawCoordinates);
                    }
                }
            }

            return points;
        }
    }
}