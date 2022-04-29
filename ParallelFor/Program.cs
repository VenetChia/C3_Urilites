using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFor
{
    class Program
    {
        static int[] data;
        static void MyTransForm(int i)
        {
            data[i] = data[i] / 10;
            if (data[i] > 10000 & data[i] < 20000) data[i] = 100;
            if (data[i] > 10000 & data[i] < 20000) data[i] = 200;
            if (data[i] > 20000 & data[i] < 30000) data[i] = 300;
            if (data[i] > 30000 & data[i] < 40000) data[i] = 400;
            if (data[i] > 50000) data[i] = 500;

        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Main thread is starting");
            data = new int[500000000];
            sw.Restart();
            for (int i = 0; i < data.Length; i++) data[i] = i;
            sw.Stop();
            Console.WriteLine("Without ParalleFor. Elapset time: " + sw.ElapsedMilliseconds);
            sw.Restart();
            Parallel.For(0, data.Length, (i) => data[i] = i);
            sw.Stop();
            Console.WriteLine("Init with ParalleFor. Elapset time: " + sw.ElapsedMilliseconds);
            sw.Restart();
            Parallel.For(0, data.Length, MyTransForm);
            sw.Stop();
            Console.WriteLine("With ParalleFor. Elapset time: " + sw.ElapsedMilliseconds);
            Console.WriteLine("Main thread is ending");
        }
    }
}
