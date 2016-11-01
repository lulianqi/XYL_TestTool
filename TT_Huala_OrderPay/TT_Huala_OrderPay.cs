﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using TT_Huala_OrderPay.MyTool;
using TT_Huala_OrderPay.MyHualaBusiness;
using MyCommonTool;

namespace TT_Huala_OrderPay
{
    public partial class TT_Huala_OrderPay : Form
    {
        public TT_Huala_OrderPay()
        {
            InitializeComponent();
            //mySqlDrive = new MySqlDrive("Server=192.168.200.152;UserId=root;Password=xpsh;Database=huala_test");
            cb_postType.SelectedIndex = 0;
            mySqlDrive = new MySqlDrive(mySqlConnStr);
            mySqlDrive.OnGetErrorMessage += mySqlDrive_OnGetErrorMessage;
            mySqlDrive.OnDriveStateChange += mySqlDrive_OnDriveStateChange;
            mySqlDrive.ConnectDataBase();
        }


        #region field
        MySqlDrive mySqlDrive;
        MyAliveTask.MyHttpTask myTs;
        HualaBuyerBusiness myHualaBuyerBusiness;
        string mySqlConnStr = "data source=192.168.200.152;user id=root;pwd=xpsh;initial catalog=huala_test;allow zero datetime=true ;pooling=false; charset=utf8";
        string defaultUrl = "wxtest.huala.com:8081"; //"wxtest.huala.com";

        static class TaskVaules
        {
            public static int checkTime = 1000;
            public static int operateDelay = 1000;
            public static string shopUserName = "shop";
            public static string shopUserPwd = "shop";
            public static string shopCookie = "hltoken=08c0bb10-1e31-4eed-8b21-48bc0976c39a";
            public static string consignee = "李杰";
            public static string orderMobile = "15158155511";
            public static string seller_id = "542";
            public static string shippingType = "0";
        }
        #endregion

        #region MyFun

        public void PauseAllTask()
        {
            cb_AutoPay.Checked = false;
            cb_AutoShopPost.Checked = false;
        }

        public void CreatRefushScanOrderTast()
        {
            myTs = new MyAliveTask.MyHttpTask("RefushScanOrderTast", string.Format("http://{0}/huala/scan_order_list", defaultUrl), 2000);
            myTs.OnPutOutData += myTs_OnPutOutData;
        }

        public void StartRefushScanOrderTast()
        {
            myTs.StartTask();
        }

        public void StopRefushScanOrderTast()
        {
            myTs.StopTask();
        }

        public void CreatPayOrderTask()
        {
            //DataTable tempTable = mySqlDrive.ExecuteQuery("select * from h_order  where consignee ='李杰1' and order_status='no_pay' order by add_time desc");
            mySqlDrive.CreateNewAliveTask("GetNoPayOrder", string.Format("select * from h_order  where mobile ='{0}' and order_status='no_pay' order by add_time desc", TaskVaules.orderMobile), TaskVaules.checkTime, GetNoPayOrder_OnNewMes);
            //mySqlDrive.StartAliveTask("GetNoPayOrder");
        }

        public void CreatShopPostTask()
        {
            //SELECT * FROM h_order WHERE consignee='李杰' and order_status='have_pay'
            mySqlDrive.CreateNewAliveTask("GetNoPostOrder", string.Format("select hso.order_id orderId,hso.order_sn,hso.mobile,hso.consignee,hso.address,hso.pay_note payNote,hso.best_time bestTime,hso.order_sn orderSn,hso.pay_time payTime,hso.shipping_type,hso.marker,(select data_value from t_dirt where dirt_key = 'order_status' and data_key = hso.order_status) as orderStatus,hso.pay_amount payAmount,(select count(1) from h_seller_order_details where sel_order_id = hso.id and order_status = 'purchase_return') as isReturn from h_seller_order hso where hso.seller_id = {0}  and hso.order_status = 'have_pay' order by hso.id desc limit 0,10", TaskVaules.seller_id), TaskVaules.checkTime, GetNoShopPost_OnNewMes);
            //mySqlDrive.StartAliveTask("GetNoPostOrder");
        }

