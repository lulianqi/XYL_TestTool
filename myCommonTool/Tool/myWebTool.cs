using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Linq;
using MyCommonTool;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


/*******************************************************************************
* Copyright (c) 2015 lijie
* All rights reserved.
* 
* 文件名称: 
* 内容摘要: mycllq@hotmail.com
* 
* 历史记录:
* 日	  期:   201505016           创建人: 李杰 15158155511
* 描    述: 创建
*******************************************************************************/


namespace MyCommonTool
{
    public static class myWebTool
    {
        public static class myHttp
        {
            public static int httpTimeOut = 100000;                                            //http time out , HttpPostData will not use this value

            //ServicePointManager

            static myHttp()
            {
                //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(
                //    (sender, certificate, chain, sslPolicyErrors) => { return true; });

                ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

                Console.WriteLine(ServicePointManager.DefaultConnectionLimit);               
            }

            public static bool MyRemoteCertificateValidationCallback(Object sender,X509Certificate certificate,X509Chain chain,SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }

             
            /// <summary>
            /// i will Send Data 
            /// </summary>
            /// <param name="url"> url </param>
            /// <param name="data"> param if method is not POST it will add to the url</param>
            /// <param name="method">GET/POST</param>
            /// <returns>back </returns>
            public static string SendData(string url, string data, string method)
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
                    wr.Timeout = httpTimeOut;
                    wr.Method = method;

                    //20151226
                    {
                        wr.Headers.Add(HttpRequestHeader.Cookie,"hltoken=68c410a4-6f38-4734-b937-3c5f3d922263");
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
                        Stream newStream = wr.GetRequestStream();                //连接建立head已经发出，POST请求体还没有发送
                        newStream.Write(SomeBytes, 0, SomeBytes.Length);         //请求交互完成
                        newStream.Close();
                    }
                    else
                    {
                        wr.ContentLength = 0;
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
                    ErrorLog.PutInLog("ID:0090 " + ex.InnerException);
                }
                return re;
            }

               

