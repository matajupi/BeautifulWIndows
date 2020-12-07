using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadControl.OldCodes
{
    public class ThreadController
    {
        public List<ThreadHandler0> Handlers { get; set; }
        private List<ThreadHandler0> RunningHandlers;
        internal List<ResumeOrder> ResumeOrders;

        public ThreadController() => this.Handlers = new List<ThreadHandler0>();
        public ThreadController(List<ThreadHandler0> handlers)
        {
            this.Handlers = handlers.Select(x => { x.Controller = this; return x; }).ToList();
        }

        private bool IsUniqueName()
        {
            var handler_names = this.Handlers.Select(x => x.Name).ToList();
            var handler_names_hash = handler_names.ToHashSet<string>();
            return handler_names.Count == handler_names_hash.Count;
        }

        public void StartAll()
        {
            this.ResumeOrders = new List<ResumeOrder>();
            if (!this.IsUniqueName()) throw new Exception("The name must be unique.");
            this.RunningHandlers = this.Handlers.Select(x => { x.Controller = this; return x; }).ToList();
            var tasks = new List<Task>();
            foreach (var h in this.RunningHandlers) tasks.Add(Task.Run(() => h.Method()));
            Task.WaitAll(tasks.ToArray());
            this.ResumeOrders.Clear();
        }

        internal void SendResumeOrder(ThreadHandler0 root, string resume_key)
        {
            var order = this.GetResumeOrder(resume_key);
            order.Handlers.Add(root);
        }

        internal void SendResumeOrder(ThreadHandler0 root, string resume_key, string[] handler_names)
        {
            var handlers = this.SearchHandler(handler_names);
            var order = this.GetResumeOrder(resume_key);
            order.Handlers.Add(root);
        }

        private ResumeOrder GetResumeOrder(string resume_key)
        {
            if (this.ResumeOrders.Select(x => x.ResumeKey).Contains(resume_key))
            {
                return this.ResumeOrders.Where(x => x.ResumeKey == resume_key).ToList()[0];
            }
            var order = new ResumeOrder(resume_key);
            this.ResumeOrders.Add(order);
            return order;
        }

        private List<ThreadHandler0> SearchHandler(string[] handler_names)
        {
            return null;
        }
    }
}
