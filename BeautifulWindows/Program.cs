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
            var handlers = new Dictionary<string, IThreadHandler>();
            handlers.Add("animation_1", new Animation1());
            handlers.Add("animation_2", new Animation2());
            var controller = new ThreadController(handlers);
            controller.Start();
        }
    }
}
