using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services.CommandDelegates
{
    class DelegateCommand : Command
    {
        static Func<bool> defaultCanExec = () => true;
        private Func<bool> canExecute;
        private Action<object> execute;


        public DelegateCommand(Action<object> executeMethod) : this(executeMethod, defaultCanExec) { }


        public DelegateCommand(Action<object> executeMethod, Func<bool> canExec)
        {
            execute = executeMethod;
            canExecute = canExec;
        }


        public override bool CanExecute()
        {
            return canExecute();
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
