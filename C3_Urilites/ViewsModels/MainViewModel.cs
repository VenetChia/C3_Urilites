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
using System.ComponentModel;

namespace C3_Urilites.ViewsModels
{
    class MainViewModel: IDataErrorInfo
    {
        private string to = "Recipient";

        public MainViewModel()
        {
            ClosingCommand = new RelayCommand(OnClosingCommand, CanClosingCommandExecute);
        }
        public List<string> Adress { get; set; } = Model.Service.GetListTo();
        public string From { get; set; } = "Sender";
        public string To 
        { get => to; 
            set
            {
                if (value.Length > 15)
                {
                    try
                    {
                        throw new ArgumentOutOfRangeException("Слишком большое значение");
                    }
                    catch (Exception ex)
                    {

                        Service.Log(ex.ToString());
                    }
                }
                to = value;
            } 
        }
        public int Number { get; set; }
        public string Text2 { get; set; } = "";
        public string Password { get; set; } = "Введите пароль";
        #region Команды
        public ICommand SendMailClick
        {
            get
            {
                return new DelegateCommand(o => Model.Service.SendMail(From, To, Password), o => CheckFromTo());
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


        public string Error { get; private set; }

        public string this[string columnName]
        {
            get
            {
                Error = String.Empty;
                switch (columnName)
                {
                    case "Text2":
                        if (Text2.Length > 15) Error = "Слишком большая длина!";
                        break;
                    case "From":
                        if (From.Contains("!")) Error = "Восклицательный знак!";
                        break;
                    default:
                        break;
                }
                return Error;
            }
        }

        private void OnClosingCommand(object o)
        {
            Service.Log("Windows is closing");
        }
        private bool CanClosingCommandExecute(object o) => true;
        #endregion

        #endregion
    }
}
