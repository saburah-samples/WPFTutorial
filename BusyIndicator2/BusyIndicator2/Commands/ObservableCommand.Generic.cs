namespace BusyIndicator.Commands
{
    using System;
    using System.Reactive.Subjects;
    using System.Windows.Input;

    public class ObservableCommand<T> : IObservableCommand<T>
    {
        private readonly Subject<T> _subj = new Subject<T>();

        private Action<T> _executeAction;
        private Func<T, bool> _canExecuteFunc;

        private bool _isDisposing;
        private bool _isDisposed;

        public event EventHandler CanExecuteChanged = delegate { };

        public ObservableCommand()
        {
        }

        public ObservableCommand(Func<T, bool> canExecuteFunc) : this(null, canExecuteFunc)
        {
        }

        public ObservableCommand(Action<T> executeAction) : this(executeAction, null)
        {
        }

        public ObservableCommand(Action<T> executeAction, Func<T, bool> canExecuteFunc)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (parameter != null)
            {
                return CanExecuteImpl((T) parameter);
            }
            else
            {
                return CanExecuteImpl(default(T));
            }
        }

        void ICommand.Execute(object parameter)
        {
            if (parameter != null)
            {
                ExecuteImpl((T) parameter);
            }
            else
            {
                ExecuteImpl(default(T));
            }
        }

        public bool CanExecute(T parameter)
        {
            return CanExecuteImpl(parameter);
        }

        public bool CanExecute()
        {
            return CanExecuteImpl(default(T));
        }

        public void Execute(T parameter)
        {
            ExecuteImpl(parameter);
        }

        public void Execute()
        {
            ExecuteImpl(default(T));
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _subj.Subscribe(observer);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            if (!_isDisposing && !_isDisposed)
            {
                _isDisposing = true;

                _executeAction = null;
                _canExecuteFunc = null;

                _subj.OnCompleted();
                _subj.Dispose();

                _isDisposed = true;
            }
        }

        private void ExecuteImpl(T parameter)
        {
            if (_executeAction != null)
            {
                _executeAction(parameter);
            }

            _subj.OnNext(parameter);
            CanExecuteChanged(this, EventArgs.Empty);
        }

        private bool CanExecuteImpl(T parameter)
        {
            if (_canExecuteFunc == null)
            {
                return true;
            }

            return _canExecuteFunc(parameter);
        }
    }
}
