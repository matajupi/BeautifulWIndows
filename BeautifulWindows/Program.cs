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
        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            // tasks.Add(Task.Run(() => BWAnimator.ShowHorizontalLine(100, 2000, true)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowVerticalLine(100, 2000)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowHorizontalLine(200, 1000)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowVerticalLine(200, 2000, true)));
            // tasks.Add(Task.Run(() => BWAnimator.Fireworks(3500, 50, false)));
            // tasks.Add(Task.Run(() => BWAnimator.Fireworks(3500, 50, true)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowSineWaveHorizontalLine(BWAnimator.DISPLAY_CENTER_Y - 100, 1, 1, 0, 2000, 50)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowSineWaveHorizontalLine(BWAnimator.DISPLAY_CENTER_Y - 100, 1, 1, 0, 2000, 50, true)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowSineWaveHorizontalLine(BWAnimator.DISPLAY_CENTER_Y - 100, 1, 0.5, Math.PI / 2, 2000, 50)));
            // tasks.Add(Task.Run(() => BWAnimator.ShowSineWaveVerticalLine(BWAnimator.DISPLAY_CENTER_X - 100, 1, 1, 0, 2000, 50)));
            tasks.Add(Task.Run(() => BWAnimator.ShowSineWaveVerticalLine(BWAnimator.DISPLAY_CENTER_X - 100, 1, 2, Math.PI / 2, 2000, 50, true)));
            Task.WaitAll(tasks.ToArray());
            Console.ReadKey();
        }
    }
}
