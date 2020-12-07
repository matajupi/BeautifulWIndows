using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ThreadControl;

namespace TestThreadControl
{
    class Program
    {
        static ThreadController controller;

        static void Main(string[] args)
        {
            Initialize();
            TestResume1();
            TestResume2();
            TestResumeSame1();
            TestResumeSame2();
            TestResumeAll1();
            TestResumeAll2();
            Console.ReadKey();
        }

        static void Initialize()
        {
            controller = new ThreadController();
        }

        static void TestResume1()
        {
            var pro1 = new TestProcess("pro1");
            pro1.SetAction(() =>
            {
                PutTime("process1", "Send Resume");
                pro1.TestResume("resume", "pro1", "pro2");
                PutTime("process1", "Resume");
            });
            controller.Processes.Add(pro1);
            var pro2 = new TestProcess("pro2");
            pro2.SetAction(() => 
            {
                Thread.Sleep(5000);
                PutTime("process2", "Wait");
                pro2.TestWait("resume");
                PutTime("process2", "Resume");
            });
            controller.Processes.Add(pro2);
            controller.StartAll();
            controller.Processes.Clear();
        }

        static void TestResume2()
        {
            var pro1 = new TestProcess("pro1");
            pro1.SetAction(() =>
            {
                Thread.Sleep(5000);
                PutTime("process1", "Send Resume");
                pro1.TestResume("resume", "pro1", "pro2");
                PutTime("process1", "Resume");
            });
            controller.Processes.Add(pro1);
            var pro2 = new TestProcess("pro2");
            pro2.SetAction(() =>
            {
                PutTime("process2", "Wait");
                pro2.TestWait("resume");
                PutTime("process2", "Resume");
            });
            controller.Processes.Add(pro2);
            controller.StartAll();
            controller.Processes.Clear();
        }

        static void TestResumeSame1()
        {
            var pro1 = new TestProcess("pro1");
            pro1.SetAction(() =>
            {
                PutTime("process1", "Send ResumeSame");
                pro1.TestResumeSame("resume", "pro1", "pro2");
                PutTime("process1", "Resume");
            });
            controller.Processes.Add(pro1);
            var pro2 = new TestProcess("pro2");
            pro2.SetAction(() =>
            {
                Thread.Sleep(5000);
                PutTime("process2", "Wait");
                pro2.TestWait("resume");
                PutTime("process2", "Resume");
            });
            controller.Processes.Add(pro2);
            controller.StartAll();
            controller.Processes.Clear();
        }

        static void TestResumeSame2()
        {
            var pro1 = new TestProcess("pro1");
            pro1.SetAction(() =>
            {
                Thread.Sleep(5000);
                PutTime("process1", "Send ResumeSame");
                pro1.TestResumeSame("resume", "pro1", "pro2");
                PutTime("process1", "Resume");
            });
            controller.Processes.Add(pro1);
            var pro2 = new TestProcess("pro2");
            pro2.SetAction(() =>
            {
                PutTime("process2", "Wait");
                pro2.TestWait("resume");
                PutTime("process2", "Resume");
            });
            controller.Processes.Add(pro2);
            controller.StartAll();
            controller.Processes.Clear();
        }

        static void TestResumeAll1()
        {
            var pro1 = new TestProcess("pro1");
            pro1.SetAction(() =>
            {
                PutTime("process1", "Send ResumeAll");
                pro1.TestResumeAll("resume");
                PutTime("process1", "Resume");
            });
            controller.Processes.Add(pro1);
            var pro2 = new TestProcess("pro2");
            pro2.SetAction(() =>
            {
                Thread.Sleep(5000);
                PutTime("process2", "Wait");
                pro2.TestWait("resume");
                PutTime("process2", "Resume");
            });
            controller.Processes.Add(pro2);
            controller.StartAll();
            controller.Processes.Clear();
        }

        static void TestResumeAll2()
        {
            var pro1 = new TestProcess("pro1");
            pro1.SetAction(() =>
            {
                Thread.Sleep(5000);
                PutTime("process1", "Send ResumeAll");
                pro1.TestResumeAll("resume");
                PutTime("process1", "Resume");
            });
            controller.Processes.Add(pro1);
            var pro2 = new TestProcess("pro2");
            pro2.SetAction(() =>
            {
                PutTime("process2", "Wait");
                pro2.TestWait("resume");
                PutTime("process2", "Resume");
            });
            controller.Processes.Add(pro2);
            controller.StartAll();
            controller.Processes.Clear();
        }

        static void PutTime(string process, string message)
        {
            Console.WriteLine($"[{DateTime.Now}] ({process}) {message}");
        }
    }

    class TestProcess : ThreadProcess
    {
        Action BodyAction;

        public TestProcess(string name) : base(name)
        {
        }

        public void SetAction(Action action) => BodyAction = action;

        public override void Body()
        {
            BodyAction();
        }

        public void TestResume(string id, params string[] processes)
        {
            this.Resume(id, processes);
        }

        public void TestResumeSame(string id, params string[] processes)
        {
            this.ResumeSame(id, processes);
        }

        public void TestResumeAll(string id)
        {
            this.ResumeAll(id);
        }

        public void TestWait(string id)
        {
            this.Wait(id);
        }
    }
}
