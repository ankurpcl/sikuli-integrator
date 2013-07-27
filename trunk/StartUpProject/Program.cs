using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SikuliModule;

namespace StartUpProject
{
    public class Program : Utils
    {
        static void Main(string[] args)
        {
            Program demo = new Program();

            demo.StartMSPaint();

            demo.DemoExists();

            demo.DemoFindAll();

            SikuliAction.Click(demo.pattern);

            SikuliAction.DoubleClick(demo.extraPattern);

            SikuliAction.RightClick(demo.pattern);

            SikuliAction.Hover(demo.extraPattern);

            SikuliAction.DragAndDrop(demo.extraPattern, demo.pattern);

            demo.KillMSPaint();

            demo.StartMSPaint(2);

            SikuliAction.Wait(demo.extraPattern, 3);

            demo.KillMSPaint(2);

            SikuliAction.WaitVanish(demo.extraPattern, 3);

            Console.ReadLine();
        }

        public void DemoExists()
        {
            if (!SikuliAction.Exists(pattern).IsEmpty)
            {
                Console.WriteLine("Yep! It's there...");
            }
            else
            {
                Console.WriteLine("Nope! It's gone...");
            }
        }

        public void DemoFindAll()
        {
            //There are 3 patterns on the test image
            List<Point> points = SikuliAction.FindAll(findAllPattern);
            if (points != null)
            {
                foreach (Point point in points)
                {
                    Console.WriteLine("X:" + point.X + "  Y: " + point.Y);
                }
                if (points.Count == 3)
                {
                    Console.WriteLine("Yep! They are 3...");
                }
                else
                {
                    Console.WriteLine("Nope! They are NOT 3, they are " + points.Count);
                }
            }
            else
            {
                Console.WriteLine("Nope! There is a problem...");
            }
        }
    }
}
