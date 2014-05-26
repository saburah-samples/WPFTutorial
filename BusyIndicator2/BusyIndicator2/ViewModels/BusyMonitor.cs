namespace BusyIndicator.ViewModels
{
    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

    public sealed class BusyMonitor : Bindable, IBusyMonitor
    {
        private bool _isBusy;
        private readonly BehaviorSubject<bool> _isBusyChanged;

        private bool _isDisposing;
        private bool _isDisposed;

        public BusyMonitor()
        {
            _isBusy = false;
            _isBusyChanged = new BehaviorSubject<bool>(false);
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                if (SetPropertyAndNotify(ref _isBusy, value, () => IsBusy))
                {
                    _isBusyChanged.OnNext(_isBusy);
                }
            }
        }

        public IObservable<bool> IsBusyChanged { get { return _isBusyChanged.AsObservable(); } }

        public bool IsDiposing { get { return _isDisposing; } }

        public bool IsDiposed { get { return _isDisposed; } }

        public void Dispose()
        {
            if (_isDisposing || _isDisposed)
            {
                return;
            }

            _isDisposing = true;

            _isBusyChanged.OnCompleted();
            _isBusyChanged.Dispose();

            _isDisposed = true;
        }
    }
}