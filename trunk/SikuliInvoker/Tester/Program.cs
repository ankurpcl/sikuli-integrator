using System;
using System.Drawing;
using System.Linq;
using SikuliInvoker;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            PointerInvoker pointerInvoker = new PointerInvoker("test.png", "GET_POINT", 0.9F, 5000L);
            Point point = pointerInvoker.TryGetPoint();
        }
    }
}
