using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_returnValue
{
    class Program
    {
        static void Main()
        {
            Task<bool> tsk = new Task<bool>(MyTask);
            Task<bool> tsk2 = Task.Factory.StartNew(MyTask);
            tsk.Start();
             
            Console.WriteLine(tsk.Result);
        }
        static bool MyTask()
        {
            Console.WriteLine("Wait 6 seconds");
            Thread.Sleep(6000);
            return true;
        }
    }
}
