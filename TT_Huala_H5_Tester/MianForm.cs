using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TT_Huala_H5_Tester
{
    public partial class MianForm : Form
    {
        public MianForm()
        {
            InitializeComponent();
        }

        private bool isDocumentCompletedLoad = false;

        private void MianForm_Load(object sender, EventArgs e)
        {
            //SetIeVer();
            //webBrowser_main.Navigate("http://xp.xiaxiaw.com/huala/v2/wi/index");

            webBrowser_main.DocumentCompleted += ((agr1, arg2) =>
            {
                isDocumentCompletedLoad = true;
            });

            DoTest1();
            //webBrowser_main.Navigate("http://xp.xiaxiaw.com/huala/v2/ws/s/562", null, null, "User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows Phone 8.0; Trident/6.0; IEMobile/10.0; ARM; Touch)");
        }


        private void DoTest1()
        {
            webBrowser_main.Navigate("http://xp.xiaxiaw.com/huala/v2/wi/index");
            HtmlDocument myHtmlDoc = webBrowser_main.Document;
            webBrowser_main.DocumentCompleted += ((agr1, arg2) => { 
                myHtmlDoc = webBrowser_main.Document;
                myHtmlDoc.GetElementById("relocation").Parent.Children[2].InvokeMember("Click"); 
                //myHtmlDoc.GetElementById("sellerList_sel").Children[0].Children[1].Children[0].InvokeMember("Click");
            });

            //myHtmlDoc.InvokeScript("go",new object[]{-1});
        }

        private void DoTest2()
        {
            webBrowser_main.Navigate("http://xp.xiaxiaw.com/huala/v2/wi/index");
            HtmlDocument myHtmlDoc = webBrowser_main.Document;
            webBrowser_main.DocumentCompleted += ((agr1, arg2) => 
            {
                myHtmlDoc = webBrowser_main.Document; 
                HtmlElement htmlEle = myHtmlDoc.Body.Children[0];
                htmlEle.InvokeMember("Click");
            });
        }

        private void DoTest3()
        {
            webBrowser_main.Navigate("http://xp.xiaxiaw.com/huala/loginpage?backUrl=http%3A%2F%2Fxp.xiaxiaw.com%2Fhuala%2Fv2%2Fwu%2Faddress%2Fadd%3FbackUrl%3D%2Fv2%2Fwm%2Frelocation");
            HtmlDocument myHtmlDoc = webBrowser_main.Document;
            webBrowser_main.DocumentCompleted += ((agr1, arg2) => { myHtmlDoc = webBrowser_main.Document; myHtmlDoc.GetElementById("phone").SetAttribute("value","15158155511"); myHtmlDoc.InvokeScript("sendCode"); });

        }


        private void SetIeVer()
        {
            int BrowserVer, RegVal;

            // get the installed IE version
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

            // set the appropriate IE version
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

            // set the actual key
            RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
            Key.Close();
        }
    }
}
