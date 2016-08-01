using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventExample
{


    class Program
    {
        static void Main(string[] args)
        {
            Heater myHeater = new Heater();
            myHeater.OnBoiled += OnboiledAProcess;
            myHeater.OnBoiled -= OnboiledBProcess;
            myHeater.OnBoiled+=new EventHandler(OnboiledBProcess);
            //myHeater.OnBoiled(null, new EventArgs());
            myHeater.Begin();
            Console.WriteLine("饮水机开始加热。");
            Console.ReadKey();

        }
        static void OnboiledAProcess(object o,EventArgs e)
        {
            Console.WriteLine("水开了，A喝水咯。");
        }
        static void OnboiledBProcess(object o,EventArgs e)
        {
            Console.WriteLine("水开了，B喝水了");
        }
    }

    class Heater
    {
        public event EventHandler OnBoiled;
        //public EventHandler OnBoiled;
        private void RaiseBoiledEvent()
        {
            if (OnBoiled == null)
            {
                Console.WriteLine("没人要喝水。");
            }
            else
                OnBoiled(this,new EventArgs());
        }
        public void Begin()
        {
            new Thread(new ThreadStart(Heat)).Start();

        }
        int heatTime=5;
        private void Heat()
        {
            while (true)
            {
                Console.WriteLine("还要加热{0}秒。", heatTime);
                if (heatTime == 0)
                {
                    RaiseBoiledEvent();
                    return;
                }
                --heatTime;
                Thread.Sleep(1000);
            }
        }

    }
}
