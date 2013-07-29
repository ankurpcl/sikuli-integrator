using System;
using System.Linq;

namespace SikuliModule
{
    class Settings
    {
        /// <summary>
        /// Expressed in seconds
        /// </summary>
        public const int DefaultTimeout = 10;

        public const float DefaultSimilarity = 0.95f;

        public const string JarFile = "JSikuliModule.jar";

        public const string Separator = "###";

        public const string ErrorMessage = Separator + "FAILURE";

        public const string SuccessMessage = Separator + "SUCCESS";
    }
}
