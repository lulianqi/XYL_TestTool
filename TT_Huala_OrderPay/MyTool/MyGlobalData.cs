using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TT_Huala_OrderPay.MyTool
{
    public interface IAliveTask:IDisposable
    {
        string Name { get; }
        int IntervalTime { get; }

        bool IsKIll { get; }

        void StartTask();

        void StopTask();
    }
}
