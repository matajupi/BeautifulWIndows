using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreadControl;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ThreadControllerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ThreadController Controller = new ThreadController();
        TestProcess Pro1 = new TestProcess("Pro1");
        TestProcess Pro2 = new TestProcess("Pro2");

        [TestInitialize]
        public void Init()
        {
            Controller.Processes.Add(Pro1);
            Controller.Processes.Add(Pro2);
            Controller.StartAll();
        }

        [TestMethod]
        public void TestAfterResume()
        {
            var tasks = new Task[2];
            Console.WriteLine($"[{DateTime.Now}] Start Controller.");
            tasks[0] = Task.Run(() =>
            {
                Task.Delay(5000);
                Pro1.TestResume();
            });
            tasks[1] = Task.Run(() =>
            {
                Pro2.TestWait("resume");
            });
            Task.WaitAll(tasks);
            Console.WriteLine($"[{DateTime.Now}] Stop Controller.");
            Console.WriteLine();
        }

        [TestMethod]
        public void TestBeforeResume()
        {
            var tasks = new Task[2];
            Console.WriteLine($"[{DateTime.Now}] Start Controller.");
            tasks[0] = Task.Run(() =>
            {
                Pro1.TestResume();
            });
            tasks[1] = Task.Run(() =>
            {
                Task.Delay(5000);
                Pro2.TestWait("resume");
            });
            Task.WaitAll(tasks);
            Console.WriteLine($"[{DateTime.Now}] Stop Controller.");
            Console.WriteLine();
        }

        [TestMethod]
        public void TestAfterResumeSame()
        {
            var tasks = new Task[2];
            Console.WriteLine($"[{DateTime.Now}] Start Controller.");
            tasks[0] = Task.Run(() =>
            {
                Task.Delay(5000);
                Pro1.TestResumeSame();
            });
            tasks[1] = Task.Run(() =>
            {
                Pro2.TestWait("resume_same");
            });
            Task.WaitAll(tasks);
            Console.WriteLine($"[{DateTime.Now}] Stop Controller.");
            Console.WriteLine();
        }

        [TestMethod]
        public void TestBeforeResumeSame()
        {
            var tasks = new Task[2];
            Console.WriteLine($"[{DateTime.Now}] Start Controller.");
            tasks[0] = Task.Run(() =>
            {
                Pro1.TestResumeSame();
            });
            tasks[1] = Task.Run(() =>
            {
                Task.Delay(5000);
                Pro2.TestWait("resume_same");
            });
            Task.WaitAll(tasks);
            Console.WriteLine($"[{DateTime.Now}] Stop Controller.");
            Console.WriteLine();
        }

        [TestMethod]
        public void TestAfterResumeAll()
        {
            var tasks = new Task[2];
            Console.WriteLine($"[{DateTime.Now}] Start Controller.");
            tasks[0] = Task.Run(() =>
            {
                Task.Delay(5000);
                Pro1.TestResumeAll();
            });
            tasks[1] = Task.Run(() =>
            {
                Pro2.TestWait("resume_all");
            });
            Task.WaitAll(tasks);
            Console.WriteLine($"[{DateTime.Now}] Stop Controller.");
            Console.WriteLine();
        }

        [TestMethod]
        public void TestBeforeResumeAll()
        {
            var tasks = new Task[2];
            Console.WriteLine($"[{DateTime.Now}] Start Controller.");
            tasks[0] = Task.Run(() =>
            {
                Pro1.TestResumeAll();
            });
            tasks[1] = Task.Run(() =>
            {
                Task.Delay(5000);
                Pro2.TestWait("resume_all");
            });
            Task.WaitAll(tasks);
            Console.WriteLine($"[{DateTime.Now}] Stop Controller.");
            Console.WriteLine();
        }
    }

    public class TestProcess : ThreadProcess
    {
        public TestProcess(string name) : base(name) { }

        public void TestResume()
        {
            Console.WriteLine($"[{DateTime.Now}] Pro1 resume Start.");
            this.Resume("resume", "Pro1", "Pro2");
            Console.WriteLine($"[{DateTime.Now}] Pro1 resume finished.");
        }

        public void TestResumeSame()
        {
            Console.WriteLine($"[{DateTime.Now}] Pro1 resume Start.");
            this.ResumeSame("resume_same", "Pro1", "Pro2");
            Console.WriteLine($"[{DateTime.Now}] Pro1 resume finished.");
        }

        public void TestResumeAll()
        {
            Console.WriteLine($"[{DateTime.Now}] Pro1 resume Start.");
            this.ResumeAll("resume_all");
            Console.WriteLine($"[{DateTime.Now}] Pro1 resume finished.");
        }

        public void TestWait(string id)
        {
            Console.WriteLine($"[{DateTime.Now}] Pro2 wait Start.");
            this.Wait(id);
            Console.WriteLine($"[{DateTime.Now}] Pro2 wait finished.");
        }

        public override void Body()
        {
            
        }
    }
}
