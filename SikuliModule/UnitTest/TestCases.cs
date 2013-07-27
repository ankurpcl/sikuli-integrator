using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SikuliModule;

namespace UnitTest
{
    [TestClass]
    public class TestCases : BaseTestCase
    {
        [TestMethod,
        Description("Test Exists mechanism")]
        public void TestExists()
        {
            if (!SikuliAction.Exists(pattern).IsEmpty)
            {
                Report.Pass("Yep! It's there...");
            }
            else
            {
                Report.Error("Nope! It's gone...");
            }
        }
    }
}