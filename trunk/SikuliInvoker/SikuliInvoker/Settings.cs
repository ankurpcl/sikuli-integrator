using System;
using System.IO;
using System.Linq;

namespace SikuliInvoker
{
    class Settings
    {
        public static string patternsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Patterns");

        public static string jarFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"pointer.jar");

    }
}
