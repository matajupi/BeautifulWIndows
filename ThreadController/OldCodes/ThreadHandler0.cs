using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadControl.OldCodes
{
    public class ThreadHandler0
    {
        public string Name { get; set; }
        internal ThreadController Controller;
        internal bool IsResume = false;
        private List<string> Orders = new List<string>();

        private void EventLoop()
        {
            while (!this.IsResume) { }
            this.IsResume = false;
        }

        public void ResumeAll()
        {

        }

        public void ResumeSame(string resume_key)
        {

        }

        public void ResumeSame(string resume_key, string[] handler_names)
        {

        }

        public virtual void Method()
        {
            throw new Exception("This method need to be implemented.");
        }
    }
}
