using System;

namespace child13_AI.AdditionalStructures.Commands
{
    internal sealed class DelegateCommand : CommandBase
    {
        private static readonly Func<bool> defaultCanExecuteMethod = () => true;

        private readonly Action executeMethod;
        private readonly Func<bool> canExecuteMethod;

        public DelegateCommand(in Action inExecuteMethod) : this(inExecuteMethod, defaultCanExecuteMethod)
        { }

        public DelegateCommand(in Action inExecuteMethod, in Func<bool> inCanExecuteMethod)
        {
            executeMethod = inExecuteMethod;
            canExecuteMethod = inCanExecuteMethod;
        }

        protected override void Execute() => executeMethod();

        protected override bool CanExecute() => canExecuteMethod();
    }
}
