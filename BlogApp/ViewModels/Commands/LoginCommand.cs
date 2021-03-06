using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlogApp.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action _action;

        public LoginCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action.Invoke();
        }
    }
}
