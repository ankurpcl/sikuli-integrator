using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace SikuliInvoker
{
    public static class ProcessExtension
    {
        public static IEnumerable<System.Diagnostics.Process> Children(int processId)
        {
            var childProcesses = new List<System.Diagnostics.Process>();

            using (var searcher = new ManagementObjectSearcher(string.Format("SELECT * FROM Win32_Process Where ParentProcessId = {0}", processId)))
            {
                using (var objects = searcher.Get())
                {
                    foreach (var obj in objects)
                    {
                        try
                        {
                            var childProcessId = (int)(uint)obj["ProcessId"];

                            var proc = System.Diagnostics.Process.GetProcessById(childProcessId);

                            childProcesses.Add(proc);
                        }
                        catch
                        {
                            // TODO: log ex
                        }
                        finally
                        {
                            obj.Dispose();
                        }   
                    }
                }
            }

            return childProcesses;
        }
    }
}
