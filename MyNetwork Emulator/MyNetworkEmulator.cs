using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using NetworkEmulator;

namespace MyNetwork_Emulator
{
    public partial class MyNetworkEmulator : Form
    {
        public MyNetworkEmulator()
        {
            InitializeComponent();
        }


        NetworkEmulatorDriver myNetworkEmulatorDriver;


        private void MyNetworkEmulator_Load(object sender, EventArgs e)
        {
            //TestCom test = new TestCom();
            //test.TestAPI();
            //test.testLoadFromProfile();

            
            myNetworkEmulatorDriver = new NetworkEmulatorDriver();
            myNetworkEmulatorDriver.OnGetErrorMessage += myNetworkEmulatorDriver_OnGetErrorMessage;
        }

       
        void myNetworkEmulatorDriver_OnGetErrorMessage(object sender, string errorMessage)
        {
            MessageBox.Show(errorMessage, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
             NetworkEmulatorConfiguration networkEmulatorConfiguration =new NetworkEmulatorConfiguration();
             networkEmulatorConfiguration.dbBandwidth=double.Parse(tb_set_Bandwidth.Text);
             myNetworkEmulatorDriver.SetDriver(networkEmulatorConfiguration);

             myNetworkEmulatorDriver.StartDriver();
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            myNetworkEmulatorDriver.StopDriver();
        }

        private void bt_test_Click(object sender, EventArgs e)
        {
            //(new TestCom()).TestAPI();
            (new TestCom()).testLoadFromProfile();
        }
    }


    public class NetworkEmulatorConfiguration
    {
        public double dbBandwidth = 0;
    }

    class NetworkEmulatorDriver
    {
        

        #region delegate and event
        public delegate void delegateGetErrorMessageEventHandler(object sender, string errorMessage);
        public event delegateGetErrorMessageEventHandler OnGetErrorMessage;
        #endregion

        // Creating an IConfigurator object
        NetworkEmulator.INewConfigurator configurator = new NetworkEmulator.NetworkEmulatorClass();

        // Creating a VirtualChannel object
        NetworkEmulator.VirtualChannel vc = new NetworkEmulator.VirtualChannelClass();

        //链路规则
        LinkRule lr = new LinkRule();

        //过滤器
        NetworkEmulator.PacketFilterRule fr = new PacketFilterRule();

        public NetworkEmulatorDriver()
        {
            if (0 != vc.InitLinkRule(ref lr))
            {
                //throw new Exception("Failed to initialize LinkRule");
                PutErrorMessages("Failed to initialize LinkRule");
            }
        }

        private void PutErrorMessages(string yourError)
        {
            if(OnGetErrorMessage!=null)
            {
                OnGetErrorMessage(this, yourError);
            }
        }

        public void SetDriver(NetworkEmulatorConfiguration yourConfiguration)
        {
            try
            {
                vc = new NetworkEmulator.VirtualChannelClass();
                lr = new LinkRule();
                fr = new PacketFilterRule();

                //带宽
                lr.BandQueueRule.dbBandwidth = yourConfiguration.dbBandwidth;

                lr.BandQueueRule.queue.QueueType = QueueType.NO_QUEUE;
                //lr.BandQueueRule.queue.dropMode = QueueDropMode.DROP_TAIL;
                //lr.BandQueueRule.queue.QueueMode = QueueMode.QUEUE_MODE_PACKET;
                //lr.BandQueueRule.queue.uiQueueSize = 100;

                //延时
                lr.LatencyRule.LatencyType = LatencyType.FIXED_LATENCY;
                lr.LatencyRule.uLatencyType.FixedLatency.ulLatency = 0;


                if (0 != vc.SetLinkRule(ref lr, ref lr, 1))
                    throw new Exception("Failed to Set LinkRule");

                //NetworkEmulator.PacketFilterRule fr = new PacketFilterRule();

                if (0 != vc.InitFilterRule(ref fr))
                    throw new Exception("Failed initializing FilterRule");

                fr.ipVersion = NetworkType.ALL_NETWORK;

                // Adding FilterRule to the VirtualChannel
                if (0 != vc.AddFilterRule(ref fr))
                    throw new Exception("Failed to add FilterRule");

                // Adding VirtualChannel to the emulation
                if (0 != configurator.SubmitVirtualChannel(vc))
                    throw new Exception("Failed to add VirtualChannel to the emulation");
            }
            catch (Exception e)
            {
                PutErrorMessages("Fail to run test API!");
                Console.WriteLine("Fail to run test API!");
                Console.WriteLine(e);
            }
        }

        public void StartDriver()
        {
            NetworkEmulator.INewController Controller = (INewController)configurator;
            Controller.Start();
        }

        public void StopDriver()
        {
            NetworkEmulator.INewController Controller = (INewController)configurator;
            Controller.Stop(0, 1000);
        }
    }

