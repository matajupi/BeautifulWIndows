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
            Animator.ShowHorizontalLine(Animator.DISPLAY_CENTER_Y, 2000);
            Console.ReadKey();
            Console.WriteLine("0 rad");
            TestSineWaveLine1();
            Console.WriteLine("pi / 2 rad");
            TestSineWaveLine2();
            Console.WriteLine("pi rad");
            TestSineWaveLine3();
            Console.WriteLine("pi * 3 / 2 rad");
            TestSineWaveLine4();
            Console.WriteLine("pi * 2 rad");
            TestSineWaveLine5();
        }

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
    }
}