        public void StartPayOrder()
        {
            TaskVaules.orderMobile = tb_name.Text;
            tb_name.Enabled = false;
            mySqlDrive.UpdateAliveTaskSqlCmd("GetNoPayOrder", string.Format("select * from h_order  where mobile ='{0}' and order_status='no_pay' order by add_time desc", TaskVaules.orderMobile));
            mySqlDrive.StartAliveTask("GetNoPayOrder");
            PutRunInfo("GetNoPayOrder Start");
        }

        public void StopPayOrder()
        {
            tb_name.Enabled = true;
            mySqlDrive.StopAliveTask("GetNoPayOrder");
            PutRunInfo("GetNoPayOrder Stop");
        }

        public void StartShopPost()
        {
            TaskVaules.shopUserName = tb_shopName.Text;
            TaskVaules.shopUserPwd = tb_shopPwd.Text; ;
            TaskVaules.shopCookie = string.Format("hltoken={0}",tb_shopToken.Text);
            TaskVaules.seller_id = tb_sellerId.Text;
            TaskVaules.shippingType = cb_postType.SelectedIndex.ToString();

            tb_shopName.Enabled = tb_shopPwd.Enabled = tb_shopToken.Enabled = tb_sellerId.Enabled = cb_postType.Enabled = false;
            mySqlDrive.UpdateAliveTaskSqlCmd("GetNoPostOrder", string.Format("select hso.order_id orderId,hso.order_sn,hso.mobile,hso.consignee,hso.address,hso.pay_note payNote,hso.best_time bestTime,hso.order_sn orderSn,hso.pay_time payTime,hso.shipping_type,hso.marker,(select data_value from t_dirt where dirt_key = 'order_status' and data_key = hso.order_status) as orderStatus,hso.pay_amount payAmount,(select count(1) from h_seller_order_details where sel_order_id = hso.id and order_status = 'purchase_return') as isReturn from h_seller_order hso where hso.seller_id = {0}  and hso.order_status = 'have_pay' order by hso.id desc limit 0,10", TaskVaules.seller_id));
            mySqlDrive.StartAliveTask("GetNoPostOrder");
            PutRunInfo("GetNoPostOrder Start");

        }

        public void StopShopPost()
        {
            tb_shopName.Enabled = tb_shopPwd.Enabled = tb_shopToken.Enabled = tb_sellerId.Enabled = cb_postType.Enabled = true;
            mySqlDrive.StopAliveTask("GetNoPostOrder");
            PutRunInfo("GetNoPostOrder Stop");
        }

        //支付
        private void GetNoPayOrder_OnNewMes(object sender, DataTable dataTable)
        {
            if (dataTable == null)
            {
                GetRunError("this [ ExecuteQuery ] is fail");
            }
            else
            {
                string[] order_sn = GetNewOrders(dataTable);
                if (order_sn != null)
                {
                    for (int i = 0; i < order_sn.Length; i++)
                    {
                        if (!PayOrder(order_sn[i]))
                        {
                            GetRunError("[PayOrder] fail");
                        }
                    }
                }
                else
                {
                    GetRunError("null data");
                }
            }
        }

        //配送
        private void GetNoShopPost_OnNewMes(object sender, DataTable dataTable)
        {
            if (dataTable == null)
            {
                GetRunError("this [ ExecuteQuery ] is fail");
            }
            else
            {
                string[] order_sn = GetNewOrders(dataTable);
                if (order_sn != null)
                {
                    for (int i = 0; i < order_sn.Length; i++)
                    {
                        if (!PostShopOrder(order_sn[i]))
                        {
                            GetRunError("[PostShopOrder] fail");
                        }
                    }
                }
                else
                {
                    GetRunError("null data");
                }
            }
        }

