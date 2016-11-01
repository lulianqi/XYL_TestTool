using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using SpeechLib;

namespace zhenxiuhe_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region myInfor
        private string data_source = "data source=61.191.190.161;user id=zhenxiuhe;pwd=A9sC9t1D;initial catalog=sqlzhenxiuhe;allow zero datetime=true";
        private string mySql_1 = "select * from pwn_dingcan_order";
        private int num = 0;
        private MySqlConnection myConnection;
        private MySqlCommand myCommand;
        private MySqlDataAdapter myAdapter;
        private MySqlTransaction myTransaction;
        private DataTable myTable;

        private static string read_text = "";
        static SpVoiceClass voic = new SpVoiceClass();

        #endregion

       
        #region 系统API

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        const uint WM_APPCOMMAND = 0x319;
        const uint APPCOMMAND_VOLUME_UP = 0x0a;
        const uint APPCOMMAND_VOLUME_DOWN = 0x09;
        const uint APPCOMMAND_VOLUME_MUTE = 0x08; 

        #endregion

        public System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        

        public class BeepUp   
        {   
        /// <param name="iFrequency">声音频率（从37Hz到32767Hz）。在windows95中忽略</param>   
        /// <param name="iDuration">声音的持续时间，以毫秒为单位。</param>   
        [DllImport("Kernel32.dll")] //引入命名空间 using System.Runtime.InteropServices;   
        public static extern bool Beep(int frequency, int duration);   
        }   
  



        private void Form1_Load(object sender, EventArgs e)
        {

            voic.Voice = voic.GetVoices(null, null).Item(0);
            voic.Volume = 100;

            //BeepUp.Beep(5000,1700);
            //MyThread_Beed.Start();
            // 连接
            myConnection = new MySqlConnection(data_source);
            myConnection.Open();
            myTable = new DataTable();
            //myConnection.Close();

            myTable = executeQuery(mySql_1);
            num = myTable.Rows.Count;

            myTimer.Interval = 8000;
            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Start();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            myConnection.Close();
        }

        public DataTable executeQuery(String sql)
        {
            DataTable myTable;
            //try
            {
                myCommand = myConnection.CreateCommand();
                myCommand.CommandText = sql;
                myAdapter = new MySqlDataAdapter(myCommand);
                DataSet mySet = new DataSet();
                myAdapter.Fill(mySet, "selectDa");
                myTable = mySet.Tables["selectDa"];
                return myTable;
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    myTable = new DataTable();
            //    MessageBox.Show("数据发生错误！");
            //    return myTable;
            //}
        }  


        void myTimer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                myTable = executeQuery(mySql_1);
                if (num != myTable.Rows.Count)
                {
                    read_text = ReadOrder(myTable, num);
                    Thread MyThread_Beed = new Thread(new ThreadStart(Beep));
                    MyThread_Beed.Start();

                    #region 界面
                    try
                    {
                        string fwq = myTable.Rows[num]["zoneid"].ToString();
                        string myInfor = "耗时:"+System.DateTime.Now.Hour.ToString()+":"+System.DateTime.Now.Minute.ToString() + myTable.Rows[num]["OrderNo"].ToString() + "   " + myTable.Rows[num]["cname"].ToString();
                        switch (fwq)
                        {
                            case "58":
                                checkedListBox3.Items.Add(new CheckBox());
                                checkedListBox3.Items[checkedListBox3.Items.Count - 1] = myInfor;
                                break;
                            case "51":
                                checkedListBox1.Items.Add(new CheckBox());
                                checkedListBox1.Items[checkedListBox3.Items.Count - 1] = myInfor;
                                break;
                            case "52":
                                checkedListBox4.Items.Add(new CheckBox());
                                checkedListBox4.Items[checkedListBox3.Items.Count - 1] = myInfor;
                                break;
                            case "55":
                                checkedListBox2.Items.Add(new CheckBox());
                                checkedListBox2.Items[checkedListBox3.Items.Count - 1] = myInfor;
                                break;
                            default:
                                checkedListBox5.Items.Add(new CheckBox());
                                checkedListBox5.Items[checkedListBox3.Items.Count - 1] = myInfor;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        richTextBox1.Text += ex.ToString();
                    }
                    #endregion
            
                    num++;
                }
            }
            catch (Exception ex)
            {
                //if (myConnection.State == ConnectionState.Broken || myConnection.State == ConnectionState.Closed)
                {
                    try
                    {
                        myConnection = new MySqlConnection(data_source);
                        myConnection.Open();
                    }
                    catch
                    {
                        BeepUp.Beep(1600, 500);
                        BeepUp.Beep(1600, 500);
                        BeepUp.Beep(1600, 500);
                        voic.Speak("连接中断", SpeechVoiceSpeakFlags.SVSFDefault);
                    }
                }
                richTextBox1.Text += ex.ToString();
            }

        }

        private bool OpenConn()
        {
            bool isOk = false;
            //while (!isOk)
            {
                BeepUp.Beep(16000, 500);   
                try
                {
                    myConnection.Open();
                }
                catch (Exception ex)
                {
                    richTextBox1.Text += ex.ToString();
                }

                if (myConnection.State == ConnectionState.Open)
                {
                    isOk = true;
                }
            }
            return isOk;
        }

        //58- 华城 51 二医 52 楚天 55 地下
        private void NewOrder(DataTable dt, int row)
        {
           string fwq = dt.Rows[row]["zoneid"].ToString();
           switch (fwq)
           {
               case "56":
                   //checkedListBox2.
                   break;
                   
           }
        }

        private string ReadOrder(DataTable dt, int row)
        {
            string fwq = dt.Rows[row]["zoneid"].ToString();
            string fwq_read = "";
            switch (fwq)
            {
                case "58":
                    fwq_read = "华城豪庭";
                    break;
                case "51":
                    fwq_read = "荆州二医";
                    break;
                case "52":
                    fwq_read = "楚天明珠";
                    break;
                case "55":
                    fwq_read = "地下商城";
                    break;
                default:
                    fwq_read = "未知区域";
                    break;
            }
            string address = dt.Rows[row]["address"].ToString();
            string goods = dt.Rows[row]["goodsmemo"].ToString();
            //string goods_read=goods.Remove(
           // voic.Speak("新到订单,服务区," + fwq_read + ",,地址," + address + ",,订单内容" + goods, SpeechVoiceSpeakFlags.SVSFDefault);
            return "新到订单,服务区," + fwq_read + ",,地址," + address + ",,订单内容" + goods;
        }



        public static void Beep()
        {
            try
            {
                BeepUp.Beep(9000, 1500);
                voic.Speak(read_text, SpeechVoiceSpeakFlags.SVSFDefault);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        #region DotNetBar
        private void buttonItem1_Click(object sender, EventArgs e)
        {

            voic.Speak("珍馐盒 ,千秋万代 ,永垂不朽", SpeechVoiceSpeakFlags.SVSFDefault);
        }
        
        private void office2007StartButton1_Click(object sender, EventArgs e)
        {
           // SendMessage(this.Handle, WM_APPCOMMAND, 0x30292, APPCOMMAND_VOLUME_UP * 0x10000);
            checkedListBox3.Items.Add(new CheckBox());
            checkedListBox3.Items[checkedListBox3.Items.Count - 1] = "cnm";
        }
        #endregion




    }
}
