using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadControl
{
    public class Resume : ThreadOrder
    {
        public bool IsSame { get; private set; }

        public Resume(string id, ThreadProcess[] spn, bool isSame) : base(id, spn)
        {
            this.IsSame = isSame;
        }

        public override void AddProcess(ThreadProcess process)
        {
            base.AddProcess(process, this.IsSame);
            if (!this.IsSame) 
                this.Controller.RunToProcess(this.OrderAction, process);
        }

        public override void OrderAction(ThreadProcess process)
        {
            process.IsWait = false;
        }
    }
}
