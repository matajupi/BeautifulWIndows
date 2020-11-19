using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulWindows
{
    interface IThreadController
    {
        Dictionary<string, IThreadHandler> Handlers { get; set; }
        void Start();
    }

    interface IThreadHandler
    {
        IThreadController Controller { get; set; }
        void Resume();
        void ResumeSame();
        void EventLoop();
        void Method();
    }
}
