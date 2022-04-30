using System;
using System.Threading;
using System.Threading.Tasks;

namespace paralelInvoke
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main thread is starting");
            Parallel.Invoke(() =>
           {
               Console.WriteLine("Expression 1 is starting");
               for (int i = 0; i < 5; i++)
               {
                   Thread.Sleep(500);
                   Console.WriteLine("Expression 1 count is " + i);
               }
               Console.WriteLine("Expression 1 is terminating");
           }, (Action)delegate ()
           {
               Console.WriteLine("Expression 2 is starting");
               for (int i = 0; i < 10; i++)
               {
                   Thread.Sleep(500);
                   Console.WriteLine("Expression 2 count is " + i);
               }
               Console.WriteLine("Expression 2 is terminating");
           });

            //пример2
            ParallelOptions parallelOptions = new ParallelOptions();
            Parallel.Invoke(Method1, Method2);
            Console.WriteLine("Main thread is ending");

        }
        static void Method1()
        {
            Console.WriteLine("Expression 1 is starting");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Expression 1 count is " + i);
            }
            Console.WriteLine("Expression 1 is terminating");
        }
        static void Method2()
        {
            Console.WriteLine("Expression 2 is starting");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Expression 2 count is " + i);
            }
            Console.WriteLine("Expression 2 is terminating");
        }
    }
}
