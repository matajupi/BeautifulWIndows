using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWAnimator;

namespace TestBWAnimator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Animator.ShowHorizontalLine(Animator.DISPLAY_CENTER_Y, 2000);
            // Console.ReadKey();
            // Console.WriteLine("0 rad");
            // TestSineWaveLine1();
            // Console.WriteLine("pi / 2 rad");
            // TestSineWaveLine2();
            // Console.WriteLine("pi rad");
            // TestSineWaveLine3();
            // Console.WriteLine("pi * 3 / 2 rad");
            // TestSineWaveLine4();
            // Console.WriteLine("pi * 2 rad");
            // TestSineWaveLine5();
            // Console.WriteLine("center: 0, magn: 2");
            // TestSineWaveLine6();
            //Console.WriteLine("center: max, magn: 2");
            //TestSineWaveLine7();
            //Console.WriteLine("period: 0.5");
            //TestSineWaveLine8();
            //Console.WriteLine("period: 2");
            //TestSineWaveLine9();
            //Console.WriteLine("TA");
            //TestSineWaveLine10();
            TestFireworks1();
            TestFireworks2();
        }

        static void TestFireworks1() => Animator.ShowFireworks(2000, 50);

        static void TestFireworks2() => Animator.ShowFireworks(2000, 50, true);

        static void TestSineWaveLine1()
        {
            var center = Animator.DISPLAY_CENTER_Y;
            var magn = 1;
            var period = 1;
            var rad = 0;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine2()
        {
            var center = Animator.DISPLAY_CENTER_Y;
            var magn = 1;
            var period = 1;
            var rad = Math.PI / 2;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine3()
        {
            var center = Animator.DISPLAY_CENTER_Y;
            var magn = 1;
            var period = 1;
            var rad = Math.PI;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine4()
        {
            var center = Animator.DISPLAY_CENTER_Y;
            var magn = 1;
            var period = 1;
            var rad = Math.PI * 3 / 2;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine5()
        {
            var center = Animator.DISPLAY_CENTER_Y;
            var magn = 1;
            var period = 1;
            var rad = Math.PI * 2;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine6()
        {
            var center = 0;
            var magn = 2;
            var period = 1;
            var rad = 0;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine7()
        {
            var center = Animator.DISPLAY_HEIGHT - 180;
            var magn = 2;
            var period = 1;
            var rad = 0;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine8()
        {
            var center = Animator.DISPLAY_CENTER_Y;
            var magn = 1;
            var period = 0.5;
            var rad = 0;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine9()
        {
            var center = Animator.DISPLAY_CENTER_Y;
            var magn = 1;
            var period = 2;
            var rad = 0;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }

        static void TestSineWaveLine10()
        {
            var center = 0;
            var magn = 2;
            var period = 0.25;
            var rad = Math.PI * 2;
            var time = 2000;
            var interval = 50;
            var reverse = false;
            Animator.ShowSineWaveHorizontalLine(center, magn, period, rad, time, interval, reverse);
        }
    }
}
