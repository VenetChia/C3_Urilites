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

namespace C3_Urilites
{
    /// <summary>
    /// Логика взаимодействия для TabSwitcher.xaml
    /// </summary>
    public partial class TabSwitcher : UserControl
    {
        public TabSwitcher()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler PrevClick;
        public event RoutedEventHandler NextClick;

        private void btPrev_Click(object sender, RoutedEventArgs e)
        {
            if (PrevClick != null) 
            PrevClick.Invoke(sender, e);
        }
        //два вида записи условия

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            NextClick?.Invoke(sender, e);
        }
    }
}
