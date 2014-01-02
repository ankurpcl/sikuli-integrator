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
    public class TestCases : BaseTestCase
    {
        const int Timeout5S = 5;
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
            //There are 6 patterns on the test image
            List<Point> points = SikuliAction.FindAll(findAllPattern, Similarity90, Timeout5S, Rectangle.Empty);
            if (points != null)
            {
                foreach (Point point in points)
                {
                    Report.Info("X:" + point.X + "  Y: " + point.Y);
                }
                if (points.Count == 6)
                {
                    Report.Pass("Yep! They are 6...");
                }
                else
                {
                    Report.Error("Nope! They are NOT 6, they are " + points.Count);
                }
            }
            else
            {
                Report.Error("Nope! There is a problem...");
            }
        }

        [TestMethod,
        Description("Test Exists mechanism - default similarity and timeout")]
        public void TestExistsDefault()
        {
            if (SikuliAction.Exists(pattern).IsEmpty)
            {
                Report.Error("Nope! It's gone...");
            }
            else
            {
                Report.Pass("Yep! It's there...");
            }
        }

        [TestMethod,
        Description("Test Find All mechanism - default similarity and timeout")]
        public void TestFindAllDefault()
        {
            //There are 3 patterns on the test image
            List<Point> points = SikuliAction.FindAll(findAllPattern);
            if (points != null)
            {
                foreach (Point point in points)
                {
                    Report.Info("X:" + point.X + "  Y: " + point.Y);
                }
                if (points.Count == 6)
                {
                    Report.Pass("Yep! They are 6...");
                }
                else
                {
                    Report.Error("Nope! They are NOT 6, they are " + points.Count);
                }
            }
            else
            {
                Report.Error("Nope! There is a problem...");
            }
        }

        //This test strongly depends on your screen resolution. There is a possibility to fail.
        [TestMethod,
        Description("Test Find All in a search region mechanism - default similarity and timeout")]
        public void TestFindAllIntoRegion()
        {
            //There are 3 patterns on the test region
            Rectangle searchRegion = new Rectangle(1, 150, 300, 100);
            List<Point> points = SikuliAction.FindAll(findAllPattern, searchRegion);

            if (points != null)
            {
                foreach (Point point in points)
                {
                    Report.Info("X:" + point.X + "  Y: " + point.Y);
                }
                if (points.Count == 3)
                {
                    Report.Pass("Yep! They are 3...");
                }
                else
                {
                    Report.Error("Nope! They are NOT 3, they are " + points.Count);
                }
            }
            else
            {
                Report.Error("Nope! There is a problem...");
            }
        }

        [TestMethod,
        Description("Test Click mechanism - default similarity and timeout")]
        public void TestClickDefault()
        {
            try
            {
                SikuliAction.Click(pattern);
                Report.Pass("Yep! It's clicked...");
            }
            catch
            {
                Report.Error("Nope! It's NOT clicked...");
            }
        }

        [TestMethod,
        Description("Test Hover mechanism - default similarity and timeout")]
        public void TestHoverDefault()
        {
            try
            {
                SikuliAction.Hover(pattern);
                Report.Pass("Yep! It's hovered...");
            }
            catch
            {
                Report.Error("Nope! It's NOT hovered...");
            }
        }

        [TestMethod,
        Description("Test Double Click mechanism - default similarity and timeout")]
        public void TestDoubleClickDefault()
        {
            try
            {
                SikuliAction.DoubleClick(extraPattern);
                Report.Pass("Yep! It's double clicked...");
            }
            catch
            {
                Report.Error("Nope! It's NOT double clicked...");
            }
        }

        [TestMethod,
        Description("Test Right Click mechanism - default similarity and timeout")]
        public void TestRightClickDefault()
        {
            try
            {
                SikuliAction.RightClick(pattern);
                Report.Pass("Yep! It's right clicked...");
            }
            catch
            {
                Report.Error("Nope! It's NOT right clicked...");
            }
        }

        [TestMethod,
        Description("Test Drag and Drop mechanism - default similarity and timeout")]
        public void TestDragAndDropDefault()
        {
            try
            {
                SikuliAction.DragAndDrop(extraPattern, pattern);
                Report.Pass("Yep! It's drag and dropped...");
            }
            catch
            {
                Report.Error("Nope! It's NOT drag and dropped...");
            }
        }

        //[TestMethod,
        //Description("Test Drag and Drop + Click + Drag and Drop mechanism")]
        //public void TestDragAndDropStartDefault()
        //{
        //    try
        //    {
        //        SikuliAction.Click(paintSelectPattern);
        //        SikuliAction.DragAndDrop(startTopLeftPattern, startRightBottomtPattern);
        //        SikuliAction.DragAndDrop(startPattern, pattern);

        //        Report.Pass("Yep! It's drag and dropped...");
        //    }
        //    catch
        //    {
        //        Report.Error("Nope! It's NOT drag and dropped...");
        //    }
        //}

        [TestMethod,
        Description("Test Wait Vanish mechanism - Positive")]
        public void TestWaitVanishDefaultPositive()
        {
            try
            {
                KillMSPaint(2);
                SikuliAction.WaitVanish(extraPattern, 3);
                Report.Pass("Yep! It's vanished...");
            }
            catch
            {
                Report.Error("Nope! It's NOT vanished...");
            }
        }

        [TestMethod,
        Description("Test Wait Vanish mechanism - Negative")]
        public void TestWaitVanishDefaultNegative()
        {
            try
            {
                KillMSPaint(3);
                SikuliAction.WaitVanish(extraPattern, 2);
                Report.Error("Nope! It's vanished, but it shouldn't...");
            }
            catch
            {
                Report.Pass("Yep! It's not vanished as expected...");
            }
        }

        [TestMethod,
        Description("Test Wait mechanism - Positive")]
        public void TestWaitDefaultPositive()
        {
            try
            {
                StartMSPaint(2);
                SikuliAction.Wait(extraPattern, 3);
                Report.Pass("Yep! It's appeared...");
            }
            catch
            {
                Report.Error("Nope! It's NOT appeared...");
            }
        }

        [TestMethod,
        Description("Test Wait mechanism - Negative")]
        public void TestWaitDefaultNegative()
        {
            try
            {
                StartMSPaint(3);
                SikuliAction.Wait(extraPattern, 2);
                Report.Error("Nope! It's appeared, but it shouldn't...");
            }
            catch
            {
                Report.Pass("Yep! It's not appeared as expected...");
            }
        }

        //[TestMethod,
        //Description("Test Type mechanism using pattern- Positive")]
        //[AppNotStart]
        //public void TestATypeDefaultPositive()
        //{
        //    try
        //    {
        //        //this test requires internet connection
        //        StartGoogle(0);
        //        System.Threading.Thread.Sleep(7000);
        //        SikuliAction.Click(googleTabPattern, 0.9f, 35);
        //        SikuliAction.Type(googleSearchPattern, "liberty statue\n\r");
        //        System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        //        SikuliAction.Click(blueSearchPattern, 0.9f, 5);
        //        if (SikuliAction.Exists(libertyStatuePattern, 0.9f, 4) != Point.Empty)
        //        {
        //            Report.Pass("Yep! Type is working");
        //        }
        //        else 
        //        {
        //            Report.Error("Nope! Could not Type. Internet zoom must be at 100% or check your internet connection");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Report.Error("Nope! Could not Type. " + ex.Message);
        //    }
        //    finally
        //    {
        //        KillExplore();
        //    }
        //}

        //[TestMethod,
        //Description("Test Type mechanism using pattern- Positive")]
        //[AppNotStart]
        //public void TestATypeTextDefaultPositive()
        //{ 
        //    StartNotepad(0, 2);                  
                    
        //    try
        //    {
        //        SikuliAction.Type("Hello World\nThis is a type example");
        //        List<Point> pts = SikuliAction.FindAll(blankTextPattern, new Rectangle(10, 30, 100, 30));
        //        Report.Error("Nope! Could not type a simple text");
        //    }
        //    catch
        //    { 
        //        Report.Pass("Yep! Type is working");
        //    }
                   
        //    KillNotepad();         
        //}

        //[TestMethod,
        //Description("Test Paste mechanism using pattern- Positive")]
        //[AppNotStart]
        //public void TestAPasteDefaultPositive()
        //{
        //    try
        //    {
        //        //this test requires internet connection
        //        StartGoogle(0);
        //        System.Threading.Thread.Sleep(7000);
        //        SikuliAction.Click(googleTabPattern, 0.9f, 30);          
        //        SikuliAction.Paste(googleSearchPattern, "sun pyramid mexico");
        //        System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        //        SikuliAction.Click(blueSearchPattern, 0.9f, 5);
        //        Report.Info("Click search button");

        //        if (SikuliAction.Exists(sunPyramidPattern, 0.9f, 4) != Point.Empty)
        //        {
        //            Report.Pass("Yep! Paste is working");
        //        }
        //        else
        //        {
        //            Report.Error("Nope! Could not Paste. Internet zoom must be at 100% or check your internet connection");
        //        }
        //    }
        //    catch
        //    {
        //        Report.Error("Nope! Could not Paste. Internet zoom must be at 100% or check your internet connection");
        //    }
        //    finally
        //    {
        //        KillExplore();
        //    }
        //}
    }
}