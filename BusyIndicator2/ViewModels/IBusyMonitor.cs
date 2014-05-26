namespace BusyIndicator.ViewModels
{
    using System;

    public interface IBusyMonitor : IBindable, IDisposable
    {
        bool IsBusy { get; set; }

        IObservable<bool> IsBusyChanged { get; }
    }
}