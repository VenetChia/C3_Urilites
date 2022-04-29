using System;
using System.Threading;
using System.Threading.Tasks;

namespace CATask
{
    class Program
    {
        static void Main()
        {
            Task tsk = new Task(MyTask);
            Task tsk2 = new Task(MyTask);
            Console.WriteLine(tsk.Id);
            Console.WriteLine(tsk2.Id);
            tsk.Start();
            tsk2.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Main is ending");
            //tsk.Wait();
            //int n = Task.WaitAny(tsk, tsk2);
            Task.WaitAll(tsk, tsk2);
        }
        static void MyTask()
        {
            Thread.CurrentThread.IsBackground = true;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask count is " + i);
            }
            Console.WriteLine("MyTask is terminating");
        }

        
        
    }
}
