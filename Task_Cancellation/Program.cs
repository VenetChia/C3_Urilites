using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Cancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting");
            CancellationTokenSource token = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(MyTAsk, token.Token, token.Token);
            Thread.Sleep(3000);
            try
            {
                token.Cancel();
                task.Wait();
            }
            catch (ArgumentException ex)
            {
                if (task.IsCanceled) Console.WriteLine("\ntask Cancelled\n");
            }
            finally
            {
                task.Dispose();
                token.Dispose();
            }
            Console.WriteLine("Main thread is ending");
        }
        static void MyTAsk(object ct)
        {
            CancellationToken cancellationToken = (CancellationToken)ct;
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine("MYTask is starting");
            for (int i = 0; i < 15; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation irequest recevied.");
                    cancellationToken.ThrowIfCancellationRequested();
                }
                Thread.Sleep(500);
                Console.WriteLine("In MyTask count is " + i);
            }
            Console.WriteLine("MyTask is terminating");

        }
    }
}
