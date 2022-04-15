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
using C3_Urilites.Commands.Base;

namespace C3_Urilites.ViewsModels
{
    class MainViewModel
    {
        public MainViewModel()
        {
            ClosingCommand = new RelayCommand(OnClosingCommand, CanClosingCommandExecute);
        }
        public List<string> Adress { get; set; } = Model.Service.GetListTo();
        public string From { get; set; } = "Sender";
        public string To { get; set; } = "Recipient";
        public string Password { get; set; } = "Введите пароль";
        #region Команды
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
        //public ICommand ClosingCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(o => Service.Log("Windows is closing"));
        //    }
        //}

        #region ClosingCommand
        public ICommand ClosingCommand { get; }
        private void OnClosingCommand(object o)
        {
            Service.Log("Windows is closing");
        }
        private bool CanClosingCommandExecute(object o) => true;
        #endregion

        #endregion
    }
}
