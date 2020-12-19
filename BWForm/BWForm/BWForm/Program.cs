using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BWForm
{
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()
            {
                Location = new Point(int.Parse(args[0]), int.Parse(args[1])),
                Size = new Size(int.Parse(args[2]), int.Parse(args[3])),
                StartPosition = FormStartPosition.Manual,
            });
        }
    }
}
