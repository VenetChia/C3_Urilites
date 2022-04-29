using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFHomeTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    ///
    /// </summary>
    /// Добавить чтение файла и подсчет чисел 

    public partial class MainWindow : Window
    {
        ThreadTaskSum threadTaskSum;
        ThreadTaskFuct threadTaskFuct;
        bool pause = false;
        public MainWindow()
        {
            InitializeComponent();
            ThreadTaskSum.calc.reporter += SendToTB;
            ThreadTaskSum.calc.mre = new System.Threading.ManualResetEvent(true);
            ThreadTaskFuct.calc.reporter += SendToTB;
            ThreadTaskFuct.calc.mre = new System.Threading.ManualResetEvent(true);
        }

        private void SendToTB(string message)

        {
            this.Dispatcher.Invoke( ()=>tbInfoRes1.AppendText($"\n{message}"));
        }

        private void btStart1_Click(object sender, RoutedEventArgs e)
        {
            threadTaskSum = new ThreadTaskSum("SumAll", int.Parse(tbNum.Text));
            threadTaskFuct = new ThreadTaskFuct("Fuct", int.Parse(tbNum.Text));
            threadTaskFuct.reporter += SendToTB;
            threadTaskSum.reporter += SendToTB;
            if (threadTaskSum != null && cbVar2.IsChecked == true) threadTaskSum.thread.Start();
            if (threadTaskFuct != null && cbVar1.IsChecked == true) threadTaskFuct.thread.Start();
            btStart1.IsEnabled = false;
        }

        private void btPause1_Click(object sender, RoutedEventArgs e)
        {
            //if (threadTaskSum != null) threadTaskSum.thread.Suspend();
            pause = !pause;
            if (pause)
            {
                ThreadTaskSum.calc.mre.Reset();
                ThreadTaskFuct.calc.mre.Reset();
            }
            else
            {
                ThreadTaskSum.calc.mre.Set();
                ThreadTaskFuct.calc.mre.Set();
            }

        }

        private void btStop1_Click(object sender, RoutedEventArgs e)
        {
            if (threadTaskSum != null) threadTaskSum.thread.Abort();
            if (threadTaskFuct != null) threadTaskFuct.thread.Abort();
            btStart1.IsEnabled = true;
        }

    }
}
