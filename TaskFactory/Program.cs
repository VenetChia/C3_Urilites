using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactory
{
    class Program
    {
        static void Main()
        {
            Task tsk = Task.Factory.StartNew(
                delegate () // ()=> можно вместо делегата
                {
                    Console.WriteLine("Task {0} starting", Task.CurrentId);
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"Task {Task.CurrentId} count is " + i);
                    }
                    Console.WriteLine("Task terminating");
                });
            Console.WriteLine("=)");
            Thread.Sleep(7000);
        }

    }
}
