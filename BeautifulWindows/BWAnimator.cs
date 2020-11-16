using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BeautifulWindows
{
    class BWAnimator
    {
        static readonly string BWFORM_PATH = @"C:\Users\kousu\source\repos\Project\BeautifulWindows\BWForm\BWForm\BWForm\bin\Release\BWForm.exe";
        static readonly int DISPLAY_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        static readonly int DISPLAY_HEIGHT = Screen.PrimaryScreen.Bounds.Height;
        static readonly int DISPLAY_CENTER_X = DISPLAY_WIDTH / 2;
        static readonly int DISPLAY_CENTER_Y = DISPLAY_HEIGHT / 2;
        static readonly int WINDOW_WIDTH = 150;
        static readonly int WINDOW_HEIGHT = 150;
        static readonly int WINDOW_INTERVAL_X = WINDOW_WIDTH - WINDOW_WIDTH / 3;
        static readonly int WINDOW_INTERVAL_Y = WINDOW_HEIGHT - WINDOW_HEIGHT / 3;
        static readonly int NORMAL_INTERVAL_PERCENT = 4;

        public static async Task ShowBWForm(int pX, int pY, int time)
        {
            var pinfo = new ProcessStartInfo();
            pinfo.FileName = BWFORM_PATH;
            pinfo.Arguments = $"{pX} {pY} {WINDOW_WIDTH} {WINDOW_HEIGHT}";
            pinfo.UseShellExecute = true;
            var p = Process.Start(pinfo);
            await Task.Delay(time);
            p.CloseMainWindow();
            p.Close();
        }

        public static void ShowHorizontalLine(int pY, int time)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            ShowHorizontalLine(pY, time, interval);
            
        }

        public static void ShowHorizontalLine(int pY, int time, int interval)
        {
            var tasks = new List<Task>();
            var loop = DISPLAY_WIDTH / WINDOW_INTERVAL_X;
            var eX = DISPLAY_WIDTH / loop;
            for (var i = 0; loop > i; i++)
            {
                tasks.Add(ShowBWForm(i * eX, pY, time));
                Thread.Sleep(interval);
            }
            Task.WaitAll(tasks.ToArray());
        }

        public static void ShowVerticalLine(int pX, int time)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            ShowVerticalLine(pX, time, interval);
        }

        public static void ShowVerticalLine(int pX, int time, int interval)
        {
            var tasks = new List<Task>();
            var loop = DISPLAY_HEIGHT / WINDOW_INTERVAL_Y;
            var eY = DISPLAY_HEIGHT / loop;
            for (var i = 0; loop > i; i++)
            {
                tasks.Add(ShowBWForm(pX, i * eY, time));
                Thread.Sleep(interval);
            }
            Task.WaitAll(tasks.ToArray());
        }

        public static void Fireworks(int time, bool centerToEnd)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            Fireworks(time, interval, centerToEnd);
        }

        public static void Fireworks(int time, int interval, bool centerToEnd)
        {
            var tasks = new List<Task>();
            tasks.Add(Task.Run(() => OneLine(time, interval, false, false, centerToEnd)));
            tasks.Add(Task.Run(() => OneLine(time, interval, true, true, centerToEnd)));
            tasks.Add(Task.Run(() => OneLine(time, interval, true, false, centerToEnd)));
            tasks.Add(Task.Run(() => OneLine(time, interval, false, true, centerToEnd)));
            Task.WaitAll(tasks.ToArray());
        }

        private static void OneLine(int time, int interval, bool reverseX, bool reverseY, bool reverseLine)
        {
            var tasks = new List<Task>();
            var loop = (DISPLAY_CENTER_X / WINDOW_INTERVAL_X) * 2;
            var eX = DISPLAY_CENTER_X / loop;
            var eY = DISPLAY_CENTER_Y / loop;

            if (reverseX) eX *= -1;
            if (reverseY) eY *= -1;

            if (reverseLine)
            {
                for (var i = loop; 0 < i; i--)
                {
                    tasks.Add(ShowBWForm(eX * i + DISPLAY_CENTER_X, eY * i + DISPLAY_CENTER_Y, time));
                    Thread.Sleep(interval);
                }
                Task.WaitAll(tasks.ToArray());
                return;
            }

            for (var i = 0; loop > i; i++)
            {
                tasks.Add(ShowBWForm(eX * i + DISPLAY_CENTER_X, eY * i + DISPLAY_CENTER_Y, time));
                Thread.Sleep(interval);
            }
            Task.WaitAll(tasks.ToArray());
        }

        public static void ShowSineWaveHorizontalLine(int center, int r, int magn, int srad, int time)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            var tasks = new List<Task>();
            var rad = 0 - srad;
            for (var i = 0; 15 > i; i++)
            {
                tasks.Add(null);
            }
        }
    }
}
