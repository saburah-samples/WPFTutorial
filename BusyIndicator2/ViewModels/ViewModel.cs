namespace BusyIndicator.ViewModels
{
    using System;
    using System.Reactive.Disposables;

    public abstract class ViewModel : Bindable, IViewModel, IBusyViewModel
    {
        private readonly IBusyMonitor _busyMonitor;
        private readonly CompositeDisposable _compositeDisposable;

        protected ViewModel(IBusyMonitor busyMonitor)
        {
            _busyMonitor = busyMonitor;

            _compositeDisposable = new CompositeDisposable();
        }

        protected ViewModel() : this(null)
        {
        }

        public bool IsDiposed { get; private set; }

        public IBusyMonitor BusyMonitor { get { return _busyMonitor; } }

        public virtual void Dispose()
        {
            if (IsDiposed)
            {
                return;
            }

            IsDiposed = true;

            _compositeDisposable.Dispose();
        }

        public void Add(IDisposable disposable)
        {
            _compositeDisposable.Add(disposable);
        }
    }
}