using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Urilites.Model;
using C3_Urilites.Commands;
using System.Windows.Input;

namespace C3_Urilites.ViewsModels
{
    class MainViewModel
    {
        public List<string> AdressTo { get; set; } = Model.Service.GetListTo();
        public ICommand SendMailClick
        {
            get
            {
                return new DelegateCommand(o => Model.Service.SendMail("", "", ""), o=> true);
            }
        }
    }
}
