using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PLINQ
{
    class Program
    {
        static void Main()
        {
            int[] data = new int[900000000];
            for (int i = 0; i < data.Length; i++) data[i] = i;
            data[1000] = -1;
            data[14000] = -2;
            data[15000] = -3;
            data[676000] = -4;
            data[8024540] = -5;
            data[9908000] = -6;

            var sw = new Stopwatch();
            sw.Start();
            var negatives = from val in data.AsParallel().AsOrdered()
                            where val < 0
                            select val;
            //var negatives2 = (from val in data
            //                where val < 0
            //                select val).ToList();
            foreach (var v in negatives) Console.WriteLine(v + " ");
            sw.Stop();
            Console.WriteLine("Time: " + sw.ElapsedMilliseconds);
            Console.WriteLine();
        }
    }
}
