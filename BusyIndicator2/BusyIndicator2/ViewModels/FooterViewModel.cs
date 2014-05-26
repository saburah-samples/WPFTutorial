namespace BusyIndicator.ViewModels
{
    public class FooterViewModel : ViewModel, IFooterViewModel
    {
        public FooterViewModel(IBusyMonitor busyMonitor)
            : base(busyMonitor)
        {
        }
    }
}