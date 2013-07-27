using System;
using System.Linq;

namespace UnitTest.Core
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AppNotStartAttribute : Attribute
    {

    }
}