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
using AdressDataBase;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace C3_Urilites.ViewsModels
{
    class MainViewModel: IDataErrorInfo
    {
        private string to = "Recipient";
        private AdressDataBase.UtilitesDB _dbContainer;

        public MainViewModel()
        {
            ClosingCommand = new RelayCommand(OnClosingCommand, CanClosingCommandExecute);
            AddAdressComand = new RelayCommand(OnAddAdressCommandExecute, CanAddAdressCommandExecute);
            RemoveAdressCommand = new RelayCommand(OnRemoveAdressCommandExecute, CanRemoveAdressExecute);
            _dbContainer = new AdressDataBase.UtilitesDB();
            _dbContainer.Adresses.Load();
        }
        //public List<string> Adress { get; set; } = Model.Service.GetListTo();
        public ObservableCollection<Adress> Adresses => _dbContainer.Adresses.Local;
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

        #region Adress Add
        public ICommand AddAdressComand { get; }
        private void OnAddAdressCommandExecute(object o)
        {
            _dbContainer.Adresses.Add(new Adress() { AdressText = o.ToString() });
            _dbContainer.SaveChanges();
        }
        private bool CanAddAdressCommandExecute(object o) => true;
        #endregion

        #region Remove Adress
        public ICommand RemoveAdressCommand { get; }
        private void OnRemoveAdressCommandExecute(object o)
        {
            Adress adr = (o as Adress);
            Adress adress = _dbContainer.Adresses.Where(a => a.AdressID == adr.AdressID).FirstOrDefault();
            _dbContainer.Adresses.Remove(adress);
            _dbContainer.SaveChanges();
        }
        private bool CanRemoveAdressExecute(object p) => true;
        #endregion
        #endregion
    }
}
