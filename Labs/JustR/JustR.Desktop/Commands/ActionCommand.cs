using System;
using System.Windows.Input;

namespace JustR.Desktop.Commands
{
    public class ActionCommand : ICommand
    {
        private readonly Action<Object> _action;

        public ActionCommand(Action<Object> action)
        {
            _action = action;
        }

        public Boolean CanExecute(Object parameter)
        {
            return true;
        }

        public void Execute(Object parameter)
        {
            _action(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

    public class ActionCommand<T> : ICommand
    {
        private readonly Action<T> _action;

        public ActionCommand(Action<T> action)
        {
            _action = action;
        }

        public Boolean CanExecute(Object parameter)
        {
            return true;
        }

        public void Execute(Object parameter)
        {
            _action((T) parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}