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
            this.Pattern1();
            this.Pattern2();
            this.Pattern3();
            this.Pattern4();
            this.Pattern5();
            this.Pattern6();
            this.Pattern7();
            this.Pattern8();
            this.Pattern9();
            this.Pattern10();
            this.Pattern11();
            this.Pattern12();
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
            Animator.ShowSineWaveHorizontalLine(Animator.DISPLAY_HEIGHT - 180, 2, 0.25, Math.PI * 6, 2000, 20);
            this.ResumeAll("resume4");
        }

        private void Pattern5()
        {
            Animator.ShowSineWaveHorizontalLine(Animator.DISPLAY_CENTER_Y, 1, 2, Math.PI / 4, 2000, 20);
            this.ResumeAll("resume5");
        }

        private void Pattern6()
        {
            Animator.ShowHorizontalLine(line1, 2000, 20, true);
            this.ResumeAll("resume6");
        }

        private void Pattern7()
        {
            Animator.ShowHorizontalLine(line1, 2000, 20);
            this.ResumeAll("resume7");
        }

        private void Pattern8()
        {
            Animator.ShowSineWaveHorizontalLine(Animator.DISPLAY_CENTER_Y, 1, 2, Math.PI / 4, 2000, 20, true);
            this.ResumeAll("resume8");
        }

        private void Pattern9()
        {
            Animator.ShowSineWaveHorizontalLine(Animator.DISPLAY_CENTER_Y, 1, 2, Math.PI / 4, 9000, 20);
            this.ResumeAll("resume9");
        }

        private void Pattern10()
        {
            Animator.ShowSineWaveVerticalLine(Animator.DISPLAY_CENTER_X, 1, 1, 0, 2000, 20);
            this.ResumeAll("resume10");
        }

        private void Pattern11()
        {
            Animator.ShowFireworks(2000, 20);
            this.ResumeAll("resume11");
        }

        private void Pattern12()
        {
            Animator.ShowFireworks(2000, 20, true);
            this.ResumeAll("resume12");
        }
    }

    class Animation2 : ThreadProcess
    {
        int line2 = (Animator.DISPLAY_HEIGHT - 180) / 2;

        public Animation2(string name) : base(name) { }

        public override void Body()
        {
            this.Pattern1();
            this.Pattern2();
            this.Pattern3();
            this.Pattern4();
            this.Pattern5();
            this.Pattern6();
            this.Pattern7();
            this.Pattern8();
            this.Pattern9();
            this.Pattern10();
            this.Pattern11();
            this.Pattern12();
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

        private void Pattern5()
        {
            this.Wait("resume5");
        }

        private void Pattern6()
        {
            Animator.ShowHorizontalLine(line2, 2000, 20);
            this.Wait("resume6");
        }

        private void Pattern7()
        {
            Animator.ShowHorizontalLine(line2, 2000, 20, true);
            this.Wait("resume7");
        }

        private void Pattern8()
        {
            this.Wait("resume8");
        }

        private void Pattern9()
        {
            this.Wait("resume9");
        }

        private void Pattern10()
        {
            this.Wait("resume10");
        }

        private void Pattern11()
        {
            Thread.Sleep(1000);
            this.Wait("resume11");
        }

        private void Pattern12()
        {
            Thread.Sleep(1000);
            this.Wait("resume12");
        }
    }

    class Animation3 : ThreadProcess
    {
        int line3 = Animator.DISPLAY_HEIGHT - 180 - 100;

        public Animation3(string name) : base(name) { }

        public override void Body()
        {
            this.Pattern1();
            this.Pattern2();
            this.Pattern3();
            this.Pattern4();
            this.Pattern5();
            this.Pattern6();
            this.Pattern7();
            this.Pattern8();
            this.Pattern9();
            this.Pattern10();
            this.Pattern11();
            this.Pattern12();
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
            Animator.ShowSineWaveHorizontalLine(0, 2, 0.25, Math.PI * 2, 2000, 20);
            this.Wait("resume4");
        }

        private void Pattern5()
        {
            Animator.ShowSineWaveHorizontalLine(0, 2, 0.25, Math.PI * 2, 2000, 20);
            this.Wait("resume5");
        }

        private void Pattern6()
        {
            Animator.ShowHorizontalLine(line3, 2000, 20, true);
            this.Wait("resume6");
        }
        
        private void Pattern7()
        {
            Animator.ShowHorizontalLine(line3, 2000, 20);
            this.Wait("resume7");
        }

        private void Pattern8()
        {
            Animator.ShowSineWaveHorizontalLine(0, 2, 0.25, Math.PI * 2, 2000, 20, true);
            this.Wait("resume8");
        }

        private void Pattern9()
        {
            Animator.ShowSineWaveHorizontalLine(Animator.DISPLAY_CENTER_Y, 1, 2, Math.PI * 3 / 4, 9000, 20);
            this.Wait("resume9");
        }

        private void Pattern10()
        {
            Animator.ShowVerticalLine(Animator.DISPLAY_CENTER_X, 2000, 400);
            this.Wait("resume10");
        }

        private void Pattern11()
        {
            this.Wait("resume11");
        }

        private void Pattern12()
        {
            this.Wait("resume12");
        }
    }
}
