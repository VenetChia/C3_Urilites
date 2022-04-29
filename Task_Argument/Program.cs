using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Argument
{
    class Program
    {
        static void Main()
        {
            Task task = new Task(new Action<object>(MyTAsk), "string");
            Task task1 = new Task<int>(new Func<object?, int>(MyTAsk2), "string2");
            task.Start();
            task.Wait();
            Console.WriteLine("Hello World!");

        }
        static void MyTAsk(object? Name)
        {
            Console.WriteLine($"MyTask({Name}) starting");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask count is " + i);
            }
            Console.WriteLine("MyTask is terminating");
        }
        static int MyTAsk2(object? Name)
        {
            Console.WriteLine($"MyTask({Name}) starting");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask count is " + i);
            }
            Console.WriteLine("MyTask is terminating");
            return 1;
        }

    }
}
