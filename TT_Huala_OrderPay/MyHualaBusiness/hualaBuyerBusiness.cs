using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TT_Huala_OrderPay.MyTool;

namespace TT_Huala_OrderPay.MyHualaBusiness
{
    class HualaBuyerBusiness : IDisposable
    {
        private string buyerName;
        private string buyerPwd;
        private string buyerCookie;
        private string buyerId;


        public string BuyerName
        {
            get
            {
                return buyerName;
            }
        }

        public string BuyPwd
        {
            get
            {
                return buyerPwd;
            }
        }

        public string BuyerId
        {
            get
            {
                return buyerId;
            }
        }

        public HualaBuyerBusiness (string name,string pwd)
        {
            buyerName = name;
            buyerPwd = pwd;
        }

        public bool Login()
        {
            string tempRqs = MyCommonTool.myWebTool.myHttp.SendData(string.Format("http://60.191.67.200/huala/seller/login/{0}/{1}", buyerName, buyerPwd), null, "GET");
            buyerCookie = XylTool.PickJsonParameter("token", tempRqs);
            if (buyerCookie == null)
            {
                return false;
            }
            buyerId = XylTool.PickJsonParameter("id", tempRqs);
            return true;
        }

        /// <summary>
        /// 开始采购
        /// </summary>
        /// <param name="order_sn"></param>
        /// <param name="outMes"></param>
        /// <returns></returns>
        public bool StartBuy(string order_sn,out string outMes)
        {
            string tempRqs = MyCommonTool.myWebTool.myHttp.SendData("http://60.191.67.200/huala/seller/order/update_order_status", string.Format("orderSn={0}&shippingType=0&type=7&userId={1}", order_sn, buyerId), "POST", "token=" + buyerCookie);
            if ("{\"success\":true}" == tempRqs)
            {
                outMes = string.Format("Order:[{0}] > hualaBuyer StartBuy sucess", order_sn);
            }
            else
            {
                outMes = string.Format("Order:[{0}] > hualaBuyer StartBuy fial", order_sn);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 采购员确认有货
        /// </summary>
        /// <param name="order_sn"></param>
        /// <param name="subIdList"></param>
        /// <param name="outMes"></param>
        /// <returns></returns>
        public bool ConfirmGoods(string order_sn, List<string> subIdList, out string outMes)
        {
            if (subIdList == null)
            {
                outMes = string.Format("Order:[{0}] > ConfirmGoods subIdList is null", order_sn);
                return false;
            }
            outMes = "";
            foreach (string subId in subIdList)
            {
                string tempRqs = MyCommonTool.myWebTool.myHttp.SendData("http://60.191.67.200/huala/seller/order/update_order_status", string.Format("orderSn={0}&subId={1}&type=8&userId={2}", order_sn, subId, buyerId), "POST", "token=" + buyerCookie);
                if ("{\"body\":\"purchaseFinish\",\"success\":true}" == tempRqs)
                {
                    outMes += string.Format("Order:[{0}] > Goods [{1}] prepare sucess", order_sn, subId)+"\r\n";
                }
                else
                {
                    outMes = string.Format("Order:[{0}] > Goods [{1}] prepare fial", order_sn, subId);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 配送至店
        /// </summary>
        /// <param name="order_sn"></param>
        /// <param name="outMes"></param>
        /// <returns></returns>
        public bool PostToShop(string order_sn, out string outMes)
        {
            string tempRqs = MyCommonTool.myWebTool.myHttp.SendData("http://60.191.67.200/huala/seller/order/update_order_status", string.Format("orderSn={0}&shippingType=0&type=9&userId={1}", order_sn, buyerId), "POST", "token=" + buyerCookie);
            if ("{\"success\":true}" == tempRqs)
            {
                outMes = string.Format("Order:[{0}] > hualaBuyer StartBuy sucess", order_sn);
            }
            else
            {
                outMes = string.Format("Order:[{0}] > hualaBuyer StartBuy fial", order_sn);
                return false;
            }
            return true;
        }


        public void Dispose()
        {
            
        }
    }
}
