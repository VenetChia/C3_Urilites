using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPFHomeTask
{
    public class ThreadTaskSum
    {
        public int Num;
        public Thread thread;
        public static Сalculations calc = new Сalculations();
        public DisplayMessage reporter;

        public ThreadTaskSum(string name, int num)
        {
            Num = num;
            thread = new Thread(this.Run);
            thread.Name = name;
            //calc.reporter += Print;
            //thread.Start();
        }

        void Run()
        {
            reporter?.Invoke($"{thread.Name}  starting.");
            reporter?.Invoke($"Sum for {thread.Name} is {calc.SumAll(Num)}");
            reporter?.Invoke($"{thread.Name}  terminating.");
        }
    }
    public class ThreadTaskFuct
    {
        public int Num;
        public Thread thread;
        public static Сalculations calc = new Сalculations();
        public DisplayMessage reporter;
        public ThreadTaskFuct(string name, int num)
        {
            Num = num;
            thread = new Thread(this.Run);
            thread.Name = name;
            //thread.Start();
        }
        void Run()
        {
            reporter?.Invoke($"{thread.Name}  starting.");
            reporter?.Invoke($"Resalt for {thread.Name} is {calc.Fuct(Num)}");
            reporter?.Invoke($"{thread.Name}  terminating.");
        }
    }
    public class Сalculations
    {
        public ManualResetEvent mre;

        public DisplayMessage reporter { get; set; }
        public int Fuct(int num)
        {
            if (num < 1) return 1;
            int sum = 1;
            for(int i = 1; i <= num; i++)
            {
                sum = sum * i;
                Thread.Sleep(500);
                mre?.WaitOne();
                reporter?.Invoke($"Вычисление факториала, итерация {i}, текущая сумма {sum}");
            }
            return sum;
            //if (num == 0) return 1;
            //if (num == 1) return 1;
            //return Fuct(num) * Fuct(num - 1);
        }
        public int SumAll(int num)
        {
            if (num < 1) return 0;
            int sum = 0;
            for (int i = 0; i <= num; i++)
            {
                sum = sum + i;
                Thread.Sleep(500);
                mre?.WaitOne();
                reporter?.Invoke($"Вычисление суммы всех чисел, итерация {i}, текущая сумма {sum}");
            }
            return sum;
            //if (num == 0) return 1;
            //if (num == 1) return 1;
            //return Fuct(num) * Fuct(num - 1);
        }
    }

}
