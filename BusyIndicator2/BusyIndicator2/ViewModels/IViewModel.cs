namespace BusyIndicator.ViewModels
{
    using System.ComponentModel;
    using Services;

    public interface IViewModel : INotifyPropertyChanging, INotifyPropertyChanged, ICompositeDisposable
    {
    }
}