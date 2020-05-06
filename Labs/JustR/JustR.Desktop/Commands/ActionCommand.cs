using System;
using System.Windows.Input;

namespace JustR.Desktop.Commands
{
    public class ActionCommand : ICommand
    {
        private readonly Action _action;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        public Boolean CanExecute(Object parameter)
        {
            return true;
        }

        public void Execute(Object parameter)
        {
            if (parameter != null)
                throw new Exception();

            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}