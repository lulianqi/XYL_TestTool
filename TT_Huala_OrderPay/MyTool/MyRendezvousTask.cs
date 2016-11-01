using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace TT_Huala_OrderPay.MyTool
{
    class MyRendezvousTask
    {
        public class HttpRendezvousTask
        {
            public class HttpRendezvousTaskParameterized
            {

            }



            private List<Thread> rendezvousTaskList;
            private AutoResetEvent myAutoResetEvent = new AutoResetEvent(false);  //stop
            public HttpRendezvousTask()
            {
                rendezvousTaskList = new List<Thread>();
                myAutoResetEvent.Set();
            }

            public void StartRendezvous()
            {

            }
            public void EndRendezvous()
            {

            }

            public void RunRendezvous()
            {
                myAutoResetEvent.Reset();
            }

            public void AddTask(HttpRendezvousTaskParameterized taskParameterized)
            {
                Thread myThread = new Thread(new ParameterizedThreadStart(RendezvousTask));
                myThread.IsBackground = true;
                rendezvousTaskList.Add(myThread);
                myThread.Start(taskParameterized);
            }

            private static void RendezvousTask(object taskParameterized)
            {
               
            }

            public static string SendRendEzvousData(AutoResetEvent autoResetEvent , string url, string data, string method, string cookie)
            {
                string re = "";
                try
                {
                    //except POST other data will add the url,if you want adjust the ruleschange here
                    if (method.ToUpper() != "POST" && data != null)
                    {
                        url += "?" + data;
                        data = null;           //make sure the data is null when Request is not post
                    }
                    WebRequest wr = WebRequest.Create(url);
                    wr.Timeout = 50000;
                    wr.Method = method;

                    //20151226
                    {
                        wr.Headers.Add(HttpRequestHeader.Cookie, cookie);
                    }

                    wr.ContentType = "application/x-www-form-urlencoded";
                    //wr.ContentType = "multipart/form-data";
                    char[] reserved = { '?', '=', '&' };
                    StringBuilder UrlEncoded = new StringBuilder();
                    byte[] SomeBytes = null;


                    if (data != null && method.ToUpper() == "POST")
                    {
                        SomeBytes = Encoding.UTF8.GetBytes(data);
                        wr.ContentLength = SomeBytes.Length;
                        autoResetEvent.WaitOne();
                        Stream newStream = wr.GetRequestStream();                //连接建立head已经发出，POST请求体还没有发送
                        newStream.Write(SomeBytes, 0, SomeBytes.Length);         //请求交互完成
                        newStream.Close();
                    }
                    else
                    {
                        wr.ContentLength = 0;
                        autoResetEvent.WaitOne();
                    }


                    WebResponse result = wr.GetResponse();                       //GetResponse 方法向 Internet 资源发送请求并返回 WebResponse 实例。如果该请求已由 GetRequestStream 调用启动，则 GetResponse 方法完成该请求并返回任何响应。

                    Stream ReceiveStream = result.GetResponseStream();

                    Byte[] read = new Byte[512];
                    int bytes = ReceiveStream.Read(read, 0, 512);

                    re = "";
                    while (bytes > 0)
                    {
                        Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
                        re += encode.GetString(read, 0, bytes);
                        bytes = ReceiveStream.Read(read, 0, 512);
                    }
                }

                catch (WebException wex)
                {
                    re = "Error:  " + wex.Message + "\r\n";
                    if (wex.Response != null)
                    {
                        using (var errorResponse = (HttpWebResponse)wex.Response)
                        {
                            re += "StatusCode:  " + Convert.ToInt32(((HttpWebResponse)wex.Response).StatusCode) + "\r\n";
                            using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                            {
                                re += reader.ReadToEnd();
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    re = ex.Message;
                    MyCommonTool.ErrorLog.PutInLog("ID:0090 " + ex.InnerException);
                }
                return re;
            }
        }
    }
}
