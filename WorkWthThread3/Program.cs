using System;
using System.Threading;

namespace WorkWthThread3
{
    class Data
    {
        public int Num { get; set; }
        public int Delay { get; set; }
    }
    class MyThread
    {
        public int Count;
        public Thread thread;
        public MyThread(string name, Data data)
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
            Console.WriteLine(thread.Name + " starting with count of " + dt.Num);
            do
            {
                Thread.Sleep(dt.Delay);
                Console.WriteLine("In thread " + thread.Name + ", Count is " + Count);
                Count++;
            } while (Count <= dt.Num);
            Console.WriteLine(thread.Name + " terminating.");
        }
    }
    class Program
    {
        static void Main()
        {
            MyThread mt1 = new MyThread("Child 1", new Data { Delay = 500, Num = 10 });
            MyThread mt2 = new MyThread("Child 2", new Data { Delay = 1000, Num = 7 });
            mt1.thread.Join();
            mt2.thread.Join();
            Console.WriteLine("Hello World! =))");
        }
    }
}
