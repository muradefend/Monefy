using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Monefy.Services
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        
        // Execution Check

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public virtual bool CanExecute()
        {
            return true;
        }



        // Execution process

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        public abstract void Execute(object parameter);



        //

        public virtual void OnCanExecuteChange(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }

        public void RiseCanExecuteChanged()
        {
            OnCanExecuteChange(EventArgs.Empty);
        }
    }
}
