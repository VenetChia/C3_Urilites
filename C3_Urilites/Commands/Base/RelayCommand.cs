using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Urilites.Commands.Base
{
    internal class RelayCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
    }
}
