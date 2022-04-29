using System;
using System.Threading;
using System.Threading.Tasks;


namespace Task_ContinueWith
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main is starting");
            Task firstTask = new Task(MyTAsk);
            Console.WriteLine("First Task is " + firstTask.Id);
            Task taskCont = firstTask.ContinueWith(ContTask);
            firstTask.Start();
            taskCont.Wait();
            firstTask.Dispose();
            taskCont.Dispose();
            Console.WriteLine("Main thread is ending");

        }
        static void MyTAsk()
        {
            Console.WriteLine("MyTask() starting");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask count is " + i);
            }
            Console.WriteLine("MyTask is terminating");
        }
        static void ContTask(Task t)
        {
            Console.WriteLine("Continuation is starting");
            for (int i = 20; i < 25; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Continuation count is " + i);
            }
            Console.WriteLine("Continuation is terminating");
        }
    }
}
