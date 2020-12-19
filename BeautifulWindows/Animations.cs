using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadControl;
using BWAnimator;

namespace BeautifulWindows
{
    class Animation1 : ThreadProcess
    {
        int line1 = 100;

        public Animation1(string name) : base(name) { }

        public override void Body()
        {
            // this.Pattern1();
            // this.Pattern2();
            // this.Pattern3();
            this.Pattern4();
        }

        private void Pattern1()
        {
            Animator.ShowHorizontalLine(line1, 2000);
            this.ResumeAll("resume1");
        }

        private void Pattern2()
        {
            Animator.ShowSineWaveHorizontalLine(line1, 0.3, 2, Math.PI / 4, 2000, 50);
            this.ResumeAll("resume2");
        }

        private void Pattern3()
        {
            Animator.ShowHorizontalLine(line1, 2000);
            this.ResumeAll("resume3");
        }

        private void Pattern4()
        {
            Animator.ShowSineWaveHorizontalLine(0, 2, 0.3, Math.PI * 3 / 2, 2000, 20);
            this.ResumeAll("resume4");
        }
    }

    class Animation2 : ThreadProcess
    {
        int line2 = (Animator.DISPLAY_HEIGHT - 180) / 2;

        public Animation2(string name) : base(name) { }

        public override void Body()
        {
            // this.Pattern1();
            // this.Pattern2();
            // this.Pattern3();
            this.Pattern4();
        }

        private void Pattern1()
        {
            Thread.Sleep(4000);
            Animator.ShowHorizontalLine(line2, 2000);
            this.Wait("resume1");
        }

        private void Pattern2()
        {
            Thread.Sleep(4000);
            Animator.ShowSineWaveHorizontalLine(line2, 0.3, 2, 0, 2000, 50);
            this.Wait("resume2");
        }

        private void Pattern3()
        {
            Thread.Sleep(4000);
            Animator.ShowHorizontalLine(line2, 2000);
            this.Wait("resume3");
        }

        private void Pattern4()
        {
            Animator.ShowHorizontalLine(line2, 2000, 250);
            this.Wait("resume4");
        }
    }

    class Animation3 : ThreadProcess
    {
        int line3 = Animator.DISPLAY_HEIGHT - 180 - 100;

        public Animation3(string name) : base(name) { }

        public override void Body()
        {
            // this.Pattern1();
            // this.Pattern2();
            // this.Pattern3();
            this.Pattern4();
        }

        private void Pattern1()
        {
            Thread.Sleep(8000);
            Animator.ShowHorizontalLine(line3, 2000);
            this.Wait("resume1");
        }

        private void Pattern2()
        {
            Thread.Sleep(8000);
            Animator.ShowSineWaveHorizontalLine(line3, 0.3, 2, Math.PI / 2, 2000, 50);
            this.Wait("resume2");
        }

        private void Pattern3()
        {
            Thread.Sleep(8000);
            Animator.ShowSineWaveHorizontalLine(0, 2, 0.3, Math.PI * 3 / 2, 2000, 20);
            this.Wait("resume3");
        }

        private void Pattern4()
        {
            Animator.ShowSineWaveHorizontalLine(0, 2, 0.3, Math.PI * 3 / 2, 2000, 20);
            this.Wait("resume4");
        }
    }
}
