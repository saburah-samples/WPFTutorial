namespace BusyIndicator.Services
{
    using System;

    public interface ICompositeDisposable : IDisposable
    {
        void Add(IDisposable disposable);
    }
}