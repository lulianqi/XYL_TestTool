using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TT_Huala_OrderPay.MyTool
{
    class XylTool
    {
        /// <summary>
        /// i can find the value you need in the json
        /// </summary>
        /// <param name="yourTarget">the key you want get</param>
        /// <param name="yourSouce">the json Souce</param>
        /// <returns>back value</returns>
        public static string PickJsonParameter(string yourTarget, string yourSouce)
        {
            string tempTarget = "\"" + yourTarget + "\"";
            string myJsonBack;
            if (!yourSouce.Contains(tempTarget))
            {
                return null;
            }

            //i will start
            try
            {
                if (yourSouce.StartsWith("["))
                {
                    JArray jAObj = (JArray)JsonConvert.DeserializeObject(yourSouce);
                    for (int i = 0; i < jAObj.Count; i++)
                    {
                        JObject jObj = (JObject)jAObj[i];
                        if (jObj[yourTarget] != null)
                        {
                            return jObj[yourTarget].ToString();
                        }
                    }
                    return null;
                }
                else if (yourSouce.StartsWith("{"))
                {
                    JObject jObj = (JObject)JsonConvert.DeserializeObject(yourSouce);
                    if (jObj[yourTarget] == null)
                    {
                        return null;
                    }
                    else
                    {
                        myJsonBack = jObj[yourTarget].ToString();
                    }
                    return myJsonBack;
                }
            }

            catch (Exception ex)
            {
                MyCommonTool.ErrorLog.PutInLog("ID:0243 " + ex.Message);
            }
            return null;
        }


        public static bool GetScanPayOrderList(string yourSouce ,out List<string[]> scanPayOrderList)
        {
            scanPayOrderList = new List<string[]>();
            try
            {
                if (yourSouce.StartsWith("["))
                {
                    JArray jAObj = (JArray)JsonConvert.DeserializeObject(yourSouce);
                    for (int i = 0; i < jAObj.Count; i++)
                    {
                        JObject jObj = (JObject)jAObj[i];
                        scanPayOrderList.Add(new string[] { jObj["sellerId"].ToString(), jObj["userId"].ToString(), jObj["mobile"].ToString(), jObj["goodAmount"].ToString(), jObj["orderAmount"].ToString(), jObj["orderSn"].ToString(), jObj["payType"].ToString(), jObj["referer"].ToString(),"" });
                    }
                    return true;
                }
                else
                {
                    MyCommonTool.ErrorLog.PutInLog("ID:0083 " + yourSouce);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MyCommonTool.ErrorLog.PutInLog("ID:0056 " + ex.Message + "\r\n" + yourSouce);
                return false;
            }
        }

        //public string[] GetStrPickData(string yourSouce, string startTarget, string endTarget)
        //{
        //    if (yourSouce != null && startTarget != null && endTarget!=null)
        //    if (yourSouce.Contains("-"))
        //    {
        //        yourTarget = yourSouce.Remove(yourSouce.LastIndexOf("-"));
        //        try
        //        {
        //            yourStrLen = int.Parse(yourSouce.Remove(0, yourSouce.LastIndexOf("-") + 1));
        //        }
        //        catch
        //        {
        //            yourTarget = null;
        //        }
        //    }
        //}
    }
}
