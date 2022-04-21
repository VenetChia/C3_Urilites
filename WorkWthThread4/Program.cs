using System;
using System.Threading;

namespace WorkWthThread4
{
    class SumArray
    {
        int sum;
        private object lockOn = new object();
        public int SumIt(int[] nums)
        {
            lock (lockOn) 
            {
                sum = 0;   

                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    Console.WriteLine("Running total for " + Thread.CurrentThread.Name + " is " + sum);
                    Thread.Sleep(10); 
                }
                return sum;
            }
        }



        public int SumIt2(int[] nums)
        {
            bool _lockWasTacken = false;
            try  
            {
                System.Threading.Monitor.Enter(lockOn, ref _lockWasTacken);
                sum = 0;   

                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    Console.WriteLine("Running total for " + Thread.CurrentThread.Name + " is " + sum);
                    Thread.Sleep(10);  
                }
                return sum;
            }
            finally
            {
                if (_lockWasTacken)
                {
                    System.Threading.Monitor.Exit(lockOn);
                }
            }
        }

    }
    class MyThread
    {
        public Thread thread;
        int[] a;
        int answer;

        static SumArray sumAr = new SumArray();

        public MyThread(string name, int[] nums)
        {
            a = nums;
            thread = new Thread(this.Run);
            thread.Name = name;
            thread.Start();   
        }

        void Run()
        {
            Console.WriteLine(thread.Name + " starting.");

            answer = sumAr.SumIt(a);

            Console.WriteLine("Sum for " + thread.Name + " is " + answer);

            Console.WriteLine(thread.Name + " terminating.");
        }
    }

    class Program
    {

        static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
