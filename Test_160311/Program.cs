using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_160311
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //    }
    //}

    public class TCloser
    {
        public Func<int> T1()
        {
            var n = 999;
            Func<int> result = () =>
            {
                return n;
            };

            n = 10;
            return result;
        }

        public dynamic T2()
        {
            var n = 999;
            dynamic result = new { A = n };
            n = 10;
            return result;
        }
        static void Main()
        {
            Test2();
            var a = new TCloser();
            var b = a.T1();
            var c = a.T2();
            Console.WriteLine(b());
            Console.WriteLine(c.A);
            Console.ReadKey();

        }

        class Cv
        {
            public int id = 0;
        }

        public static void ClosePrcByName(string precessName)
        {
            int myPid=System.Diagnostics.Process.GetCurrentProcess().Id;
            //System.Diagnostics.Process myps = new System.Diagnostics.Process();
            foreach (System.Diagnostics.Process ps in System.Diagnostics.Process.GetProcesses())
            {
                if(ps.ProcessName==precessName)
                {
                    if (myPid == ps.Id)
                    {
                        Console.WriteLine("当前PID");
                    }
                    else
                    {
                        Console.WriteLine("ID: " + ps.Id + "close");
                        ps.Kill();
                    }
                }
                else
                {
                    Console.WriteLine("Name: " + ps.ProcessName + "  skip");
                }
            }
        }
        public static void Test1()
        {
            int x = 99;
            //object y = (object)x;
            object y = x;
            y = 88;
            Console.WriteLine(x.ToString());
            Console.WriteLine(y.ToString());
            Console.ReadKey();
        }

        public static void Test2()
        {
            ClosePrcByName("chromedriver");
            Console.WriteLine("ALL:" + (420 + 270 + 34 + 31 + 150 + 150 + 42.5 + 0.01 + 5 + 37.71 + 220 + 220 + 481 + 2.9 + 3.32 + 3.32 + 1.46 + 14.02 + 15.58 + 15.37 + 65 + 150));
            Console.WriteLine("1");
            Console.WriteLine("2");
            goto addd1;
            Console.WriteLine("3");
            Console.WriteLine("4");

            Cv c1 = new Cv();
            c1.id = 99;
            object c2 = (object)c1;
            ((Cv)c2).id = 88;

            Console.WriteLine(c1.id.ToString());
            Console.WriteLine(((Cv)c2).id.ToString());
            Console.ReadKey();

addd1:
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");
        }

    }


    public class Tester
    {
        public void MyTest()
        {
            List<long> goods_1 = new List<long>((new long[] { 6903148080153, 6903148080139, 6903148080146, 6903148080177, 6903148093580, 6903148093597, 6903148093641, 6903148093658, 6903148091470, 6903148091487, 6903148091425, 6903148091432, 6903148091449, 6903148091463, 6903148108338, 6903148131411, 6903148126660, 6903148126677, 6920177916680, 6920177916758, 6920177916826, 6920177917380, 6903148157848, 6903148157855, 6904915631011, 6903148030448, 6903148030455, 6903148030455, 6903148030462, 6903148030479, 4901872831197, 6920177962090, 6903148044919, 6903148044926, 6920177961536, 6903148048788, 6903148048795, 6903148048801, 6903148048870, 6903148048887, 6903148048818, 6903148048825, 6903148048832, 6924882335224, 6924882335538, 6924882335200, 6924882335514, 6924882335286, 6902088112184, 6902088111934, 6902088111866, 6902088112009, 6902088111927, 6902088111873, 6902088112016, 6920177916833, 6920177916697, 6920177916765, 6938314606516, 6938314606509, 6920177916956, 6920177917267, 6920177917472, 6902088113174, 6902088113075, 6902088113143, 6902088112962, 6902088112993, 6902088112924, 6902088112887, 6902088113099, 6902088113167, 6902088113082, 6902088112979, 6902088112863, 6902088112931, 6902088112894, 6904915642208, 6902088113808, 6902088113822, 6902088113846, 6926799690823, 6926799690830, 6926799690854, 6926799690861, 6926799690892, 6903148144190, 6903148139714, 6903148139721, 6903148139738, 6920177915041, 6946537059187, 6946537059705, 6946537059743, 6955818202334, 6955818202297, 6955818202372 }));
            //foreach(long tempGoods in goods_1)
            for (int i = goods_1.Count - 1; i > 0; i--)
            {
                long tempGoods = goods_1[i];
                goods_1.RemoveAt(i);
                if (goods_1.Contains<long>(tempGoods))
                {
                    Console.WriteLine(tempGoods.ToString());
                }
            }
        }

    }
}
