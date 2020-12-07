using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadControl
{
    public class ThreadOrder
    {
        public string Id { get; private set; }
        public ThreadController Controller { get; internal set; }

        private int ProcessCount = 0;
        internal ThreadProcess[] SpecifiedProcesses;

        public ThreadOrder(string id, ThreadProcess[] spn)
        {
            this.Id = id;
            this.SpecifiedProcesses = spn;
        }

        public virtual void AddProcess(ThreadProcess process)
        {
            this.AddProcess(process, true);
        }
        
        protected void AddProcess(ThreadProcess process, bool isRunToProcess)
        {
            if (!this.SpecifiedProcesses.Contains(process)) throw new Exception("This process is not specified.");
            this.ProcessCount++;
            if (this.ProcessCount == this.SpecifiedProcesses.Length && isRunToProcess)
                this.Controller.RunToProcess(this.OrderAction, this.SpecifiedProcesses);
        }

        public virtual void OrderAction(ThreadProcess process)
        {
            throw new Exception("This method must be implemented.");
        }
    }
}
