using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SikuliModule
{
    public class SikuliAction
    {
        //EXISTS
        public static Point Exists(string pattern, float similarity, int timeout)
        {
            List<Point> point = Commander.Execute(Command.EXISTS, pattern, null, similarity, timeout);
            if (point != null && point.Count > 0)
            {
                return point[0];
            }
            else
            {
                return Point.Empty;
            }
        }

        public static Point Exists(string pattern)
        {
            List<Point> point = Commander.Execute(Command.EXISTS, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
            if (point != null && point.Count > 0)
            {
                return point[0];
            }
            else
            {
                return Point.Empty;
            }
        }


        //CLICK
        public static void Click(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.CLICK, pattern, null, similarity, timeout);
        }

        public static void Click(string pattern)
        {
            Commander.Execute(Command.CLICK, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }


        //DOUBLE_CLICK
        public static void DoubleClick(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.DOUBLE_CLICK, pattern, null, similarity, timeout);
        }

        public static void DoubleClick(string pattern)
        {
            Commander.Execute(Command.DOUBLE_CLICK, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }


        //RIGHT_CLICK
        public static void RightClick(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.RIGHT_CLICK, pattern, null, similarity, timeout);
        }

        public static void RightClick(string pattern)
        {
            Commander.Execute(Command.RIGHT_CLICK, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }


        //HOVER
        public static void Hover(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.HOVER, pattern, null, similarity, timeout);
        }

        public static void Hover(string pattern)
        {
            Commander.Execute(Command.HOVER, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }


        //DRAG_DROP
        public static void DragAndDrop(string pattern, string toPattern, float similarity, int timeout)
        {
            Commander.Execute(Command.DRAG_DROP, pattern, toPattern, similarity, timeout);
        }

        public static void DragAndDrop(string pattern, string toPattern)
        {
            Commander.Execute(Command.DRAG_DROP, pattern, toPattern, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }


        //FIND_ALL
        public static List<Point> FindAll(string pattern, float similarity, int timeout)
        {
            return Commander.Execute(Command.FIND_ALL, pattern, null, similarity, timeout);
        }

        public static List<Point> FindAll(string pattern)
        {
            return Commander.Execute(Command.FIND_ALL, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }

        //WAIT_VANISH
        public static void WaitVanish(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.WAIT_VANISH, pattern, null, similarity, timeout);
        }

        public static void WaitVanish(string pattern, int timeout)
        {
            Commander.Execute(Command.WAIT_VANISH, pattern, null, Settings.DefaultSimilarity, timeout);
        }

	    //WAIT
        public static void Wait(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.WAIT, pattern, null, similarity, timeout);
        }

        public static void Wait(string pattern)
        {
            Commander.Execute(Command.WAIT, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }
    }
}