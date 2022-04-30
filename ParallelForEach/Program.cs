using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForEach
{
    class Program
    {
        static int[] data;
        static void Main()
        {
            Console.WriteLine("Main thread is starting");
            data = new int[1000000000];
            for (int i = 0; i < data.Length; i++) data[i] = i;
            data[100] = -10;
            ParallelLoopResult loopResult = Parallel.ForEach(data, (value, plstate) =>
            {
                Console.WriteLine($"Value: {value}");
                if (value < 0) plstate.Break();
            });
            if (!loopResult.IsCompleted)
                Console.Write("\nLoop Terminated early because a negative value was encountered\n in iteration number " + loopResult.LowestBreakIteration + ".\n");

            Console.WriteLine("Main thread is ending");
        }
        static void DisplayData(int v, ParallelLoopState pls)
        {
            if (v < 0) pls.Break();
            Console.WriteLine("Value: " + v);
        }
    }
}
