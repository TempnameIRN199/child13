using System;
using System.Windows.Input;

namespace child13_AI.AdditionalStructures.Commands
{
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        protected abstract void Execute();

        protected virtual bool CanExecute() => true;

        void ICommand.Execute(object inParameter) => Execute();

        bool ICommand.CanExecute(object inParameter) => CanExecute();
    }
}
