using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ThreadControl;

namespace BeautifulWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ThreadController();
            controller.Processes.Add(new Animation1("animation_1"));
            controller.Processes.Add(new Animation2("animation_2"));
            controller.Processes.Add(new Animation3("animation_3"));
            controller.StartAll();
        }
    }
}
