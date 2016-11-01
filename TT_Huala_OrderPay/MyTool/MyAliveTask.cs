using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TT_Huala_OrderPay.MyTool
{
    public class MyAliveTask
    {
        public class MyHttpTask : IAliveTask
        {

            private string name;
            private string taskCmd;
            private int intervalTime;
            private bool isKill;

            private Thread myAliveTaskThread;

            private ManualResetEvent myManualResetEvent = new ManualResetEvent(false);

            public delegate void delegatePutOutDataEventHandler(object sender, string outMes);

            public event delegatePutOutDataEventHandler OnPutOutData;


            public string Name
            {
                get { return name; }
            }

            public int IntervalTime
            {
                get { return intervalTime; }
            }

            public bool IsKIll
            {
                get { return isKill; }
            }

            public MyHttpTask(string yourName,string yourTaskCmd,int yourIntervalTime)
            {
                name = yourName;
                taskCmd = yourTaskCmd;
                intervalTime = yourIntervalTime;
                isKill = false;

                CreateAliveTaskThread();
            }

            private void PutOutData(string outMes)
            {
                if(OnPutOutData!=null)
                {
                    OnPutOutData(this, outMes);
                }
            }

            private bool CreateAliveTaskThread()
            {
                if (myAliveTaskThread != null)
                {
                    return false;
                }
                myAliveTaskThread = new Thread(new ParameterizedThreadStart(AliveTaskBody));
                myAliveTaskThread.Name = Name + "_MyHttpTask";
                myAliveTaskThread.Priority = ThreadPriority.Normal;
                myAliveTaskThread.IsBackground = true;
                myAliveTaskThread.Start(null);
                return true;
            }

            private void AliveTaskBody(object obj)
            {
                while (!isKill)
                {
                    myManualResetEvent.WaitOne();
                    string tempResult = MyCommonTool.myWebTool.myHttp.SendData(taskCmd, null, "GET");
                    if (tempResult != "")
                    {
                        PutOutData(tempResult);
                    }
                    Thread.Sleep(IntervalTime);
                }
            }

            public void StartTask()
            {
                if (myAliveTaskThread != null)
                {
                    myManualResetEvent.Set();
                }
            }

            public void StopTask()
            {
                if (myAliveTaskThread != null)
                {
                    myManualResetEvent.Reset();
                }
            }

            public void Dispose()
            {
                isKill = true;
                if (myAliveTaskThread != null)
                {
                    myAliveTaskThread.Abort();
                }
                myAliveTaskThread = null;
            }
        }
    }
}
