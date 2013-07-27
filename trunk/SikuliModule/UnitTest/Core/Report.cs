using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Core
{
    public class Report
    {
        public static void Error(string text)
        {
            text = "FAULT:\t" + text;
            Write(text + " :(");
            Assert.Fail();
        }

        public static void Pass(string text)
        {
            text = "PASS:\t" + text;
            Write(text + " :)");
        }

        public static void Info(string text)
        {
            text = "I:\t" + text;
            Write(text + " :|");
        }

        private static void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}