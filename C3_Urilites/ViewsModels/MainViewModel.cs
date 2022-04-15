using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Urilites.Model;
using C3_Urilites.Commands;
using System.Windows.Input;
using System.Windows;
using C3_Urilites;

namespace C3_Urilites.ViewsModels
{
    class MainViewModel
    {
        public List<string> Adress { get; set; } = Model.Service.GetListTo();
        public string From { get; set; } = "Sender";
        public string To { get; set; } = "Recipient";
        public string Password { get; set; } = "Введите пароль"; 
        public ICommand SendMailClick
        {
            get
            {
                return new DelegateCommand(o => Model.Service.SendMail(From, To, Password), o=> CheckFromTo());
            }
        }
        public ICommand CloseWindowCommand
        {
            get
            {
                return new DelegateCommand((o) => Application.Current.Shutdown(), o => true);
            }
        }

        private bool CheckFromTo()
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(From) && regex.IsMatch(To);
        }
        public ICommand ClosingCommand
        {
            get
            {
                return new DelegateCommand(o => Service.Log("Windows is closing"));
            }
        }
    }
}
