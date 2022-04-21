using System;
using System.Threading;

namespace WorkWthThreads
{
    class Program1class
    {
        static void Main()
        {
            Console.WriteLine("Main thread is starting at " + DateTime.Now.ToLongTimeString());
            MyThread mt1 = new MyThread("Child 1");
            Thread.Sleep(10);
            MyThread mt2 = new MyThread("Child 2");
            Thread.Sleep(10);
            MyThread mt3 = new MyThread("Child 3");

            do
            {
                Console.Write(".");
                Thread.Sleep(1000);
            } while (mt1.Count < 10 || mt2.Count < 10 || mt3.Count < 10);
        }
    }

    class MyThread
    {
        public int Count;
        public Thread thread;

        public MyThread(string name)
        {
            Count = 0;
            thread = new Thread(this.Run);
            thread.IsBackground = true;
            thread.Name = name;
            thread.Start();
        }
        public void Run() //работа потока с увеличеникм Count
        {
            Console.WriteLine(thread.Name + " starting");
            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("In " + thread.Name + ", Count is " + Count);
                Count++;
            } while (Count < 20);
            Console.WriteLine(thread.Name + " terminating");
        }
    }
}
