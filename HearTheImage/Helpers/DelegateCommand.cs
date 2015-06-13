using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HearTheImage.Helpers
{
    public class DelegateCommand : ICommand
    {
        private Func<object, bool> _canExecute = (x) => { return true; } ;
        private Action<object> _execute = (x) => { };

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute != null) _execute = execute;
            if (canExecute != null) _canExecute = canExecute;
        }
    }
}
