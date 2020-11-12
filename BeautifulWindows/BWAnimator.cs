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
        static readonly int BASE_WINDOW_SIZE = 150;
        static readonly string BWFORM_PATH = @"C:\Users\kousu\source\repos\Project\BeautifulWindows\BWForm\BWForm\BWForm\bin\Release\BWForm.exe";
        // 後発開発（スクリーンの大きさによる拡大率の変更）
        static readonly int DISPLAY_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        static readonly int DISPLAY_HEIGHT = Screen.PrimaryScreen.Bounds.Height;
        static readonly int MAGN_X = DISPLAY_WIDTH;
        static readonly int MAGN_Y = DISPLAY_HEIGHT;
        static readonly string NOTEPAD_PATH = @"C:\WINDOWS\system32\notepad.exe";

        [DllImport("user32.dll")]
        static extern int MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeight, int bRepaint);

        public static async Task ShowWindow(int pX, int pY, int time)
        {
            var form = new Form();
            form.Size = new Size(BASE_WINDOW_SIZE, BASE_WINDOW_SIZE);
            form.Location = new Point(pX, pY);
            form.StartPosition = FormStartPosition.Manual;
            form.Show();
            await Task.Delay(time);
            form.Close();
        }

        public static async Task ShowBWForm(int pX, int pY, int time)
        {
            var pinfo = new ProcessStartInfo();
            pinfo.FileName = BWFORM_PATH;
            pinfo.Arguments = $"{pX.ToString()} {pY.ToString()}";
            pinfo.UseShellExecute = true;
            var p = Process.Start(pinfo);
            await Task.Delay(time);
            p.CloseMainWindow();
            p.Close();
        }

        public static void ShowHorizontalLine(int pY, int time)
        {
            var interval = time / 4;
            var tasks = new List<Task>();
            for (var i = 0; 15 > i; i++)
            {
                tasks.Add(ShowBWForm(i * 100, pY, time));
                Thread.Sleep(interval);
            }
            Task.WaitAll(tasks.ToArray());
        }

        public static void ShowVerticalLine(int pX, int time)
        {
            var interval = time / 4;
            var tasks = new List<Task>();
            for (var i = 0; 10 > i; i++)
            {
                tasks.Add(ShowWindow(pX, i * 100, time));
                Thread.Sleep(interval);
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
