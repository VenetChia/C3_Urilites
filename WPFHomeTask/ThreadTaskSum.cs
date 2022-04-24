using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPFHomeTask
{
    public class ThreadTaskSum
    {
        public int Num;
        public Thread thread;
        static Сalculations calc = new Сalculations();
        public ThreadTaskSum(string name, int num)
        {
            Num = num;
            thread = new Thread(this.Run);
            thread.Name = name;
            //thread.Start();
        }
        void Run()
        {
            Console.WriteLine(thread.Name + " starting.");

            Console.WriteLine("Sum for " + thread.Name + " is " + calc.SumAll(Num));

            Console.WriteLine(thread.Name + " terminating.");
        }
    }
    public class ThreadTaskFuct
    {
        public int Num;
        public Thread thread;
        static Сalculations calc = new Сalculations();
        public ThreadTaskFuct(string name, int num)
        {
            Num = num;
            thread = new Thread(this.Run);
            thread.Name = name;
            //thread.Start();
        }
        void Run()
        {
            Console.WriteLine(thread.Name + " starting.");

            Console.WriteLine("Sum for " + thread.Name + " is " + calc.Fuct(Num));

            Console.WriteLine(thread.Name + " terminating.");
        }
    }
    class Сalculations
    {
        public int Fuct(int num)
        {
            //Console.WriteLine("Вычисление по " + num);
            if (num == 0) return 1;
            if (num == 1) return 1;
            return Fuct(num) * Fuct(num - 1);
        }
        public int SumAll(int num)
        {
            //Console.WriteLine("Вычисление по " + num);
            if (num == 0) return 0;
            return SumAll(num) + SumAll(num - 1);
        }
    }

}
