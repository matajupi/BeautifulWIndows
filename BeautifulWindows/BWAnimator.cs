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
        public static readonly int DISPLAY_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        public static readonly int DISPLAY_HEIGHT = Screen.PrimaryScreen.Bounds.Height;
        public static readonly int DISPLAY_CENTER_X = DISPLAY_WIDTH / 2;
        public static readonly int DISPLAY_CENTER_Y = DISPLAY_HEIGHT / 2;
        static readonly int WINDOW_WIDTH = 150;
        static readonly int WINDOW_HEIGHT = 150;
        static readonly int WINDOW_INTERVAL_X = WINDOW_WIDTH - WINDOW_WIDTH / 3;
        static readonly int WINDOW_INTERVAL_Y = WINDOW_HEIGHT - WINDOW_HEIGHT / 3;
        static readonly int NORMAL_INTERVAL_PERCENT = 4;
        static readonly int Y_MAGN = 2;
        static readonly int X_MAGN = 5;

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

        private static void ShowLoop(int start, int end, int interval, Func<int, Task> show)
        {
            var tasks = new List<Task>();
            if (start > end)
            {
                for (var i = start; end < i; i--)
                {
                    tasks.Add(show(i));
                    Thread.Sleep(interval);
                }
                Task.WaitAll(tasks.ToArray());
                return;
            }

            for (var i = start; end > i; i++)
            {
                tasks.Add(show(i));
                Thread.Sleep(interval);
            }
            Task.WaitAll(tasks.ToArray());
        }

        public static void ShowHorizontalLine(int pY, int time, bool reverse=false)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            ShowHorizontalLine(pY, time, interval, reverse);   
        }

        public static void ShowHorizontalLine(int pY, int time, int interval, bool reverse=false)
        {
            var loop = DISPLAY_WIDTH / WINDOW_INTERVAL_X;
            var eX = DISPLAY_WIDTH / loop;
            if (reverse)
            {
                ShowLoop(loop, 0, interval, x => ShowBWForm((x - 1) * eX, pY, time));
                return;
            }
            ShowLoop(0, loop, interval, x => ShowBWForm(x * eX, pY, time));
        }

        public static void ShowVerticalLine(int pX, int time, bool reverse=false)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            ShowVerticalLine(pX, time, interval, reverse);
        }

        public static void ShowVerticalLine(int pX, int time, int interval, bool reverse=false)
        {
            var loop = DISPLAY_HEIGHT / WINDOW_INTERVAL_Y;
            var eY = DISPLAY_HEIGHT / loop;
            if (reverse)
            {
                ShowLoop(loop, 0, interval, x => ShowBWForm(pX, (x - 1) * eY, time));
                return;
            }
            ShowLoop(0, loop, interval, x => ShowBWForm(pX, x * eY, time));
        }

        public static void ShowFireworks(int time, bool endToCenter=false)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            ShowFireworks(time, interval, endToCenter);
        }

        public static void ShowFireworks(int time, int interval, bool endToCenter=false)
        {
            var tasks = new List<Task>();
            tasks.Add(Task.Run(() => ShowOneLine(time, interval, false, false, endToCenter)));
            tasks.Add(Task.Run(() => ShowOneLine(time, interval, true, true, endToCenter)));
            tasks.Add(Task.Run(() => ShowOneLine(time, interval, true, false, endToCenter)));
            tasks.Add(Task.Run(() => ShowOneLine(time, interval, false, true, endToCenter)));
            Task.WaitAll(tasks.ToArray());
        }

        private static void ShowOneLine(int time, int interval, bool reverseX, bool reverseY, bool reverseLine)
        {
            var loop = (DISPLAY_CENTER_X / WINDOW_INTERVAL_X) * Y_MAGN;
            var eX = DISPLAY_CENTER_X / loop;
            var eY = DISPLAY_CENTER_Y / loop;

            if (reverseX) eX *= -1;
            if (reverseY) eY *= -1;

            if (reverseLine)
            {
                ShowLoop(loop, 0, interval, x => ShowBWForm(eX * (x - 1) + DISPLAY_CENTER_X, eY * (x - 1) + DISPLAY_CENTER_Y, time));
                return;
            }
            ShowLoop(0, loop, interval, x => ShowBWForm(eX * x + DISPLAY_CENTER_X, eY * x + DISPLAY_CENTER_Y, time));
        }

        public static void ShowSineWaveHorizontalLine(int center, double magn, double period, double rad, int time, bool reverse=false)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        public static void ShowSineWaveHorizontalLine(int center, double magn, double period, double rad, int time, int interval, bool reverse=false)
        {
            var loop = (DISPLAY_WIDTH / WINDOW_INTERVAL_X) * Y_MAGN * (period < 1 ? 1 : (int)period);
            var eX = DISPLAY_WIDTH / loop;
            var plusRad = 2 * Math.PI / loop;
            if (reverse)
            {
                ShowLoop(loop, 0, interval, x =>
                {
                    var task = ShowBWForm(eX * (x - 1), (int)(magn * Math.Sin(period * rad) * DISPLAY_CENTER_Y + center), time);
                    rad += plusRad;
                    return task;
                });
                return;
            }
            ShowLoop(0, loop, interval, x =>
            {
                var task = ShowBWForm(eX * x, (int)(magn * Math.Sin(period * rad) * DISPLAY_CENTER_Y + center), time);
                rad += plusRad;
                return task;
            });
        }

        public static void ShowSineWaveVerticalLine(int center, double magn, double period, double rad, int time, bool reverse=false)
        {
            var interval = time / NORMAL_INTERVAL_PERCENT;
            ShowSineWaveVerticalLine(center, magn, period, rad, time, interval, reverse);
        }

        public static void ShowSineWaveVerticalLine(int center, double magn, double period, double rad, int time, int interval, bool reverse=false)
        {
            var loop = (DISPLAY_HEIGHT / WINDOW_INTERVAL_Y) * X_MAGN * (period < 1 ? 1 : (int)period);
            var eY = DISPLAY_HEIGHT / loop;
            var plusRad = 2 * Math.PI / loop;
            if (reverse)
            {
                ShowLoop(loop, 0, interval, x =>
                {
                    var task = ShowBWForm((int)(magn * Math.Sin(period * rad) * DISPLAY_CENTER_X + center), eY * (x - 1), time);
                    rad += plusRad;
                    return task;
                });
                return;
            }
            ShowLoop(0, loop, interval, x =>
            {
                var task = ShowBWForm((int)(magn * Math.Sin(period * rad) * DISPLAY_CENTER_X + center), eY * x, time);
                rad += plusRad;
                return task;
            });
        }
    }
}
