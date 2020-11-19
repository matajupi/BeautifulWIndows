using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulWindows
{
    class ThreadController : IThreadController
    {
        public Dictionary<string, IThreadHandler> Handlers { get; set; }

        public ThreadController() { }
        public ThreadController(Dictionary<string, IThreadHandler> handlers) => this.Handlers = handlers;

        public virtual void Start()
        {
            this.Handlers = this.Handlers.Select(x => { x.Value.Controller = this; return x; }).ToDictionary(x => x.Key, x => x.Value);
            var tasks = new List<Task>();
            foreach (var h in this.Handlers) tasks.Add(Task.Run(() => h.Value.Method()));
            Task.WaitAll(tasks.ToArray());
        }
    }

    class ThreadHandler : IThreadHandler
    {
        public IThreadController Controller { get; set; }
        private bool is_resume = false;

        public void Resume() => this.is_resume = true;

        public void ResumeSame()
        {
            this.is_resume = true;
            while (this.is_resume) { }
        }

        public virtual void EventLoop()
        {
            while (!this.is_resume) { }
            this.is_resume = false;
        }

        public virtual void Method() { }
    }
}