    class TestCom
    {
        /**
         * Test invoke the API to run the emulator
         */
        public void TestAPI()
        {
            try
            {
                // Creating an IConfigurator object
                NetworkEmulator.INewConfigurator configurator = new NetworkEmulator.NetworkEmulatorClass();

                // Creating a VirtualChannel object
                NetworkEmulator.VirtualChannel vc = new NetworkEmulator.VirtualChannelClass();

                LinkRule lr = new LinkRule();
                if (0 != vc.InitLinkRule(ref lr))
                    throw new Exception("Failed to initialize LinkRule");

                lr.BandQueueRule.dbBandwidth = 1000;

                lr.BandQueueRule.queue.QueueType = QueueType.NORMAL_QUEUE;
                lr.BandQueueRule.queue.dropMode = QueueDropMode.DROP_TAIL;
                lr.BandQueueRule.queue.QueueMode = QueueMode.QUEUE_MODE_PACKET;
                lr.BandQueueRule.queue.uiQueueSize = 100;
                lr.BandQueueRule.queue.red.QueueMin = 50;
                lr.BandQueueRule.queue.red.QueueMax = 100;
                lr.BandQueueRule.queue.red.MeanPacketSize = 500;


                lr.LatencyRule.LatencyType = LatencyType.FIXED_LATENCY;
                lr.LatencyRule.uLatencyType.FixedLatency.ulLatency = 0;

                if (0 != vc.SetLinkRule(ref lr, ref lr, 1))
                    throw new Exception("Failed to Set LinkRule");


                NetworkEmulator.PacketFilterRule fr = new PacketFilterRule();
                if (0 != vc.InitFilterRule(ref fr))
                    throw new Exception("Failed initializing FilterRule");

                fr.ipVersion = NetworkType.ALL_NETWORK;

                // Adding FilterRule to the VirtualChannel
                if (0 != vc.AddFilterRule(ref fr))
                    throw new Exception("Failed to add FilterRule");

                // Adding VirtualChannel to the emulation
                if (0 != configurator.SubmitVirtualChannel(vc))
                    throw new Exception("Failed to add VirtualChannel to the emulation");

                NetworkEmulator.INewController Controller = (INewController)configurator;
                Controller.Start();
                System.Threading.Thread.Sleep(30000);
                Controller.Stop(0, 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail to run test API!");
                Console.WriteLine(e);
            }  
        }

        /**
         * Test loading profile to run the emulator
         */
        public void testLoadFromProfile()
        {
            try
            {
                NetworkEmulator.INewController controller = new NetworkEmulator.NetworkEmulatorClass();
                controller.LoadProfile(Environment.CurrentDirectory + "\\config\\56kModem.xml");

                //LIJIE
                NetworkEmulator.VirtualChannel vc;
                ((NetworkEmulatorClass)controller).GetNextVirtualChannel(null, out vc);

                controller.Start();
                System.Threading.Thread.Sleep(6000);
                controller.Stop(0, 2000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail to run test profile!");
                Console.WriteLine(e);
            }
        }

        ///**
        // * main function
        // */
        //[STAThread]
        //static void Main(string[] args)
        //{
        //    TestCom test = new TestCom();
        //    test.TestAPI();
        //    test.testLoadFromProfile();
        //}
    }

    //public class TestClass
    //{
    //    private static void SetIP(string ip_address, string subnet_mask)
    //    {
    //        ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
    //        ManagementObjectCollection objMOC = objMC.GetInstances();

    //        foreach (ManagementObject objMO in objMOC)
    //        {
    //            if ((bool)objMO("IPEnabled"))
    //            {
    //                try
    //                {
    //                    ManagementBaseObject setIP = default(ManagementBaseObject);
    //                    ManagementBaseObject newIP = objMO.GetMethodParameters("EnableStatic");

    //                    newIP("IPAddress") = new string[] { ip_address };
    //                    newIP("SubnetMask") = new string[] { subnet_mask };

    //                    setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
    //                }
    //                catch (Exception generatedExceptionName)
    //                {
    //                    throw;
    //                }
    //            }


    //        }
    //    }

    //    private static void SetDHCP()
    //    {
    //        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
    //        ManagementObjectCollection moc = mc.GetInstances();

    //        foreach (ManagementObject mo in moc)
    //        {
    //            // Make sure this is a IP enabled device. Not something like memory card or VM Ware
    //            if ((bool)mo("IPEnabled"))
    //            {
    //                ManagementBaseObject newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
    //                newDNS("DNSServerSearchOrder") = null;
    //                ManagementBaseObject enableDHCP = mo.InvokeMethod("EnableDHCP", null, null);
    //                ManagementBaseObject setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
    //            }
    //        }
    //    }




    //}

}
