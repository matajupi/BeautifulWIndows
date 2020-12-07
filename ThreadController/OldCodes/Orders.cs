using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadControl.OldCodes
{
    internal class ResumeOrder
    {
        internal string ResumeKey { get; set; }
        internal HashSet<ThreadHandler0> Handlers { get; set; }
        internal HashSet<ThreadHandler0> ResumeHandlers = null;

        internal ResumeOrder(string resume_key)
        {
            this.ResumeKey = resume_key;
            this.Handlers = new HashSet<ThreadHandler0>();
        }

        internal void SetResumeHandlers(List<ThreadHandler0> resume_handlers)
        {
            this.ResumeHandlers = resume_handlers.ToHashSet();
            foreach (var h in this.Handlers)
            {
                if (!this.ResumeHandlers.Contains(h))
                    throw new Exception("This handler is not included in resume.");
            }
        }

        internal void AddHandler(ThreadHandler0 handler)
        {
            if (this.ResumeHandlers != null && !this.ResumeHandlers.Contains(handler))
                throw new Exception("This handler is not included in resume.");
            this.Handlers.Add(handler);
            if (this.ResumeHandlers != null && this.Handlers.Count == this.ResumeHandlers.Count)
                this.Resume();
        }

        private void Resume()
        {

        }
    }

    internal interface Order
    {

    }

    internal class Resume : Order
    {

    }

    internal class ResumeSame : Order
    {

    }
}
