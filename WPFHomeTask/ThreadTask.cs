using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPFHomeTask
{
    class ThreadTask
    {
        public int Count;
        public Thread thread;
        public ThreadTask(string name, Data data)
        {
            Count = 1;
            thread = new Thread(new ParameterizedThreadStart(this.Run));
            thread.Name = name;
            thread.Start(data);
        }
        void Run(object data)
        {
            Data dt = (data as Data);
            if (dt == null) return;
            Console.WriteLine(thread.Name + " starting with count of " + dt.Num); //оформить через делегат
            do
            {
                Thread.Sleep(dt.Delay);
                Console.WriteLine("In thread " + thread.Name + ", Count is " + Count);
                Count++;
            } while (Count <= dt.Num);
            Console.WriteLine(thread.Name + " terminating.");
        }

    }
    class Data
    {
        public int Num { get; set; }
        public int Delay { get; set; }
    }

}
