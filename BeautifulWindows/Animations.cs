using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeautifulWindows
{
    class Animation1 : ThreadHandler
    {
        public override void Method()
        {
            BWAnimator.ShowHorizontalLine(500, 1000);
            this.EventLoop();
            BWAnimator.ShowSineWaveHorizontalLine(BWAnimator.DISPLAY_CENTER_Y - 100, 1, 2, Math.PI / 2, 2000, 50);
            this.Controller.Handlers["animation_2"].ResumeSame();
            BWAnimator.ShowVerticalLine(BWAnimator.DISPLAY_CENTER_X, 2000);
        }
    }

    class Animation2 : ThreadHandler
    {
        public override void Method()
        {
            BWAnimator.ShowHorizontalLine(100, 2000);
            this.Controller.Handlers["animation_1"].Resume();
            Thread.Sleep(1000);
            BWAnimator.ShowHorizontalLine(BWAnimator.DISPLAY_CENTER_Y - 100, 2000);
            this.EventLoop();
            BWAnimator.ShowFireworks(3000, 50);
        }
    }
}