            /// <summary>
            /// i will Send Data with multipart,if you do not want updata any file you can set isFile is false and set filePath is null
            /// </summary>
            /// <param name="url">url</param>
            /// <param name="timeOut">timeOut</param>
            /// <param name="name">Parameter name</param>
            /// <param name="filename">filename</param>
            /// <param name="isFile">is a file</param>
            /// <param name="filePath">file path or cmd</param>
            /// <param name="bodyParameter">the other Parameter in body</param>
            /// <returns>back</returns>
            public static string HttpPostData(string url, int timeOut, string name, string filename,bool isFile ,string filePath, string bodyParameter)
            {
                string responseContent; 
                NameValueCollection stringDict = new NameValueCollection();

                if (bodyParameter != null)
                {
                    string[] sArray = bodyParameter.Split('&');
                    foreach (string tempStr in sArray)
                    {
                        int myBreak = tempStr.IndexOf('=');
                        if (myBreak == -1)
                        {
                            return "can't find =";
                        }
                        stringDict.Add(tempStr.Substring(0, myBreak), tempStr.Substring(myBreak + 1));
                    }
                }

                var memStream = new MemoryStream();
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                // 边界符
                var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
                // 边界符
                var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
                // 最后的结束符
                var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

                // 设置属性
                webRequest.Method = "POST";
                webRequest.Timeout = timeOut;

                //是否带文件提交
                if (filePath != null)
                {
                    webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
                    // 写入文件
                    const string filePartHeader = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" + "Content-Type: application/octet-stream\r\n\r\n";
                    var header = string.Format(filePartHeader, name, filename);
                    var headerbytes = Encoding.UTF8.GetBytes(header);

                    memStream.Write(beginBoundary, 0, beginBoundary.Length);
                    memStream.Write(headerbytes, 0, headerbytes.Length);

                    if (isFile)
                    {
                        try
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            {
                                var buffer = new byte[1024];
                                int bytesRead; // =0
                                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                {
                                    memStream.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            responseContent = "Error:  " + ex.Message + "\r\n";
                            ErrorLog.PutInLog("ID:0544 " + ex.InnerException);
                            return responseContent;
                        }
                    }
                    else
                    {
                        byte[] myCmd = Encoding.UTF8.GetBytes(filePath);
                        memStream.Write(myCmd, 0, myCmd.Length);
                    }
                }

                //写入POST非文件参数
                if (bodyParameter != null)
                {
                    //写入字符串的Key
                    var stringKeyHeader = "\r\n--" + boundary +
                                           "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                           "\r\n\r\n{1}";


                    for (int i = 0; i < stringDict.Count; i++)
                    {
                        try
                        {
                            byte[] formitembytes = Encoding.UTF8.GetBytes(string.Format(stringKeyHeader, stringDict.GetKey(i), stringDict.Get(i)));
                            memStream.Write(formitembytes, 0, formitembytes.Length);
                        }
                        catch (Exception ex)
                        {
                            return "can not send :" + ex.Message;
                        }
                    }
                    memStream.Write(Encoding.ASCII.GetBytes("\r\n"), 0, Encoding.ASCII.GetBytes("\r\n").Length);

                }
                else
                {
                    memStream.Write(Encoding.ASCII.GetBytes("\r\n"), 0, Encoding.ASCII.GetBytes("\r\n").Length);
                }

                //写入最后的结束边界符
                //memStream.Write(Encoding.ASCII.GetBytes("\r\n"), 0, Encoding.ASCII.GetBytes("\r\n").Length);
                memStream.Write(endBoundary, 0, endBoundary.Length);

                webRequest.ContentLength = memStream.Length;

                //开始请求
                try
                {
                    var requestStream = webRequest.GetRequestStream();

                    memStream.Position = 0;
                    var tempBuffer = new byte[memStream.Length];
                    memStream.Read(tempBuffer, 0, tempBuffer.Length);
                    memStream.Close();

                    requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                    requestStream.Close();

                    var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

                    using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                                                                    Encoding.GetEncoding("utf-8")))
                    {
                        responseContent = httpStreamReader.ReadToEnd();
                    }

                    httpWebResponse.Close();
                    webRequest.Abort();
                }
                catch (WebException wex)
                {
                    responseContent = "Error:  " + wex.Message + "\r\n";
                    if (wex.Response != null)
                    {
                        using (var errorResponse = (HttpWebResponse)wex.Response)
                        {
                            responseContent += "StatusCode:  " + Convert.ToInt32(((HttpWebResponse)wex.Response).StatusCode) + "\r\n";
                            using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                            {
                                responseContent += reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        byte[] myCmd = Encoding.UTF8.GetBytes(filePath);
                        memStream.Write(myCmd, 0, myCmd.Length);
                    }
                }

                catch (Exception ex)
                {
                    responseContent = ex.Message;
                    ErrorLog.PutInLog("ID:0090 " + ex.InnerException);
                }

                return responseContent;
            }






            //*****************************************************only for xinyunlian and it will change soon

            public static string SendData(string url, string data, string method, string cookie)
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
                    wr.Timeout = httpTimeOut;
                    wr.Method = method;

                    //20151226
                    {
                        wr.Headers.Add(HttpRequestHeader.Cookie, cookie);
                        wr.Headers.Add("cnm:cnm");
                        wr.Headers.Add("cnm:cnm");
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
                        Stream newStream = wr.GetRequestStream();                //连接建立head已经发出，POST请求体还没有发送
                        newStream.Write(SomeBytes, 0, SomeBytes.Length);         //请求交互完成
                        newStream.Close();
                    }
                    else
                    {
                        wr.ContentLength = 0;
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
                    ErrorLog.PutInLog("ID:0090 " + ex.InnerException);
                }
                return re;
            }

        }
    }
}
