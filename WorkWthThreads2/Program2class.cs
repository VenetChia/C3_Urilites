using System;
using System.Threading;

namespace WorkWthThreads2
{
    class Program2class
    {

        static void Main()
        {
            Console.WriteLine("Main thread is starting");

            MyThread mt1 = new MyThread("Child #1");
            MyThread mt2 = new MyThread("Child #2");
            MyThread mt3 = new MyThread("Child #3");

            mt1.thread.Join();
            Console.WriteLine("Child #1 joined");
            mt2.thread.Join();
            Console.WriteLine("Child #2 joined");
            mt3.thread.Join();
            Console.WriteLine("Child #3 joined");
            Console.WriteLine("Main thread is ending");
        }
    }
    class MyThread
    {
        public int Count;
        public Thread thread;

        public MyThread(string name)
        {
            Count = 0;
            thread = new Thread(new ThreadStart(this.Run));
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
