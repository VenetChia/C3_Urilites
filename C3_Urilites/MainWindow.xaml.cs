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
using C3_Urilites.Model;

namespace C3_Urilites
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string senderE = null;
        string recipient = null;
        string password =   null;
        public string textPrev { get; set; } = "Back";
        //List<service_client> serviceClient = new List<service_client>();
        public MainWindow()
        {
            InitializeComponent();
            //serviceClient.Add(new service_client() { serviceClient = "", portClient = "25" });
            this.DataContext = this;
        }

        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            ChooseAdress();
            if (password !="" && senderE != "" && recipient != "")
            {
                Model.Service.SendMail(sender.ToString(), recipient.ToString(), password.ToString());
            }
            else
            {
                MessageBox.Show("Введите почтовые адреса отправителя, получателя и пароль от почтового ящика отправителя");
            }
            //Model.Service.SendMail("venetchia@mail.ru", "cat6@list.ru", "password");
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Внимание!", MessageBoxButton.YesNo)== MessageBoxResult.Yes) this.Close();
        }
        private void ChooseAdress()
        {
            senderE = tbFrom.Text;
            recipient = tbTo.Text;
            password = tbPassword.Text;
        }

        private void cbRecipient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbFrom.Text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
        }

        private void btPrev_Click(object sender, RoutedEventArgs e)
        {
            tcControl.SelectedIndex = tcControl.SelectedIndex == 0 ? tcControl.Items.Count - 1 : --tcControl.SelectedIndex;
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            tcControl.SelectedIndex = (tcControl.SelectedIndex + 1) % tcControl.Items.Count;
        }
    }
}
