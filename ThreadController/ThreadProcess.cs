using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadControl
{
    public class ThreadProcess
    {
        public string Name { get; set; }
        public ThreadController Controller;
        public bool IsWait { get; set; }

        public ThreadProcess()
        {
            this.IsWait = false;
        }

        public ThreadProcess(string name)
        {
            this.Name = name;
            this.IsWait = false;
        }
        
        public virtual void Body()
        {
            throw new Exception("This method must be implemented.");
        }

        protected void Resume(string resumeId, params string[] processNames)
        {
            var processes = this.Controller.GetProcesses(processNames);
            var resume = new Resume(resumeId, processes, false);
            this.Controller.RunOrder(resume);
        }

        protected void ResumeSame(string resumeId, params string[] processNames)
        {
            var processes = this.Controller.GetProcesses(processNames);
            var resume = new Resume(resumeId, processes, true);
            this.Controller.RunOrder(resume);
            if (processes.Contains(this))
            {
                this.IsWait = true;
                this.Controller.AddProcessToOrder(resumeId, this);
                this.EventLoop();
            }
        }

        protected void ResumeAll(string resumeId)
        {
            this.IsWait = true;
            var processes = this.Controller.GetProcesses();
            var resume = new Resume(resumeId, processes, true);
            this.Controller.RunOrder(resume);
            this.IsWait = true;
            this.Controller.AddProcessToOrder(resumeId, this);
            this.EventLoop();
        }

        protected void Wait(string resumeId)
        {
            this.IsWait = true;
            this.Controller.AddProcessToOrder(resumeId, this);
            this.EventLoop();
        }

        protected void EventLoop()
        {
            while (this.IsWait) { }
        }
    }
}
