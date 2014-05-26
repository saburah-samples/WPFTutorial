namespace BusyIndicator.Commands
{
    using System;
    using System.Reactive;

    public class ObservableCommand : ObservableCommand<Unit>, IObservableCommand
    {
        public ObservableCommand() : this(null, null)
        {
        }

        public ObservableCommand(Action execute) : base(u => execute(), null)
        {
        }

        public ObservableCommand(Action execute, Func<bool> canExecute) : base(u => execute(), o => canExecute())
        {
        }
    }
}