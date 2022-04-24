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
    /// </summary>
    public partial class MainWindow : Window
    {
        ThreadTaskSum threadTaskSum;
        ThreadTaskFuct threadTaskFuct;

        public MainWindow()
        {
            InitializeComponent();
            threadTaskSum = new ThreadTaskSum("SumAll", int.Parse(tbNum.Text));
            threadTaskFuct = new ThreadTaskFuct("Fuct", int.Parse(tbNum.Text));

        }

        private void btStart1_Click(object sender, RoutedEventArgs e)
        {
            if(threadTaskSum != null) threadTaskSum.thread.Start();
        }

        private void btPause1_Click(object sender, RoutedEventArgs e)
        {
            if (threadTaskSum != null) threadTaskSum.thread.Suspend();
        }

        private void btStop1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbVar1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbVar2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
