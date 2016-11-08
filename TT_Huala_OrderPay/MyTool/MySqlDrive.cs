using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace TT_Huala_OrderPay.MyTool
{
    class MySqlDrive:IDisposable
    {
        #region inner class
        /// <summary>
        /// AliveTask Info (if you want kill the AliveTask Thread  just set IsKill is true)
        /// </summary>
        private class AliveTaskInfo:IDisposable
        {
            /// <summary>
            /// AliveTaskInfo name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Task sql
            /// </summary>
            public string TaskSqlcmd { get; set; }

            /// <summary>
            /// Interval Time
            /// </summary>
            public int IntervalTime { get; set; }

            /// <summary>
            /// if set it ture
            /// </summary>
            private bool IsKill { get; set; }

            private MySqlDrive executeMySqlDrive;

            private Thread myAliveTaskThread;

            private ManualResetEvent myManualResetEvent = new ManualResetEvent(false);  //stop
            //myAutoResetEvent.Set();     //go           
            //myAutoResetEvent.WaitOne();    //stop

            public event delegateGetAliveTaskDataTableInfoEventHandler OnGetAliveTaskDataTableInfo;

            public AliveTaskInfo(string yourTaskName,String sqlcmd, int intervalTime ,MySqlDrive yourExecuteMySqlDrive)
            {
                Name = yourTaskName;
                TaskSqlcmd = sqlcmd;
                IntervalTime = intervalTime;
                IsKill = false;
                executeMySqlDrive=yourExecuteMySqlDrive;
            }

            public void PutOutAliveTaskDataTableInfo(DataTable yourPutData)
            {
                if (OnGetAliveTaskDataTableInfo != null)
                {
                    //[AliveTaskInfo] is private here so other class may not know this data type in IDE,so i put his name as sender
                    OnGetAliveTaskDataTableInfo(this.Name, yourPutData);
                }
            }

            /// <summary>
            /// Create  Thread  and it is Pauseed,if you wnat it run just call [ResumeAliveTask]
            /// </summary>
            /// <returns></returns>
            public bool CreateAliveTaskThread()
            {
                if (myAliveTaskThread!=null)
                {
                    return false;
                }
                myAliveTaskThread = new Thread(new ParameterizedThreadStart(AliveTaskBody));
                myAliveTaskThread.Name = Name + "_AliveTask";
                myAliveTaskThread.Priority = ThreadPriority.Normal;
                myAliveTaskThread.IsBackground = true;
                myAliveTaskThread.Start(null);

                return true;
            }

            /// <summary>
            /// Pause Task Thread
            /// </summary>
            public void PauseAliveTask()
            {
                if(myAliveTaskThread!=null)
                {
                    myManualResetEvent.Reset();
                }
            }

            /// <summary>
            /// Resume Task Thread
            /// </summary>
            public void ResumeAliveTask()
            {
                if (myAliveTaskThread != null)
                {
                    myManualResetEvent.Set();
                }
            }

            /// <summary>
            /// Stop the Task and will set it null
            /// </summary>
            public void StopAliveTask()
            {
                if (myAliveTaskThread != null)
                {
                    IsKill=true;
                    myAliveTaskThread.Abort();
                    myAliveTaskThread = null;
                }
            }

            /// <summary>
            /// the main task work
            /// </summary>
            /// <param name="taskInfo"></param>
            private void AliveTaskBody(object taskInfo)
            {
                while (!IsKill)
                {
                    myManualResetEvent.WaitOne();
                    DataTable tempTable = executeMySqlDrive.ExecuteQuery(TaskSqlcmd);
                    if (tempTable != null)
                    {
                        if (tempTable.Rows.Count > 0)
                        {
                            PutOutAliveTaskDataTableInfo(tempTable);
                        }
                    }
                    else
                    {
                        executeMySqlDrive.SetErrorMes(" [ExecuteQuery] fail in RunSynchronousAliveTask");
                    }
                    Thread.Sleep(IntervalTime);
                }
            }
  
            public void Dispose()
            {
                StopAliveTask();
            }
        }
        #endregion
        
        #region delegate and event
        public delegate void delegateGetErrorMessageEventHandler(object sender, string ErrorMessage);
        public delegate void delegateGetInfoMessageEventHandler(object sender, string InfoMessage);
        public delegate void delegateDriveStateChangeEventHandler(object sender, bool isCounect);

        public delegate void delegateGetAliveTaskDataTableInfoEventHandler(object sender, DataTable dataTable);

        public event delegateGetErrorMessageEventHandler OnGetErrorMessage;
        public event delegateGetInfoMessageEventHandler OnGetInfoMessage;
        public event delegateDriveStateChangeEventHandler OnDriveStateChange;
        #endregion

        #region field
        private Dictionary<string, AliveTaskInfo> aliveTaskList = new Dictionary<string, AliveTaskInfo>();
        private Thread newAliveTaskThread;
        private AutoResetEvent myAutoResetEvent = new AutoResetEvent(false);
        private string data_source = ""; //Server=192.168.200.152;UserId=root;Password=xpsh;Database=huala_test
        private bool isDriveConnect = false;
        private MySqlConnection myConnection;
        private MySqlCommand myCommand;
        private MySqlDataAdapter myAdapter;
        private MySqlTransaction myTransaction;
        private DataTable myTable;
        private string nowError;
        private int defaultReconnectTime;
        private int reconnectTime;
        #endregion

        #region attribute
        /// <summary>
        /// get Conninfo string
        /// </summary>
        public string ConnStr
        {
            get { return data_source; }
        }

        /// <summary>
        /// get a vaule that mean MySqlDrive is connected
        /// </summary>
        public bool IsDriveConnect
        {
            get { return isDriveConnect; }
        }

        /// <summary>
        /// get Alive TaskList
        /// </summary>
        public string[] AliveTaskList
        {
            get 
            {
                if (aliveTaskList != null)
                {
                    return (aliveTaskList.Keys).ToArray<string>();
                }
                else
                {
                    return null;
                }
                    
            }
        }

        /// <summary>
        /// get the last error message
        /// </summary>
        public string NowError
        {
            get { return nowError; }
        }

        /// <summary>
        /// get or set the times of reconnect to mysql
        /// </summary>
        public int ReconnectTime
        {
            get { return defaultReconnectTime; }
            set { defaultReconnectTime = reconnectTime = value; }
        }

        #endregion

        #region function
        /// <summary>
        /// initialize a new MySqlDrive
        /// </summary>
        /// <param name="connStr">conn Str</param>
        public MySqlDrive(string connStr)
        {
            data_source = connStr;
            isDriveConnect = false;
            defaultReconnectTime = reconnectTime = 1;
            myAutoResetEvent.Set();
        }

        /// <summary>
        /// set error message your should use it deal your error that you want tell the user
        /// </summary>
        /// <param name="errorMes">error message</param>
        private void SetErrorMes(string errorMes)
        {
            nowError = errorMes;
            if (OnGetErrorMessage != null)
            {
                OnGetErrorMessage(this, errorMes);
            }
        }

        /// <summary>
        /// set info message your should use it deal your error that you want tell the user
        /// </summary>
        /// <param name="errorMes">error message</param>
        private void SetInfoMes(string infoMes)
        {
            if (OnGetInfoMessage != null)
            {
                OnGetInfoMessage(this, infoMes);
            }
        }

        /// <summary>
        /// updata Drive Connect State
        /// </summary>
        /// <param name="isConnect">is Connect</param>
        private void UpdataDriveConnectState(bool isConnect)
        {
            if(isConnect!=isDriveConnect)
            {
                isDriveConnect = isConnect;
                if(OnDriveStateChange!=null)
                {
                    OnDriveStateChange(this, this.IsDriveConnect);
                }
            }
        }

        /// <summary>
        /// Connect DataBase if it is need (each [ExecuteQuery] will check the Connect so you donot need call it befor ExecuteQuery)
        /// </summary>
        /// <returns>is sucusse</returns>
        public bool ConnectDataBase()
        {
            try
            {
                if (myConnection == null)
                {
                    myConnection = new MySqlConnection(data_source);
                }
                if (myConnection.State == ConnectionState.Closed || myConnection.State == ConnectionState.Broken)
                {
                    try
                    {
                        myConnection.Open();
                    }
                    catch
                    {
                        if (reconnectTime > 0)
                        {
                            SetInfoMes("Reconnect to the database");
                            reconnectTime--;
                            myConnection.Dispose();
                            myConnection = new MySqlConnection(data_source);
                            return ConnectDataBase();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                UpdataDriveConnectState(true);
                reconnectTime = defaultReconnectTime;
                return true;
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                if (myConnection.State == ConnectionState.Open || myConnection.State == ConnectionState.Connecting)
                {
                    //MySql库中链接异常时也显示open状态，导致最后会跳过连接
                    myConnection.Close();
                }
                SetErrorMes("DataBase Connect Fial");
                SetErrorMes(ex.Message);
            }
            catch (Exception ex)
            {
                if (myConnection.State == ConnectionState.Open || myConnection.State == ConnectionState.Connecting)
                {
                    myConnection.Close();
                }
                SetErrorMes(ex.Message);
            }
            UpdataDriveConnectState(false);
            return false;
        }

        public bool ConnectDataBase(string connStr)
        {
            data_source = connStr;
            return ConnectDataBase();
        }

        /// <summary>
        /// Add a new AliveTask (it will be a new Thread)
        /// </summary>
        /// <param name="yourName">your task name</param>
        /// <param name="yourInfo">your task info</param>
        /// <returns></returns>
        private bool AddAliveTaskInfo(string yourName, AliveTaskInfo yourInfo)
        {
            if (aliveTaskList.ContainsKey(yourName))
            {
                SetErrorMes("existed task name");
                return false;
            }
            else
            {
                aliveTaskList.Add(yourName, yourInfo);
                return true;
            }
        }

        #endregion

        #region action

        #region AliveTask
        /// <summary>
        /// Create New AliveTask [it will not start ]
        /// </summary>
        /// <param name="yourTaskName"></param>
        /// <param name="sqlcmd"></param>
        /// <param name="intervalTime"></param>
        /// <param name="yourAction"></param>
        /// <returns></returns>
        public bool CreateNewAliveTask(string yourTaskName, String sqlcmd, int intervalTime, delegateGetAliveTaskDataTableInfoEventHandler yourAction)
        {
            AliveTaskInfo tempTaskInfo = new AliveTaskInfo(yourTaskName, sqlcmd, intervalTime, this);
            tempTaskInfo.OnGetAliveTaskDataTableInfo += yourAction;
            if (AddAliveTaskInfo(yourTaskName, tempTaskInfo))
            {
                tempTaskInfo.CreateAliveTaskThread();
                return true;
            }
            else
            {
                tempTaskInfo.Dispose();
                tempTaskInfo = null;
                return false;
            }
        }

        /// <summary>
        /// you can update the sql cmd by Task name
        /// </summary>
        /// <param name="yourName">Task name</param>
        /// <param name="sqlcmd">sqlcmd</param>
        /// <returns>is succse</returns>
        public bool UpdateAliveTaskSqlCmd(string yourName, String sqlcmd)
        {
            if (aliveTaskList.ContainsKey(yourName))
            {
                aliveTaskList[yourName].TaskSqlcmd = sqlcmd;
                return true;
            }
            else
            {
                SetErrorMes("not find this task name : " + yourName);
                return false;
            }
        }

        /// <summary>
        /// Start Task（这里的Start/Stop实际上是指恢复暂停任务线程的意思）
        /// </summary>
        /// <param name="yourName">Task name</param>
        /// <returns>is succse</returns>
        public bool StartAliveTask(string yourName)
        {
            if (aliveTaskList.ContainsKey(yourName))
            {
                aliveTaskList[yourName].ResumeAliveTask();
                return true;
            }
            else
            {
                SetErrorMes("not find this task name : " + yourName);
                return false;
            }
        }

        /// <summary>
        /// Stop Task （这里的Start/Stop实际上是指恢复暂停任务线程的意思）
        /// </summary>
        /// <param name="yourName">task name</param>
        /// <returns>is sucess</returns>
        public bool StopAliveTask(string yourName)
        {
            if (aliveTaskList.ContainsKey(yourName))
            {
                aliveTaskList[yourName].PauseAliveTask();
                return true;
            }
            else
            {
                SetErrorMes("not find this task name : " + yourName);
                return false;
            }
        }

        /// <summary>
        /// remove a AliveTask by his name ( it will remove the list immediately and the Thread will over but not immediately)
        /// </summary>
        /// <param name="yourName">task name</param>
        /// <returns>is succes</returns>
        public bool DelAliveTask(string yourName)
        {
            if (aliveTaskList.ContainsKey(yourName))
            {
                aliveTaskList[yourName].StopAliveTask();
                aliveTaskList[yourName].Dispose();
                aliveTaskList[yourName] = null;
                aliveTaskList.Remove(yourName);
                return true;
            }
            else
            {
                SetErrorMes("not find this task name");
                return false;
            }
        }
        #endregion
        

        /// <summary>
        /// execute a query command with sql 
        /// </summary>
        /// <param name="sql">your sql commod</param>
        /// <returns>the result with DataTable(it will be null when find error)</returns>
        public DataTable ExecuteQuery(String sql)
        {
            DataTable myTable;
            myAutoResetEvent.WaitOne();
            if (!ConnectDataBase())
            {
                SetErrorMes("can not connect MySqlDrive");
                myAutoResetEvent.Set();
                return null;
            }
            try
            {
                myCommand = myConnection.CreateCommand();
                myCommand.CommandText = sql;
                myAdapter = new MySqlDataAdapter(myCommand);
                //DataSet mySet = new DataSet();
                //myAdapter.Fill(mySet, "selectDa");
                //myTable = mySet.Tables["selectDa"];
                myTable = new DataTable();
                myAdapter.Fill(myTable);
            }
            catch (Exception ex)
            {
                SetErrorMes(ex.Message);
                myTable = null;
            }
            myAutoResetEvent.Set();
            return myTable;
        }

        /// <summary>
        /// execute a query command with sql in MySqlParameter mode
        /// </summary>
        /// <param name="sql">your sql commod</param>
        /// <param name="yourParameter">MySqlParameter</param>
        /// <returns>the result with DataTable</returns>
        public DataTable ExecuteQuery(String sql, MySqlParameter[] yourParameter)
        {
            DataTable myTable;
            myAutoResetEvent.WaitOne();
            if (!ConnectDataBase())
            {
                SetErrorMes("can not connect MySqlDrive");
                myTable = null;
            }
            try
            {
                myCommand = myConnection.CreateCommand();
                myCommand.CommandText = sql;
                if (yourParameter != null)
                {
                    foreach (MySqlParameter tempParameter in yourParameter)
                    {
                        myCommand.Parameters.Add(tempParameter);
                    }
                }
                myAdapter = new MySqlDataAdapter(myCommand);
                DataSet mySet = new DataSet();
                myAdapter.Fill(mySet, "selectDa");
                myTable = mySet.Tables["selectDa"];
                myAutoResetEvent.Set();
                return myTable;
            }
            catch (Exception ex)
            {
                SetErrorMes(ex.Message);
                myTable = null;
            }
            myAutoResetEvent.Set();
            return myTable;
        }

        public DataTable ExecuteQuery(String sql, MySqlParameter yourParameter)
        {
            return ExecuteQuery(sql, new MySqlParameter[] { yourParameter });
        }


        /// <summary>
        /// only call it when you want drop it
        /// </summary>
        public void Dispose()
        {
            if (myConnection != null)
            {
                myConnection.Close();
                myConnection.Dispose();
            }
        }

        #endregion

    }
}
