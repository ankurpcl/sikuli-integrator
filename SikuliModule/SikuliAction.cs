using System;
using System.Drawing;
using System.Linq;

namespace SikuliModule
{
    public class SikuliAction
    {

        public static Point Exists(string pattern, float similarity, int timeout)
        {
            return Commander.Execute(Command.EXISTS, pattern, null, similarity, timeout);
        }

        public static Point Exists(string pattern)
        {
            return Commander.Execute(Command.EXISTS, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }

        public static void Click(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.CLICK, pattern, null, similarity, timeout);
        }

        public static void Click(string pattern)
        {
            Commander.Execute(Command.CLICK, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }

        public static void DoubleClick(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.DOUBLE_CLICK, pattern, null, similarity, timeout);
        }

        public static void DoubleClick(string pattern)
        {
            Commander.Execute(Command.DOUBLE_CLICK, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }

        public static void RightClick(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.RIGHT_CLICK, pattern, null, similarity, timeout);
        }

        public static void RightClick(string pattern)
        {
            Commander.Execute(Command.RIGHT_CLICK, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }

        public static void Hover(string pattern, float similarity, int timeout)
        {
            Commander.Execute(Command.HOVER, pattern, null, similarity, timeout);
        }

        public static void Hover(string pattern)
        {
            Commander.Execute(Command.HOVER, pattern, null, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }

        public static void DragAndDrop(string pattern, string toPattern, float similarity, int timeout)
        {
            Commander.Execute(Command.DRAG_DROP, pattern, toPattern, similarity, timeout);
        }

        public static void DragAndDrop(string pattern, string toPattern)
        {
            Commander.Execute(Command.DRAG_DROP, pattern, toPattern, Settings.DefaultSimilarity, Settings.DefaultTimeout);
        }
    }
}