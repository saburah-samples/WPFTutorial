namespace BusyIndicator.ViewModels
{
    public class ContentViewModel : ViewModel, IContentViewModel
    {
        public ContentViewModel(IBusyMonitor busyMonitor)
            : base(busyMonitor)
        {
        }
    }
}