using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SikuliModule;
using UnitTest.Core;

namespace UnitTest.TestCases
{
    [TestClass]
    public class CustomSimilarityAndTimeout : BaseTestCase
    {
        const int Timeout5S = 5 * 1000;
        const float Similarity90 = 0.90f;

        [TestMethod,
        Description("Test Exists mechanism - similarity = 90% and timeout = 5s")]
        public void TestExistsWithSimilarity90AndTimeout5()
        {
            if (SikuliAction.Exists(pattern, Similarity90, Timeout5S).IsEmpty)
            {
                Report.Error("Nope! It's gone...");
            }
            else
            {
                Report.Pass("Yep! It's there...");
            }
        }

        [TestMethod,
        Description("Test Find All mechanism - similarity = 90% and timeout = 5s")]
        public void TestFindAllWithSimilarity90AndTimeout5()
        {
            //There are 3 patterns on the test image
            List<Point> points = SikuliAction.FindAll(findAllPattern, Similarity90, Timeout5S);
            if (points != null &&
                points.Count == 3)
            {
                foreach (Point point in points)
                {
                    Report.Info("X:" + point.X + "  Y: " + point.Y);
                }
                Report.Pass("Yep! They are 3...");
            }
            else
            {
                Report.Error("Nope! They are NOT 3...");
            }
        }

        [TestMethod,
        Description("Test Click mechanism - similarity = 90% and timeout = 5s")]
        public void TestClickWithSimilarity90AndTimeout5()
        {
            try
            {
                SikuliAction.Click(pattern, Similarity90, Timeout5S);
                Report.Pass("Yep! It's clicked...");
            }
            catch
            {
                Report.Error("Nope! It's NOT clicked...");
            }
        }

        [TestMethod,
        Description("Test Hover mechanism - similarity = 90% and timeout = 5s")]
        public void TestHoverWithSimilarity90AndTimeout5()
        {
            try
            {
                SikuliAction.Hover(pattern, Similarity90, Timeout5S);
                Report.Pass("Yep! It's hovered...");
            }
            catch
            {
                Report.Error("Nope! It's NOT hovered...");
            }
        }

        [TestMethod,
        Description("Test Double Click mechanism - similarity = 90% and timeout = 5s")]
        public void TestDoubleClickWithSimilarity90AndTimeout5()
        {
            try
            {
                SikuliAction.DoubleClick(extraPattern, Similarity90, Timeout5S);
                Report.Pass("Yep! It's double clicked...");
            }
            catch
            {
                Report.Error("Nope! It's NOT double clicked...");
            }
        }

        [TestMethod,
        Description("Test Right Click mechanism - similarity = 90% and timeout = 5s")]
        public void TestRightClickWithSimilarity90AndTimeout5()
        {
            try
            {
                SikuliAction.RightClick(pattern, Similarity90, Timeout5S);
                Report.Pass("Yep! It's right clicked...");
            }
            catch
            {
                Report.Error("Nope! It's NOT right clicked...");
            }
        }

        [TestMethod,
        Description("Test Drag and Drop mechanism - similarity = 90% and timeout = 5s")]
        public void TestDragAndDropWithSimilarity90AndTimeout5()
        {
            try
            {
                SikuliAction.DragAndDrop(extraPattern, pattern, Similarity90, Timeout5S);
                Report.Pass("Yep! It's drag and dropped...");
            }
            catch
            {
                Report.Error("Nope! It's NOT drag and dropped...");
            }
        }
    }
}