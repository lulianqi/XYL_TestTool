﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpSvn;
using System.IO;

namespace TT_Huala_OrderPay.MyTool
{
    class MySvn:IDisposable
    {
        class MyRealTimeTextWriter : TextWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }

            public event Action<string> DataReceived;
            private void OnDataReceived(string value)
            {
                if (DataReceived != null)
                {
                    DataReceived(value);
                }
            }

            public override void Write(string value)
            {
                OnDataReceived(value);
            }
            public override void WriteLine(string value)
            {
                OnDataReceived(value + "\r\n");
            }


        }


        public delegate void delegateGetSnvMessageEventHandler(object sender, string InfoMessage);
        //public event delegateGetSnvMessageEventHandler OnGetSnvMessage;
        public delegateGetSnvMessageEventHandler OnGetSnvMessage;
        public delegateGetSnvMessageEventHandler OnGetSnvStateInfo;

        SvnClient client;
        MyRealTimeTextWriter realtimeTextWriter;
        SvnClientReporter reporter;

        public MySvn()
        {
            client = new SvnClient();
            realtimeTextWriter = new MyRealTimeTextWriter();
            reporter = new SvnClientReporter(client, realtimeTextWriter);
            ShowChange(true);
        }


        public MySvn(string usrName ,string usrPwd):this()
        {
            client.Authentication.Clear();  //清除原有的账户信息   //重新设定账户信息 
            //client.Authentication.UserNamePasswordHandlers += new EventHandler<SharpSvn.Security.SvnUserNamePasswordEventArgs>((object s, SharpSvn.Security.SvnUserNamePasswordEventArgs se) =>{ se.UserName = usrName; se.Password = usrPwd; });
            client.Authentication.UserNamePasswordHandlers += new EventHandler<SharpSvn.Security.SvnUserNamePasswordEventArgs>(delegate(object s, SharpSvn.Security.SvnUserNamePasswordEventArgs se) { se.UserName = usrName; se.Password =usrPwd ; });
        }

        private void realtimeTextWriter_DataReceived(string DataReceived)
        {
            ShowInfo(DataReceived);
        }

        private void ShowInfo(string mes)
        {
            if(OnGetSnvMessage!=null)
            {
                this.OnGetSnvMessage(null, mes);
            }
        }

        private void ShowState(string mes)
        {
            if (OnGetSnvMessage != null)
            {
                this.OnGetSnvStateInfo(null, mes+"\r\n");
            }
        }


        public bool Updata(string SvnPathTarget)
        {
            ShowState(String.Format("{0} start updata", SvnPathTarget));
            //SvnInfoEventArgs serverInfo;
            SvnInfoEventArgs clientInfo;
            //SvnUpdateResult svnUpdateResult;
            //System.Collections.ObjectModel.Collection<SvnLogEventArgs> logSvnArgs;
            //SvnUriTarget repos = new SvnUriTarget(svnUriTarget);
            SvnPathTarget local = new SvnPathTarget(SvnPathTarget);
            //client.GetInfo(repos, out serverInfo);
            try
            {
                client.GetInfo(local, out clientInfo);
            }
            catch(Exception ex)
            {
                ShowState(String.Format("[updata errer] {0}", ex.Message));
                return false;
            }
            //client.GetLog(SvnPathTarget, out logSvnArgs);
            if(!client.Update(SvnPathTarget))
            {
                ShowState(String.Format("updata errer {0}", SvnPathTarget));
                return false;
            }
            ShowState(string.Format("Svn remote path is :{0} \r\nLocal path is :{1} \r\nLast change revision is :{2} \r\nLast change time is :{3} \r\nLast change author is :{4} \r\n",
                clientInfo.Uri, clientInfo.Path, clientInfo.LastChangeRevision,clientInfo.LastChangeTime,clientInfo.LastChangeAuthor,clientInfo.Revision));
            return true;
        }

        public void CheckOut(string svnUriTarget, string SvnPathTarget)
        {
            ShowState(String.Format("{0} start CheckOut", SvnPathTarget));
            client.CheckOut(new SvnUriTarget(svnUriTarget), SvnPathTarget);
            SvnInfoEventArgs clientInfo;
            client.GetInfo(new SvnPathTarget(SvnPathTarget), out clientInfo);
            if (!client.Update(SvnPathTarget))
            {
                ShowState(String.Format("{0} CheckOut errer", SvnPathTarget));
            }
            ShowState(string.Format("Svn remote path is :{0} \r\nLocal path is :{1} \r\nLast change revision is :{2} \r\nLast change time is :{3} \r\nLast change author is :{4} \r\n",
                clientInfo.Uri, clientInfo.Path, clientInfo.LastChangeRevision, clientInfo.LastChangeTime, clientInfo.LastChangeAuthor, clientInfo.Revision));
        }

        public void CleanUp(string SvnPathTarget)
        {
            client.CleanUp(SvnPathTarget);
        }

        public void Commit(string SvnPathTarget)
        {
            client.Commit(SvnPathTarget);
        }

        public void ShowChange(bool isShow)
        {
            if (isShow)
            {
                realtimeTextWriter.DataReceived += realtimeTextWriter_DataReceived;
            }
            else
            {
                realtimeTextWriter.DataReceived -= realtimeTextWriter_DataReceived;
            }
        }


        public void GetLogs(string SvnPathTarget)
        {
            //log
            client.Log(SvnPathTarget, new EventHandler<SvnLogEventArgs>((obj, svnAgrs) =>
            {
                StringBuilder outlogs = new StringBuilder();
                foreach (SvnChangeItem changeItem in svnAgrs.ChangedPaths)
                {
                    outlogs.Append(string.Format(
                                                "{0} {1} {2} {3} {4}\r{5} {6}",
                                                changeItem.Action,
                                                changeItem.Path,
                                                changeItem.CopyFromRevision,
                                                changeItem.CopyFromPath,
                                                svnAgrs.Author,
                                                svnAgrs.LogMessage,
                                                svnAgrs.Revision)
                                                );

                }
                ShowInfo(outlogs.ToString());
            }));
        }


        public void Dispose()
        {
            reporter.Dispose();
            client.Dispose();
        }
    }
}
