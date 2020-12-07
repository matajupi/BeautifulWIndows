using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadControl
{
    public class ThreadController
    {
        public List<ThreadProcess> Processes = new List<ThreadProcess>();
        private ReadOnlyCollection<ThreadProcess> RunningProcesses;
        private List<ThreadOrder> Orders = new List<ThreadOrder>();
        private Dictionary<string, List<ThreadProcess>> WaitingProcesses = new Dictionary<string, List<ThreadProcess>>();

        /// <summary>
        /// 追加されてあるプロセスを一斉にスタートさせます。
        /// </summary>
        public void StartAll()
        {
            this.RunningProcesses = this.Processes.AsReadOnly();
            foreach (var p in this.RunningProcesses)
            {
                p.Controller = this;
            }

            var tasks = new List<Task>();
            foreach (var p in this.RunningProcesses)
            {
                tasks.Add(Task.Run(() => p.Body()));
            }
            Task.WaitAll(tasks.ToArray());
            this.Orders.Clear();
            this.WaitingProcesses.Clear();
        }

        public ThreadProcess[] GetProcesses()
        {
            var processes = this.RunningProcesses.ToArray();
            return processes;
        }

        /// <summary>
        /// 受け取った名前の配列よりプロセスを探し返します。
        /// </summary>
        /// <param name="pnames">プロセス名の配列</param>
        /// <returns>プロセスの配列</returns>
        public ThreadProcess[] GetProcesses(params string[] pnames)
        {
            var processes = new List<ThreadProcess>();
            foreach (var pn in pnames)
            {
                var p = this.RunningProcesses.Where(x => x.Name == pn).ToArray();
                if (p.Length == 0)
                    throw new Exception($"Name {pn} process is not found.");
                processes.Add(p[0]);
            }
            return processes.ToArray();
        }

        /// <summary>
        /// 与えられた命令を実行します。
        /// </summary>
        /// <param name="order">命令</param>
        public void RunOrder(ThreadOrder order)
        {
            this.Orders.Add(order);
            order.Controller = this;
            if (this.WaitingProcesses.ContainsKey(order.Id))
            {
                var processes = this.WaitingProcesses[order.Id];
                foreach (var p in processes) order.AddProcess(p);
            }
        }

        /// <summary>
        /// 与えられたIDと一致する命令にプロセスを追加します。
        /// </summary>
        /// <param name="id">命令のID</param>
        /// <param name="process">プロセス</param>
        public void AddProcessToOrder(string id, ThreadProcess process)
        {
            if (this.Orders.Select(x => x.Id).Contains(id))
            {
                this.Orders.Where(x => x.Id == id).ToList()[0].AddProcess(process);
                return;
            }
            if (this.WaitingProcesses.ContainsKey(id))
            {
                this.WaitingProcesses[id].Add(process);
                return;
            }
            this.WaitingProcesses.Add(id, new List<ThreadProcess>() { process });
        }

        internal void RunToProcess(Action<ThreadProcess> action, params ThreadProcess[] processes)
        {
            foreach (var p in processes)
            {
                action(p);
            }
        }
    }
}
