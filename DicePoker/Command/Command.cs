using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DicePoker.Command
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action executeMethod;
        Func<object, bool> canExecuteMethod;

        public Command(Action executeMethod, Func<object, bool> canExecuteMethod = null)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        public void Execute()
        {
            executeMethod();
        }
    }
}
