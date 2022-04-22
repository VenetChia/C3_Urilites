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
        public ThreadTask(string name)
        {
            Count = 1;
            thread = new Thread(new ParameterizedThreadStart(this.Run));
            thread.Name = name;
            thread.Start();
        }
        void Run(object data)
        {
            //Data dt = (data as Data);
            //if (dt == null) return;
            //Console.WriteLine(thread.Name + " starting with count of " + dt.Num); //оформить через делегат
            //do
            //{
            //    Thread.Sleep(dt.Delay);
            //    Console.WriteLine("In thread " + thread.Name + ", Count is " + Count);
            //    Count++;
            //} while (Count <= dt.Num);
            //Console.WriteLine(thread.Name + " terminating.");
        }

    }
    public class Сalculations
    {
        public int Fuct(int num)
        {
            Console.WriteLine("Вычисление по " + num);
            if (num == 0) return 1;
            if (num == 1) return 1;
            return Fuct(num) * Fuct(num - 1);
        }
        public int SumAll(int num)
        {
            Console.WriteLine("Вычисление по " + num);
            if (num == 0) return 0;
            return SumAll(num) + SumAll(num - 1);
        }
    }

}
