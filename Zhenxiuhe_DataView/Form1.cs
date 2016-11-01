using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Zhenxiuhe_DataView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region myInfor
        private string data_source = "data source=61.191.190.161;user id=zhenxiuhe;pwd=A9sC9t1D;initial catalog=sqlzhenxiuhe;allow zero datetime=true;charset=gbk;";
        private string mySql_1 = "select * from pwn_dingcan_order";
        private int num = 0;
        private MySqlConnection myConnection;
        private MySqlCommand myCommand;
        private MySqlDataAdapter myAdapter;
        private MySqlTransaction myTransaction;
        private DataTable myTable;

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            myConnection = new MySqlConnection(data_source);
            myConnection.Open();
            //myAdapter.SelectCommand.CommandTimeout = 1200;
            myTable = new DataTable();
        }

        public DataTable executeQuery(String sql)
        {
            try
            {
                DataTable myTable;
                if (myConnection.State == ConnectionState.Broken || myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                myCommand = myConnection.CreateCommand();
                myCommand.CommandText = sql;
                myAdapter = new MySqlDataAdapter(myCommand);
                myAdapter.SelectCommand.CommandTimeout = 10000;
                using (DataSet mySet = new DataSet())
                {
                    myAdapter.Fill(mySet, "selectDa");
                    myTable = mySet.Tables["selectDa"];
                    return myTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return myTable;
            }
            finally
            {
                //return myTable;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = executeQuery(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = executeQuery("select * from pwn_dingcan_order where goodsmemo like  '%"+textBox2.Text+"%' and orderid > 143 and ifcheck=1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = executeQuery("select * from pwn_dingcan_order where address like  '%" + textBox3.Text + "%' and orderid > 143 and ifcheck=1");
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = executeQuery(" select address ,SUM(totalcost) from pwn_dingcan_order   where orderid > 143 and ifcheck=1 group by address");
        }  
    }
}