        /// <summary>
        /// if you get or catch a error ,just put it here
        /// </summary>
        /// <param name="errorMes">error content</param>
        public void FindApplicationError(string errorMes)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(FindApplicationError), errorMes);
            }
            else
            {
                MessageBox.Show(errorMes, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void GetRunError(string errorMes)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(GetRunError), errorMes);
            }
            else
            {
                dataRecordBox_MesInfo.AddDate(errorMes, Color.Red, true);
            }
        }

        public void PutRunInfo(string infoMes)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(PutRunInfo), infoMes);
            }
            else
            {
                dataRecordBox_MesInfo.AddDate(infoMes, Color.Black, true);
            }
        }

        private string[] myOldScanOrderSnList = new string[0];

        public void RefreshScanOederSn(List<string[]> souceData)
        {
            
            if (souceData != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<List<string[]>>(RefreshScanOederSn), souceData);
                }
                else
                {
                    myCommonTool.SetControlFreeze(lv_orderSnList);
                    lv_orderSnList.ClearEx();
                    foreach (var tempSnVal in souceData)
                    {
                        ListViewItem tempLvi = new ListViewItem(tempSnVal);
                        tempLvi.Tag = new Button();
                        ((Button)tempLvi.Tag).Text = "支付";
                        lv_orderSnList.AddItemEx(tempLvi);
                    }
                    myCommonTool.SetControlUnfreeze(lv_orderSnList);
                }
            }
            
            
        }

        public string[] GetNewOrders(DataTable OrdersDataTable)
        {
            if(OrdersDataTable!=null)
            {
                if(OrdersDataTable.Rows.Count>0)
                {
                    //string[] NewOrderNames = new string[OrdersDataTable.Rows.Count];
                    List<string> tempNameList = new List<string>();
                    foreach (DataRow tempRaw in OrdersDataTable.Rows)
                    {
                        tempNameList.Add(tempRaw["order_sn"].ToString());
                    }
                    return tempNameList.ToArray<string>();
                }
            }
            return null;
        }

        /// <summary>
        /// pay the order
        /// </summary>
        /// <param name="yourOrderName">order ID</param>
        /// <returns>is sucess</returns>
        public bool PayOrder(string yourOrderName)
        {
            //Thread.Sleep(TaskVaules.operateDelay);
            //http://xp.xiaxiaw.com/huala/v2/wo/paytest/
            string tempRqs = MyCommonTool.myWebTool.myHttp.SendData("http://" + defaultUrl + "/huala/paytest/" + yourOrderName + "/1", null, "GET");
            if (tempRqs == "{\"success\":true}")
            {
                PutRunInfo(string.Format("Order:[{0}] pay sucess", yourOrderName));
                return true;
            }
            else
            {
                PutRunInfo(string.Format("Order:[{0}] pay fail", yourOrderName));
                PutRunInfo(tempRqs);
                return false;
            }
        }

        /// <summary>
        /// 支付扫码订单
        /// </summary>
        /// <param name="yourOrderName"></param>
        /// <returns></returns>
        public bool PayScanOrder(string yourOrderName)
        {
            string tempRqs = MyCommonTool.myWebTool.myHttp.SendData("http://" + defaultUrl + "/huala/scanpaytest/" + yourOrderName , null, "GET");
            if (tempRqs == "{\"success\":true}")
            {
                PutRunInfo(string.Format("Order:[{0}] pay sucess", yourOrderName));
                return true;
            }
            else
            {
                PutRunInfo(string.Format("Order:[{0}] pay fail", yourOrderName));
                PutRunInfo(tempRqs);
                return false;
            }
        }

        /// <summary>
        /// Post Order
        /// </summary>
        /// <param name="yourOrderSn">Order Name</param>
        /// <returns>is ok</returns>
        public bool PostShopOrder(string yourOrderSn)
        {
            //DataTable tempSupermarketOrderGoods = mySqlDrive.ExecuteQuery(string.Format("SELECT *FROM h_seller_order_details d WHERE d.sel_order_id IN (SELECT id FROM h_seller_order o WHERE o.order_id IN (SELECT id FROM h_order h WHERE h.order_sn = '{0}') and d.remark =2)", yourOrderSn));
            DataTable tempOrderGoods = mySqlDrive.ExecuteQuery(string.Format("SELECT *FROM h_seller_order_details d WHERE d.sel_order_id IN (SELECT id FROM h_seller_order o WHERE o.order_id IN (SELECT id FROM h_order h WHERE h.order_sn = '{0}'))",yourOrderSn));
            if (tempOrderGoods != null)
            {
                if (tempOrderGoods.Rows.Count > 0)
                {
                    string tempRqs;
                    bool isHaveSupermarketGoods = false;
                    List<KeyValuePair<string, string>> supermarketGoodsPostList = new List<KeyValuePair<string, string>>();
                    

                    List<string> subIdList = new List<string>();
                    foreach (DataRow tempRaw in tempOrderGoods.Rows)
                    {
                        subIdList.Add(tempRaw["id"].ToString());
                        //if (tempRaw["remark"].ToString() == "2" && tempRaw["user_id"].ToString() == "")  //remark is 2 mean the goods is in supermaket ,and user_id is null mean no cg deal it
                        if (tempRaw["remark"].ToString() == "2")
                        {
                            //isHaveSupermarketGoods = true;//【暂时不使用下面的方法进行采购员配送，如果需要使用去掉注释】
                            if (tempRaw["user_id"].ToString() == "")
                            {
                                PutRunInfo(string.Format("Order:[{0}] > Goods [{1}] not have buyer so can not Post it", yourOrderSn, tempRaw["id"]));
                                return false;
                            }
                            else if (tempRaw["order_status"].ToString() == "no_purchase")
                            {
                                PutRunInfo(string.Format("Order:[{0}] > Goods [{1}] will be post by buyer [{2}]", yourOrderSn, tempRaw["id"], tempRaw["user_id"].ToString()));
                                supermarketGoodsPostList.Add(new KeyValuePair<string, string>(tempRaw["id"].ToString(), tempRaw["user_id"].ToString()));
                            }
                        }
                    }

                    //采购员采购超市商品
                    if (isHaveSupermarketGoods)
                    {
                        bool isHaveBuyer = false;

                        foreach(KeyValuePair<string,string> tempKvp in supermarketGoodsPostList)
                        {
                            if(myHualaBuyerBusiness.BuyerId==tempKvp.Value)
                            {
                                isHaveBuyer = true;
                                break;
                            }
                        }
                        if(isHaveBuyer)
                        {
                            string outMes;
                            List<string> supermarketSubIds = new List<string>();
                            for (int i = supermarketGoodsPostList.Count - 1; i >= 0;i-- )
                            {
                                if(supermarketGoodsPostList[i].Value==myHualaBuyerBusiness.BuyerId)
                                {
                                    supermarketSubIds.Add(supermarketGoodsPostList[i].Key);
                                    supermarketGoodsPostList.RemoveAt(i);
                                }
                            }

                            //开始采购_采购员处理
                            if (myHualaBuyerBusiness.StartBuy(yourOrderSn, out outMes))
                            {
                                PutRunInfo(string.Format("Order:[{0}] > [StartBuy] => {1}", yourOrderSn, outMes));
                            }
                            else
                            {
                                GetRunError(string.Format("Order:[{0}] > [StartBuy] => {1}", yourOrderSn, outMes));
                                return false;
                            }
                            //确认有货_采购员处理
                            if (myHualaBuyerBusiness.ConfirmGoods(yourOrderSn, supermarketSubIds, out outMes))
                            {
                                PutRunInfo(string.Format(outMes));
                            }
                            else
                            {
                                GetRunError(string.Format("Order:[{0}] > [ConfirmGoods] => {1}", yourOrderSn, outMes));
                                return false;
                            }
                            //配送到小店_采购员处理
                            if(myHualaBuyerBusiness.PostToShop(yourOrderSn, out outMes))
                            {
                                PutRunInfo(string.Format(outMes));
                            }
                            else
                            {
                                GetRunError(string.Format("Order:[{0}] > [PostToShop] => {1}", yourOrderSn, outMes));
                                return false;
                            }
                        }

                        if(supermarketGoodsPostList.Count>0)
                        {
                            GetRunError(string.Format("Order:[{0}] > some goods not be posted ", yourOrderSn));
                            return false;
                        }
                    }

                    //备货_店铺处理
                    foreach (string subId in subIdList)
                    {
                        Thread.Sleep(TaskVaules.operateDelay);
                        tempRqs = MyCommonTool.myWebTool.myHttp.SendData(string.Format("http://{0}/huala/seller/order/update_order_status?orderSn={1}&sellerId={2}&shippingType=0&type=2&subId={3}",defaultUrl,yourOrderSn, TaskVaules.seller_id, subId), null, "POST", TaskVaules.shopCookie);
                        if ("{\"success\":true}" == tempRqs)
                        {
                            PutRunInfo(string.Format("Order:[{0}] > Goods [{1}] prepare sucess", yourOrderSn, subId));
                        }
                        else
                        {
                            PutRunInfo(string.Format("Order:[{0}] > Goods [{1}] prepare fial", yourOrderSn, subId));
                            PutRunInfo(tempRqs);
                        }
                    }
                    //派送_店铺处理
                    tempRqs = MyCommonTool.myWebTool.myHttp.SendData(string.Format("http://{0}/huala/seller/order/update_order_status?orderSn={1}&sellerId={2}&shippingType={3}&type=1", defaultUrl, yourOrderSn, TaskVaules.seller_id, TaskVaules.shippingType), null, "POST", TaskVaules.shopCookie);
                    if ("{\"success\":true}" == tempRqs)
                    {
                        PutRunInfo(string.Format("Order:[{0}] > post sucess", yourOrderSn));
                        //商家确认收货_店铺处理
                        if (cb_SellerAffirm.Checked)
                        {
                            tempRqs = MyCommonTool.myWebTool.myHttp.SendData(string.Format("http://{0}/huala/seller/order/update_order_status?orderSn={1}&sellerId={2}&shippingType={3}&type=4", defaultUrl, yourOrderSn, TaskVaules.seller_id, TaskVaules.shippingType), null, "POST", TaskVaules.shopCookie);
                            if ("{\"success\":true}" == tempRqs)
                            {
                                PutRunInfo(string.Format("Order:[{0}] > seller sure sucess", yourOrderSn ));
                            }
                            else
                            {
                                PutRunInfo(string.Format("Order:[{0}] >  seller sure fial", yourOrderSn));
                                PutRunInfo(tempRqs);
                            }
                        }
                        return true;
                    }
                    else
                    {
                        PutRunInfo(string.Format("Order:[{0}] > post fial", yourOrderSn));
                        PutRunInfo(tempRqs);
                        return false;
                    }
                }
            }
            else
            {
                PutRunInfo(string.Format("Order:[{0}] not find any goods", yourOrderSn));
                return false;
            }
            return true;
        }

        #endregion
       


        private void TT_Huala_OrderPay_Load(object sender, EventArgs e)
        {
            CreatPayOrderTask();
            Thread.Sleep(100);
            CreatShopPostTask();
            CreatRefushScanOrderTast();
            
        }

        void mySqlDrive_OnDriveStateChange(object sender, bool isCounect)
        {
            if (isCounect)
            {
                PutRunInfo("MySqlDrive connect sucess");
            }
            else
            {
                PutRunInfo("MySqlDrive connect fail");
                if(this.InvokeRequired)
                {
                    //this.Invoke(new Action(() => { cb_AutoPay.Checked = false; }));
                    this.Invoke(new Action(PauseAllTask));
                }
                else
                {
                    PauseAllTask();
                }
            }
        }

        void mySqlDrive_OnGetErrorMessage(object sender, string ErrorMessage)
        {
            GetRunError(ErrorMessage);
        }


        private void TT_Huala_OrderPay_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void TT_Huala_OrderPay_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void bt_shopLogin_Click(object sender, EventArgs e)
        {
            string tempRqs = MyCommonTool.myWebTool.myHttp.SendData(string.Format("http://{0}/huala/seller/login/{1}/{2}", defaultUrl, tb_shopName.Text, tb_shopPwd.Text), null, "GET");
            try
            {
                string sellerId = XylTool.PickJsonParameter("sellerId", XylTool.PickJsonParameter("sellerList", XylTool.PickJsonParameter("body", tempRqs)));
                string cookie = XylTool.PickJsonParameter("token", tempRqs);
                tb_sellerId.Text = sellerId;
                tb_shopToken.Text = cookie;
            }
            catch
            {
                FindApplicationError("login fail");
            }
        }

        private void bt_buyer_login_Click(object sender, EventArgs e)
        {
            if(myHualaBuyerBusiness!=null)
            {
                myHualaBuyerBusiness.Dispose();
                myHualaBuyerBusiness = null;
            }
            myHualaBuyerBusiness = new HualaBuyerBusiness(tb_buyer_name.Text, tb_buyer_pwd.Text);
            if(myHualaBuyerBusiness.Login())
            {
                PutRunInfo("Login sucess");
            }
            else
            {
                GetRunError("Login fial");
            }
        }

        private void bt_test_Click(object sender, EventArgs e)
        {
            MyAliveTask.MyHttpTask myTs = new MyAliveTask.MyHttpTask("New", "http://wxtest.huala.com:8081/huala/scan_order_list", 1000);
            myTs.OnPutOutData += myTs_OnPutOutData;
            myTs.StartTask();
        }

        private void bt_scanOrder_Click(object sender, EventArgs e)
        {
            string tempRqs = MyCommonTool.myWebTool.myHttp.SendData(string.Format("http://{0}/huala/scan_order_list", defaultUrl), null, "GET");
            myTs_OnPutOutData(null, tempRqs);
        }

        void myTs_OnPutOutData(object sender, string outMes)
        {
            //PutRunInfo(outMes);
            List<string[]> mySnList;
            if(XylTool.GetScanPayOrderList(outMes, out mySnList))
            {
                //自动支付扫码订单
                if(ck_antoSacnPay.Checked)
                {
                    foreach(var tempScanPayOrder in mySnList)
                    {
                        if (tempScanPayOrder[1] == tb_scanUserId.Text || tb_scanUserId.Text=="")
                        {
                            PayScanOrder(tempScanPayOrder[5]);
                        }
                    }
                }
                string[] nowScanOrderSnList = mySnList.MyGetAppointArray(5);
                List<string> orderAdd, orderdel;
                if (!myCommonTool.IsMyArrayIndexSame(myOldScanOrderSnList, nowScanOrderSnList, out orderAdd, out orderdel))
                {
                    myOldScanOrderSnList = nowScanOrderSnList;
                    RefreshScanOederSn(mySnList);
                }
            }
            else
            {
                GetRunError("获取扫码订单列表错误");
            }
        }

        private void cb_AutoPay_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_AutoPay.Checked)
            {
                StartPayOrder();
            }
            else
            {
                StopPayOrder();
            }
        }

        private void cb_AutoShopPost_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_AutoShopPost.Checked)
            {
                StartShopPost();
            }
            else
            {
                StopShopPost();
            }
        }

        private void lv_orderSnList_ButtonClickEvent(object sender, EventArgs e)
        {
            if(sender is ListViewItem)
            {
                if(PayScanOrder(((ListViewItem)sender).SubItems[5].Text))
                {
                    MessageBox.Show("完成支付");
                }
                else
                {
                    MessageBox.Show("支付失败");
                }
            }
        }
        private void ck_antoRefush_CheckedChanged(object sender, EventArgs e)
        {
            if(ck_antoRefush.Checked)
            {
                StartRefushScanOrderTast();
            }
            else
            {
                StopRefushScanOrderTast();
            }
        
        }
        private void TT_Huala_OrderPay_Resize(object sender, EventArgs e)
        {
            dataRecordBox_MesInfo.Width = this.Width - 211;
            lv_orderSnList.Width = this.Width - 211;
            lv_orderSnList.Height = this.Height - 358;
        }

       
       

    }
}