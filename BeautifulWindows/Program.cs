using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BeautifulWindows
{
    class Program
    {
        static readonly int DISPLAY_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        static readonly int DISPLAY_HEIGHT = Screen.PrimaryScreen.Bounds.Height;

        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            tasks.Add(Task.Run(() => BWAnimator.ShowHorizontalLine(100, 2000)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowVerticalLine(100, 2000)));
            tasks.Add(Task.Run(() => BWAnimator.ShowHorizontalLine(200, 1000)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowVerticalLine(200, 2000)));
            Task.WaitAll(tasks.ToArray());
            Console.ReadKey();
        }
    }
}
