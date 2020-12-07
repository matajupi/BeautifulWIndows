using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeautifulWindows
{
    /* class Animation1 : ThreadHandler
    {
        int line1 = 100;

        public override void Method()
        {
            this.Pattern1();
            this.Pattern2();
        }

        private void Pattern1()
        {
            BWAnimator.ShowHorizontalLine(line1, 2000);
            this.Controller.Handlers["animation_3"].ResumeSame();
            this.Controller.Handlers["animation_2"].ResumeSame();
        }
        private void Pattern2()
        {
            BWAnimator.ShowSineWaveHorizontalLine(line1, 0.3, 2, Math.PI / 4, 2000, 50);
            this.Controller.Handlers["animation_2"].ResumeSame();
            this.Controller.Handlers["animation_3"].ResumeSame();
        }

        private void Pattern3()
        {
            
        }
    }

    class Animation2 : ThreadHandler
    {
        int line2 = 100 + (BWAnimator.DISPLAY_HEIGHT - 350) / 2;

        public override void Method()
        {
            this.Pattern1();
            this.Pattern2();   
        }

        private void Pattern1()
        {
            Thread.Sleep(4000);
            BWAnimator.ShowHorizontalLine(line2, 2000);
            this.EventLoop();
        }

        private void Pattern2()
        {
            Thread.Sleep(4000);
            BWAnimator.ShowSineWaveHorizontalLine(line2, 0.3, 2, Math.PI / 2, 2000, 50);
            this.EventLoop();
        }
    }

    class Animation3 : ThreadHandler
    {
        int line3 = 100 + ((BWAnimator.DISPLAY_HEIGHT - 350) / 2) * 2;

        public override void Method()
        {
            this.Pattern1();
            this.Pattern2();
        }

        private void Pattern1()
        {
            Thread.Sleep(8000);
            BWAnimator.ShowHorizontalLine(line3, 2000);
            this.EventLoop();
        }

        private void Pattern2()
        {
            Thread.Sleep(8000);
            BWAnimator.ShowSineWaveHorizontalLine(line3, 0.3, 2, Math.PI / 2, 2000, 50);
            this.EventLoop();
        }
    }*/ 
}
